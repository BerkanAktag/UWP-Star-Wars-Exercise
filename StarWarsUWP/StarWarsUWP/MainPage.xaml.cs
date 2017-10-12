using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using StarWars.DAL;
using StarWars.Domain;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StarWarsUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IList<Movie> allMovies;
        private Movie selectedMovie;
        public MainPage()
        {
            this.InitializeComponent();
            IRepository repository = new ApiRepository();

            Movie movie = repository.GetMobieByUrl("api/films/1");
            MovieGrid.DataContext = movie;
            allMovies = repository.GetAllMovies().OrderBy(e => e.EpisodeId).ToList();
            

            EpisodesListView.ItemsSource = allMovies;


        }

        private void EpisodesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMovie = e.AddedItems[0] as Movie;

            if (selectedMovie != null)
            {
                MovieTitleTextBlock.Text = selectedMovie.Title;
                DirectorTextBlock.Text = selectedMovie.Director;
                ProducerTextBlock.Text = selectedMovie.Producer;

                //MovieReleaseDateTextBlock.Text = selectedMovie.ReleaseDate.ToString();

                String changeValue = selectedMovie.Title.ToString().Replace(" ", "_").ToLower() + ".jpg";

                BitmapImage img = new BitmapImage(new Uri("ms-appx://StarWarsUWP.App/Assets/Posters/" + changeValue));

                MovieImage.Source = img;
                DetailStackOanel.DataContext = selectedMovie;
            }
        }


        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            selectedMovie.Rating -= 0.5;
            
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            selectedMovie.Rating += 0.5;
            
        }
    }
}
