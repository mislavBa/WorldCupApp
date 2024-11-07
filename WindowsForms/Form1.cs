namespace WindowsForms
{
    public partial class Form1 : Form
    {
        static string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\Data");
        string PATH = Path.Combine(folderPath, "settings.txt");

        public Form1()
        {
            Directory.CreateDirectory(folderPath);
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string[] settings = new string[2];
            string? selectedLang = cbLang.SelectedItem?.ToString();
            string? selectedGender = cbGender.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedLang) || string.IsNullOrEmpty(selectedGender))
            {
                MessageBox.Show("Please select laguage and gender!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            settings[0] = selectedLang;
            settings[1] = selectedGender;
            File.WriteAllLines(PATH, settings);

            MessageBox.Show(Path.GetFullPath(PATH), "Full Path");

            this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSelect.PerformClick();
            }
        }
    }
}
