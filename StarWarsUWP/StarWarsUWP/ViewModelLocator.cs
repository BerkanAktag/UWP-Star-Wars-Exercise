using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsUWP.ViewModels;

namespace StarWarsUWP
{
    public class ViewModelLocator
    {
        private static MoviesViewModel moviesViewModel = new MoviesViewModel();
        private static PlanetsViewModel planetsViewModel = new PlanetsViewModel();

        public static PlanetsViewModel PlanetsViewModel
        {
            get => planetsViewModel;
        }

        public static MoviesViewModel MoviesViewModel
        {
            get => moviesViewModel; 
        }
    }

}
