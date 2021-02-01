using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp4
{

    public partial class FormMain : Form
    {
        static int FormCounter = 0;
        readonly int FormNumber;
        /// <summary>
        /// Initialises main form. Also increment counter for additional forms created not to load previous state.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            if (FormCounter == 0)
            {
                LoadPrevFormState();
            }
            FormNumber = FormCounter;
            try
            {
                SettingsWindow = new FormSettings(this);
                if (FormCounter == 0)
                    MessageBox.Show($"Backup files could be found in notapadData/backups. {Environment.NewLine}" +
                        $"Loaded settings for autosave and autobackup will not be displayed in settings window, but they will be loaded, if loading file is correct.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error. {ex.Message}");
            }
            FormCounter++;

        }

        /// <summary>
        /// Loads previous state of program from files.
        /// </summary>
        private void LoadPrevFormState()
        {
            try
            {
                string prevStateStr = File.ReadAllText(Path.Combine("notapadData", "central.txt"));
                string[] splitedState = prevStateStr.Split("@@");
                CurrentTheme = splitedState[0];
                AutoSave = splitedState[1];
                CompilerPath = splitedState[2];
                BackupDelay = splitedState[3];
                // Load previous state opened files.
                for (int i = 4; i < splitedState.Length; i += 2)
                {
                    try
                    {
                        string name = splitedState[i];
                        string path = splitedState[i + 1];
                        OpenFile(path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Can't reopen {splitedState[i + 1]}. {ex.Message}");
                    }
                }
                if (AutoSave != "Off")
                {
                    SetAutoSaveInterval(int.Parse(AutoSave));
                    TurnAutoSaveOn();
                }
                if (BackupDelay != "Off")
                {
                    SetBackupInverval(int.Parse(BackupDelay));
                    TurnBackupOn();
                }

                RefreshColorTheme();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't load previous state of program. {ex.Message}");
            }
        }
        public FormState Formstate = new FormState();
        public int CountOpenedWindows = 0;
        Button lastClickedButton = null;
        readonly bool[] freeNewFileNames = new bool[256];
        static FormSettings SettingsWindow = null;
        readonly ColorTheme darkTheme = new ColorTheme
        {
            InterfaceColor = Color.FromArgb(255, 50, 50, 50),
            InterfaceForeColor = Color.FromArgb(255, 255, 255, 255),
            TextBoxFontColor = Color.FromArgb(255, 255, 255, 255),
            TextBoxBackColor = Color.FromArgb(255, 50, 50, 50),
            PanelBackColor = Color.FromArgb(255, 50, 50, 50),
            ButtonColor = Color.FromArgb(255, 50, 50, 50),
            ButtonTextColor = Color.FromArgb(255, 255, 255, 255),
            PanelForeColor = Color.FromArgb(255, 50, 50, 50)
        };
        readonly ColorTheme whiteTheme = new ColorTheme
        {
            InterfaceColor = Color.White,
            InterfaceForeColor = Color.Black,
            TextBoxFontColor = Color.Black,
            TextBoxBackColor = Color.White,
            PanelBackColor = Color.White,
            ButtonColor = Color.White,
            ButtonTextColor = Color.Black,
            PanelForeColor = Color.Black
        };
        public string CurrentTheme = "white";
        public string AutoSave = "Off";
        public string CompilerPath = "";
        public string BackupDelay = "Off";

        /// <summary>
        /// Handles choice of element in context menu of File.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStripFile_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStripFile.Hide();
            try
            {
                switch (e.ClickedItem.ToString())
                {
                    case "New":
                        CreateNextNewTextWindow();
                        break;
                    case "Close":
                        CloseActiveTextWindow();
                        break;
                    case "Open":
                        OpenFile();
                        break;
                    case "Save":
                        SaveActiveFile();
                        break;
                    case "Save as":
                        SaveActiveFileAs();
                        break;
                    case "Save All":
                        SaveAllOpenedFiles();
                        break;
                    case "New window":
                        CreateNewFormWindow();
                        break;
                    case "Exit":
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something unexpected happened! {ex.Message}");
            }
        }

        /// <summary>
        /// Creates additional form window.
        /// </summary>
        private void CreateNewFormWindow()
        {
            FormMain newWindow = new FormMain();
            newWindow.CreateNextNewTextWindow();
            newWindow.Show();
        }

        /// <summary>
        /// Handles choice of Edit menu element.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStripEdit_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStripEdit.Hide();
            try
            {
                switch (e.ClickedItem.ToString())
                {
                    case "Undo":
                        UndoActiveChildAction();
                        break;
                    case "Redo":
                        RedoActiveChildAction();
                        break;
                    case "Reformat":
                        ReformatActiveChild();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something unexpected happened! {ex.Message}");
            }
        }


        /// <summary>
        /// Reformats cs file.
        /// </summary>
        private void ReformatActiveChild()
        {
            if (Path.GetExtension((ActiveMdiChild as FormFileWindow).FileName) != ".cs")
            {
                MessageBox.Show("This is not .cs file. Formatting will not be performed.");
                return;
            }
            MessageBox.Show("Before code formatting you should save your file.");
            (ActiveMdiChild as FormFileWindow).Save("Current");
            (ActiveMdiChild as FormFileWindow).FormatFile();

        }

        /// <summary>
        /// Handles buttons settings, format and compile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuStripMainWindow_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Settings":
                    ShowSettingsWindow();
                    break;
                case "Format":
                    CallFontChoiceAndSetFont();
                    break;
                case "Compile":
                    CompileFile();
                    break;
            }
        }

        /// <summary>
        /// Compiles c sharp file with compiler provided by user.
        /// </summary>
        private void CompileFile()
        {
            try
            {
                if (Path.GetExtension((ActiveMdiChild as FormFileWindow).FileName) != ".cs")
                {
                    MessageBox.Show("Choose .cs file to compile code!");
                    return;
                }
                if (CompilerPath.Length == 0)
                {
                    MessageBox.Show("You should enter compiler path first. Can't compile.");
                    return;
                }
                MessageBox.Show("You should save file before compiling.");
                (ActiveMdiChild as FormFileWindow).Save("Current");
                string strCmdText = $"/C {CompilerPath} {(ActiveMdiChild as FormFileWindow).FilePath}";
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "CMD.EXE",
                    Arguments = strCmdText,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                p.StartInfo = psi;
                p.Start();
                if (!p.WaitForExit(20 * 1000))
                {
                    p.Kill();
                    MessageBox.Show("Incorrect compiler path or something unexpected happened. Process was stopped.");
                }
                else
                {
                    string output = p.StandardOutput.ReadToEnd();
                    MessageBox.Show(output + $"{Environment.NewLine} You can find .exe file in notapad folder.");
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("You didn't choose file to compile!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error happened. {ex.Message}");
            }

        }

        // Private members access methods.
        public void TurnAutoSaveOff() => timerAutoSave.Enabled = false;
        public void TurnAutoSaveOn() => timerAutoSave.Enabled = true;
        public void TurnBackupOn() => timerBackup.Enabled = true;
        public void TurnBackupOff() => timerBackup.Enabled = false;
        public void SetAutoSaveInterval(int mileseconds) => timerAutoSave.Interval = mileseconds;
        public void SetBackupInverval(int mileseconds) => timerBackup.Interval = mileseconds;
        public void RemoveFileButton(Button buttonToRemove) => flowLayoutPanelTabButtons.Controls.Remove(buttonToRemove);

        // Save methods.
        private void SaveActiveFileAs()
        {
            (ActiveMdiChild as FormFileWindow).SaveAs();
        }
        private void SaveActiveFile()
        {
            (ActiveMdiChild as FormFileWindow).Save("Current");
        }

        /// <summary>
        /// Shows file dialog for file opening.
        /// </summary>
        /// <returns></returns>
        private (string, string) GetFilePathViaDialog()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Txt files (*.txt)|*.txt|Rtf files (*.rtf)|*.rtf|C# files (*.cs)|*.cs";
                openFileDialog.FilterIndex = 1;
                openFileDialog.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var dialogResult = openFileDialog.ShowDialog();
                if (DialogResult != DialogResult.Cancel)
                    return (Path.GetFullPath(openFileDialog.FileName), openFileDialog.FileName);
                return (null, null);
            }
        }
        /// <summary>
        /// Checks if too many files are created, then it is not possible to create more.
        /// </summary>
        /// <returns>True if possible, false if not.</returns>
        private bool CheckIfPossibleToCreateOrOpenNewFile()
        {
            if (MdiChildren.Length > 15)
            {
                MessageBox.Show("16 text files are already opened, close one of them to create or open new.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets number for new text file.
        /// </summary>
        /// <returns></returns>
        private int GetNewFileIndex()
        {
            for (int newFileIndex = 0; newFileIndex < freeNewFileNames.Length; newFileIndex++)
            {
                if (!freeNewFileNames[newFileIndex])
                {
                    freeNewFileNames[newFileIndex] = true;
                    return newFileIndex;
                }
            }
            return -1;
        }

        /// <summary>
        /// Hides all file windows.
        /// </summary>
        public void HideAllChildrenForms() => Array.ForEach(MdiChildren, x => x.Hide());
        /// <summary>
        /// Saves and closes all files.
        /// </summary>
        public void CloseAllOpenedFiles()
        {
            string path = @"notapadData";
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
            Array.ForEach(MdiChildren, x => (x as FormFileWindow).CloseFile(true));
        }
        public void SaveAllOpenedFiles() => Array.ForEach(MdiChildren, x => (x as FormFileWindow).Save("Current"));
        /// <summary>
        /// Creates backup of all opened files in notapadData folder
        /// </summary>
        public void BackupAllFilesOpened() => Array.ForEach(MdiChildren, x => (x as FormFileWindow).CreateBackup());

        /// <summary>
        /// Applies color theme again.
        /// </summary>
        private void RefreshColorTheme()
        {
            switch (CurrentTheme)
            {
                case "white":
                    ChangeThemeToWhite();
                    break;
                case "dark":
                    ChangeThemeToDark();
                    break;
            }
        }


        /// <summary>
        /// Undo active file action.
        /// </summary>
        public void UndoActiveChildAction()
        {
            try
            {
                (ActiveMdiChild as FormFileWindow).UndoTextBoxAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while trying to undo operation. {ex.Message}");
            }
        }

        /// <summary>
        /// Redo undone active file action.
        /// </summary>
        public void RedoActiveChildAction()
        {
            try
            {
                (ActiveMdiChild as FormFileWindow).RedoTextBoxAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while trying to undo operation. {ex.Message}");
            }
        }

        /// <summary>
        /// Shows font dialog and sets font for active file.
        /// </summary>
        private void CallFontChoiceAndSetFont()
        {
            if (ActiveMdiChild == null)
            {
                MessageBox.Show("Error. No active document to apply font to.");
                return;
            }
            try
            {
                DialogResult fontResult = fontDialog.ShowDialog();
                if (fontResult == DialogResult.OK)
                {
                    (ActiveMdiChild as FormFileWindow).ChangeTextFont(fontDialog.Font);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while trying to change font of active file. {ex.Message}");
            }
        }

        /// <summary>
        /// Opens new file.
        /// </summary>
        private void OpenFile(string filePath = null)
        {
            FormFileWindow newForm = null;
            string fileName;
            try
            {
                if (filePath == null)
                {
                    if (!CheckIfPossibleToCreateOrOpenNewFile())
                        return;
                    (filePath, fileName) = GetFilePathViaDialog();
                    if (filePath == null)
                        return;
                }
                else
                    fileName = Path.GetFileName(filePath);
                newForm = CreateParameterizedTextWindow(Path.GetFileName(filePath), filePath, false);
                // Checks file extensons and chooses actions.
                if (Path.GetExtension(filePath) == ".rtf")
                {
                    newForm.LoadRichText();
                }
                else if (Path.GetExtension(filePath) == ".txt")
                {
                    newForm.LoadText(File.ReadAllText(filePath));
                }
                else if (Path.GetExtension(filePath) == ".cs")
                {
                    newForm.LoadText(File.ReadAllText(filePath));
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while trying to open new file. {ex.Message}");
            }
            if (newForm != null)
                newForm.ForcedCloseFile();
        }

        /// <summary>
        /// Performs all actions that is nessesary to close active file.
        /// </summary>
        private void CloseActiveTextWindow()
        {
            try
            {
                if (lastClickedButton == null)
                {
                    MessageBox.Show("Select document to close.");
                    return;
                }

                (ActiveMdiChild as FormFileWindow).CloseFile();
                lastClickedButton = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while trying to close active window. {ex.Message}");
            }
        }


        /// <summary>
        /// Creates new empty text window.
        /// </summary>
        private void CreateNextNewTextWindow()
        {
            try
            {
                if (!CheckIfPossibleToCreateOrOpenNewFile())
                    return;
                int newFileIndex = GetNewFileIndex();
                string fileName = "new" + newFileIndex + ".txt";
                string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
                CreateParameterizedTextWindow(fileName, filePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while trying to create new editor window. {ex.Message}");
            }
        }
        /// <summary>
        /// Creates new custom file window.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="filePath"></param>
        /// <param name="isNextNew">If new window's file should be blank new file, then it should be set to true, otherwise false</param>
        /// <returns></returns>
        private FormFileWindow CreateParameterizedTextWindow(string fileName, string filePath, bool isNextNew)
        {
            try
            {
                Button newFormButton = new Button();
                FormFileWindow newForm = new FormFileWindow
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized,
                    IsChangedFlag = false,
                    connectedButton = newFormButton
                };
                // Sets new filename and connects button to form.
                newForm.ChangeFileName(fileName, isNextNew ? null : filePath);
                newFormButton.Click += (sender, EventArgs) => { ButtonNext_Click(sender, EventArgs, newForm); };
                newFormButton.MouseDown += (sender, EventArgs) => { Button_MouseWheelClick(sender, EventArgs, newForm); };
                flowLayoutPanelTabButtons.Controls.Add(newFormButton);
                CountOpenedWindows++;
                RefreshColorTheme();
                return newForm;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while trying to create new editor window. {ex.Message}");
            }
            return null;
        }
        /// <summary>
        /// Allows to close windows by clicking middle mouse button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        /// <param name="newForm"></param>
        private void Button_MouseWheelClick(object sender, MouseEventArgs eventArgs, FormFileWindow newForm)
        {
            if (eventArgs.Button == MouseButtons.Middle)
            {
                newForm.CloseFile();
            }
        }
        /// <summary>
        /// Activates file window to which clicked button belongs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="formToShow"></param>
        void ButtonNext_Click(object sender, EventArgs e, Form formToShow)
        {
            try
            {
                HideAllChildrenForms();
                formToShow.WindowState = FormWindowState.Maximized;
                formToShow.Activate();
                formToShow.Show();
                lastClickedButton = (Button)sender;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while trying to show this tab. {ex.Message}");
            }
        }

        /// <summary>
        /// Allows to save state of app on closing, also closes and save all windows on exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MdiChildren != null)
                    CloseAllOpenedFiles();
                if (MdiChildren.Length > 0)
                    e.Cancel = true;
                if (FormNumber == 0)
                    Formstate.SaveState(CurrentTheme, AutoSave, CompilerPath, BackupDelay);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while trying to close application. {ex.Message}");
            }
        }
        /// <summary>
        /// Handles autosave timer tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerAutosave_Tick(object sender, EventArgs e)
        {

            try
            {
                /*if (MdiChildren.Length == 0)
                    MessageBox.Show("ALARM");*/
                SaveAllOpenedFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while autosaving. {ex.Message}");
            }
        }


        /// <summary>
        /// Makes settings window visible.
        /// </summary>
        private void ShowSettingsWindow()
        {
            try
            {
                if (SettingsWindow == null)
                    SettingsWindow = new FormSettings(this);
                SettingsWindow.SetComboThemeText(CurrentTheme.Substring(0, 1).ToUpper() + CurrentTheme.Substring(1) + " theme");
                SettingsWindow.SetCompilerPath(CompilerPath);
                SettingsWindow.Show();
                SettingsWindow.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while trying to open setting window. {ex.Message}");
            }
        }
        /// <summary>
        /// Changes theme to dark.
        /// </summary>
        public void ChangeThemeToDark()
        {
            try
            {
                BackColor = darkTheme.InterfaceColor;
                ForeColor = darkTheme.InterfaceForeColor;
                if (SettingsWindow != null)
                {
                    SettingsWindow.BackColor = darkTheme.InterfaceColor;
                    SettingsWindow.ForeColor = darkTheme.InterfaceForeColor;
                    darkTheme.SetThisTheme(Controls, SettingsWindow.Controls);
                }
                else
                    darkTheme.SetThisTheme(Controls);
                CurrentTheme = "dark";
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while changing theme. {ex.Message}");
            }
        }

        /// <summary>
        /// Changes theme to white.
        /// </summary>
        public void ChangeThemeToWhite()
        {
            try
            {
                BackColor = whiteTheme.InterfaceColor;
                ForeColor = whiteTheme.InterfaceForeColor;
                if (SettingsWindow != null)
                {
                    SettingsWindow.BackColor = whiteTheme.InterfaceColor;
                    SettingsWindow.ForeColor = whiteTheme.InterfaceForeColor;
                    whiteTheme.SetThisTheme(Controls, SettingsWindow.Controls);
                }
                else
                    whiteTheme.SetThisTheme(Controls);
                CurrentTheme = "white";
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while changing theme. {ex.Message}");
            }
        }

        /// <summary>
        /// Handles backup timer tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerBackup_Tick(object sender, EventArgs e)
        {
            try
            {
                BackupAllFilesOpened();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while backuping. {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Class for representing color theme.
    /// </summary>
    class ColorTheme
    {
        public Color InterfaceColor;
        public Color InterfaceForeColor;
        public Color TextBoxFontColor;
        public Color TextBoxBackColor;
        public Color PanelBackColor;
        public Color ButtonColor;
        public Color ButtonTextColor;
        public Color PanelForeColor;


        /// <summary>
        /// Sets color theme.
        /// </summary>
        /// <param name="controlContainerMain"></param>
        /// <param name="controlContainerSettings"></param>
        public void SetThisTheme(Control.ControlCollection controlContainerMain, Control.ControlCollection controlContainerSettings = null)
        {
            if (controlContainerSettings != null)
                SetThisTheme(controlContainerSettings);
            // Iterates through controls and changes them.
            foreach (Control component in controlContainerMain)
            {
                SetThisTheme(component.Controls);
                if (component is Panel)
                {
                    component.BackColor = PanelBackColor;
                    component.ForeColor = PanelForeColor;
                }
                else if (component is Button)
                {
                    component.BackColor = ButtonColor;
                    component.ForeColor = ButtonTextColor;
                }
                else if (component is RichTextBox)
                {
                    component.BackColor = TextBoxBackColor;
                    component.ForeColor = TextBoxFontColor;
                }
                else if (component is TextBox)
                {
                    component.BackColor = TextBoxBackColor;
                    component.ForeColor = TextBoxFontColor;
                }
                else if (component is MenuStrip)
                {
                    component.BackColor = InterfaceColor;
                    component.ForeColor = InterfaceForeColor;
                }
                else if (component is ContextMenuStrip)
                {
                    (component as ContextMenuStrip).BackColor = InterfaceColor;
                    component.ForeColor = InterfaceForeColor;
                }
                else if (component is ComboBox)
                {
                    component.BackColor = InterfaceColor;
                    component.ForeColor = InterfaceForeColor;
                }
            }
        }
    }
    /// <summary>
    /// Describes opened file.
    /// </summary>
    public class OpenedDoc
    {
        public string FileName;
        public string Path;

        public OpenedDoc(string name, string path) => (FileName, Path) = (name, path);
    }
    /// <summary>
    /// Keeps application state.
    /// </summary>
    public class FormState
    {
        public List<OpenedDoc> CurrentDocsOpened = new List<OpenedDoc>();
        /// <summary>
        /// Saves app state on disk for futher reopening.
        /// </summary>
        /// <param name="theme"></param>
        /// <param name="save"></param>
        /// <param name="comp"></param>
        public void SaveState(string currentTheme, string autoSaveDelay, string compilerPath, string backupDelay)
        {
            // Saves current state data in special format.
            StringBuilder startupFileBuilder = new StringBuilder();
            startupFileBuilder.Append(currentTheme + "@@");
            startupFileBuilder.Append(autoSaveDelay + "@@");
            startupFileBuilder.Append(compilerPath + "@@");
            startupFileBuilder.Append(backupDelay);
            foreach (var file in CurrentDocsOpened)
            {
                startupFileBuilder.Append($"@@{file.FileName}@@{file.Path}");
            }
            File.WriteAllText(Path.Combine("notapadData", "central.txt"), startupFileBuilder.ToString());
        }
    }
}
