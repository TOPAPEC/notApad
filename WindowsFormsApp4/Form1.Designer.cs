
namespace WindowsFormsApp4
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStripFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCloseActive = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMainWindow = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItmFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCompile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanelTabButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.timerAutoSave = new System.Windows.Forms.Timer(this.components);
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.timerBackup = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripFile.SuspendLayout();
            this.menuStripMainWindow.SuspendLayout();
            this.contextMenuStripEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripFile
            // 
            this.contextMenuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewWindow,
            this.toolStripMenuItemNewFile,
            this.toolStripMenuItemOpenFile,
            this.toolStripMenuItemSave,
            this.toolStripMenuItemSaveAs,
            this.toolStripMenuItemSaveAll,
            this.toolStripSeparator1,
            this.toolStripMenuItemCloseActive,
            this.toolStripMenuItemExit});
            this.contextMenuStripFile.Name = "contextMenuStripFile";
            this.contextMenuStripFile.OwnerItem = this.toolStripMenuItemFile;
            this.contextMenuStripFile.Size = new System.Drawing.Size(219, 186);
            this.contextMenuStripFile.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripFile_ItemClicked);
            // 
            // toolStripMenuItemNewWindow
            // 
            this.toolStripMenuItemNewWindow.Name = "toolStripMenuItemNewWindow";
            this.toolStripMenuItemNewWindow.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItemNewWindow.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItemNewWindow.Text = "New window";
            // 
            // toolStripMenuItemNewFile
            // 
            this.toolStripMenuItemNewFile.Name = "toolStripMenuItemNewFile";
            this.toolStripMenuItemNewFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItemNewFile.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItemNewFile.Text = "New";
            // 
            // toolStripMenuItemOpenFile
            // 
            this.toolStripMenuItemOpenFile.Name = "toolStripMenuItemOpenFile";
            this.toolStripMenuItemOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemOpenFile.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItemOpenFile.Text = "Open";
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItemSave.Text = "Save";
            // 
            // toolStripMenuItemSaveAs
            // 
            this.toolStripMenuItemSaveAs.Name = "toolStripMenuItemSaveAs";
            this.toolStripMenuItemSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSaveAs.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItemSaveAs.Text = "Save as";
            // 
            // toolStripMenuItemSaveAll
            // 
            this.toolStripMenuItemSaveAll.Name = "toolStripMenuItemSaveAll";
            this.toolStripMenuItemSaveAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSaveAll.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItemSaveAll.Text = "Save All";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // toolStripMenuItemCloseActive
            // 
            this.toolStripMenuItemCloseActive.Name = "toolStripMenuItemCloseActive";
            this.toolStripMenuItemCloseActive.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.toolStripMenuItemCloseActive.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItemCloseActive.Text = "Close";
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(218, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDown = this.contextMenuStripFile;
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(35, 22);
            this.toolStripMenuItemFile.Text = "&File";
            // 
            // menuStripMainWindow
            // 
            this.menuStripMainWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStripMainWindow.GripMargin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.menuStripMainWindow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemFormat,
            this.toolStripMenuItemCompile,
            this.toolStripMenuItemSettings});
            this.menuStripMainWindow.Location = new System.Drawing.Point(0, 0);
            this.menuStripMainWindow.Name = "menuStripMainWindow";
            this.menuStripMainWindow.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.menuStripMainWindow.Size = new System.Drawing.Size(629, 24);
            this.menuStripMainWindow.TabIndex = 3;
            this.menuStripMainWindow.Text = "menuStrip1";
            this.menuStripMainWindow.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripMainWindow_ItemClicked);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.DropDown = this.contextMenuStripEdit;
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(37, 22);
            this.toolStripMenuItemEdit.Text = "Edit";
            // 
            // contextMenuStripEdit
            // 
            this.contextMenuStripEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUndo,
            this.toolStripMenuItemRedo,
            this.toolStripSeparator2,
            this.toolStripMenuItmFormat});
            this.contextMenuStripEdit.Name = "contextMenuStripEdit";
            this.contextMenuStripEdit.OwnerItem = this.toolStripMenuItemEdit;
            this.contextMenuStripEdit.Size = new System.Drawing.Size(175, 76);
            this.contextMenuStripEdit.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripEdit_ItemClicked);
            // 
            // toolStripMenuItemUndo
            // 
            this.toolStripMenuItemUndo.Name = "toolStripMenuItemUndo";
            this.toolStripMenuItemUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.toolStripMenuItemUndo.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItemUndo.Text = "Undo";
            // 
            // toolStripMenuItemRedo
            // 
            this.toolStripMenuItemRedo.Name = "toolStripMenuItemRedo";
            this.toolStripMenuItemRedo.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.toolStripMenuItemRedo.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItemRedo.Text = "Redo";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // toolStripMenuItmFormat
            // 
            this.toolStripMenuItmFormat.Name = "toolStripMenuItmFormat";
            this.toolStripMenuItmFormat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.toolStripMenuItmFormat.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItmFormat.Text = "Reformat";
            // 
            // toolStripMenuItemFormat
            // 
            this.toolStripMenuItemFormat.Name = "toolStripMenuItemFormat";
            this.toolStripMenuItemFormat.Size = new System.Drawing.Size(51, 22);
            this.toolStripMenuItemFormat.Text = "Format";
            // 
            // toolStripMenuItemCompile
            // 
            this.toolStripMenuItemCompile.Name = "toolStripMenuItemCompile";
            this.toolStripMenuItemCompile.Size = new System.Drawing.Size(56, 22);
            this.toolStripMenuItemCompile.Text = "Compile";
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Size = new System.Drawing.Size(57, 22);
            this.toolStripMenuItemSettings.Text = "Settings";
            // 
            // flowLayoutPanelTabButtons
            // 
            this.flowLayoutPanelTabButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelTabButtons.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanelTabButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelTabButtons.Name = "flowLayoutPanelTabButtons";
            this.flowLayoutPanelTabButtons.Size = new System.Drawing.Size(629, 27);
            this.flowLayoutPanelTabButtons.TabIndex = 5;
            // 
            // timerAutoSave
            // 
            this.timerAutoSave.Interval = 10000;
            this.timerAutoSave.Tick += new System.EventHandler(this.timerAutosave_Tick);
            // 
            // timerBackup
            // 
            this.timerBackup.Tick += new System.EventHandler(this.timerBackup_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(629, 663);
            this.Controls.Add(this.flowLayoutPanelTabButtons);
            this.Controls.Add(this.menuStripMainWindow);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMainWindow;
            this.MinimumSize = new System.Drawing.Size(600, 700);
            this.Name = "FormMain";
            this.Text = "NotApad+";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.contextMenuStripFile.ResumeLayout(false);
            this.menuStripMainWindow.ResumeLayout(false);
            this.menuStripMainWindow.PerformLayout();
            this.contextMenuStripEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.MenuStrip menuStripMainWindow;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTabButtons;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCloseActive;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer timerAutoSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFormat;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUndo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRedo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewWindow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.Timer timerBackup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItmFormat;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCompile;
    }
}

