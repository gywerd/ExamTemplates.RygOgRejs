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
    /// Interaction logic for UIInsertUpdate.xaml
    /// </summary>
    public partial class UIInsertUpdate : UserControl
    {
        private Payer payer;
        private Journey journey;
        Journey CJR = new Journey();

        public UIInsertUpdate(string dest)
        {
            InitializeComponent();
            journey.Destionation = dest;
            labelChosenDestination.Content = dest;
        }

        private void ButtonCreateJourney_Click(object sender, RoutedEventArgs e)
        {
            journey.IsFirstClass = Convert.ToBoolean(checkBoxFirstClass.IsChecked);
            journey.Adults = Convert.ToInt32(textBoxAdults.Text);
            journey.Children = Convert.ToInt32(textBoxChildren.Text);
            journey.LuggaAmount = Convert.ToInt32(textBoxLuggage.Text);
            journey.DepaturTime = DateTime.Now;
            payer.FirstName = textBoxFirstName.Text;
            payer.LastName = textBoxLastName.Text;
            CJR.CreateJourney(journey, payer);
        }
    }
}
