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
            Appbizz.EditJourney();
        }

        private void btnClickSlet(object sender, RoutedEventArgs e)
        {
            Appbizz.DeleteJourney();
        }

        private void IsFirstClassChanged(object sender, RoutedEventArgs e)
        {
            if (firstClassChecked.IsChecked != Appbizz.TempTransaction.IsFirstClass)
            {
                if (firstClassChecked.IsChecked == true)
                {
                    Appbizz.TempTransaction.IsFirstClass = true;
                }
                else
                {
                    Appbizz.TempTransaction.IsFirstClass = false;
                }
            }
        }

        private void AdultsChanged(object sender, TextChangedEventArgs e)
        {
                if (!string.IsNullOrEmpty(textBoxAdults.Text))
                {
                    bool gyldig = false;
                    foreach (char c in textBoxAdults.Text)
                    {
                        if (!char.IsDigit(c))
                        {
                            gyldig = false;
                            textBoxAdults.BorderBrush = Brushes.Red;
                            textBoxAdults.BorderThickness = new Thickness(2);
                            MessageBox.Show("må ikke indeholde bogstaver eller tegn");
                            textBoxAdults.Text = textBoxAdults.Text.Remove(textBoxAdults.Text.Length - 1);
                            textBoxAdults.CaretIndex = textBoxAdults.Text.Length; //amazing
                        }
                        else
                        {
                            gyldig = true;
                            textBoxAdults.BorderBrush = Brushes.Transparent;
                            textBoxAdults.BorderThickness = new Thickness(1);
                        }

                    }
                    if (gyldig == true)
                    {
                    int Adults = Convert.ToInt32(textBoxAdults.Text);
                        if (Adults != Appbizz.TempTransaction.Adults)
                        {
                            textBoxAdults.BorderBrush = Brushes.Green;
                            textBoxAdults.BorderThickness = new Thickness(2);
                            Appbizz.TempTransaction.Adults = Adults;
                        }
                    }
                }
                else
                {
                    textBoxAdults.BorderBrush = Brushes.Red;
                    textBoxAdults.BorderThickness = new Thickness(2);
                }
        }

        private void ChildrenChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void LuggageChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
