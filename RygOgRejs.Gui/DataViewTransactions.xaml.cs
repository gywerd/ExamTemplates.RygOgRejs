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
using RygOgRejs.Bizz.App;
namespace RygOgRejs.Gui
{
    /// <summary>
    /// Interaction logic for DataViewTransactions.xaml
    /// </summary>
    public partial class DataViewTransactions : UserControl
    {
        AppBizz CAB;
        UserControl uc;
        UIOpdater UiOpdater;
        public DataViewTransactions(object b, UserControl UC)
        {
            InitializeComponent();
            CAB = (AppBizz)b;
            uc = UC;
            dataGridTransaction.ItemsSource = CAB.Transactions;
        }

        private void TextBoxFilterTransactions_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGridTransaction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
