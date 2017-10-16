using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StarWars.Domain;
using StarWars.Domain.Annotations;
using StarWarsUWP.Utitlity;

namespace StarWarsUWP.ViewModels
{
    public class PlanetsViewModel : INotifyPropertyChanged
    {
        private IList<Planet> _planets;
        private Movie _selectedMovie;
        private Planet _selectedPlanet;

        public PlanetsViewModel()
        {
            Messenger.Default.Register<Movie>(this, OnMovieRecieved);
        }

        public IList<Planet> Planets
        {
            get => _planets;
            set
            {
                _planets = value;
                OnPropertyChanged(nameof(Planets));
            }
        }

        private void OnMovieRecieved(Movie movie)
        {
            _selectedMovie = movie;
            _planets = movie.Planets.ToList();
        }

        public Planet SelectedPlanet
        {
            get => _selectedPlanet;
            set
            {
                _selectedPlanet = value;
                OnPropertyChanged(nameof(SelectedPlanet));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
