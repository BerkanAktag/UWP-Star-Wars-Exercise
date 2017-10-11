using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace StarWars.DAL.Converter
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(targetType != typeof(ImageSource))
                throw new InvalidOperationException("Target must be type of System.Windows.Media.ImageSource");

            try
            {
                BitmapImage img = new BitmapImage();
                String changeValue = value.ToString().Replace(" ", "_");
                img.UriSource = new Uri("/StarWarsUWP.App;component/Assets/Posters/"+changeValue+".jpg",UriKind.Relative);
                return img;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
