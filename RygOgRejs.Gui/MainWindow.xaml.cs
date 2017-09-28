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
using RygOgRejs.IO.WeatherService;
using System.Net.NetworkInformation; //mac xDDDD
using RygOgRejs.IO.DataAccess.App; //for testing if the connection string worked


namespace RygOgRejs.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        private UserControl currentUserControlCentre;
        private UserControl  currentUserControlRight;
        private WeatherAPI weatherAPI;
        private string macAddress;
        DataViewJourneys ucJourneys;
        JourneyEnquiries DataJourney = new JourneyEnquiries();
        List<string> Distanition = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            var DJ = DataJourney.GetAll();
            foreach (var Data in DJ)
            {
                 Distanition.Add(Data.Destionation);
            }
            userControlCentre.Content = ucJourneys = new DataViewJourneys(Distanition);
            macAddress = (from nic in NetworkInterface.GetAllNetworkInterfaces() where nic.OperationalStatus == OperationalStatus.Up select nic.GetPhysicalAddress().ToString()).FirstOrDefault();

            //maybe change this 
            weatherAPI = new WeatherAPI(labelStatusBar);
            weatherAPI.GetCityNameAsync();

        }

        private void OnMenuFilesClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Vil du afslutte Ryg & Rejs?", "Luk Ryg & Rejs", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void ButtonJourneys_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MenuHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dette er et eksempel på løsning af S2 eksamensopgaven Ryg & Rejs, Bygget af Emil, Daniel Og Jack", "Om Ryg & Rejs", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}