//using StripsClientWPFReeksView.Model;
using StripsClientWPFReeksView.Model;
using StripsClientWPFReeksView.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StripsClientWPFReeksView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StripServiceClient stripService;
        private string path = "api/strips/beheer/reeks/";
        public MainWindow()
        {
            InitializeComponent();
            stripService = new StripServiceClient();
        }

        private async void GetReeksButton_Click(object sender, RoutedEventArgs e)
        {
            string id = ParseValue();

            string fullpath = $"{path}{id}";
            Reeks reeks = await stripService.GetReeksAsync(fullpath);

            if (reeks is not null)
            {
                NaamTextBox.Text = reeks.Name;
                AantalTextBox.Text = reeks.strips.Count.ToString();
                StripsDataGrid.ItemsSource = reeks.strips;
            }
            else
            {
                MessageBox.Show("could not retrieve data.");
            }


        }


        private string ParseValue()
        {
            string ID = ReeksIdTextBox.Text;

            if (string.IsNullOrWhiteSpace(ID) || !int.TryParse(ID, out _))
            {
                MessageBox.Show("Please provide a valid ID");
            }

            return ID;
        }



    }
}
