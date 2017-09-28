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
        RygOgRejsBizz CRB = new RygOgRejsBizz();

        #region Window
        public UIPayments(RygOgRejsBizz b)
        {
            InitializeComponent();
            CRB = (RygOgRejsBizz)b;
            InitializeContent();
        }
        #endregion

        #region Buttons
        private void ButtonExecutePayment_Click(object sender, RoutedEventArgs e)
        {
            CRB.ExecutePayment();
        }

        private void ButtonExecuteRefusion_Click(object sender, RoutedEventArgs e)
        {
            CRB.ExecuteRefusion();
        }
        #endregion

        #region Methods
        private void InitializeContent()
        {
            if (CRB.JourneyOrTransaction == "transaction")
            {
                labelReceivedAmount.Visibility = Visibility.Hidden;
                textReceivedAmountContent.Visibility = Visibility.Hidden;
                buttonExecutePayment.Visibility = Visibility.Visible;
                buttonExecuteRefusion.Visibility = Visibility.Visible;
            }
            else
            {
                textReceivedAmountContent.Visibility = Visibility.Visible;
                buttonExecutePayment.Visibility = Visibility.Hidden;
                buttonExecuteRefusion.Visibility = Visibility.Hidden;
            }
        }
        #endregion

    }
}
