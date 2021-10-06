using ModuleExtension;
using ImageMagick;
using System.Drawing;
using System;

namespace GeolocationInfo
{
    public class GeolocationInfo : IPlugin
    {
        public string Name => "Отобразить геолокацию";

        public string Author => "Dmitry Telegin";

        public Bitmap Transform(Bitmap bitmap)
        {
            string latitude = "Широта:{0}°{1}'{2}''";
            string longtitude = "Долгота:{0}°{1}'{2}''";
            string current_time = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");

            MagickImageFactory imageFactory = new MagickImageFactory();
            using (var magickImage = new MagickImage(imageFactory.Create(bitmap)))
            {
                var profile = magickImage.GetExifProfile();
                // Check if image contains an exif profile
                if (profile == null)
                {
                    latitude = "Широта: данные отсутствуют";
                    longtitude = "Долгота: данные отсутствуют";
                }
                else
                {
                    // Write all values to the console
                    foreach (var value in profile.Values)
                    {
                        if (value.Tag == ExifTag.GPSLatitude)
                        {
                            var values = (Rational[])value.GetValue();
                            latitude = string.Format(latitude, values[0].ToDouble(), values[1].ToDouble(), values[2].ToDouble());
                        }
                        else if (value.Tag == ExifTag.GPSLongitude)
                        {
                            Rational[] values = (Rational[])value.GetValue();
                            longtitude = string.Format(longtitude, values[0].ToDouble(), values[1].ToDouble(), values[2].ToDouble());
                        }
                    }
                }
                int font_size = magickImage.Width / 32;
                new Drawables()
                    .FontPointSize(font_size)
                    .Font("Comic Sans")
                    .StrokeColor(new MagickColor("black"))
                    .FillColor(MagickColors.DarkViolet)
                    .TextAlignment(TextAlignment.Right)
                    .Text(magickImage.Width, magickImage.Height-font_size * 1, latitude)
                    .Text(magickImage.Width, magickImage.Height-font_size * 2, longtitude)
                    .Text(magickImage.Width, magickImage.Height-font_size * 3, current_time)
                    .Draw(magickImage);

                return magickImage.ToBitmap();
            }
        }
    }
}
