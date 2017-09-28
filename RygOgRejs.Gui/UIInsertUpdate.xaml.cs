using RygOgRejs.App.Bizz;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        AppBizz CAB;

        public UIInsertUpdate(AppBizz bizz)
        {
            InitializeComponent();
            InitializeContent(bizz);
        }

        #region Buttons
        private void ButtonCreateJourney_Click(object sender, RoutedEventArgs e)
        {
            CAB.CreateJourney();
        }

        private void ButtonDeleteJourney_Click(object sender, RoutedEventArgs e)
        {
            CAB.DeleteJourney();
        }

        private void ButtonEditJourney_Click(object sender, RoutedEventArgs e)
        {
            CAB.EditJourney();
        }
        #endregion

        #region Events
        private void CheckBoxFirstClass_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBoxFirstClass_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Methods
        private void InitializeContent(AppBizz bizz)
        {
            CAB = bizz;
            if (CAB.JourneyOrTransaction == "transaction")
            {
                buttonCreateJourney.Visibility = Visibility.Hidden;
                buttonEditJourney.Visibility = Visibility.Visible;
                buttonDeleteJourney.Visibility = Visibility.Visible;
            }
            else
        	{
                buttonCreateJourney.Visibility = Visibility.Visible;
                buttonEditJourney.Visibility = Visibility.Hidden;
                buttonDeleteJourney.Visibility = Visibility.Hidden;
                labelChosenDestination.Content = CAB.Journey.Destination;
            }
        }

        #endregion

        private void TextBoxAdults_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxChildren_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxLuggage_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxLastName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
