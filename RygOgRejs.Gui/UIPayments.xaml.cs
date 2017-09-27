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
    /// Interaction logic for UIPayments.xaml
    /// </summary>
    public partial class UIPayments : UserControl
    {
        private Journey journey = new Journey();
        private Payer payer = new Payer();
        RygOgRejsBizz CRB = new RygOgRejsBizz();

        #region Window
        public UIPayments(string payref, Journey jour, Payer pay)
        {
            InitializeComponent();
            InitializeContent(payref);
        }
        #endregion

        #region Buttons
        private void ButtonExecutePayment_Click(object sender, RoutedEventArgs e)
        {
            CRB.ExecutePayment();
        }

        private void ButtonExecuteRefusion_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Methods
        private void InitializeContent(string payref)
        {
            if (payref == "trans")
            {
                textReceivedAmountContent.IsEnabled = false;
                buttonExecutePayment.IsEnabled = false;
                buttonExecuteRefusion.IsEnabled = true;
            }
            else
            {
                textReceivedAmountContent.IsEnabled = false;
                buttonExecutePayment.IsEnabled = false;
                buttonExecuteRefusion.IsEnabled = true;
            }
        }
        #endregion

    }
}
