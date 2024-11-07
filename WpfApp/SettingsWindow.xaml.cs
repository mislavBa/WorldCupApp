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
using System.IO;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        static string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\Data");
        string PATH = System.IO.Path.Combine(folderPath, "settings.txt");

        public SettingsWindow()
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

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            string[] settings = new string[3];

            ComboBoxItem? langItem = cbLang.SelectedItem as ComboBoxItem;
            ComboBoxItem? genderItem = cbGender.SelectedItem as ComboBoxItem;
            ComboBoxItem? resItem = cbResolution.SelectedItem as ComboBoxItem;

            string? lang = langItem?.Content as string;
            string? gender = genderItem?.Content as string;
            string? resolution = resItem?.Content as string;

            if(string.IsNullOrEmpty(lang) || string.IsNullOrEmpty(gender) 
                || string.IsNullOrEmpty(resolution))
            {
                MessageBox.Show("Please select all options!", "Error");
                return; 
            }

            settings[0] = lang;
            settings[1] = gender;
            settings[2] = resolution;

            File.WriteAllLines(PATH, settings);

            MessageBox.Show(System.IO.Path.GetFullPath(PATH), "Full Path");                       

            this.Close();
        }
    }
}
