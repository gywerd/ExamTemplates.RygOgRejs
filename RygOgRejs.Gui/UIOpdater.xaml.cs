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
    /// Interaction logic for UIOpdater.xaml
    /// </summary>
    public partial class UIOpdater : UserControl
    {
        AppBizz Appbizz;
        public UIOpdater(AppBizz appbizz)
        {
            InitializeComponent();
            Appbizz = appbizz;
            var Bizz = Appbizz.TempJourney;
            labelDestination.Content = Bizz.Destination.ToString();
            textBoxAdults.Text = Bizz.Adults.ToString();
            textBoxChildren.Text = Bizz.Children.ToString();
            textBoxBagage.Text = Bizz.LuggageAmount.ToString();
            firstClassChecked.IsChecked = Bizz.IsFirstClass;
            textBoxFirstName.Text = Appbizz.TempPayer.FirstName;
            textBoxLastName.Text = Appbizz.TempPayer.LastName;
        }

        private void btnClickRet(object sender, RoutedEventArgs e)
        {

        }

        private void btnClickSlet(object sender, RoutedEventArgs e)
        {

        }
    }
}
