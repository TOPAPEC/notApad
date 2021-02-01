
namespace WindowsFormsApp4
{
    partial class FormFileWindow
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
            this.richTextBoxFileContent = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemBold = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemItalic = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCrossed = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUnderlined = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxFileContent
            // 
            this.richTextBoxFileContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxFileContent.ContextMenuStrip = this.contextMenuStripRightClick;
            this.richTextBoxFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxFileContent.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxFileContent.MaxLength = 10000000;
            this.richTextBoxFileContent.Name = "richTextBoxFileContent";
            this.richTextBoxFileContent.Size = new System.Drawing.Size(800, 450);
            this.richTextBoxFileContent.TabIndex = 0;
            this.richTextBoxFileContent.Text = "";
            this.richTextBoxFileContent.TextChanged += new System.EventHandler(this.richTextBoxFIleContent_TextChanged);
            // 
            // contextMenuStripRightClick
            // 
            this.contextMenuStripRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBold,
            this.toolStripMenuItemItalic,
            this.toolStripMenuItemCrossed,
            this.toolStripMenuItemUnderlined,
            this.toolStripSeparator1,
            this.toolStripMenuItemSelectAll,
            this.toolStripMenuItemCut,
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemPaste,
            this.toolStripSeparator2,
            this.toolStripMenuItemFormat});
            this.contextMenuStripRightClick.Name = "contextMenuStripRightClick";
            this.contextMenuStripRightClick.Size = new System.Drawing.Size(165, 214);
            this.contextMenuStripRightClick.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripRightClick_ItemClicked);
            // 
            // toolStripMenuItemBold
            // 
            this.toolStripMenuItemBold.Name = "toolStripMenuItemBold";
            this.toolStripMenuItemBold.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemBold.Text = "Bold";
            // 
            // toolStripMenuItemItalic
            // 
            this.toolStripMenuItemItalic.Name = "toolStripMenuItemItalic";
            this.toolStripMenuItemItalic.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemItalic.Text = "Italic";
            // 
            // toolStripMenuItemCrossed
            // 
            this.toolStripMenuItemCrossed.Name = "toolStripMenuItemCrossed";
            this.toolStripMenuItemCrossed.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemCrossed.Text = "Crossed";
            // 
            // toolStripMenuItemUnderlined
            // 
            this.toolStripMenuItemUnderlined.Name = "toolStripMenuItemUnderlined";
            this.toolStripMenuItemUnderlined.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemUnderlined.Text = "Underlined";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // toolStripMenuItemSelectAll
            // 
            this.toolStripMenuItemSelectAll.Name = "toolStripMenuItemSelectAll";
            this.toolStripMenuItemSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.toolStripMenuItemSelectAll.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemSelectAll.Text = "Select All";
            // 
            // toolStripMenuItemCut
            // 
            this.toolStripMenuItemCut.Name = "toolStripMenuItemCut";
            this.toolStripMenuItemCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.toolStripMenuItemCut.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemCut.Text = "Cut";
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemCopy.Text = "Copy";
            // 
            // toolStripMenuItemPaste
            // 
            this.toolStripMenuItemPaste.Name = "toolStripMenuItemPaste";
            this.toolStripMenuItemPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.toolStripMenuItemPaste.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemPaste.Text = "Paste";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // toolStripMenuItemFormat
            // 
            this.toolStripMenuItemFormat.Name = "toolStripMenuItemFormat";
            this.toolStripMenuItemFormat.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItemFormat.Text = "Format";
            // 
            // FormFileWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBoxFileContent);
            this.Name = "FormFileWindow";
            this.Text = "Form2";
            this.contextMenuStripRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxFileContent;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRightClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBold;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemItalic;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCrossed;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUnderlined;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFormat;
    }
}