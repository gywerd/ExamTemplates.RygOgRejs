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
        UIOpret UCOpret;
        UserControl uc;

        public DataViewJourneys(List<string> Entities, object b, UserControl UC)
        {
            InitializeComponent();
            CAB = (AppBizz)b;
            uc = UC;
            dataGridJourneys.ItemsSource = CAB.Destinations.ToList().Select(Destinations => new { Destinations });
            UCOpret = new UIOpret(CAB);
        }

        private void TextBoxFilterJourneys_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dataGridJourneys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = Convert.ToString(dataGridJourneys.SelectedItem);
            selectedItem = selectedItem.Remove(0, 17);
            if (selectedItem.Contains("}"))
            {
                selectedItem = selectedItem.Remove(selectedItem.Length - 2);
            }
            
            CAB.TempJourney.Destination = selectedItem;
            uc.Content = UCOpret;
        }
    }
}
