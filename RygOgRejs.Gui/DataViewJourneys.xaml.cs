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
            dataGridJourneys.ItemsSource = CAB.Destinations.ToList().Select(Destinations => new { Destinations });
        }

        private void TextBoxFilterJourneys_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        // Bitch Please kage
        private void dataGridJourneys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = Convert.ToString(dataGridJourneys.SelectedItem);
            //"{ Destinations = EKBI - BILLUND, Denmark }"
            selectedItem = selectedItem.Remove(0, 18);
            if (selectedItem.Contains("}"))
            {
                selectedItem = selectedItem.Remove(selectedItem.Length - 2);
            }
            
            CAB.TempJourney.Destination = selectedItem;

            UCInsert = new UIInsertUpdate(CAB);
            uc.Content = UCInsert;
        }
    }
}
