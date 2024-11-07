using ClassLibrary.Match;
using System;
using System.Collections.Generic;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerDetails.xaml
    /// </summary>
    public partial class PlayerDetails : Window
    {
        public void LoadData(string playerName, List<StartingEleven> team)
        {
            string name = playerName;
            List<StartingEleven> newTeam = team;

            foreach (StartingEleven player in newTeam)
            {
                if (player.Name == name)
                {
                    tbName.Text = player.Name;
                    tbNumber.Text = player.ShirtNumber.ToString();
                    tbPosition.Text = player.Position.ToString();
                    tbCaptain.Text = player.Captain.ToString();
                }
            }
        }

        public PlayerDetails()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
