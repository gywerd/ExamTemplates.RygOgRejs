using RygOgRejs.Bizz.App;
using RygOgRejs.Bizz.Entities;
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

namespace RygOgRejs.Gui
{
    /// <summary>
    /// Interaction logic for DataViewJourneys.xaml
    /// </summary>
    public partial class DataViewJourneys: UserControl
    {
        AppBizz CAB;
        UIInsertUpdate UCInsert;
        UserControl uc;
        private string destination;

        public DataViewJourneys(List<string> Entities, object b, UserControl UC)
        {
            InitializeComponent();
            CAB = (AppBizz)b;
            uc = UC;
            //UCInsert = new UIInsertUpdate(CAB); //Moved to dataGridJourneys_SelectionChanged - works partially now
            //foreach(string dest in Entities)
            //{
            //    dataGridJourneys.Items.Add(dest.ToString());
            //}
            dataGridJourneys.ItemsSource = CAB.Destinations.ToList().Select(Destinations => new { Destinations });
            //dataGridJourneys.ItemsSource = CAB.Destinations;
        }

        private void TextBoxFilterJourneys_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        // Bitch Please.....
        private void dataGridJourneys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem =  Convert.ToString(dataGridJourneys.SelectedItem);
            //CAB.Destination = selecctedItem;
            CAB.TempJourney.Destination = selectedItem; //corrected reference
            UCInsert = new UIInsertUpdate(CAB);
            uc.Content = UCInsert;
        }
    }
}
