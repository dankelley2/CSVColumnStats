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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.contextMenuStripTabs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMetaFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitSettingsWindow = new System.Windows.Forms.SplitContainer();
            this.groupBoxMiscSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxIsTextQualified = new System.Windows.Forms.CheckBox();
            this.CheckBoxHasHeaders = new System.Windows.Forms.CheckBox();
            this.groupBoxSampleRows = new System.Windows.Forms.GroupBox();
            this.numericUpDownSampleRows = new System.Windows.Forms.NumericUpDown();
            this.groupBoxDelimiter = new System.Windows.Forms.GroupBox();
            this.txtFieldDelimiter = new System.Windows.Forms.TextBox();
            this.groupBoxLineEnding = new System.Windows.Forms.GroupBox();
            this.comboBoxRowDelimiter = new System.Windows.Forms.ComboBox();
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
            this.contextMenuStripTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSettingsWindow)).BeginInit();
            this.splitSettingsWindow.Panel1.SuspendLayout();
            this.splitSettingsWindow.Panel2.SuspendLayout();
            this.splitSettingsWindow.SuspendLayout();
            this.groupBoxMiscSettings.SuspendLayout();
            this.groupBoxSampleRows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSampleRows)).BeginInit();
            this.groupBoxDelimiter.SuspendLayout();
            this.groupBoxLineEnding.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watcherProgramDirectory)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(5, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
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
            this.tabSettings.ContextMenuStrip = this.contextMenuStripTabs;
            this.tabSettings.Controls.Add(this.splitSettingsWindow);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(863, 424);
            this.tabSettings.TabIndex = 0;
            this.tabSettings.Text = "Settings";
            // 
            // contextMenuStripTabs
            // 
            this.contextMenuStripTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.deleteMetaFileToolStripMenuItem});
            this.contextMenuStripTabs.Name = "contextMenuStrip1";
            this.contextMenuStripTabs.Size = new System.Drawing.Size(159, 48);
            this.contextMenuStripTabs.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripTabs_Opening);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.closeToolStripMenuItem.Text = "Close Meta File";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // deleteMetaFileToolStripMenuItem
            // 
            this.deleteMetaFileToolStripMenuItem.Name = "deleteMetaFileToolStripMenuItem";
            this.deleteMetaFileToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteMetaFileToolStripMenuItem.Text = "Delete Meta File";
            this.deleteMetaFileToolStripMenuItem.Click += new System.EventHandler(this.deleteMetaFileToolStripMenuItem_Click);
            // 
            // splitSettingsWindow
            // 
            this.splitSettingsWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSettingsWindow.IsSplitterFixed = true;
            this.splitSettingsWindow.Location = new System.Drawing.Point(3, 3);
            this.splitSettingsWindow.Name = "splitSettingsWindow";
            // 
            // splitSettingsWindow.Panel1
            // 
            this.splitSettingsWindow.Panel1.Controls.Add(this.groupBoxMiscSettings);
            this.splitSettingsWindow.Panel1.Controls.Add(this.groupBoxSampleRows);
            this.splitSettingsWindow.Panel1.Controls.Add(this.groupBoxDelimiter);
            this.splitSettingsWindow.Panel1.Controls.Add(this.groupBoxLineEnding);
            this.splitSettingsWindow.Panel1.Controls.Add(this.button1);
            this.splitSettingsWindow.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitSettingsWindow.Panel1MinSize = 175;
            // 
            // splitSettingsWindow.Panel2
            // 
            this.splitSettingsWindow.Panel2.Controls.Add(this.txtBoxFilePath);
            this.splitSettingsWindow.Panel2.Controls.Add(this.groupBoxPreview);
            this.splitSettingsWindow.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitSettingsWindow.Panel2MinSize = 300;
            this.splitSettingsWindow.Size = new System.Drawing.Size(853, 414);
            this.splitSettingsWindow.SplitterDistance = 175;
            this.splitSettingsWindow.TabIndex = 2;
            // 
            // groupBoxMiscSettings
            // 
            this.groupBoxMiscSettings.Controls.Add(this.checkBoxIsTextQualified);
            this.groupBoxMiscSettings.Controls.Add(this.CheckBoxHasHeaders);
            this.groupBoxMiscSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxMiscSettings.Location = new System.Drawing.Point(5, 169);
            this.groupBoxMiscSettings.Name = "groupBoxMiscSettings";
            this.groupBoxMiscSettings.Size = new System.Drawing.Size(165, 100);
            this.groupBoxMiscSettings.TabIndex = 4;
            this.groupBoxMiscSettings.TabStop = false;
            this.groupBoxMiscSettings.Text = "Other Settings";
            // 
            // checkBoxIsTextQualified
            // 
            this.checkBoxIsTextQualified.AutoSize = true;
            this.checkBoxIsTextQualified.Checked = true;
            this.checkBoxIsTextQualified.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsTextQualified.Enabled = false;
            this.checkBoxIsTextQualified.Location = new System.Drawing.Point(7, 43);
            this.checkBoxIsTextQualified.Name = "checkBoxIsTextQualified";
            this.checkBoxIsTextQualified.Size = new System.Drawing.Size(102, 17);
            this.checkBoxIsTextQualified.TabIndex = 1;
            this.checkBoxIsTextQualified.Text = "Is Text Qualified";
            this.checkBoxIsTextQualified.UseVisualStyleBackColor = true;
            // 
            // CheckBoxHasHeaders
            // 
            this.CheckBoxHasHeaders.AutoSize = true;
            this.CheckBoxHasHeaders.Checked = true;
            this.CheckBoxHasHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxHasHeaders.Enabled = false;
            this.CheckBoxHasHeaders.Location = new System.Drawing.Point(7, 20);
            this.CheckBoxHasHeaders.Name = "CheckBoxHasHeaders";
            this.CheckBoxHasHeaders.Size = new System.Drawing.Size(88, 17);
            this.CheckBoxHasHeaders.TabIndex = 0;
            this.CheckBoxHasHeaders.Text = "Has Headers";
            this.CheckBoxHasHeaders.UseVisualStyleBackColor = true;
            // 
            // groupBoxSampleRows
            // 
            this.groupBoxSampleRows.Controls.Add(this.numericUpDownSampleRows);
            this.groupBoxSampleRows.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSampleRows.Location = new System.Drawing.Point(5, 110);
            this.groupBoxSampleRows.Name = "groupBoxSampleRows";
            this.groupBoxSampleRows.Size = new System.Drawing.Size(165, 59);
            this.groupBoxSampleRows.TabIndex = 3;
            this.groupBoxSampleRows.TabStop = false;
            this.groupBoxSampleRows.Text = "Rows to Sample";
            // 
            // numericUpDownSampleRows
            // 
            this.numericUpDownSampleRows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownSampleRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownSampleRows.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSampleRows.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSampleRows.Location = new System.Drawing.Point(3, 16);
            this.numericUpDownSampleRows.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownSampleRows.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSampleRows.Name = "numericUpDownSampleRows";
            this.numericUpDownSampleRows.Size = new System.Drawing.Size(159, 32);
            this.numericUpDownSampleRows.TabIndex = 0;
            this.numericUpDownSampleRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSampleRows.ThousandsSeparator = true;
            this.numericUpDownSampleRows.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupBoxDelimiter
            // 
            this.groupBoxDelimiter.Controls.Add(this.txtFieldDelimiter);
            this.groupBoxDelimiter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDelimiter.Location = new System.Drawing.Point(5, 57);
            this.groupBoxDelimiter.Name = "groupBoxDelimiter";
            this.groupBoxDelimiter.Size = new System.Drawing.Size(165, 53);
            this.groupBoxDelimiter.TabIndex = 2;
            this.groupBoxDelimiter.TabStop = false;
            this.groupBoxDelimiter.Text = "Field Delimiter Sequence";
            // 
            // txtFieldDelimiter
            // 
            this.txtFieldDelimiter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFieldDelimiter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFieldDelimiter.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFieldDelimiter.Location = new System.Drawing.Point(3, 16);
            this.txtFieldDelimiter.MaxLength = 10;
            this.txtFieldDelimiter.Name = "txtFieldDelimiter";
            this.txtFieldDelimiter.Size = new System.Drawing.Size(159, 32);
            this.txtFieldDelimiter.TabIndex = 0;
            this.txtFieldDelimiter.Text = ",";
            this.txtFieldDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFieldDelimiter.TextChanged += new System.EventHandler(this.txtFieldDelimiter_TextChanged);
            // 
            // groupBoxLineEnding
            // 
            this.groupBoxLineEnding.BackColor = System.Drawing.Color.White;
            this.groupBoxLineEnding.Controls.Add(this.comboBoxRowDelimiter);
            this.groupBoxLineEnding.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxLineEnding.Location = new System.Drawing.Point(5, 5);
            this.groupBoxLineEnding.Name = "groupBoxLineEnding";
            this.groupBoxLineEnding.Size = new System.Drawing.Size(165, 52);
            this.groupBoxLineEnding.TabIndex = 1;
            this.groupBoxLineEnding.TabStop = false;
            this.groupBoxLineEnding.Text = "Row Delimiter Sequence";
            // 
            // comboBoxRowDelimiter
            // 
            this.comboBoxRowDelimiter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxRowDelimiter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxRowDelimiter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxRowDelimiter.Font = new System.Drawing.Font("Consolas", 15.75F);
            this.comboBoxRowDelimiter.FormattingEnabled = true;
            this.comboBoxRowDelimiter.Items.AddRange(new object[] {
            "[CR][LF]",
            "[CR]",
            "[LF]"});
            this.comboBoxRowDelimiter.Location = new System.Drawing.Point(3, 16);
            this.comboBoxRowDelimiter.Name = "comboBoxRowDelimiter";
            this.comboBoxRowDelimiter.Size = new System.Drawing.Size(159, 32);
            this.comboBoxRowDelimiter.TabIndex = 0;
            this.comboBoxRowDelimiter.Text = "[CR][LF]";
            // 
            // txtBoxFilePath
            // 
            this.txtBoxFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxFilePath.Location = new System.Drawing.Point(10, 10);
            this.txtBoxFilePath.Name = "txtBoxFilePath";
            this.txtBoxFilePath.ReadOnly = true;
            this.txtBoxFilePath.Size = new System.Drawing.Size(654, 20);
            this.txtBoxFilePath.TabIndex = 2;
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPreview.Controls.Add(this.txtBoxFilePreview);
            this.groupBoxPreview.Location = new System.Drawing.Point(10, 36);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(661, 365);
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
            this.txtBoxFilePreview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxFilePreview.Size = new System.Drawing.Size(655, 346);
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
            this.MinimumSize = new System.Drawing.Size(550, 512);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CSV Analyzer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabContainer.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.contextMenuStripTabs.ResumeLayout(false);
            this.splitSettingsWindow.Panel1.ResumeLayout(false);
            this.splitSettingsWindow.Panel2.ResumeLayout(false);
            this.splitSettingsWindow.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSettingsWindow)).EndInit();
            this.splitSettingsWindow.ResumeLayout(false);
            this.groupBoxMiscSettings.ResumeLayout(false);
            this.groupBoxMiscSettings.PerformLayout();
            this.groupBoxSampleRows.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSampleRows)).EndInit();
            this.groupBoxDelimiter.ResumeLayout(false);
            this.groupBoxDelimiter.PerformLayout();
            this.groupBoxLineEnding.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBoxLineEnding;
        private System.Windows.Forms.GroupBox groupBoxDelimiter;
        private System.Windows.Forms.TextBox txtFieldDelimiter;
        private System.Windows.Forms.GroupBox groupBoxMiscSettings;
        private System.Windows.Forms.GroupBox groupBoxSampleRows;
        private System.Windows.Forms.NumericUpDown numericUpDownSampleRows;
        private System.Windows.Forms.CheckBox checkBoxIsTextQualified;
        private System.Windows.Forms.CheckBox CheckBoxHasHeaders;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTabs;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxRowDelimiter;
        private System.Windows.Forms.ToolStripMenuItem deleteMetaFileToolStripMenuItem;
    }
}

