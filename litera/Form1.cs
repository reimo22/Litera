using System.Diagnostics;
using System.Drawing.Printing;
using TextBox = System.Windows.Forms.TextBox;

namespace litera
{
    public partial class Form1 : Form
    {
        private MenuStrip menuStrip;
        private Dictionary<string, Stack<string>> undoStacks = new Dictionary<string, Stack<string>>();
        private Dictionary<string, Stack<string>> redoStacks = new Dictionary<string, Stack<string>>();
        private Dictionary<string, string> filePaths = new Dictionary<string, string>();


        public Form1()
        {
            InitializeComponent();
            menuStrip = menuStrip1;
            // create initial tab
            createNewTab(this.tabControl1.TabCount - 1);

            // allow resizing
            tabControl1.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            var lastIndex = this.tabControl1.TabCount - 1;
            // New tab button
            if (this.tabControl1.GetTabRect(lastIndex).Contains(e.Location))
            {
                createNewTab(lastIndex);
            }

            // Close button
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                if (closeButton.Contains(e.Location))
                {
                    TabPage selectedTab = this.tabControl1.TabPages[i];
                    TextBox textBox = selectedTab.Controls.OfType<TextBox>().FirstOrDefault();
                    if (textBox != null && textBox.Modified) // Check if the text box has been modified
                    {
                        DialogResult saveDialogResult = MessageBox.Show("The tab has unsaved changes. Would you like to save before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (saveDialogResult == DialogResult.Yes)
                        {
                            saveAs(selectedTab);
                            if (textBox.Modified)
                            {
                                MessageBox.Show("Changes were saved successfully.");
                            }
                        }
                        else if (saveDialogResult == DialogResult.No)
                        {
                            this.tabControl1.TabPages.RemoveAt(i);
                            break;
                        }
                        else
                        {
                            // User chose Cancel, do nothing and break the loop
                            break;
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.tabControl1.TabPages.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }


        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // prevent selecting new tab
            if (e.TabPageIndex == this.tabControl1.TabCount - 1)
                e.Cancel = true;

            // Add MenuStrip to the new tab
            if (e.TabPageIndex > 0 && tabControl1.TabPages[e.TabPageIndex - 1].Controls.Contains(menuStrip))
            {
                tabControl1.TabPages[e.TabPageIndex - 1].Controls.Remove(menuStrip);
            }

            if (!tabControl1.TabPages[e.TabPageIndex].Controls.Contains(menuStrip))
            {
                tabControl1.TabPages[e.TabPageIndex].Controls.Add(menuStrip);
                menuStrip.Location = new Point(3, 3);
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawCloseButton(sender, e);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lastIndex = this.tabControl1.TabCount - 1;
            createNewTab(lastIndex);
        }
        private void createNewTab(int lastIndex)
        {
            TabPage newTab = new TabPage("New Tab     "); // add whitespace to leave space for close button
            TextBox textBox = new TextBox
            {
                Location = new Point(0, 0),
                Size = new Size(newTab.ClientSize.Width, newTab.ClientSize.Height),
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                WordWrap = true,
            };
            textBox.Name = $"textBox{Guid.NewGuid()}"; // Set a unique name for each TextBox
            AttachTextChangedEvent(textBox);
            newTab.Controls.Add(textBox);
            textBox.Focus();

            newTab.Controls.Add(menuStrip);
            menuStrip.Location = new Point(3, 3);

            while (tabControl1.TabPages.ContainsKey(newTab.Name))
            {
                newTab.Name = $"New Tab({tabControl1.TabCount})";
            }

            this.tabControl1.TabPages.Insert(lastIndex, newTab);
            this.tabControl1.SelectedIndex = lastIndex;
        }
        private void drawCloseButton(object sender, DrawItemEventArgs e)
        {
            if (e.Index < tabControl1.TabCount - 1)
            {
                e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
                e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
                e.DrawFocusRectangle();
            }
            else
            {
                e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 20, e.Bounds.Top + 4);
                e.DrawFocusRectangle();
            }
        }
        private void openFile()
        {
            // Find the currently selected tab and its TextBox
            TabPage selectedTab = tabControl1.SelectedTab;
            TextBox textBox = getTextBox();

            if (textBox != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(filePath);

                    // Check if the filename already exists in the dictionary
                    if (filePaths.ContainsKey(fileName))
                    {
                        // Generate a new filename by appending a number
                        int index = 1;
                        string newFileName;
                        do
                        {
                            newFileName = $"{Path.GetFileNameWithoutExtension(fileName)}({index}){Path.GetExtension(fileName)}";
                            index++;
                        } while (filePaths.ContainsKey(newFileName));

                        fileName = newFileName;
                    }

                    // Read the file content
                    string content = File.ReadAllText(filePath);
                    textBox.Text = content;

                    // Update the dictionary with the new filename and file path
                    filePaths[fileName] = filePath;

                    // Update the tab text
                    selectedTab.Text = fileName + "     ";
                }
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            save(selectedTab);
        }

        private void save(TabPage selectedTab)
        {
            TextBox textBox = selectedTab.Controls.OfType<TextBox>().FirstOrDefault();
            if (textBox == null)
            {
                MessageBox.Show("No text box found in the selected tab.");
                return;
            }

            string fileName = selectedTab.Text.Trim();
            if (filePaths.ContainsKey(fileName))
            {
                DialogResult result = MessageBox.Show($"File '{fileName}' already exists. Do you want to overwrite it?", "Confirm Save", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string filePath = filePaths[fileName];
                    string content = textBox.Text;
                    File.WriteAllText(filePath, content);
                }
            }
            else
            {
                saveAs(selectedTab);
            }
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveAs(tabControl1.SelectedTab);
        }

        private void saveAs(TabPage selectedTab)
        {
            TextBox textBox = selectedTab.Controls.OfType<TextBox>().Reverse().FirstOrDefault();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string content = textBox.Text;
                File.WriteAllText(filePath, content);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            TextBox textBox = getTextBox();
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = "Print Document";
            printDocument.PrintPage += (sender, e) =>
            {
                e.Graphics.DrawString(textBox.Text, new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
            };
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printPreviewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            TextBox textBox = getTextBox();
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = "Print Document";
            printDocument.PrintPage += (sender, e) =>
            {
                e.Graphics.DrawString(textBox.Text, new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
            };
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void AttachTextChangedEvent(TextBox textBox)
        {
            textBox.TextChanged += TextChanged;

            if (!undoStacks.ContainsKey(textBox.Name))
            {
                undoStacks.Add(textBox.Name, new Stack<string>());
            }

            if (!redoStacks.ContainsKey(textBox.Name))
            {
                redoStacks.Add(textBox.Name, new Stack<string>());
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox activeTextBox = tabControl1.SelectedTab.Controls.OfType<TextBox>().First();
            string textBoxName = activeTextBox.Name;

            if (undoStacks[textBoxName].Count > 0)
            {
                redoStacks[textBoxName].Push(activeTextBox.Text);
                activeTextBox.Text = undoStacks[textBoxName].Pop();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox activeTextBox = tabControl1.SelectedTab.Controls.OfType<TextBox>().First();
            string textBoxName = activeTextBox.Name;

            if (redoStacks[textBoxName].Count > 0)
            {
                undoStacks[textBoxName].Push(activeTextBox.Text);
                activeTextBox.Text = redoStacks[textBoxName].Pop();
            }
        }

        private void TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string textBoxName = textBox.Name;

            if (!undoStacks.ContainsKey(textBoxName))
            {
                undoStacks.Add(textBoxName, new Stack<string>());
            }

            undoStacks[textBoxName].Push(textBox.Text);
            textBox.ClearUndo();

            Debug.WriteLine($"Undo stack for {textBoxName}: {string.Join(", ", undoStacks[textBoxName])}");
            Debug.WriteLine($"Redo stack for {textBoxName}: {string.Join(", ", redoStacks[textBoxName])}");
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox textBox = getTextBox();
            if (textBox.SelectionLength > 0)
                textBox.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox textBox = getTextBox();
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (textBox.SelectionLength > 0)
                {
                    textBox.SelectionStart = textBox.SelectionStart + textBox.SelectionLength;
                }
                textBox.Paste();
            }
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox textBox = getTextBox();
            if (textBox.SelectionLength > 0)
                textBox.Cut();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = getTextBox();
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Font = fontDialog.Font;
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = getTextBox();
            ZoomInOut(textBox, true);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = getTextBox();
            ZoomInOut(textBox, false);
        }

        private void ZoomInOut(TextBox textBox, bool zoomIn)
        {
            if (zoomIn)
            {
                if (textBox.Font.Size < 72) // Maximum font size is 72
                {
                    textBox.Font = new Font(textBox.Font.FontFamily, textBox.Font.Size + 1);
                }
            }
            else
            {
                if (textBox.Font.Size > 8) // Minimum font size is 8
                {
                    textBox.Font = new Font(textBox.Font.FontFamily, textBox.Font.Size - 1);
                }
            }
        }

        private void defaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox textBox = getTextBox();
            textBox.Font = new Font(textBox.Font.FontFamily, 9);
        }

        private TextBox getTextBox()
        {
            return tabControl1.SelectedTab.Controls.OfType<TextBox>().FirstOrDefault();
        }

        // Prompts user to save changes when closing app
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            HandleExit(e);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            // exit button
            FormClosingEventArgs dummyArgs = new FormClosingEventArgs(CloseReason.UserClosing, false);
            HandleExit(dummyArgs);
        }

        private void HandleExit(FormClosingEventArgs e)
        {
            bool allTextboxesEmpty = true;

            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                TextBox textBox = tabPage.Controls.OfType<TextBox>().FirstOrDefault();
                if (textBox != null && textBox.Text != string.Empty)
                {
                    allTextboxesEmpty = false;
                    break;
                }
            }


            if (!allTextboxesEmpty)
            {
                DialogResult result = MessageBox.Show("Do you want to save your changes before closing?", "Save Changes", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    foreach (TabPage tabPage in tabControl1.TabPages)
                    {
                        TextBox textBox = tabPage.Controls.OfType<TextBox>().FirstOrDefault();
                        if (textBox != null && textBox.Text != string.Empty)
                        {
                            save(tabPage);
                        }
                    }
                }
                else if (result == DialogResult.No)
                {
                    // Proceed with closing without saving
                    e.Cancel = false;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // Cancel the form closing
                }
            }
            else
            {
                e.Cancel = false; // Proceed with closing if no tabs are open
            }
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            // selectAll
            TextBox textBox = getTextBox();
            SelectAllText(textBox);
        }

        private void SelectAllText(TextBox textBox)
        {
            if (textBox != null)
            {
                textBox.Select(0, textBox.Text.Length);
            }
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            // Word wrap
            TextBox textBox = getTextBox();

            if (textBox != null)
            {
                textBox.WordWrap = !textBox.WordWrap;
                toolStripMenuItem21.Checked = textBox.WordWrap;
            }
        }
    }
}
