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

        public static MoviesViewModel MoviesViewModel
        {
            get { return moviesViewModel; }
        }
    }
}
