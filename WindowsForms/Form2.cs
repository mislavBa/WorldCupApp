using ClassLibrary;
using ClassLibrary.Team;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form2 : Form
    {
        static string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\Data");
        string PATH = Path.Combine(folderPath, "settings.txt");
        string TEAM_PATH = Path.Combine(folderPath, "favouriteTeam.txt");

        string selectedLang;
        string selectedGender;

        private const string HR = "hr";
        private const string EN = "en";

        PlayersUserControl puc = new PlayersUserControl();

        public Form2()
        {
            InitializeComponent();
            CheckSettings();
            LoadSettings();
            AddTeams();
            

            puc.Dock = DockStyle.Bottom;
            this.Controls.Add(puc);
        }

        private void SetLanguage()
        {
            if (selectedLang == "Croatian")
            {
                var culture = new CultureInfo(HR);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }
            else
            {
                var culture = new CultureInfo(EN);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }            

        }

        private async void AddTeams()
        {

            try
            {
                if (selectedGender == "Men")
                {
                    var responseData = await TeamDataFetcher.GetMenTeams();
                    List<Team> menTeams = Deserializer.DeserializeData<List<Team>>(responseData);
                    foreach (var team in menTeams)
                    {
                        cbTeams.Items.Add($"{team.Country} ({team.FifaCode})");
                    }
                }
                else if (selectedGender == "Women")
                {
                    var responseData = await TeamDataFetcher.GetWomenTeams();
                    List<Team> womenTeams = Deserializer.DeserializeData<List<Team>>(responseData);
                    foreach (var team in womenTeams)
                    {
                        cbTeams.Items.Add($"{team.Country} ({team.FifaCode})");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void LoadSettings()
        {
            try
            {
                string[] userSelection = File.ReadAllLines(PATH);
                selectedLang = userSelection[0];
                selectedGender = userSelection[1];
                lblSelectGender.Text = selectedGender;
                lblSelectLang.Text = selectedLang;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void CheckSettings()
        {
            if (!File.Exists(PATH))
            {
                using (Form1 form1 = new Form1())
                {
                    form1.ShowDialog();

                    if (!File.Exists(PATH))
                    {
                        this.Close();
                    }
                }
            }
        }

        private void btnSelectTeam_Click(object sender, EventArgs e)
        {
            string? selectedTeam = cbTeams.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedTeam))
            {
                MessageBox.Show("Please select team!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            File.WriteAllText(TEAM_PATH, selectedTeam);

            puc.RefreshData();

        }

        private void changeSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(PATH);
            File.Delete(TEAM_PATH);
            Application.Restart();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit?",
                "Confirmation", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {                       
        }

       
    }
}
