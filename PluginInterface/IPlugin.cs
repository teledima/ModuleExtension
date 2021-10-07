using System.Drawing;
using System;

namespace ModuleExtension
{
    public interface IPlugin
    {
        string DisplayName { get; }
        string Name { get; }
        string Author { get; }
        Bitmap Transform(Bitmap bitmap);

        Version Version { get; }
    }
}
