using EnvDTE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FormFileWindow : Form
    {

        public FormFileWindow()
        {
            InitializeComponent();
        }

        public int IndexInNewFileNamesIfUsedOne = -1;
        public string FilePath = null;
        public string FileName = null;
        public bool IsChangedFlag = false;
        public Button connectedButton;

        /// <summary>
        /// Show file dialog and returns chosen path.
        /// </summary>
        /// <returns></returns>
        private (string, string) GetFilePathViaDialog()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|Rtf files (*.rtf)|*.rtf";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                saveFileDialog.FileName = FileName;
                var dialogResult = saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName.Length > 0)
                    return (Path.GetFullPath(saveFileDialog.FileName), saveFileDialog.FileName);
                return (null, null);
            }
        }
        /// <summary>
        /// Reformats code file.
        /// </summary>
        public void FormatFile()
        {
            try
            {
                Solution soln = System.Activator.CreateInstance(Type.GetTypeFromProgID("VisualStudio.Solution.16.0")) as EnvDTE.Solution;
                soln.DTE.ItemOperations.OpenFile(FilePath);
                TextSelection selection = soln.DTE.ActiveDocument.Selection as TextSelection;
                selection.SelectAll();
                selection.SmartFormat();
                soln.DTE.ActiveDocument.Save();
                LoadText(File.ReadAllText(FilePath));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to format file. {ex.Message}");
            }

        }
        /// <summary>
        /// Tries to save file.
        /// </summary>
        /// <param name="filePath">"Current" - means you want to try to save file to its current FilePath. If it is null, fileDialog will be called.
        /// Also save cancels if use press "cancel" in file dialog. </param>
        /// <returns></returns>
        public bool Save(string filePath)
        {
            try
            {
                string newFileName;
                if (filePath == "Current")
                {
                    filePath = FilePath;
                }
                if (filePath == null)
                {
                    (filePath, newFileName) = GetFilePathViaDialog();
                    if (filePath == null)
                        return false;
                }
                string extension = Path.GetExtension(filePath);
                switch (extension)
                {
                    case ".rtf":
                        richTextBoxFileContent.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        break;
                    default:
                        File.WriteAllText(filePath, richTextBoxFileContent.Text);
                        break;
                }
                ChangeFileName(Path.GetFileName(filePath), filePath);
                IsChangedFlag = false;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error happened while saving file. {ex.Message}");
            }
            return false;
        }
        /// <summary>
        /// Creates backup of the file in notapadData\backups. Puts current time in backup's name.
        /// </summary>
        public void CreateBackup()
        {
            try
            {
                if (!Directory.Exists(Path.Combine(@"notapadData", @"backups")))
                {
                    Directory.CreateDirectory(Path.Combine(@"notapadData", @"backups"));
                }
                // If file is rft process is a little different.
                if (Path.GetExtension(FileName) == ".rtf")
                    richTextBoxFileContent.SaveFile(Path.Combine(Path.Combine("notapadData", "backups"), Path.GetFileName(FileName) + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".rtf"));
                else
                    File.WriteAllText(Path.Combine(Path.Combine("notapadData", "backups"), Path.GetFileName(FileName) + DateTime.Now.ToString("ddMMyyyyhhmmss") +
                        (Path.GetExtension(FileName) == string.Empty ? ".txt" : Path.GetExtension(FileName))), richTextBoxFileContent.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create backup copy for {FileName}. {ex.Message}");
            }
        }
        /// <summary>
        /// Saves and closes file.
        /// </summary>
        /// <param name="saveToState">If true, then file is being save to notapadData to be opened during next launch of program.</param>
        public void CloseFile(bool saveToState = false)
        {

            try
            {
                FormMain parent = MdiParent as FormMain;
                if (IsChangedFlag)
                {
                    DialogResult dialogResult = MessageBox.Show($"You have unsaved changes for file {FileName}. Save your changes?", "Save changes?", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (!Save("Current"))
                        {
                            return;
                        }
                    }
                    else if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                if (saveToState)
                {
                    parent.Formstate.CurrentDocsOpened.Add(new OpenedDoc(FileName, FilePath != null ? FilePath : Path.Combine("notapadData", FileName)));
                    if (FilePath == null)
                        File.Create(Path.Combine("notapadData", FileName));
                }
                parent.RemoveFileButton(connectedButton);
                parent.CountOpenedWindows--;
                Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while trying to close tab. {ex.Message}");
            }
        }

        /// <summary>
        /// Gets text with formatting.
        /// </summary>
        public string GetRichText() => richTextBoxFileContent.Rtf;
        /// <summary>
        /// Gets text without formatting.
        /// </summary>
        public string GetRawText() => richTextBoxFileContent.Text;

        /// <summary>
        /// Closes files without trying to save its content.
        /// </summary>
        public void ForcedCloseFile()
        {
            try
            {
                FormMain parent = MdiParent as FormMain;
                parent.RemoveFileButton(connectedButton);
                parent.CountOpenedWindows--;
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error happened while trying to force close tab. {ex.Message}");
            }
        }

        /// <summary>
        /// Changes variables responsible for file name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        public void ChangeFileName(string name, string path)
        {
            connectedButton.Text = name;
            connectedButton.Tag = "windowButton" + name;
            FileName = name;
            FilePath = path;
        }

        /// <summary>
        /// Forces save location choice on saving file.
        /// </summary>
        public void SaveAs() => Save(null);

        /// <summary>
        /// Loads file into richTextBox by its path.
        /// </summary>
        /// <param name="filepath"></param>
        public void LoadRichText()
        {
            richTextBoxFileContent.LoadFile(FilePath);
        }

        /// <summary>
        /// Changes text of richTextbox.
        /// </summary>
        /// <param name="text"></param>
        public void LoadText(string text)
        {
            richTextBoxFileContent.Text = text;
        }

        /// <summary>
        /// Changes font of selection in richTextBox.
        /// </summary>
        /// <param name="font"></param>
        public void ChangeTextFont(Font font)
        {
            richTextBoxFileContent.SelectionFont = font;
        }

        // Undo and redo actions.
        public void UndoTextBoxAction() => richTextBoxFileContent.Undo();
        public void RedoTextBoxAction() => richTextBoxFileContent.Redo();

        private void richTextBoxFIleContent_TextChanged(object sender, EventArgs e) => IsChangedFlag = true;

        // RichTextBox context menu part.
        /// <summary>
        /// Changes Italic parameter of font.
        /// </summary>
        public void MakeItalicSelectedText()
        {
            richTextBoxFileContent.SelectionFont =
                new Font(richTextBoxFileContent.SelectionFont, FontStyle.Italic ^ richTextBoxFileContent.SelectionFont.Style);
        }

        /// <summary>
        /// Changes strikeout parameter of font.
        /// </summary>
        public void MakeCrossedSelectedText()
        {
            richTextBoxFileContent.SelectionFont =
                new Font(richTextBoxFileContent.SelectionFont, FontStyle.Strikeout ^ richTextBoxFileContent.SelectionFont.Style);
        }

        /// <summary>
        /// Changes underlined parameter of font.
        /// </summary>
        public void MakeUnderlinedSelectedText()
        {
            richTextBoxFileContent.SelectionFont =

                new Font(richTextBoxFileContent.SelectionFont, FontStyle.Underline ^ richTextBoxFileContent.SelectionFont.Style);
        }
        /// <summary>
        /// Changes bold parameter of font.
        /// </summary>
        public void MakeBoldSelectedText()
        {
            richTextBoxFileContent.SelectionFont =
                new Font(richTextBoxFileContent.SelectionFont, FontStyle.Bold ^ richTextBoxFileContent.SelectionFont.Style);
        }

        /// <summary>
        /// Calls font dialog and sets chosen font.
        /// </summary>
        private void CallFontChoiceAndSetFont()
        {
            try
            {
                FontDialog fontDialog = new FontDialog();
                DialogResult fontResult = fontDialog.ShowDialog();
                if (fontResult == DialogResult.OK)
                {
                    ChangeTextFont(fontDialog.Font);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened while trying to change font of active file. {ex.Message}");
            }
        }

        /// <summary>
        /// Shows context menu and handles choice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStripRightClick_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                contextMenuStripRightClick.Hide();
                switch (e.ClickedItem.ToString())
                {
                    case "Bold":
                        MakeBoldSelectedText();
                        break;
                    case "Italic":
                        MakeItalicSelectedText();
                        break;
                    case "Crossed":
                        MakeCrossedSelectedText();
                        break;
                    case "Underlined":
                        MakeUnderlinedSelectedText();
                        break;
                    case "Cut":
                        richTextBoxFileContent.Cut();
                        break;
                    case "Copy":
                        richTextBoxFileContent.Copy();
                        break;
                    case "Paste":
                        richTextBoxFileContent.Paste();
                        break;
                    case "Select All":
                        richTextBoxFileContent.SelectAll();
                        break;
                    case "Format":
                        CallFontChoiceAndSetFont();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error happened. {ex.Message}");
            }
        }
    }
}
