using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StarWars.DAL;
using StarWars.Domain;
using StarWars.Domain.Annotations;

namespace StarWarsUWP.ViewModels
{
    public class MoviesViewModel:INotifyPropertyChanged
    {
        private IRepository _repository;

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
