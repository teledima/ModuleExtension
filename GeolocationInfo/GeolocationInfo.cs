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
                IExifProfile profile = magickImage.GetExifProfile();
                // Check if image contains an exif profile
                if (profile == null)
                {
                    latitude = "Широта: данные отсутствуют";
                    longtitude = "Долгота: данные отсутствуют";
                }
                else
                {
                    var latitude_values = profile.GetValue(ExifTag.GPSLatitude)?.Value;
                    latitude = latitude_values != null ? string.Format(latitude, latitude_values[0].ToDouble(), latitude_values[1].ToDouble(), latitude_values[2].ToDouble()) : "Широта: данные отсутствуют";

                    var longtitude_values = profile.GetValue(ExifTag.GPSLongitude)?.Value;
                    longtitude = longtitude_values != null ? string.Format(longtitude, longtitude_values[0].ToDouble(), longtitude_values[1].ToDouble(), longtitude_values[2].ToDouble()) : "Долгота: данные отсутствуют";
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
