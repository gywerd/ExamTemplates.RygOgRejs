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

namespace RygOgRejs.Gui
{
    /// <summary>
    /// Interaction logic for DataViewJourneys.xaml
    /// </summary>
    public partial class DataViewJourneys: UserControl
    {
        private string destination;
        RygOgRejsBizz CRB;

        public DataViewJourneys(List<string> Entities, object b)
        {
            InitializeComponent();
            CRB = (RygOgRejsBizz)b;
            //foreach(string dest in Entities)
            //{
            //    dataGridJourneys.Items.Add(dest.ToString());
            //}
            dataGridJourneys.ItemsSource = CRB.Destinations;
        }

        private void TextBoxFilterJourneys_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dataGridJourneys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            CRB.Destination = (string)dg.SelectedItem;
        }
    }
}
