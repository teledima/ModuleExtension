using System.Drawing;

namespace ModuleExtension
{
    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        Bitmap Transform(Bitmap bitmap);
    }
}
