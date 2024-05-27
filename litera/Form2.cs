using TextBox = System.Windows.Forms.TextBox;

namespace litera
{
    public partial class Form2 : Form
    {
        private TextBox _textBox;
        private string _searchText;
        private bool _matchCase;
        private int _currentIndex;

        public Form2(TextBox textBox)
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
            // Cancel / close form
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Match case
            _matchCase = checkBox1.Checked;
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
                // No matches found, display a message box
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
    }
}