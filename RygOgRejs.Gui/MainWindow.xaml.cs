using RygOgRejs.Bizz.App;
using RygOgRejs.IO.DataAccess.App; //for testing if the connection string worked
using RygOgRejs.IO.WeatherService;
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
using System.Net.NetworkInformation;
using System.Xml;

//mac xDDDD

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
        AppBizz CAB = new AppBizz();
        DataViewJourneys ucJourneys;
        DataViewTransactions ucTransaction;
        JourneyEnquiries DataJourney = new JourneyEnquiries();
        List<string> Distanition = new List<string>();
        AppBizz CRB = new AppBizz();


        public MainWindow()
        {
            InitializeComponent();
            CRB.GetAllDestinations(); //Reads the destinations from the database into the list newDestination - Daniel 
            var DJ = DataJourney.GetAll();
            foreach (var Data in DJ)
            {
                Distanition.Add(Data.Destination);
            }
            userControlCentre.Content = ucJourneys = new DataViewJourneys(Distanition, CRB, userControlRight);
            ucTransaction = new DataViewTransactions(CRB, userControlRight);
            //macAddress = (from nic in NetworkInterface.GetAllNetworkInterfaces() where nic.OperationalStatus == OperationalStatus.Up select nic.GetPhysicalAddress().ToString()).FirstOrDefault();

            //maybe change this 
            weatherAPI = new WeatherAPI(labelStatusBar, CRB);
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
            //userControlRight.Content = null; jack stole FeelsBad
            CAB.JourneyOrTransaction = "journeys";
            userControlCentre.Content = ucJourneys;
        }

        private void ButtonTransactions_Click(object sender, RoutedEventArgs e)
        {
            //userControlRight.Content = null; jack stole FeelsBad
            CAB.JourneyOrTransaction = "transactions";
            userControlCentre.Content = ucTransaction;
        }

        private void MenuHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dette er et eksempel på løsning af S2 eksamensopgaven Ryg & Rejs, Bygget af Emil, Daniel Og Jack", "Om Ryg & Rejs", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}