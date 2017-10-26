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
        bool LugageOK = false;
        bool AdultsOK = false;
        bool ChildrenOK = false;
        bool isFirstClassOK;
        public UIOpdater(AppBizz appbizz, DataGrid datagrid)
        {
            InitializeComponent();
            Appbizz = appbizz;
            this.selecteditem = (Transaction)datagrid.SelectedItem;
            var Bizz = Appbizz.TempTransaction;
            
            if (selecteditem == null)
            {
                Appbizz.GetUpdate();
            }
            else
            {
                this.isFirstClassOK = Appbizz.TempTransaction.IsFirstClass;
                labelDestination.Content = Bizz.DestinationName;
                textBoxAdults.Text = Bizz.Adults.ToString();
                textBoxChildren.Text = Bizz.Children.ToString();
                textBoxBagage.Text = Bizz.LuggageAmount.ToString();
                firstClassChecked.IsChecked = Bizz.IsFirstClass;
                textBoxFirstName.Text = Bizz.FirstName;
                textBoxLastName.Text = Bizz.LastName;
                textBoxIndbetalt.Text = Bizz.AmountInclVat.ToString("N2");

                //for now change later
                Appbizz.TempPriceDetails.CalculateAmounts(Appbizz.TempTransaction, Appbizz.Transactions, Appbizz.Destinations); //data moved to updated tempPriceDetails
                textBoxTotalPris.Text = Appbizz.TempPriceDetails.AmountInclVat.ToString();
                textBoxPrisUdenMoms.Text = Appbizz.TempPriceDetails.AmountExclVat.ToString();
                textBoxPrisForMoms.Text = Appbizz.TempPriceDetails.VatOfAmount.ToString();
            }
        }

        private void btnClickRet(object sender, RoutedEventArgs e)
        {
            if (Appbizz.TempTransaction != null)
            {
                if (isFirstClassOK == true)
                {
                    Appbizz.TempTransaction.IsFirstClass = true;
                }
                if (isFirstClassOK == false)
                {
                    Appbizz.TempTransaction.IsFirstClass = false;
                }
                if (ChildrenOK == true)
                {
                    Appbizz.TempTransaction.Children = Convert.ToInt32(textBoxChildren.Text);
                }
                if (AdultsOK == true)
                {
                    Appbizz.TempTransaction.Adults = Convert.ToInt32(textBoxAdults.Text);
                }
                if (LugageOK == true)
                {
                    Appbizz.TempTransaction.LuggageAmount = Convert.ToInt32(textBoxBagage.Text);
                }

            }
            else
            {
                MessageBox.Show("GetGud");
            }
            try
            {
                Appbizz.EditJourney();
                MessageBox.Show("Rejsen blev opdateret.");
                if (Convert.ToDecimal(textBoxRetur.Text) > 0)
                {
                    MessageBox.Show($"Rejsen blev opdateret.\nKunder skal have {textBoxRetur.Text} tilbage ");
                }
                if (Convert.ToDecimal(textBoxRetur.Text) < 0)
                {
                    MessageBox.Show($"Rejsen blev opdateret.\nKunden Skal betale {textBoxRetur.Text} mere");
                }
                else
                {
                    MessageBox.Show("Rejsen blev opdateret.\nDet går lige op");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnClickSlet(object sender, RoutedEventArgs e)
        {
            Appbizz.DeleteJourney();
            Appbizz.GetUpdate();
        }

        private void IsFirstClassChanged(object sender, RoutedEventArgs e)
        {
            if (firstClassChecked.IsChecked != Appbizz.TempTransaction.IsFirstClass)
            {
                if (firstClassChecked.IsChecked == true)
                {
                    isFirstClassOK = true;
                }
                else
                {
                    isFirstClassOK = false;
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
                        textBoxAdults.BorderBrush = Brushes.Gray;
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
                        AdultsOK = true;
                        Appbizz.TempTransaction.Adults = Adults;
                        Appbizz.TempPriceDetails.CalculateAmounts(Appbizz.TempTransaction, Appbizz.Transactions, Appbizz.Destinations); //data moved to updated tempPriceDetails
                        textBoxTotalPris.Text = Appbizz.TempPriceDetails.AmountInclVat.ToString("N2");
                        textBoxPrisUdenMoms.Text = Appbizz.TempPriceDetails.AmountExclVat.ToString();
                        textBoxPrisForMoms.Text = Appbizz.TempPriceDetails.VatOfAmount.ToString();
                        if(Convert.ToDecimal(textBoxTotalPris.Text) < Convert.ToDecimal(textBoxIndbetalt.Text))
                        {
                            decimal fuu = Convert.ToDecimal(textBoxIndbetalt.Text) - Convert.ToDecimal(textBoxTotalPris.Text);
                            textBoxRetur.Text = fuu.ToString();
                        }
                        else
                        {

                            decimal fuu = Convert.ToDecimal(textBoxTotalPris.Text) - Convert.ToDecimal(textBoxIndbetalt.Text);
                            textBoxRetur.Text = fuu.ToString();

                        }
                    }
                    else
                    {
                        textBoxAdults.BorderBrush = Brushes.Gray;
                        textBoxAdults.BorderThickness = new Thickness(1);
                        AdultsOK = false;
                    }
                }
            }
            else
            {
                textBoxAdults.BorderBrush = Brushes.Red;
                textBoxAdults.BorderThickness = new Thickness(2);
                AdultsOK = false;
            }
        }

        private void ChildrenChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxChildren.Text))
            {
                bool gyldig = false;
                foreach (char c in textBoxChildren.Text)
                {
                    if (!char.IsDigit(c))
                    {
                        gyldig = false;
                        textBoxChildren.BorderBrush = Brushes.Red;
                        textBoxChildren.BorderThickness = new Thickness(2);
                        MessageBox.Show("må ikke indeholde bogstaver eller tegn");
                        textBoxChildren.Text = textBoxChildren.Text.Remove(textBoxChildren.Text.Length - 1);
                        textBoxChildren.CaretIndex = textBoxChildren.Text.Length; //amazing
                    }
                    else
                    {
                        gyldig = true;
                        textBoxChildren.BorderBrush = Brushes.Gray;
                        textBoxChildren.BorderThickness = new Thickness(1);
                    }

                }
                if (gyldig == true)
                {
                    int Children = Convert.ToInt32(textBoxChildren.Text);
                    if (Children != Appbizz.TempTransaction.Children)
                    {
                        textBoxChildren.BorderBrush = Brushes.Green;
                        textBoxChildren.BorderThickness = new Thickness(2);
                        ChildrenOK = true;
                        Appbizz.TempTransaction.Children = Children;
                        Appbizz.TempPriceDetails.CalculateAmounts(Appbizz.TempTransaction, Appbizz.Transactions, Appbizz.Destinations); //data moved to updated tempPriceDetails
                        textBoxTotalPris.Text = Appbizz.TempPriceDetails.AmountInclVat.ToString();
                        textBoxPrisUdenMoms.Text = Appbizz.TempPriceDetails.AmountExclVat.ToString();
                        textBoxPrisForMoms.Text = Appbizz.TempPriceDetails.VatOfAmount.ToString();
                    }
                    else
                    {
                        textBoxChildren.BorderBrush = Brushes.Gray;
                        textBoxChildren.BorderThickness = new Thickness(1);
                        ChildrenOK = false;
                    }
                }
            }
            else
            {
                textBoxChildren.BorderBrush = Brushes.Red;
                textBoxChildren.BorderThickness = new Thickness(2);
                ChildrenOK = false;
            }
        }

        private void LuggageChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxBagage.Text))
            {
                bool gyldig = false;
                foreach (char c in textBoxBagage.Text)
                {
                    if (!char.IsDigit(c))
                    {
                        gyldig = false;
                        textBoxBagage.BorderBrush = Brushes.Red;
                        textBoxBagage.BorderThickness = new Thickness(2);
                        MessageBox.Show("må ikke indeholde bogstaver eller tegn");
                        textBoxBagage.Text = textBoxBagage.Text.Remove(textBoxBagage.Text.Length - 1);
                        textBoxBagage.CaretIndex = textBoxBagage.Text.Length; //amazing
                    }
                    else
                    {
                        gyldig = true;
                        textBoxBagage.BorderBrush = Brushes.Gray;
                        textBoxBagage.BorderThickness = new Thickness(1);
                    }

                }
                if (gyldig == true)
                {
                    int Luggage = Convert.ToInt32(textBoxBagage.Text);
                    if (Luggage != Appbizz.TempTransaction.LuggageAmount)
                    {
                        textBoxBagage.BorderBrush = Brushes.Green;
                        textBoxBagage.BorderThickness = new Thickness(2);
                        LugageOK = true;
                        Appbizz.TempTransaction.LuggageAmount = Luggage;
                        Appbizz.TempPriceDetails.CalculateAmounts(Appbizz.TempTransaction, Appbizz.Transactions, Appbizz.Destinations); //data moved to updated tempPriceDetails
                        textBoxTotalPris.Text = Appbizz.TempPriceDetails.AmountInclVat.ToString();
                        textBoxPrisUdenMoms.Text = Appbizz.TempPriceDetails.AmountExclVat.ToString();
                        textBoxPrisForMoms.Text = Appbizz.TempPriceDetails.VatOfAmount.ToString();
                    }
                    else
                    {
                        textBoxBagage.BorderBrush = Brushes.Gray;
                        textBoxBagage.BorderThickness = new Thickness(1);
                        LugageOK = false;
                    }
                }
            }
            else
            {
                textBoxBagage.BorderBrush = Brushes.Red;
                textBoxBagage.BorderThickness = new Thickness(2);
                LugageOK = false;
            }
        }

        private void textBoxTotalPris_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
