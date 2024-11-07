using ClassLibrary;
using ClassLibrary.Match;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Data;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for TeamDetails.xaml
    /// </summary>
    public partial class TeamDetails : Window
    {       


        public TeamDetails()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); }
        }

  

        public async void LoadData(string team, string gender)
        {
            string teamName = "";
            string[] strings = team.Split(' ');
            string fifaCode = strings.Last().Trim('(', ')');

            int played = 0, won = 0, draw = 0, lost = 0;
            

            if(strings.Length == 2 )
            {
                teamName = strings[0];
            }
            else if(strings.Length == 3 )
            {
                teamName = strings[0] + " " + strings[1];
            }

            tbName.Text = teamName;
            tbCode.Text = fifaCode;

            if (gender == "Men")
            {
                var response = await MatchDataFetcher.GetMenMatchesCountry(fifaCode);
                List<Match> menMatch = Deserializer.DeserializeData<List<Match>>(response);

                foreach(var match in menMatch)
                {
                    if (match.HomeTeamCountry == teamName && match.Winner == teamName)
                    {
                        played += 1;
                        won += 1;
                    }
                    else if (match.AwayTeamCountry == teamName && match.Winner == teamName)
                    {
                        played += 1;
                        won += 1;
                    }
                    else if (match.Winner == "Draw")
                    {
                        played += 1;
                        draw += 1;
                    }
                    else
                    {
                        played += 1;
                        lost += 1;
                    }
                }

            }
            else if(gender == "Women")
            {
                var response = await MatchDataFetcher.GetWomenMatchesCountry(fifaCode);
                List<Match> womenMatch = Deserializer.DeserializeData<List<Match>>(response);

                foreach (var match in womenMatch)
                {
                    if (match.HomeTeamCountry == teamName && match.Winner == teamName)
                    {
                        played += 1;
                        won += 1;
                    }
                    else if (match.AwayTeamCountry == teamName && match.Winner == teamName)
                    {
                        played += 1;
                        won += 1;
                    }
                    else if (match.Winner == "Draw")
                    {
                        played += 1;
                        draw += 1;
                    }
                    else
                    {
                        played += 1;
                        lost += 1;
                    }
                }
            }
            lvMatch.Items.Add(new MatchStats
            {
                Played = played,
                Won = won,
                Draw = draw,
                Lost = lost,
            });
           
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
