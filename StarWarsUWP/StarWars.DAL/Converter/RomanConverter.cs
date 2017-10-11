using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace StarWars.DAL.Converter
{
    public class RomanConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int episodeNr = (int) value;

            if (episodeNr == 1)
                return "I";
            if (episodeNr == 2)
                return "II";
            if (episodeNr == 3)
                return "III";
            if (episodeNr == 4)
                return "IV";
            if (episodeNr == 5)
                return "V";
            if (episodeNr == 6)
                return "VI";
            if (episodeNr == 7)
                return "VII";
            throw new Exception();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
