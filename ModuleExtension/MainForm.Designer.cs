
namespace ModuleExtension
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.main_menu = new System.Windows.Forms.MenuStrip();
            this.filters = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsSettingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.main_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.ImageLocation = "cat.jpg";
            this.pictureBox.Location = new System.Drawing.Point(10, 24);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(464, 427);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox_LoadCompleted);
            // 
            // main_menu
            // 
            this.main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filters,
            this.pluginsSettingMenuItem});
            this.main_menu.Location = new System.Drawing.Point(10, 0);
            this.main_menu.Name = "main_menu";
            this.main_menu.Size = new System.Drawing.Size(464, 24);
            this.main_menu.TabIndex = 1;
            this.main_menu.Text = "menuStrip1";
            // 
            // filters
            // 
            this.filters.Name = "filters";
            this.filters.Size = new System.Drawing.Size(69, 20);
            this.filters.Text = "Фильтры";
            // 
            // pluginsSettingMenuItem
            // 
            this.pluginsSettingMenuItem.Name = "pluginsSettingMenuItem";
            this.pluginsSettingMenuItem.Size = new System.Drawing.Size(149, 20);
            this.pluginsSettingMenuItem.Text = "Управление плагинами";
            this.pluginsSettingMenuItem.Click += new System.EventHandler(this.pluginsSettingMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.main_menu);
            this.MainMenuStrip = this.main_menu;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.main_menu.ResumeLayout(false);
            this.main_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip main_menu;
        private System.Windows.Forms.ToolStripMenuItem filters;
        private System.Windows.Forms.ToolStripMenuItem pluginsSettingMenuItem;
    }
}

