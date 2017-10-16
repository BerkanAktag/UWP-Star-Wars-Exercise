using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StarWarsUWP.Views;

namespace StarWarsUWP.Service
{
    public class NavigationService
    {
        public void NavigateTo(string key)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            switch (key)
            {
                case "Planets":
                    rootFrame.Navigate(typeof(PlanetsView));
                    break;
                case "Back":
                    rootFrame.GoBack();
                    break;
                    
            }
        }
    }
}
