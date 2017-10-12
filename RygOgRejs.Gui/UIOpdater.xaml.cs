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
    /// Interaction logic for UIOpdater.xaml
    /// </summary>
    public partial class UIOpdater : UserControl
    {
        Transaction selecteditem;
        AppBizz Appbizz;
        public UIOpdater(AppBizz appbizz, DataGrid datagrid)
        {
            InitializeComponent();
            Appbizz = appbizz;
            this.selecteditem = (Transaction)datagrid.SelectedItem;
            Appbizz.LoadTransaction();
            var Bizz = Appbizz.TempTransaction;
            if (selecteditem != null)
            {
                labelDestination.Content = Bizz.DestinationName;
                textBoxAdults.Text = Bizz.Adults.ToString();
                textBoxChildren.Text = Bizz.Children.ToString();
                textBoxBagage.Text = Bizz.LuggageAmount.ToString();
                firstClassChecked.IsChecked = Bizz.IsFirstClass;
                textBoxFirstName.Text = Bizz.FirstName;
                textBoxLastName.Text = Bizz.LastName;
            }
        }

        private void btnClickRet(object sender, RoutedEventArgs e)
        {

        }

        private void btnClickSlet(object sender, RoutedEventArgs e)
        {
            Appbizz.DeleteJourney();
        }
    }
}
