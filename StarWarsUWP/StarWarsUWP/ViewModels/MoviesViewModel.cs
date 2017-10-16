using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StarWars.DAL;
using StarWars.Domain;
using StarWars.Domain.Annotations;
using StarWarsUWP.Service;
using StarWarsUWP.Utitlity;

namespace StarWarsUWP.ViewModels
{
    public class MoviesViewModel:INotifyPropertyChanged
    {
        public ApiRepository _repository;

        public ICommand RateUpCommand { get; set; }
        public ICommand RateDownCommand { get; set; }
        public ICommand ShowPlanetsCommand { get; set; }

        public NavigationService NavigationService;

        private IList<Movie> _movies;
        private Movie _SelectedMovie;

        public IList<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                _movies = value;
                OnPropertyChanged(nameof(Movies));
            }
        }

        public Movie SelectedMovie
        {
            get
            {
                return _SelectedMovie;
            }
            set
            {
           _SelectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }



        public MoviesViewModel()
        {
            LoadDate();
            LoadCommands();
            NavigationService = new NavigationService();

        }

        private void LoadCommands()
        {
            RateUpCommand = new CustomCommand(RateUpMovie,CanRateMovie);
            RateDownCommand = new CustomCommand(RateDownMovie,CanRateMovie);
            ShowPlanetsCommand = new CustomCommand(ShowPlanets,CanRateMovie);
        }

        private void ShowPlanets(object obj)
        {
            Messenger.Default.Send<Movie>(SelectedMovie);
            NavigationService.NavigateTo("Planets");

        }

        private void RateDownMovie(object obj)
        {
                
            SelectedMovie.Rating -= 0.5;
        }

        private void RateUpMovie(object obj)
        {
            SelectedMovie.Rating += 0.5;
        }

        private bool CanRateMovie(object obj)
        {
            if (SelectedMovie != null)
                return true;
            return false;
        }

        private void LoadDate()
        {
            _repository = new ApiRepository();
            Movies = _repository.GetAllMovies().OrderBy(e => e.EpisodeId).ToList();
            SelectedMovie = Movies.FirstOrDefault(e => e.EpisodeId == 1);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
