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
            dataGridJourneys.ItemsSource = CAB.DestinationList.ToList().Select(Destinations => new { Destinations });
            
        }

        private void TextBoxFilterJourneys_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dataGridJourneys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridJourneys.SelectedItem != null) //this is weird
            {

                string selectedItem = Convert.ToString(dataGridJourneys.SelectedItem);
                selectedItem = selectedItem.Remove(0, 17);
                if (selectedItem.Contains("}"))
                {
                    selectedItem = selectedItem.Remove(selectedItem.Length - 2);
                }

                //CAB.TempJourney.Destination = selectedItem;
                //CAB.CreateMasterid();
                //CAB.TempJourney.MasterId = CAB.Master.Id;
                //CAB.TempPayer.MasterID = CAB.Master.Id;
                //CAB.TempTransaction.MasterId = CAB.Master.Id;
                uc.Content = UCOpret = new UIOpret(CAB, uc);
                dataGridJourneys.UnselectAll();
            }
        }
    }
}
