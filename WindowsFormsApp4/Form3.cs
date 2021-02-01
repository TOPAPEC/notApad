using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FormSettings : Form
    {
        // Just points to main form.
        FormMain parentForm;
        public FormSettings(FormMain parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }
        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveAutoSaveSetting();
            SaveColorThemeSettings();
            SaveBackupSettings();
            parentForm.CompilerPath = textBoxCompilerPath.Text;
        }
        /// <summary>
        /// Sets the backup settings.
        /// </summary>
        private void SaveBackupSettings()
        {
            switch (comboBoxBackup.Text)
            {
                case "Off":
                    parentForm.TurnBackupOff();
                    parentForm.BackupDelay = "Off";
                    break;
                case "0.5 minutes":
                    parentForm.TurnBackupOn();
                    parentForm.SetBackupInverval(30 * 1000);
                    parentForm.BackupDelay = (30 * 1000).ToString();
                    break;
                case "10 minutes":
                    parentForm.TurnBackupOn();
                    parentForm.SetBackupInverval(10 * 60 * 1000);
                    parentForm.BackupDelay = (10 * 60 * 1000).ToString();
                    break;
                case "30 minutes":
                    parentForm.TurnBackupOn();
                    parentForm.SetBackupInverval(30 * 60 * 1000);
                    parentForm.BackupDelay = (30 * 60 * 1000).ToString();
                    break;

            }
        }

        // Access methods that allows to set settings fields on startup.
        public void SetComboSaveText(string text) => comboBoxAutoSave.Text = text;
        public void SetComboThemeText(string text) => comboBoxColorTheme.Text = text;
        public void SetComboBackupText(string text) => comboBoxBackup.Text = text;
        public void SetCompilerPath(string text) => textBoxCompilerPath.Text = text;

        /// <summary>
        /// Sets the color theme.
        /// </summary>
        private void SaveColorThemeSettings()
        {
            switch (comboBoxColorTheme.Text)
            {
                case "Dark theme":
                    parentForm.ChangeThemeToDark();
                    parentForm.CurrentTheme = "dark";
                    break;
                case "White theme":
                    parentForm.ChangeThemeToWhite();
                    parentForm.CurrentTheme = "white";
                    break;
            }
        }
        /// <summary>
        /// Sets autosave parametres.
        /// </summary>
        private void SaveAutoSaveSetting()
        {
            switch (comboBoxAutoSave.Text)
            {
                case "Off":
                    parentForm.TurnAutoSaveOff();
                    parentForm.AutoSave = "Off";
                    break;
                case "0.5 minutes":
                    parentForm.TurnAutoSaveOn();
                    parentForm.SetAutoSaveInterval(30 * 1000);
                    parentForm.AutoSave = (30 * 1000).ToString();
                    break;
                case "1 minutes":
                    parentForm.TurnAutoSaveOn();
                    parentForm.SetAutoSaveInterval(60 * 1000);
                    parentForm.AutoSave = (60 * 1000).ToString();
                    break;
                case "5 minutes":
                    parentForm.TurnAutoSaveOn();
                    parentForm.SetAutoSaveInterval(300 * 1000);
                    parentForm.AutoSave = (300 * 1000).ToString();
                    break;
                case "10 minutes":
                    parentForm.TurnAutoSaveOn();
                    parentForm.SetAutoSaveInterval(600 * 1000);
                    parentForm.AutoSave = (600 * 1000).ToString();
                    break;
                case "30 minutes":
                    parentForm.TurnAutoSaveOn();
                    parentForm.SetAutoSaveInterval(1800 * 1000);
                    parentForm.AutoSave = (1800 * 1000).ToString();
                    break;
                case "60 minutes":
                    parentForm.TurnAutoSaveOn();
                    parentForm.SetAutoSaveInterval(6000 * 1000);
                    parentForm.AutoSave = (6000 * 1000).ToString();
                    break;
            }
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }


    }
}
