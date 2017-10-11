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
                
                String changeValue = value.ToString().Replace(" ", "_").ToLower() + ".jpg";

                BitmapImage img = new BitmapImage(new Uri("ms-appx://StarWarsUWP.App/Assets/Posters/" + changeValue));
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
