
namespace WindowsFormsApp4
{
    partial class FormSettings
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
            this.groupBoxAutosave = new System.Windows.Forms.GroupBox();
            this.comboBoxAutoSave = new System.Windows.Forms.ComboBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxColorTheme = new System.Windows.Forms.GroupBox();
            this.comboBoxColorTheme = new System.Windows.Forms.ComboBox();
            this.labelColorTheme = new System.Windows.Forms.Label();
            this.groupBoxFileBackup = new System.Windows.Forms.GroupBox();
            this.comboBoxBackup = new System.Windows.Forms.ComboBox();
            this.labelFileBackup = new System.Windows.Forms.Label();
            this.groupBoxCompilerPath = new System.Windows.Forms.GroupBox();
            this.labelCompilerPath = new System.Windows.Forms.Label();
            this.textBoxCompilerPath = new System.Windows.Forms.TextBox();
            this.groupBoxAutosave.SuspendLayout();
            this.groupBoxColorTheme.SuspendLayout();
            this.groupBoxFileBackup.SuspendLayout();
            this.groupBoxCompilerPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAutosave
            // 
            this.groupBoxAutosave.Controls.Add(this.comboBoxAutoSave);
            this.groupBoxAutosave.Controls.Add(this.labelTimer);
            this.groupBoxAutosave.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAutosave.Name = "groupBoxAutosave";
            this.groupBoxAutosave.Size = new System.Drawing.Size(460, 47);
            this.groupBoxAutosave.TabIndex = 0;
            this.groupBoxAutosave.TabStop = false;
            this.groupBoxAutosave.Text = "Autosave";
            // 
            // comboBoxAutoSave
            // 
            this.comboBoxAutoSave.FormattingEnabled = true;
            this.comboBoxAutoSave.Items.AddRange(new object[] {
            "0.5 minutes",
            "1 minutes",
            "5 minutes",
            "10 minutes ",
            "30 minutes ",
            "60 minutes",
            "Off"});
            this.comboBoxAutoSave.Location = new System.Drawing.Point(216, 18);
            this.comboBoxAutoSave.Name = "comboBoxAutoSave";
            this.comboBoxAutoSave.Size = new System.Drawing.Size(238, 23);
            this.comboBoxAutoSave.TabIndex = 2;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTimer.Location = new System.Drawing.Point(6, 17);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(205, 20);
            this.labelTimer.TabIndex = 1;
            this.labelTimer.Text = "Autosave interval (off by def.)\r\n";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(391, 426);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(310, 426);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxColorTheme
            // 
            this.groupBoxColorTheme.Controls.Add(this.comboBoxColorTheme);
            this.groupBoxColorTheme.Controls.Add(this.labelColorTheme);
            this.groupBoxColorTheme.Location = new System.Drawing.Point(12, 65);
            this.groupBoxColorTheme.Name = "groupBoxColorTheme";
            this.groupBoxColorTheme.Size = new System.Drawing.Size(460, 62);
            this.groupBoxColorTheme.TabIndex = 3;
            this.groupBoxColorTheme.TabStop = false;
            this.groupBoxColorTheme.Text = "Color theme";
            // 
            // comboBoxColorTheme
            // 
            this.comboBoxColorTheme.FormattingEnabled = true;
            this.comboBoxColorTheme.Items.AddRange(new object[] {
            "Dark theme",
            "White theme"});
            this.comboBoxColorTheme.Location = new System.Drawing.Point(216, 28);
            this.comboBoxColorTheme.Name = "comboBoxColorTheme";
            this.comboBoxColorTheme.Size = new System.Drawing.Size(238, 23);
            this.comboBoxColorTheme.TabIndex = 5;
            this.comboBoxColorTheme.Text = "White theme";
            // 
            // labelColorTheme
            // 
            this.labelColorTheme.AutoSize = true;
            this.labelColorTheme.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelColorTheme.Location = new System.Drawing.Point(6, 28);
            this.labelColorTheme.Name = "labelColorTheme";
            this.labelColorTheme.Size = new System.Drawing.Size(145, 20);
            this.labelColorTheme.TabIndex = 4;
            this.labelColorTheme.Text = "Choose color theme:";
            // 
            // groupBoxFileBackup
            // 
            this.groupBoxFileBackup.Controls.Add(this.comboBoxBackup);
            this.groupBoxFileBackup.Controls.Add(this.labelFileBackup);
            this.groupBoxFileBackup.Location = new System.Drawing.Point(12, 133);
            this.groupBoxFileBackup.Name = "groupBoxFileBackup";
            this.groupBoxFileBackup.Size = new System.Drawing.Size(460, 74);
            this.groupBoxFileBackup.TabIndex = 4;
            this.groupBoxFileBackup.TabStop = false;
            this.groupBoxFileBackup.Text = "File backup";
            // 
            // comboBoxBackup
            // 
            this.comboBoxBackup.FormattingEnabled = true;
            this.comboBoxBackup.Items.AddRange(new object[] {
            "Off",
            "0.5 minutes",
            "10 minutes",
            "30 minutes"});
            this.comboBoxBackup.Location = new System.Drawing.Point(216, 34);
            this.comboBoxBackup.Name = "comboBoxBackup";
            this.comboBoxBackup.Size = new System.Drawing.Size(238, 23);
            this.comboBoxBackup.TabIndex = 6;
            // 
            // labelFileBackup
            // 
            this.labelFileBackup.AutoSize = true;
            this.labelFileBackup.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFileBackup.Location = new System.Drawing.Point(6, 33);
            this.labelFileBackup.Name = "labelFileBackup";
            this.labelFileBackup.Size = new System.Drawing.Size(146, 20);
            this.labelFileBackup.TabIndex = 5;
            this.labelFileBackup.Text = "Create backup every:";
            // 
            // groupBoxCompilerPath
            // 
            this.groupBoxCompilerPath.Controls.Add(this.textBoxCompilerPath);
            this.groupBoxCompilerPath.Controls.Add(this.labelCompilerPath);
            this.groupBoxCompilerPath.Location = new System.Drawing.Point(12, 213);
            this.groupBoxCompilerPath.Name = "groupBoxCompilerPath";
            this.groupBoxCompilerPath.Size = new System.Drawing.Size(460, 71);
            this.groupBoxCompilerPath.TabIndex = 5;
            this.groupBoxCompilerPath.TabStop = false;
            this.groupBoxCompilerPath.Text = "Compiler Path";
            // 
            // labelCompilerPath
            // 
            this.labelCompilerPath.AutoSize = true;
            this.labelCompilerPath.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCompilerPath.Location = new System.Drawing.Point(6, 31);
            this.labelCompilerPath.Name = "labelCompilerPath";
            this.labelCompilerPath.Size = new System.Drawing.Size(107, 20);
            this.labelCompilerPath.TabIndex = 0;
            this.labelCompilerPath.Text = "Compiler path:";
            // 
            // textBoxCompilerPath
            // 
            this.textBoxCompilerPath.Location = new System.Drawing.Point(216, 32);
            this.textBoxCompilerPath.Name = "textBoxCompilerPath";
            this.textBoxCompilerPath.Size = new System.Drawing.Size(238, 23);
            this.textBoxCompilerPath.TabIndex = 1;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.groupBoxCompilerPath);
            this.Controls.Add(this.groupBoxFileBackup);
            this.Controls.Add(this.groupBoxColorTheme);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxAutosave);
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "FormSettings";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.groupBoxAutosave.ResumeLayout(false);
            this.groupBoxAutosave.PerformLayout();
            this.groupBoxColorTheme.ResumeLayout(false);
            this.groupBoxColorTheme.PerformLayout();
            this.groupBoxFileBackup.ResumeLayout(false);
            this.groupBoxFileBackup.PerformLayout();
            this.groupBoxCompilerPath.ResumeLayout(false);
            this.groupBoxCompilerPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAutosave;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.ComboBox comboBoxAutoSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBoxColorTheme;
        private System.Windows.Forms.Label labelColorTheme;
        private System.Windows.Forms.ComboBox comboBoxColorTheme;
        private System.Windows.Forms.GroupBox groupBoxFileBackup;
        private System.Windows.Forms.ComboBox comboBoxBackup;
        private System.Windows.Forms.Label labelFileBackup;
        private System.Windows.Forms.GroupBox groupBoxCompilerPath;
        private System.Windows.Forms.Label labelCompilerPath;
        private System.Windows.Forms.TextBox textBoxCompilerPath;
    }
}