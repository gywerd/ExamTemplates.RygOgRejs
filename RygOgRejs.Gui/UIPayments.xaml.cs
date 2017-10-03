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
    /// Interaction logic for UIPayments.xaml
    /// UserControl is redundant, and can be removed
    /// </summary>
    public partial class UIPayments : UserControl
    {
        AppBizz CAB = new AppBizz();

        #region Window
        public UIPayments(AppBizz b)
        {
            InitializeComponent();
            CAB = (AppBizz)b;
            InitializeContent();
        }
        #endregion

        #region Buttons
        private void ButtonExecutePayment_Click(object sender, RoutedEventArgs e)
        {
            CAB.ExecutePayment();
        }

        private void ButtonExecuteRefusion_Click(object sender, RoutedEventArgs e)
        {
            CAB.ExecuteRefusion();
        }
        #endregion

        #region Methods
        private void InitializeContent()
        {
            if (CAB.JourneyOrTransaction == "transaction")
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
