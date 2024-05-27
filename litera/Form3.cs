using System;
using System.Windows.Forms;

namespace litera
{
    public partial class Form3 : Form
    {
        private TextBox _textBox;
        private string _searchText;
        private bool _matchCase;
        private int _currentIndex;

        public Form3(TextBox textBox)
        {
            InitializeComponent();
            _textBox = textBox;
            _currentIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Find next
            FindNext();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Replace
            Replace();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Match case
            _matchCase = checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Cancel / close form
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Replace All
            ReplaceAll();
        }

        private void FindNext()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            _searchText = textBox1.Text;
            _matchCase = checkBox1.Checked;

            if (_textBox.Text.Length == 0)
            {
                MessageBox.Show("The document is empty.");
                return;
            }

            int startIndex = 0;
            if (_currentIndex != -1)
            {
                startIndex = _currentIndex + _searchText.Length;
                if (startIndex >= _textBox.Text.Length)
                {
                    startIndex = 0;
                }
            }

            _currentIndex = _textBox.Text.IndexOf(_searchText, startIndex, _matchCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);

            if (_currentIndex == -1)
            {
                MessageBox.Show("No matches found.");
                return;
            }

            _textBox.Select(_currentIndex, _searchText.Length);
            _textBox.ScrollToCaret();
            _textBox.HideSelection = false;
            _currentIndex += _searchText.Length;
            if (_currentIndex >= _textBox.Text.Length)
            {
                _currentIndex = 0; // Loop back to the beginning
            }
        }

        private void Replace()
        {
            if (!string.IsNullOrEmpty(_textBox.SelectedText))
            {
                // Check if the selected text matches the search text with case sensitivity based on the checkbox state
                bool isMatch = _matchCase ? _textBox.SelectedText == _searchText : _textBox.SelectedText.Equals(_searchText, StringComparison.OrdinalIgnoreCase);

                if (isMatch)
                {
                    int startIndex = _textBox.SelectionStart;
                    int length = _textBox.SelectedText.Length;
                    _textBox.Text = _textBox.Text.Remove(startIndex, length).Insert(startIndex, textBox2.Text);

                    _textBox.SelectionStart = startIndex;
                    _textBox.SelectionLength = textBox2.Text.Length;

                    _textBox.ScrollToCaret();
                    _textBox.HideSelection = false;
                }
                else
                {
                    // If the selected text does not match, find the next occurrence of the search text
                    FindNext();
                    if (_currentIndex != -1)
                    {
                        // Replace the found text
                        int startIndex = _currentIndex;
                        int length = _searchText.Length;
                        _textBox.Text = _textBox.Text.Remove(startIndex, length).Insert(startIndex, textBox2.Text);

                        _textBox.SelectionStart = startIndex;
                        _textBox.SelectionLength = textBox2.Text.Length;

                        _textBox.ScrollToCaret();
                        _textBox.HideSelection = false;
                    }
                }
            }
        }

        private void ReplaceAll()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            _searchText = textBox1.Text;
            _matchCase = checkBox1.Checked;

            int startIndex = 0;
            int count = 0;

            while (startIndex != -1)
            {
                startIndex = _textBox.Text.IndexOf(_searchText, startIndex, _matchCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
                if (startIndex != -1)
                {
                    _textBox.Text = _textBox.Text.Remove(startIndex, _searchText.Length).Insert(startIndex, textBox2.Text);
                    startIndex += textBox2.Text.Length;
                    count++;
                }
            }

            MessageBox.Show($"Replaced {count} occurrences.");
        }
    }
}