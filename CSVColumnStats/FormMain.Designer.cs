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
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAnylysisSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTableSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMetaFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitSettingsWindow = new System.Windows.Forms.SplitContainer();
            this.fileSampleProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBoxMiscSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxIsTextQualified = new System.Windows.Forms.CheckBox();
            this.CheckBoxHasHeaders = new System.Windows.Forms.CheckBox();
            this.groupBoxSampleRows = new System.Windows.Forms.GroupBox();
            this.numericUpDownSampleRows = new System.Windows.Forms.NumericUpDown();
            this.groupBoxDelimiter = new System.Windows.Forms.GroupBox();
            this.txtFieldDelimiter = new System.Windows.Forms.TextBox();
            this.groupBoxLineEnding = new System.Windows.Forms.GroupBox();
            this.txtRowDelimiter = new System.Windows.Forms.TextBox();
            this.txtBoxFilePath = new System.Windows.Forms.TextBox();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.txtBoxFilePreview = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer_MetaData = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAnylysisSQLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyTableSQLToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bgwWorker_CSVFile = new System.ComponentModel.BackgroundWorker();
            this.bgwWorker_BulkProcess = new System.ComponentModel.BackgroundWorker();
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
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MetaData)).BeginInit();
            this.splitContainer_MetaData.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.button1.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tabSettings);
            this.tabContainer.Controls.Add(this.tabPage1);
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.Location = new System.Drawing.Point(0, 24);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(871, 450);
            this.tabContainer.TabIndex = 1;
            this.tabContainer.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabContainer_TabIndexChanged);
            this.tabContainer.TabIndexChanged += new System.EventHandler(this.tabContainer_TabIndexChanged);
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
            this.actionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem,
            this.deleteMetaFileToolStripMenuItem});
            this.contextMenuStripTabs.Name = "contextMenuStrip1";
            this.contextMenuStripTabs.Size = new System.Drawing.Size(159, 76);
            this.contextMenuStripTabs.Opening += new System.ComponentModel.CancelEventHandler(this.ToolStripMenuTabs_Opening);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAnylysisSQLToolStripMenuItem,
            this.copyTableSQLToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.actionsToolStripMenuItem.Text = "&Actions";
            // 
            // copyAnylysisSQLToolStripMenuItem
            // 
            this.copyAnylysisSQLToolStripMenuItem.Name = "copyAnylysisSQLToolStripMenuItem";
            this.copyAnylysisSQLToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.copyAnylysisSQLToolStripMenuItem.Text = "Copy &Anylysis SQL";
            this.copyAnylysisSQLToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_copyAnylysisSQL_Click);
            // 
            // copyTableSQLToolStripMenuItem
            // 
            this.copyTableSQLToolStripMenuItem.Name = "copyTableSQLToolStripMenuItem";
            this.copyTableSQLToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.copyTableSQLToolStripMenuItem.Text = "Copy &Table SQL";
            this.copyTableSQLToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_copyTableSQL_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.closeToolStripMenuItem.Text = "&Close Meta File";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_close_Click);
            // 
            // deleteMetaFileToolStripMenuItem
            // 
            this.deleteMetaFileToolStripMenuItem.Name = "deleteMetaFileToolStripMenuItem";
            this.deleteMetaFileToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteMetaFileToolStripMenuItem.Text = "&Delete Meta File";
            this.deleteMetaFileToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_deleteMetaFile_Click);
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
            this.splitSettingsWindow.Panel1.Controls.Add(this.fileSampleProgressBar);
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
            // fileSampleProgressBar
            // 
            this.fileSampleProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fileSampleProgressBar.Location = new System.Drawing.Point(5, 376);
            this.fileSampleProgressBar.Name = "fileSampleProgressBar";
            this.fileSampleProgressBar.Size = new System.Drawing.Size(165, 10);
            this.fileSampleProgressBar.Step = 1;
            this.fileSampleProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.fileSampleProgressBar.TabIndex = 5;
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
            1000,
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
            1000,
            0,
            0,
            0});
            this.numericUpDownSampleRows.Name = "numericUpDownSampleRows";
            this.numericUpDownSampleRows.Size = new System.Drawing.Size(159, 32);
            this.numericUpDownSampleRows.TabIndex = 0;
            this.numericUpDownSampleRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSampleRows.ThousandsSeparator = true;
            this.numericUpDownSampleRows.Value = new decimal(new int[] {
            1000,
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
            // 
            // groupBoxLineEnding
            // 
            this.groupBoxLineEnding.BackColor = System.Drawing.Color.White;
            this.groupBoxLineEnding.Controls.Add(this.txtRowDelimiter);
            this.groupBoxLineEnding.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxLineEnding.Location = new System.Drawing.Point(5, 5);
            this.groupBoxLineEnding.Name = "groupBoxLineEnding";
            this.groupBoxLineEnding.Size = new System.Drawing.Size(165, 52);
            this.groupBoxLineEnding.TabIndex = 1;
            this.groupBoxLineEnding.TabStop = false;
            this.groupBoxLineEnding.Text = "Row Delimiter Sequence";
            // 
            // txtRowDelimiter
            // 
            this.txtRowDelimiter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRowDelimiter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRowDelimiter.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRowDelimiter.Location = new System.Drawing.Point(3, 16);
            this.txtRowDelimiter.MaxLength = 10;
            this.txtRowDelimiter.Name = "txtRowDelimiter";
            this.txtRowDelimiter.Size = new System.Drawing.Size(159, 32);
            this.txtRowDelimiter.TabIndex = 1;
            this.txtRowDelimiter.Text = "\\r\\n";
            this.txtRowDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.txtBoxFilePreview.AutoWordSelection = true;
            this.txtBoxFilePreview.BackColor = System.Drawing.Color.Black;
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer_MetaData);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(863, 424);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer_MetaData
            // 
            this.splitContainer_MetaData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_MetaData.Location = new System.Drawing.Point(3, 3);
            this.splitContainer_MetaData.Name = "splitContainer_MetaData";
            // 
            // splitContainer_MetaData.Panel1
            // 
            this.splitContainer_MetaData.Panel1.DoubleClick += new System.EventHandler(this.splitContainer_MetaData_Panel1_DoubleClick);
            this.splitContainer_MetaData.Size = new System.Drawing.Size(857, 418);
            this.splitContainer_MetaData.SplitterDistance = 242;
            this.splitContainer_MetaData.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.actionsToolStripMenuItem1});
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
            this.openToolStripMenuItem.Click += new System.EventHandler(this.MenuStrip_open_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.MenuStrip_exit_Click);
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
            // actionsToolStripMenuItem1
            // 
            this.actionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAnylysisSQLToolStripMenuItem1,
            this.copyTableSQLToolStripMenuItem1});
            this.actionsToolStripMenuItem1.Name = "actionsToolStripMenuItem1";
            this.actionsToolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem1.Text = "&Actions";
            // 
            // copyAnylysisSQLToolStripMenuItem1
            // 
            this.copyAnylysisSQLToolStripMenuItem1.Name = "copyAnylysisSQLToolStripMenuItem1";
            this.copyAnylysisSQLToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.copyAnylysisSQLToolStripMenuItem1.Text = "Copy &Anylysis SQL";
            this.copyAnylysisSQLToolStripMenuItem1.Click += new System.EventHandler(this.MenuStrip_copyAnylysisSQL_Click);
            // 
            // copyTableSQLToolStripMenuItem1
            // 
            this.copyTableSQLToolStripMenuItem1.Name = "copyTableSQLToolStripMenuItem1";
            this.copyTableSQLToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.copyTableSQLToolStripMenuItem1.Text = "Copy &Table SQL";
            this.copyTableSQLToolStripMenuItem1.Click += new System.EventHandler(this.MenuStrip_copyTableSQL_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "CSV files|*.csv|txt files|*.txt|All files|*.*";
            this.openFileDialog.ReadOnlyChecked = true;
            this.openFileDialog.ShowReadOnly = true;
            // 
            // bgwWorker_CSVFile
            // 
            this.bgwWorker_CSVFile.WorkerReportsProgress = true;
            this.bgwWorker_CSVFile.WorkerSupportsCancellation = true;
            // 
            // bgwWorker_BulkProcess
            // 
            this.bgwWorker_BulkProcess.WorkerReportsProgress = true;
            this.bgwWorker_BulkProcess.WorkerSupportsCancellation = true;
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
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
            this.groupBoxLineEnding.PerformLayout();
            this.groupBoxPreview.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MetaData)).EndInit();
            this.splitContainer_MetaData.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem deleteMetaFileToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgwWorker_CSVFile;
        private System.Windows.Forms.ProgressBar fileSampleProgressBar;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAnylysisSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyTableSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyAnylysisSQLToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyTableSQLToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker bgwWorker_BulkProcess;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtRowDelimiter;
        private System.Windows.Forms.SplitContainer splitContainer_MetaData;
    }
}

