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
    /// Interaction logic for UIOpret.xaml
    /// </summary>
    public partial class UIOpret : UserControl
    {
        public UIOpret(AppBizz CAB)
        {
            InitializeComponent();
            labelDestination.Content = CAB.TempJourney.Destination;
        }

        private void btnClickOpretRejse(object sender, RoutedEventArgs e)
        {

        }
    }
}
