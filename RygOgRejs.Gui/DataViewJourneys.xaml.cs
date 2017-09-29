using RygOgRejs.Bizz;
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
using RygOgRejs.App.Bizz;
namespace RygOgRejs.Gui
{
    /// <summary>
    /// Interaction logic for DataViewJourneys.xaml
    /// </summary>
    public partial class DataViewJourneys: UserControl
    {
        UIInsertUpdate UCInsert;
        UserControl uc;
        private string destination;
        AppBizz CAB;

        public DataViewJourneys(List<string> Entities, object b, UserControl UC)
        {
            InitializeComponent();
            CAB = (AppBizz)b;
            uc = UC;
            UCInsert = new UIInsertUpdate(CAB);
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
            string selecctedItem =  Convert.ToString(dataGridJourneys.SelectedItem);
            CAB.Destination = selecctedItem;
            uc.Content = UCInsert;
        }
    }
}
