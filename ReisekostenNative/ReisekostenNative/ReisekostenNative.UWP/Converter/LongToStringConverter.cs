using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.UWP.Converter
{
    public class LongToStringConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value is long?)
                {
                    if (((long?)value).HasValue)
                    {
                        return ((long?)value).ToString();
                    } 
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value is string) {
                    if (!string.IsNullOrWhiteSpace((string)value))
                    {
                        long result = 0;
                        if (long.TryParse((string)value, out result))
                        {
                            return (long?) result;
                        }
                        else
                        {
                            return (long?)0;
                        }
                    }
                    else
                    {
                        return (long?)0;
                    }
                }
                return (long?)0;
            }
            catch (Exception)
            {
                return (long?)0;
            }

        }
    }
}
