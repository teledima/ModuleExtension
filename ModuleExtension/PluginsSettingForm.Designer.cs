
namespace ModuleExtension
{
    partial class PluginsSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewPlugins = new System.Windows.Forms.ListView();
            this.save_button = new System.Windows.Forms.Button();
            this.DisplayNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewPlugins
            // 
            this.listViewPlugins.CheckBoxes = true;
            this.listViewPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DisplayNameColumn,
            this.NameColumn,
            this.AuthorColumn,
            this.VersionColumn});
            this.listViewPlugins.HideSelection = false;
            this.listViewPlugins.Location = new System.Drawing.Point(8, 12);
            this.listViewPlugins.Name = "listViewPlugins";
            this.listViewPlugins.Size = new System.Drawing.Size(706, 203);
            this.listViewPlugins.TabIndex = 3;
            this.listViewPlugins.UseCompatibleStateImageBehavior = false;
            this.listViewPlugins.View = System.Windows.Forms.View.Details;
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.save_button.Location = new System.Drawing.Point(256, 228);
            this.save_button.Margin = new System.Windows.Forms.Padding(5, 10, 3, 3);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(173, 51);
            this.save_button.TabIndex = 1;
            this.save_button.Text = "Сохранить изменения";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // DisplayNameColumn
            // 
            this.DisplayNameColumn.Text = "Display Name";
            this.DisplayNameColumn.Width = 150;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 122;
            // 
            // AuthorColumn
            // 
            this.AuthorColumn.Text = "Author";
            this.AuthorColumn.Width = 144;
            // 
            // VersionColumn
            // 
            this.VersionColumn.Text = "Version";
            this.VersionColumn.Width = 127;
            // 
            // PluginsSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 288);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.listViewPlugins);
            this.Name = "PluginsSettingForm";
            this.Text = "PluginsSettingForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button save_button;
        public System.Windows.Forms.ListView listViewPlugins;
        private System.Windows.Forms.ColumnHeader DisplayNameColumn;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader AuthorColumn;
        private System.Windows.Forms.ColumnHeader VersionColumn;
    }
}