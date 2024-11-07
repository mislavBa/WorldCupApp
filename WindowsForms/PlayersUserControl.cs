using ClassLibrary;
using ClassLibrary.Match;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PlayersUserControl : UserControl
    {
        static string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\Data");
        string PATH = Path.Combine(folderPath, "settings.txt");
        string TEAM_PATH = Path.Combine(folderPath, "favouriteTeam.txt");
        string STOCK_IMG_PATH = Path.Combine(folderPath, "football-player.png");
        string PLAYERS_PATH = Path.Combine(folderPath, "favouritePlayers.txt");

        string selectedGender;
        string favouriteTeam;
        string selectedLang;

        private const string HR = "hr";
        private const string EN = "en";

        List<GoalsCards> goalsCards = new List<GoalsCards>();

        public void RefreshData()
        {
            LoadTeam();
        }

        public PlayersUserControl()
        {
            try
            {
                InitializeComponent();
                SetEvents();
                LoadTeam();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK); }
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

        private void SetEvents()
        {
            lbAllPlayers.MouseDown += new MouseEventHandler(lbAllPlayers_MouseDown);
            lbFavPlayers.MouseDown += new MouseEventHandler(lbFavPlayers_MouseDown);
            lbAllPlayers.DragEnter += new DragEventHandler(lb_DragEnter);
            lbFavPlayers.DragEnter += new DragEventHandler(lb_DragEnter);
            lbAllPlayers.DragDrop += new DragEventHandler(lb_DragDrop);
            lbFavPlayers.DragDrop += new DragEventHandler(lb_DragDrop);
            this.ContextMenuStrip = contextMenuStrip;
        }

        private void LbAllPlayers_DragDrop(object? sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void LoadTeam()
        {
            lvPlayer.Items.Clear();
            lvLocation.Items.Clear();

            lbAllPlayers.Items.Clear();
            lbFavPlayers.Items.Clear();
            lblPlayer.Text = "Player Name";
            btnAddImg.Enabled = false;
            goalsCards.Clear();

            if (pbPlayer.Image != null)
            {
                pbPlayer.Image.Dispose();
                pbPlayer.Image = null;
            }

            if (File.Exists(TEAM_PATH))
            {
                string[] settings = File.ReadAllLines(PATH);
                selectedLang = settings[0];
                selectedGender = settings[1];
                string[] teamSelection = File.ReadAllLines(TEAM_PATH);
                string[] team = teamSelection[0].Split(' ');

                favouriteTeam = team.Last().Trim('(', ')');

                if (selectedGender == "Men")
                {
                    var responseData = await MatchDataFetcher.GetMenMatches();
                    List<Match> matches = Deserializer.DeserializeData<List<Match>>(responseData);

                    //Dodavanje igrača
                    foreach (var match in matches)
                    {
                        if (match.HomeTeam.Code == favouriteTeam)
                        {
                            var allPLayers = match.HomeTeamStatistics.StartingEleven
                                .Union(match.HomeTeamStatistics.Substitutes);

                            foreach (var player in allPLayers)
                            {
                                lbAllPlayers.Items.Add($"{player.Name} | {player.ShirtNumber} | {player.Position} | {player.Captain}\n");
                            }
                            break;
                        }
                    }

                    //Dodavanje golova i kartona
                    foreach (var match in matches)
                    {
                        //HOME TEAM
                        if (match.HomeTeam.Code == favouriteTeam)
                        {
                            foreach (var e in match.HomeTeamEvents)
                            {
                                GoalsCards? player = goalsCards.FirstOrDefault(x => x.Name == e.Player, null);

                                if (e.TypeOfEvent == "goal" && player is null)
                                {
                                    GoalsCards playerGoal = new GoalsCards();
                                    playerGoal.Name = e.Player;
                                    playerGoal.Goals = 1;
                                    goalsCards.Add(playerGoal);
                                }
                                else if (e.TypeOfEvent == "goal" && goalsCards.Contains(player))
                                {
                                    player.Goals += 1;
                                }
                                else if (e.TypeOfEvent == "yellow-card" && player is null)
                                {
                                    GoalsCards playerC = new GoalsCards();
                                    playerC.Name = e.Player;
                                    playerC.YellowCards = 1;
                                    goalsCards.Add(playerC);
                                }
                                else if (e.TypeOfEvent == "yellow-card" && player is not null)
                                {
                                    player.YellowCards += 1;
                                }
                            }


                        }
                        //AWAY TEAM
                        else if (match.AwayTeam.Code == favouriteTeam)
                        {
                            foreach (var e in match.AwayTeamEvents)
                            {
                                GoalsCards? player = goalsCards.FirstOrDefault(x => x.Name == e.Player, null);

                                if (e.TypeOfEvent == "goal" && player is null)
                                {
                                    GoalsCards playerGoal = new GoalsCards();
                                    playerGoal.Name = e.Player;
                                    playerGoal.Goals = 1;
                                    goalsCards.Add(playerGoal);
                                }
                                else if (e.TypeOfEvent == "goal" && goalsCards.Contains(player))
                                {
                                    player.Goals += 1;
                                }
                                else if (e.TypeOfEvent == "yellow-card" && player is null)
                                {
                                    GoalsCards playerC = new GoalsCards();
                                    playerC.Name = e.Player;
                                    playerC.YellowCards = 1;
                                    goalsCards.Add(playerC);
                                }
                                else if (e.TypeOfEvent == "yellow-card" && player is not null)
                                {
                                    player.YellowCards += 1;
                                }
                            }
                        }
                    }

                    foreach (var item in goalsCards)
                    {
                        ListViewItem listViewItem = new ListViewItem(item.Name);
                        listViewItem.SubItems.Add(item.Goals.ToString());
                        listViewItem.SubItems.Add(item.YellowCards.ToString());
                        lvPlayer.Items.Add(listViewItem);
                    }

                    //DODAVANJE LOKACIJE

                    foreach (var match in matches)
                    {
                        if (match.HomeTeam.Code == favouriteTeam || match.AwayTeam.Code == favouriteTeam)
                        {
                            ListViewItem item = new ListViewItem(match.Location);
                            item.SubItems.Add(match.Attendance.ToString());
                            item.SubItems.Add(match.HomeTeamCountry.ToString());
                            item.SubItems.Add(match.AwayTeamCountry.ToString());
                            lvLocation.Items.Add(item);
                        }
                    }
                }
                else if (selectedGender == "Women")
                {
                    var responseData = await MatchDataFetcher.GetWomenMatches();
                    List<Match> matches = Deserializer.DeserializeData<List<Match>>(responseData);

                    //Dodavanje Igrača
                    foreach (var match in matches)
                    {
                        if (match.HomeTeam?.Code == favouriteTeam)
                        {
                            var allPlayers = match.HomeTeamStatistics.StartingEleven
                                .Union(match.HomeTeamStatistics.Substitutes);

                            foreach (var player in allPlayers)
                            {
                                lbAllPlayers.Items.Add($"{player.Name} | {player.ShirtNumber} | {player.Position} | {player.Captain}\n");
                            }
                            break;
                        }

                    }

                    //Dodavanje statistika golovi i kartoni
                    foreach (var match in matches)
                    {
                        //HOME TEAM
                        if (match.HomeTeam.Code == favouriteTeam)
                        {
                            foreach (var e in match.HomeTeamEvents)
                            {
                                GoalsCards? player = goalsCards.FirstOrDefault(x => x.Name == e.Player, null);

                                if (e.TypeOfEvent == "goal" && player is null)
                                {
                                    GoalsCards playerGoal = new GoalsCards();
                                    playerGoal.Name = e.Player;
                                    playerGoal.Goals = 1;
                                    goalsCards.Add(playerGoal);
                                }
                                else if (e.TypeOfEvent == "goal" && goalsCards.Contains(player))
                                {
                                    player.Goals += 1;
                                }
                                else if (e.TypeOfEvent == "yellow-card" && player is null)
                                {
                                    GoalsCards playerC = new GoalsCards();
                                    playerC.Name = e.Player;
                                    playerC.YellowCards = 1;
                                    goalsCards.Add(playerC);
                                }
                                else if (e.TypeOfEvent == "yellow-card" && player is not null)
                                {
                                    player.YellowCards += 1;
                                }
                            }
                        }
                        //AWAY TEAM
                        else if (match.AwayTeam.Code == favouriteTeam)
                        {
                            foreach (var e in match.AwayTeamEvents)
                            {
                                GoalsCards? player = goalsCards.FirstOrDefault(x => x.Name == e.Player, null);

                                if (e.TypeOfEvent == "goal" && player is null)
                                {
                                    GoalsCards playerGoal = new GoalsCards();
                                    playerGoal.Name = e.Player;
                                    playerGoal.Goals = 1;
                                    goalsCards.Add(playerGoal);
                                }
                                else if (e.TypeOfEvent == "goal" && goalsCards.Contains(player))
                                {
                                    player.Goals += 1;
                                }
                                else if (e.TypeOfEvent == "yellow-card" && player is null)
                                {
                                    GoalsCards playerC = new GoalsCards();
                                    playerC.Name = e.Player;
                                    playerC.YellowCards = 1;
                                    goalsCards.Add(playerC);
                                }
                                else if (e.TypeOfEvent == "yellow-card" && player is not null)
                                {
                                    player.YellowCards += 1;
                                }
                            }
                        }
                    }

                    foreach (var item in goalsCards)
                    {
                        ListViewItem listViewItem = new ListViewItem(item.Name);
                        listViewItem.SubItems.Add(item.Goals.ToString());
                        listViewItem.SubItems.Add(item.YellowCards.ToString());
                        lvPlayer.Items.Add(listViewItem);
                    }

                    //DODAVANJE LOKACIJA
                    foreach (var match in matches)
                    {
                        if (match.HomeTeam.Code == favouriteTeam || match.AwayTeam.Code == favouriteTeam)
                        {
                            ListViewItem item = new ListViewItem(match.Location);
                            item.SubItems.Add(match.Attendance.ToString());
                            item.SubItems.Add(match.HomeTeamCountry.ToString());
                            item.SubItems.Add(match.AwayTeamCountry.ToString());
                            lvLocation.Items.Add(item);
                        }
                    }
                }
            }
            else
            {
                lbAllPlayers.Text = "No team selected";
                
            }
        }

        private void btnMoveToFavourite_Click(object sender, EventArgs e)
        {
            object? selectedPlayer = lbAllPlayers.SelectedItem;
            if (selectedPlayer != null)
            {
                if (!lbFavPlayers.Items.Contains(selectedPlayer))
                {
                    lbFavPlayers.Items.Add(selectedPlayer);
                    lbAllPlayers.Items.Remove(selectedPlayer);
                }
                else
                {
                    MessageBox.Show("That player is already in Favourites list");
                }

            }

        }

        private void btnMoveToAll_Click(object sender, EventArgs e)
        {
            object? selectedPlayer = lbFavPlayers.SelectedItem;
            if (selectedPlayer != null)
            {
                if (!lbAllPlayers.Items.Contains(selectedPlayer))
                {
                    lbAllPlayers.Items.Add(selectedPlayer);
                    lbFavPlayers.Items.Remove(selectedPlayer);
                }
                else
                {
                    MessageBox.Show("That player is already in All players list");
                }
            }
        }

        private void lbAllPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbAllPlayers.SelectedItem is null)
            {
                return;
            }
            lbAllPlayers.DoDragDrop(lbAllPlayers.SelectedItem, DragDropEffects.Move);
        }

        private void lb_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lb_DragDrop(object sender, DragEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            string player = (string)e.Data.GetData(typeof(string));

            if (!lb.Items.Contains(player))
            {
                lb.Items.Add(player);

                if (lb == lbFavPlayers)
                {
                    lbAllPlayers.Items.Remove(player);
                }
                else
                {
                    lbFavPlayers.Items.Remove(player);
                }
            }
            else
            {
                return;
            }
        }

        private void lbFavPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbFavPlayers.SelectedItem is null)
            {
                return;
            }
            lbAllPlayers.DoDragDrop(lbFavPlayers.SelectedItem, DragDropEffects.Move);
        }

        private void btnSelectPLayer_Click(object sender, EventArgs e)
        {
            object? select1 = lbAllPlayers.SelectedItem;
            object? select2 = lbFavPlayers.SelectedItem;

            if (select1 != null && select2 == null)
            {
                lblPlayer.Text = select1.ToString();

                string name = lblPlayer.Text.Split('|')[0]; ;
                string path = Path.Combine(folderPath, name + ".png");
                if (File.Exists(path))
                {
                    pbPlayer.Image = Image.FromFile(path);
                    return;
                }
                ShowStockPicture();
                btnAddImg.Enabled = true;
            }
            else if (select1 == null && select2 != null)
            {
                lblPlayer.Text = select2.ToString();

                string name = lblPlayer.Text.Split('|')[0]; ;
                string path = Path.Combine(folderPath, name + ".png");
                if (File.Exists(path))
                {
                    pbPlayer.Image = Image.FromFile(path);
                    return;
                }
                ShowStockPicture();
                btnAddImg.Enabled = true;
            }
            else if (select1 != null && select2 != null)
            {
                lblPlayer.Text = select1.ToString();

                string name = lblPlayer.Text.Split('|')[0]; ;
                string path = Path.Combine(folderPath, name + ".png");
                if (File.Exists(path))
                {
                    pbPlayer.Image = Image.FromFile(path);
                    return;
                }
                ShowStockPicture();
                btnAddImg.Enabled = true;
            }
            else
            {
                MessageBox.Show("No player selected!");
            }

            lbAllPlayers.ClearSelected();
            lbFavPlayers.ClearSelected();
        }

        private void ShowStockPicture()
        {
            pbPlayer.Image = Image.FromFile(STOCK_IMG_PATH);
        }

        private void btnAddImg_Click(object sender, EventArgs e)
        {
            LoadPicture();
        }

        private void LoadPicture()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pictures|*.bmp;*.jpg;*.jpeg;*.png;|All files|*.*";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string playerTxt = lblPlayer.Text.Split('|')[0];
                string destinationFilePath = Path.Combine(folderPath, playerTxt + ".png");
                File.Copy(ofd.FileName, destinationFilePath, true);
                pbPlayer.Image = Image.FromFile(destinationFilePath);
            }
        }

        private void movePlayerToFavouritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object? selectedPlayer = lbAllPlayers.SelectedItem;
            if (selectedPlayer != null)
            {
                if (!lbFavPlayers.Items.Contains(selectedPlayer))
                {
                    lbFavPlayers.Items.Add(selectedPlayer);
                    lbAllPlayers.Items.Remove(selectedPlayer);
                }
                else
                {
                    MessageBox.Show("That player is already in Favourites list");
                }

            }
        }

        private void movePlayerToAllPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object? selectedPlayer = lbFavPlayers.SelectedItem;
            if (selectedPlayer != null)
            {
                if (!lbAllPlayers.Items.Contains(selectedPlayer))
                {
                    lbAllPlayers.Items.Add(selectedPlayer);
                    lbFavPlayers.Items.Remove(selectedPlayer);
                }
                else
                {
                    MessageBox.Show("That player is already in All players list");
                }
            }
        }

        private void saveFavouritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbFavPlayers.Items.Count > 0)
            {
                using (StreamWriter writer = new StreamWriter(PLAYERS_PATH))
                {
                    foreach (var item in lbFavPlayers.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
                MessageBox.Show("Saved to " + PLAYERS_PATH);

            }
            else
            {
                MessageBox.Show("Nothing to save");
            }
        }

        private void printPlayerStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog(this.lvPlayer);
        }

        private void printMatchStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog(this.lvLocation);
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(lvPlayer.Width, lvPlayer.Height);

            lvPlayer.DrawToBitmap(bmp, new Rectangle
            {
                X = 0,
                Y = 0,
                Width = lvPlayer.Width,
                Height = lvPlayer.Height
            });

            e.Graphics?.DrawImage(bmp, e.MarginBounds.X, e.MarginBounds.Y);
        }

        private void PlayersUserControl_Load(object sender, EventArgs e)
        {
            
        }



        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }



        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }


        private void lbAllPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbAllPlayers_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbAllPlayers_MouseClick(object sender, MouseEventArgs e)
        {

        }

    }
}
