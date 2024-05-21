using System.Drawing.Printing;
using TextBox = System.Windows.Forms.TextBox;

namespace litera
{
    public partial class Form1 : Form
    {
        private MenuStrip menuStrip;

        public Form1()
        {
            InitializeComponent();
            menuStrip = menuStrip1;
            menuStrip.Location = new Point(3, 3);

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
                    if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.tabControl1.TabPages.RemoveAt(i);
                        break;
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
            TabPage newTab = new TabPage("New Tab     ");

            newTab.Controls.Add(menuStrip);
            menuStrip.Location = new Point(3, 3);

            // Add a TextBox to the new tab
            TextBox textBox = new TextBox
            {
                Location = new Point(0, menuStrip.Bottom + 6),
                Size = new Size(newTab.ClientSize.Width, newTab.ClientSize.Height - menuStrip.Bottom - 6),
                Dock = DockStyle.Fill,
                Multiline = true
            };
            newTab.Controls.Add(textBox);

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
            TextBox textBox = tabControl1.SelectedTab.Controls.OfType<TextBox>().Reverse().FirstOrDefault();

            if (textBox != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string content = File.ReadAllText(filePath);
                    textBox.Text = content;

                    string fileName = Path.GetFileName(filePath);
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
            // save
            TabPage selectedTab = tabControl1.SelectedTab;
            TextBox textBox = tabControl1.SelectedTab.Controls.OfType<TextBox>().Reverse().FirstOrDefault();
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + selectedTab.Text.Trim() + ".txt";
            string content = textBox.Text;
            if (File.Exists(filePath))
            {
                DialogResult result = MessageBox.Show($"{selectedTab.Text.Trim()} already exists. Do you want to overwrite it?", "Overwrite File", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    File.WriteAllText(filePath, content);
                }
            }
            else
            {
                File.WriteAllText(filePath, content);
            }
            MessageBox.Show($"{selectedTab.Text.Trim()} successfully saved in Documents");
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox textBox = tabControl1.SelectedTab.Controls.OfType<TextBox>().Reverse().FirstOrDefault();
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
            TextBox textBox = tabControl1.SelectedTab.Controls.OfType<TextBox>().Reverse().FirstOrDefault();
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
            TextBox textBox = tabControl1.SelectedTab.Controls.OfType<TextBox>().Reverse().FirstOrDefault();
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

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox textBox = tabControl1.SelectedTab.Controls.OfType<TextBox>().Reverse().FirstOrDefault();
            if (textBox.SelectionLength > 0)
                textBox.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox textBox = tabControl1.SelectedTab.Controls.OfType<TextBox>().Reverse().FirstOrDefault();
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (textBox.SelectionLength > 0)
                {
                    textBox.SelectionStart = textBox1.SelectionStart + textBox1.SelectionLength;
                }
                textBox.Paste();
            }
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox textBox = tabControl1.SelectedTab.Controls.OfType<TextBox>().Reverse().FirstOrDefault();
            if (textBox.SelectionLength > 0)
                textBox.Cut();
        }
    }
}
