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
        public DataViewJourneys(List<string> Entities)
        {
            InitializeComponent();

            foreach(var item in Entities)
            {
                dataGridJourneys.Items.Add(item.ToString());
            }
           // dataGridJourneys.ItemsSource = Entities.GetRange(0,0);
        }

        private void TextBoxFilterJourneys_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
