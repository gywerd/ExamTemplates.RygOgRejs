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
using RygOgRejs.Bizz.Entities;
namespace RygOgRejs.Gui
{
    /// <summary>
    /// Interaction logic for DataViewTransactions.xaml
    /// </summary>
    public partial class DataViewTransactions : UserControl
    {
        AppBizz CAB;
        UserControl uc;
        UIOpdater UCOpdater;
        public DataViewTransactions(object appbizz, UserControl UC)
        {
            InitializeComponent();
            CAB = (AppBizz)appbizz;
            uc = UC;
            UCOpdater = new UIOpdater(CAB);
            dataGridTransaction.ItemsSource = CAB.Payers;
            DataGridTextColumn FirstName = new DataGridTextColumn()
            {
                Header = "Fornavn",
                Binding = new Binding("FirstName"),
            };
            DataGridTextColumn LastName = new DataGridTextColumn()
            {
                Header = "Efternavn",
                Binding = new Binding("LastName")
            };
            dataGridTransaction.Columns.Add(FirstName);
            dataGridTransaction.Columns.Add(LastName);

        }

        private void TextBoxFilterTransactions_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGridTransaction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Payer Payerid = new Payer();
            Payer Payerid = (Payer)dataGridTransaction.SelectedItem;
            CAB.TempPayer.PayerId = Payerid.PayerId;
            uc.Content = UCOpdater;

        }
    }
}
