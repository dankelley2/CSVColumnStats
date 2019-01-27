namespace CSVColumnStats
{
    partial class MainWindow
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
            this.button1 = new System.Windows.Forms.Button();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.splitSettingsWindow = new System.Windows.Forms.SplitContainer();
            this.txtBoxFilePath = new System.Windows.Forms.TextBox();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.txtBoxFilePreview = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.watcherProgramDirectory = new System.IO.FileSystemWatcher();
            this.tabContainer.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSettingsWindow)).BeginInit();
            this.splitSettingsWindow.Panel1.SuspendLayout();
            this.splitSettingsWindow.Panel2.SuspendLayout();
            this.splitSettingsWindow.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watcherProgramDirectory)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(281, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Analyze Sample";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tabSettings);
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.Location = new System.Drawing.Point(0, 24);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(871, 450);
            this.tabContainer.TabIndex = 1;
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.White;
            this.tabSettings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabSettings.Controls.Add(this.splitSettingsWindow);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(863, 424);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "Settings";
            // 
            // splitSettingsWindow
            // 
            this.splitSettingsWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSettingsWindow.Location = new System.Drawing.Point(3, 3);
            this.splitSettingsWindow.Name = "splitSettingsWindow";
            // 
            // splitSettingsWindow.Panel1
            // 
            this.splitSettingsWindow.Panel1.Controls.Add(this.button1);
            this.splitSettingsWindow.Panel1MinSize = 100;
            // 
            // splitSettingsWindow.Panel2
            // 
            this.splitSettingsWindow.Panel2.Controls.Add(this.txtBoxFilePath);
            this.splitSettingsWindow.Panel2.Controls.Add(this.groupBoxPreview);
            this.splitSettingsWindow.Size = new System.Drawing.Size(853, 414);
            this.splitSettingsWindow.SplitterDistance = 281;
            this.splitSettingsWindow.TabIndex = 2;
            // 
            // txtBoxFilePath
            // 
            this.txtBoxFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxFilePath.Location = new System.Drawing.Point(0, 0);
            this.txtBoxFilePath.Name = "txtBoxFilePath";
            this.txtBoxFilePath.ReadOnly = true;
            this.txtBoxFilePath.Size = new System.Drawing.Size(568, 20);
            this.txtBoxFilePath.TabIndex = 2;
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPreview.Controls.Add(this.txtBoxFilePreview);
            this.groupBoxPreview.Location = new System.Drawing.Point(0, 26);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(565, 385);
            this.groupBoxPreview.TabIndex = 1;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "File Preview";
            // 
            // txtBoxFilePreview
            // 
            this.txtBoxFilePreview.AcceptsTab = true;
            this.txtBoxFilePreview.BackColor = System.Drawing.Color.White;
            this.txtBoxFilePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxFilePreview.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxFilePreview.HideSelection = false;
            this.txtBoxFilePreview.Location = new System.Drawing.Point(3, 16);
            this.txtBoxFilePreview.Name = "txtBoxFilePreview";
            this.txtBoxFilePreview.ReadOnly = true;
            this.txtBoxFilePreview.Size = new System.Drawing.Size(559, 366);
            this.txtBoxFilePreview.TabIndex = 0;
            this.txtBoxFilePreview.Text = "";
            this.txtBoxFilePreview.WordWrap = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(871, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "CSV files|*.csv|txt files|*.txt|All files|*.*";
            this.openFileDialog.ReadOnlyChecked = true;
            this.openFileDialog.ShowReadOnly = true;
            // 
            // watcherProgramDirectory
            // 
            this.watcherProgramDirectory.EnableRaisingEvents = true;
            this.watcherProgramDirectory.Filter = "*.meta";
            this.watcherProgramDirectory.SynchronizingObject = this;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 474);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CSV Analyzer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabContainer.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.splitSettingsWindow.Panel1.ResumeLayout(false);
            this.splitSettingsWindow.Panel2.ResumeLayout(false);
            this.splitSettingsWindow.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSettingsWindow)).EndInit();
            this.splitSettingsWindow.ResumeLayout(false);
            this.groupBoxPreview.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watcherProgramDirectory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.SplitContainer splitSettingsWindow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.RichTextBox txtBoxFilePreview;
        private System.Windows.Forms.TextBox txtBoxFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.IO.FileSystemWatcher watcherProgramDirectory;
    }
}

