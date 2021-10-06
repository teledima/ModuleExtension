using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleExtension
{
    public partial class MainForm : Form
    {
        Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();
        Bitmap sourceImage;

        public MainForm()
        {
            InitializeComponent();
            FindPlugins();
            CreatePluginsMenu();
        }

        private void FindPlugins()
        {
            // папка с плагинами
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;
            // dll-файлы в этой папке
            string[] files = Directory.GetFiles(folder, "*.dll");
            foreach (string file in files)
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("IPlugin");
                        // проверяем все библиотеки в текущей папке, и если находим класс, который реализует интерфейс IPlugin, то добавляем его в меню
                        if (iface != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin.Name, plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
        }

        private void CreatePluginsMenu()
        {
            foreach (var plugin in plugins)
            {
                ToolStripItem item = filters.DropDownItems.Add(plugin.Key);
                item.Click += PluginClick;
            }
        }

        private void PluginClick(object sender, EventArgs args)
        {
            ToolStripItem item = (ToolStripItem)sender;
            pictureBox.Image = plugins[item.Text].Transform(sourceImage);
        }

        private void pictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            sourceImage = (Bitmap)pictureBox.Image;
        }
    }
}
