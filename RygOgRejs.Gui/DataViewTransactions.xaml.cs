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

            dataGridTransaction.ItemsSource = CAB.Transactions;
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

        /// <summary>
        /// needs total revision as Master.Id, GiveMasterID and TempPayer is obsolete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridTransaction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CAB.TempTransaction = (Transaction)dataGridTransaction.SelectedItem;
            if (CAB.TempTransaction != null)
            { //payer
                CAB.UpdateTransactions(CAB.TempTransaction.TransactionId);
            }
            else
            {
                dataGridTransaction.ItemsSource = CAB.Transactions; //Changed from Payers
            }
            UCOpdater = new UIOpdater(CAB, dataGridTransaction);
            uc.Content = UCOpdater;

        }
    }
}
