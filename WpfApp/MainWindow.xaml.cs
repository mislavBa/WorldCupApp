using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using ClassLibrary.Team;
using ClassLibrary;
using ClassLibrary.Match;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\Data");
        string PATH = System.IO.Path.Combine(folderPath, "settings.txt");
        string TEAM_PATH = System.IO.Path.Combine(folderPath, "favouriteTeam.txt");        
        
        string? selectedLang;
        string? selectedGender;
        string? selectedResolution;

        string? favorTeam;
        string? opposTeam;

        List<StartingEleven> startingElevenFav = new List<StartingEleven> { };
        List<StartingEleven> startingElevenOpp = new List<StartingEleven> { };
        

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                CheckSettings();
                LoadSettings();
                _ = AddTeamsAsync();
                CheckFavouriteTeam();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void CheckFavouriteTeam()
        {
            if(System.IO.Path.Exists(TEAM_PATH))
            {
                string? favouriteTeam = File.ReadAllText(TEAM_PATH);
                lblFavTeam.Content = $"Favourite Team: {favouriteTeam}";
                btnInfoFav.IsEnabled = true;
                btnInfoOpp.IsEnabled = false;
                btnSelectFav.IsEnabled = false;
                btnSelectOpp.IsEnabled = false;
                favorTeam = favouriteTeam;
                lbPlayersOpp.Items.Clear();
                lbPlayersFav.Items.Clear();
                LoadOppositeTeam(favouriteTeam);
            }
        }

        private async Task AddTeamsAsync()
        {
            if (selectedGender == "Men")
            {
                var responseData = await TeamDataFetcher.GetMenTeams();
                List<Team> menTeams = Deserializer.DeserializeData<List<Team>>(responseData);

                foreach (var team in menTeams)
                {
                    cbTeam.Items.Add($"{team.Country} ({team.FifaCode})");
                }


            }
            else if (selectedGender == "Women")
            {
                var responseData = await TeamDataFetcher.GetWomenTeams();
                List<Team> womenTeams = Deserializer.DeserializeData<List<Team>>(responseData);

                foreach (var team in womenTeams)
                {
                    cbTeam.Items.Add($"{team.Country} ({team.FifaCode})");
                }
            }
        }

        private void LoadSettings()
        {
            string[] settings = File.ReadAllLines(PATH);

            if (settings.Length == 3) 
            {
                selectedLang = settings[0];
                selectedGender = settings[1];
                selectedResolution = settings[2];
            }
            else
            {
                selectedLang = settings[0];
                selectedGender = settings[1];
                selectedResolution = "1280x720";
            }            

            SetResolution(selectedResolution);

            lblLang.Content = selectedLang;
            lblGender.Content = selectedGender;
            lblRes.Content = selectedResolution;
        }

        private void SetResolution(string res)
        {
            if (res == "FullScreen")
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                string[] dimensions = res.Split('x');
                if (dimensions.Length == 2)
                {
                    int width, height;
                    if (int.TryParse(dimensions[0], out width) &&
                        int.TryParse(dimensions[1], out height))
                    {
                        this.WindowState = WindowState.Normal;
                        this.Width = width;
                        this.Height = height;
                    }
                }
            }
        }

        private void CheckSettings()
        {
            if (!File.Exists(PATH))
            {
                SettingsWindow settingsWindow = new SettingsWindow();
                settingsWindow.ShowDialog();
                if(!File.Exists(PATH))
                {
                    this.Close();
                }
            }
        }

        private void SelectFavTeamButton_Click(object sender, RoutedEventArgs e)
        {
            string? favouriteTeam = cbTeam.SelectedItem?.ToString();
            if(string.IsNullOrEmpty(favouriteTeam) )
            {
                MessageBox.Show("Please Select Team!");
                return;
            }
            File.WriteAllText(TEAM_PATH, favouriteTeam);
            cbOppTeam.Items.Clear();
            lblOppTeam.Content = "Select Team";
            lblFavTeam.Content = $"Favourite Team: {favouriteTeam}";
            btnInfoFav.IsEnabled = true;
            btnInfoOpp.IsEnabled = false;
            btnSelectFav.IsEnabled = false;
            btnSelectOpp.IsEnabled = false;
            favorTeam = favouriteTeam;
            lbPlayersOpp.Items.Clear();
            lbPlayersFav.Items.Clear();
            LoadOppositeTeam(favouriteTeam);            
        }

        private async void LoadOppositeTeam(string favTeam)
        {
            cbOppTeam.IsEnabled = true;
            btnOppTeam.IsEnabled = true;

            string[] team = favTeam.Split(' ');
            string fifaCode = team.Last().Trim('(', ')');

            string teamName = "";

            if (team.Length == 2 )
            {
                teamName = team[0];
            }
            else if (team.Length == 3 )
            {
                teamName = team[0] + " " + team[1]; 
            }

            if(selectedGender == "Men")
            {
                var response = await MatchDataFetcher.GetMenMatchesCountry(fifaCode);
                List<Match> menMatch = Deserializer.DeserializeData<List<Match>>(response);

                foreach(var match in menMatch)
                {
                    if(match?.HomeTeamCountry== teamName)
                    {
                        cbOppTeam.Items.Add($"{match.AwayTeam?.Country} ({match.AwayTeam?.Code})");
                    }
                    else if (match?.AwayTeamCountry == teamName)
                    {
                        cbOppTeam.Items.Add($"{match.HomeTeam?.Country} ({match.HomeTeam?.Code})");
                    }
                   
                }
            }
            else if(selectedGender == "Women")
            {
                var response = await MatchDataFetcher.GetWomenMatchesCountry(fifaCode);
                List<Match> womenMatch = Deserializer.DeserializeData<List<Match>>(response);

                foreach (var match in womenMatch)
                {
                    if (match?.HomeTeamCountry == teamName)
                    {
                        cbOppTeam.Items.Add($"{match.AwayTeam?.Country} ({match.AwayTeam?.Code})");
                    }
                    else if (match?.AwayTeamCountry == teamName)
                    {
                        cbOppTeam.Items.Add($"{match.HomeTeam?.Country} ({match.HomeTeam?.Code})");
                    }

                }
            }
        }

        private async void SelectOppTeamButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            lbPlayersOpp.Items.Clear();
            lbPlayersFav.Items.Clear();
            opposTeam = cbOppTeam.SelectedItem?.ToString();

            if(string.IsNullOrEmpty(opposTeam))
            {
                MessageBox.Show("Please Select Team!");
                return;
            }

            string[] oTeam = opposTeam.Split(' ');
            string opTeam = "";
            if (oTeam.Length == 2)
            {
                opTeam = oTeam[0];
            }
            else if (oTeam.Length == 3)
            {
                opTeam = oTeam[0] + " " + oTeam[1];
            }

            string[] fTeam = favorTeam.Split(' ');
            string faTeam = "";
            if (fTeam.Length == 2)
            {
                faTeam = fTeam[0];
            }
            else if (fTeam.Length == 3)
            {
                faTeam = fTeam[0] + " " + fTeam[1];
            }


            if (string.IsNullOrEmpty(opposTeam))
            {
                MessageBox.Show("Please Select Team!");
                return;
            }

            if (selectedGender == "Men")
            {
                var response = await MatchDataFetcher.GetMenMatchesCountry(fTeam.Last().Trim('(',')'));
                List<Match> menMatch = Deserializer.DeserializeData<List<Match>>(response);

                foreach (var match in menMatch)
                {
                    if (match?.HomeTeamCountry == faTeam && 
                        match?.AwayTeamCountry == opTeam)
                    {
                        lblFavTeam.Content = $"Favourite team: {favorTeam} {match.HomeTeam.Goals}";
                        lblOppTeam.Content = $"Opposite Team: {opposTeam} {match.AwayTeam.Goals}";                     

                        foreach(var player in match.HomeTeamStatistics.StartingEleven)
                        {
                            lbPlayersFav.Items.Add(player.Name);
                            startingElevenFav.Add(player);
                        }
                        foreach(var player in match.AwayTeamStatistics.StartingEleven)
                        {
                            lbPlayersOpp.Items.Add(player.Name);
                            startingElevenOpp.Add(player);
                        }
                    }
                    else if (match?.AwayTeamCountry == faTeam &&
                        match?.HomeTeamCountry == opTeam)
                    {
                        lblFavTeam.Content = $"Favourite team: {favorTeam} {match.AwayTeam.Goals}";
                        lblOppTeam.Content = $"Opposite Team: {opposTeam} {match.HomeTeam.Goals}";


                        foreach (var player in match.HomeTeamStatistics.StartingEleven)
                        {
                            lbPlayersOpp.Items.Add(player.Name);
                            startingElevenOpp.Add(player);
                        }
                        foreach (var player in match.AwayTeamStatistics.StartingEleven)
                        {
                            lbPlayersFav.Items.Add(player.Name);
                            startingElevenFav.Add(player);
                        }
                    }
                   
                }
            }
            else if (selectedGender == "Women")
            {
                var response = await MatchDataFetcher.GetWomenMatchesCountry(fTeam.Last().Trim('(', ')'));
                List<Match> womenMatch = Deserializer.DeserializeData<List<Match>>(response);

                foreach (var match in womenMatch)
                {
                    if (match?.HomeTeamCountry == faTeam &&
                        match?.AwayTeamCountry == opTeam)
                    {
                        lblFavTeam.Content = $"Favourite team: {favorTeam} {match.HomeTeam.Goals}";
                        lblOppTeam.Content = $"Opposite Team: {opposTeam} {match.AwayTeam.Goals}";


                        foreach (var player in match.HomeTeamStatistics.StartingEleven)
                        {
                            lbPlayersFav.Items.Add(player.Name);
                            startingElevenFav.Add(player);
                        }
                        foreach (var player in match.AwayTeamStatistics.StartingEleven)
                        {
                            lbPlayersOpp.Items.Add(player.Name);
                            startingElevenOpp.Add(player);
                        }
                    }
                    else if (match?.AwayTeamCountry == faTeam &&
                        match?.HomeTeamCountry == opTeam)
                    {
                        lblFavTeam.Content = $"Favourite team: {favorTeam} {match.AwayTeam.Goals}";
                        lblOppTeam.Content = $"Opposite Team: {opposTeam} {match.HomeTeam.Goals}";


                        foreach (var player in match.HomeTeamStatistics.StartingEleven)
                        {
                            lbPlayersOpp.Items.Add(player.Name);
                            startingElevenOpp.Add(player);
                        }
                        foreach (var player in match.AwayTeamStatistics.StartingEleven)
                        {
                            lbPlayersFav.Items.Add(player.Name);
                            startingElevenFav.Add(player);
                        }
                    }

                }
            }

            btnInfoOpp.IsEnabled = true;
            btnSelectFav.IsEnabled = true;
            btnSelectOpp.IsEnabled = true;
        }

        private void FavInfoButtonClick(object sender, RoutedEventArgs e)
        {
            TeamDetails teamDetails = new TeamDetails();
            teamDetails.LoadData(favorTeam, selectedGender);
            teamDetails.ShowDialog();
        }    

        private void OppInfoButtonClick(object sender, RoutedEventArgs e)
        {
            TeamDetails teamDetails = new TeamDetails();
            teamDetails.LoadData(opposTeam, selectedGender);
            teamDetails.ShowDialog();
        }

        private void SelectFavPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (lbPlayersFav.SelectedItem is null)
            {
                MessageBox.Show("Select player");
                return;
            }
            string playerName = lbPlayersFav.SelectedItem.ToString();
            PlayerDetails playerDetails = new PlayerDetails();
            playerDetails.LoadData(playerName, startingElevenFav);
            playerDetails.ShowDialog();
        }

        private void SelectOppPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (lbPlayersOpp.SelectedItem is null)
            {
                MessageBox.Show("Select player");
                return;
            }
            string playerName = lbPlayersOpp.SelectedItem.ToString();
            PlayerDetails playerDetails = new PlayerDetails();
            playerDetails.LoadData(playerName, startingElevenOpp);
            playerDetails.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to quit?", 
                "Closing",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void ChangeSettings_Click(object sender, RoutedEventArgs e)
        {
            ChangeSettingsWindow changeSettingsWindow = new ChangeSettingsWindow();
            changeSettingsWindow.ShowDialog();
        }
    }
}