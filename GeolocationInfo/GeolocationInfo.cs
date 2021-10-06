using ModuleExtension;
using System.Drawing;

namespace GeolocationInfo
{
    public class GeolocationInfo : IPlugin
    {
        public string Name => "Отобразить геолокацию";

        public string Author => "Dmitry Telegin";

        public void Transform(Bitmap app)
        {
            throw new System.NotImplementedException();
        }
    }
}
