using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ModuleExtension
{
    public partial class MainForm : Form
    {
        class PluginInfo
        {
            public IPlugin plugin;
            public bool is_active;

            public PluginInfo(IPlugin plugin, bool is_active)
            {
                this.plugin = plugin;
                this.is_active = is_active;
            }
        };

        Dictionary<string, PluginInfo> plugins = new Dictionary<string, PluginInfo>();
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
            List<string> active_plugins = Plugins.Default["active_plugins"].ToString().Split(';').ToList().Where(x => x != "").ToList();
            foreach (string file in files)
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("IPlugin");
                        // проверяем все библиотеки в текущей папке, и если находим класс, который реализует интерфейс IPlugin, то добавляем его в меню
                        if (iface != null && active_plugins.Contains(type.Name))
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin.Name, new PluginInfo(plugin, true));
                        }
                        else if (iface != null && !active_plugins.Contains(type.Name) && !plugins.ContainsKey(type.Name))
                        {
                            plugins.Add(type.Name, new PluginInfo(null, false));
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
                if (plugin.Value.is_active)
                {
                    ToolStripItem item = filters.DropDownItems.Add(plugin.Value.plugin.DisplayName);
                    item.Name = plugin.Key;
                    item.Click += pluginsFilter_Click;
                }
            }
        }

        private void pluginsFilter_Click(object sender, EventArgs args)
        {
            ToolStripItem item = (ToolStripItem)sender;
            pictureBox.Image = plugins[item.Name].plugin.Transform(sourceImage);
        }

        private void pictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            sourceImage = (Bitmap)pictureBox.Image;
        }

        private void pluginsSettingMenuItem_Click(object sender, EventArgs e)
        {
            var plugin_setting_form = new PluginsSettingForm();
            foreach (var plugin in plugins)
            {
                ListViewItem item = new ListViewItem(new string[] { plugin.Value.plugin?.DisplayName, plugin.Key, plugin.Value.plugin?.Author, plugin.Value.plugin?.Version?.ToString() });
                item.Name = plugin.Key;
                item.Checked = plugin.Value.is_active;
                plugin_setting_form.listViewPlugins.Items.Add(item);
            }
            plugin_setting_form.ShowDialog();
        }
    }
}
