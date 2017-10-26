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

        public DataViewJourneys(List<string> Entities, object b, UserControl UC, UIOpret uIOpret)
        {
            InitializeComponent();
            CAB = (AppBizz)b;
            uc = UC;
            UCOpret = uIOpret;
            List<string> locations = new List<string>();
            foreach (var dist in CAB.DestinationList)
            {
                locations.Add(dist.DestinationName);
            }
            dataGridJourneys.ItemsSource = locations.Select(Destination => new {Destination });
            
        }
        private void TextBoxFilterJourneys_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dataGridJourneys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (dataGridJourneys.SelectedItem != null)
            {
                CAB.TempTransaction.IsFirstClass = false;
                CAB.TempTransaction.Adults = 0;
                CAB.TempTransaction.Children = 0;
                CAB.TempTransaction.LuggageAmount = 0;
                CAB.TempTransaction.FirstName = "";
                CAB.TempTransaction.LastName = "";
                string selectedItem = Convert.ToString(dataGridJourneys.SelectedItem);
                selectedItem = selectedItem.Remove(0, 16);
                if (selectedItem.Contains("}"))
                {
                    selectedItem = selectedItem.Remove(selectedItem.Length - 2);
                }
                CAB.TempTransaction.DestinationName = selectedItem;
                uc.Content = UCOpret = new UIOpret(CAB, uc);
                dataGridJourneys.UnselectAll();
            }
        }
    }
}
