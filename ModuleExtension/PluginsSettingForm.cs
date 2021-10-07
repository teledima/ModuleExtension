using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ModuleExtension
{
    public partial class PluginsSettingForm : Form
    {
        public PluginsSettingForm()
        {
            InitializeComponent();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            List<string> list_active_plugins = new List<string>();
            foreach(ListViewItem plugin in listViewPlugins.Items)
            {
                if (plugin.Checked)
                    list_active_plugins.Add(plugin.Name);
            }
            Plugins.Default.active_plugins = string.Join(";", list_active_plugins);
            Plugins.Default.Save();
        }
    }
}
