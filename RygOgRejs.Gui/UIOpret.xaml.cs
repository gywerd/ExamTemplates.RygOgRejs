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
    /// Interaction logic for UIOpret.xaml
    /// </summary>
    public partial class UIOpret : UserControl
    {
        UserControl UC;
        AppBizz CAB;
        public UIOpret(AppBizz CAB, UserControl UC)
        {
            InitializeComponent();
            this.UC = UC;
            this.CAB = CAB;
            //this.CAB.TempPriceDetails.FirstClassPrice = CAB.AnchillaryCharges;
        }
        private void btnClickOpretRejse(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBoxIndbetalt.Text) >= Convert.ToInt32(textBoxTotalPris.Text))
                {
                    CAB.TempTransaction.TransActionDate = DateTime.Now;
                    //CAB.TempTransaction.AmountExclVat = Convert.ToSingle(textBoxIndbetalt.Text);
                    CAB.TempTransaction.AmountExclVat = Convert.ToSingle(textBoxIndbetalt.Text) * Convert.ToSingle("0.8"); //substracted VAT
                    //CAB.TempTransaction.PayerId = CAB.TempPayer.PayerId; obsolete code
                    CAB.CreateJourney();
                    MessageBox.Show("Rejsen Blevet Oprettet");
                    UC.Content = null;
                    
                }
                else
                {
                    MessageBox.Show("Der er ikke Betalt Nok");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Du Magnler at udfylde noget. " + ex.Message);
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //yes Sir. jack
            if (firstClassChecked.IsChecked == true)
            {
                CAB.TempTransaction.IsFirstClass = true;
                textBoxTotalPris.Text = CAB.TempPriceDetails.GetTotalWithoutTax(CAB.TempTransaction, CAB.Transactions, CAB.Destinations).ToString();
            }
            else
            {
                CAB.TempTransaction.IsFirstClass = false;
                textBoxTotalPris.Text = CAB.TempPriceDetails.GetTotalWithoutTax(CAB.TempTransaction, CAB.Transactions, CAB.Destinations).ToString();
            }

                
        }
        //thx to jack for his validation #LAZY
        private void textBoxLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                bool Gyldig = false;
                foreach (char c in textBoxLastName.Text)
                {
                    if (!char.IsLetter(c))
                    {
                        Gyldig = false;
                        textBoxLastName.BorderBrush = Brushes.Red;
                        textBoxLastName.BorderThickness = new Thickness(2);
                        MessageBox.Show("Fornavn må ikke indeholde ugyldige tegn eller tal.");
                        textBoxLastName.Text = textBoxLastName.Text.Remove(textBoxLastName.Text.Length - 1);
                        textBoxLastName.CaretIndex = textBoxLastName.Text.Length;
                    }
                    else
                    {
                        Gyldig = true;
                        textBoxLastName.BorderBrush = Brushes.Transparent;
                        textBoxLastName.BorderThickness = new Thickness(1);
                    }
                }
                if (Gyldig == true)
                {
                    textBoxLastName.BorderBrush = Brushes.Green;
                    textBoxLastName.BorderThickness = new Thickness(2);

                    CAB.TempTransaction.LastName = textBoxLastName.Text;
                }

            }
            else
            {
                textBoxLastName.BorderBrush = Brushes.Red;
                textBoxLastName.BorderThickness = new Thickness(2);
            }
        }

        //thx to jack for his validation #LAZY
        private void textBoxFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFirstName.Text))
            {
                bool gyldig = false;
                foreach (char c in textBoxFirstName.Text)
                {
                    if (!char.IsLetter(c))
                    {
                        gyldig = false;
                        textBoxFirstName.BorderBrush = Brushes.Red;
                        textBoxFirstName.BorderThickness = new Thickness(2);
                        MessageBox.Show("Fornavn må ikke indeholde ugyldige tegn eller tal.");
                        textBoxFirstName.Text = textBoxFirstName.Text.Remove(textBoxFirstName.Text.Length - 1);
                        textBoxFirstName.CaretIndex = textBoxFirstName.Text.Length; //amazing
                    }
                    else
                    {
                        gyldig = true;
                        textBoxFirstName.BorderBrush = Brushes.Transparent;
                        textBoxFirstName.BorderThickness = new Thickness(1);

                    }

                }
                if (gyldig == true)
                {
                    textBoxFirstName.BorderBrush = Brushes.Green;
                    textBoxFirstName.BorderThickness = new Thickness(2);
                    CAB.TempTransaction.FirstName = textBoxFirstName.Text;
                }
            }
            else
            {
                textBoxFirstName.BorderBrush = Brushes.Red;
                textBoxFirstName.BorderThickness = new Thickness(2);
            }
        }

        private void textBoxAdults_TextChanged(object sender, TextChangedEventArgs e)
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
                        MessageBox.Show("må ikke indeholde ugyldige bogstaver eller tegn");
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
                    textBoxAdults.BorderBrush = Brushes.Green;
                    textBoxAdults.BorderThickness = new Thickness(2);
                    CAB.TempTransaction.Adults = Convert.ToInt32(textBoxAdults.Text);
                    textBoxTotalPris.Text = CAB.TempPriceDetails.GetTotalWithoutTax(CAB.TempTransaction, CAB.Transactions, CAB.Destinations).ToString();
                }
            }
            else
            {
                textBoxAdults.BorderBrush = Brushes.Red;
                textBoxAdults.BorderThickness = new Thickness(2);
            }
        }

        private void textBoxChildren_TextChanged(object sender, TextChangedEventArgs e)
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
                        MessageBox.Show("må ikke indeholde ugyldige bogstaver eller tegn");
                        textBoxChildren.Text = textBoxChildren.Text.Remove(textBoxChildren.Text.Length - 1);
                        textBoxChildren.CaretIndex = textBoxChildren.Text.Length; //amazing
                    }
                    else
                    {
                        gyldig = true;
                        textBoxChildren.BorderBrush = Brushes.Transparent;
                        textBoxChildren.BorderThickness = new Thickness(1);
                      
                    }

                }
                if (gyldig == true)
                {
                    textBoxChildren.BorderBrush = Brushes.Green;
                    textBoxChildren.BorderThickness = new Thickness(2);
                    CAB.TempTransaction.Children = Convert.ToInt32(textBoxChildren.Text);
                    textBoxTotalPris.Text = CAB.TempPriceDetails.GetTotalWithoutTax(CAB.TempTransaction, CAB.Transactions, CAB.Destinations).ToString();
                }
            }
            else
            {
                textBoxChildren.BorderBrush = Brushes.Red;
                textBoxChildren.BorderThickness = new Thickness(2);
            }
        }

        private void textBoxBagage_TextChanged(object sender, TextChangedEventArgs e)
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
                        MessageBox.Show("må ikke indeholde ugyldige bogstaver eller tegn");
                        textBoxBagage.Text = textBoxBagage.Text.Remove(textBoxBagage.Text.Length - 1);
                        textBoxBagage.CaretIndex = textBoxBagage.Text.Length; //amazing
                    }
                    else
                    {
                        gyldig = true;
                        textBoxBagage.BorderBrush = Brushes.Transparent;
                        textBoxBagage.BorderThickness = new Thickness(1);
                        
                    }

                }
                if (gyldig == true)
                {
                    textBoxBagage.BorderBrush = Brushes.Green;
                    textBoxBagage.BorderThickness = new Thickness(2);
                    CAB.TempTransaction.LuggageAmount = Convert.ToSingle(textBoxBagage.Text);
                    textBoxTotalPris.Text = CAB.TempPriceDetails.GetTotalWithoutTax(CAB.TempTransaction, CAB.Transactions, CAB.Destinations).ToString();
                }
            }
            else
            {
                textBoxBagage.BorderBrush = Brushes.Red;
                textBoxBagage.BorderThickness = new Thickness(2);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            labelDestination.Content = CAB.TempTransaction.DestinationName;
            foreach (var ac in CAB.AnchillaryCharges)
            {
                CAB.TempPriceDetails.FirstClassPrice = ac.FirstClassPrice;
                CAB.TempPriceDetails.Luggageprice = ac.LuggagePriceOverlodKg;
            }
        }

        private void textBoxIndbetalt_TextChanged(object sender, TextChangedEventArgs e)
        {
            int betalt = 0;
            if (!string.IsNullOrEmpty(textBoxIndbetalt.Text))
            {
                bool gyldig = false;
                foreach (char c in textBoxIndbetalt.Text)
                {
                    if (!char.IsDigit(c))
                    {
                        gyldig = false;
                        textBoxIndbetalt.BorderBrush = Brushes.Red;
                        textBoxIndbetalt.BorderThickness = new Thickness(2);
                        MessageBox.Show("må ikke indeholde ugyldige bogstaver eller tegn");
                        textBoxIndbetalt.Text = textBoxIndbetalt.Text.Remove(textBoxIndbetalt.Text.Length - 1);
                        textBoxIndbetalt.CaretIndex = textBoxIndbetalt.Text.Length; //amazing
                    }
                    else
                    {
                        if(Convert.ToInt64(textBoxIndbetalt.Text) < int.MaxValue)
                        {   gyldig = true;
                            textBoxIndbetalt.BorderBrush = Brushes.Transparent;
                            textBoxIndbetalt.BorderThickness = new Thickness(1);
                        }
                        else
                        {
                            gyldig = false;
                            textBoxIndbetalt.BorderBrush = Brushes.Red;
                            textBoxIndbetalt.BorderThickness = new Thickness(2);
                            MessageBox.Show("Værdien er for stor");
                            textBoxIndbetalt.Text = textBoxIndbetalt.Text.Remove(textBoxIndbetalt.Text.Length - 1);
                            textBoxIndbetalt.CaretIndex = textBoxIndbetalt.Text.Length;
                        }
                    }
                }
                if (gyldig == true)
                {
                    textBoxIndbetalt.BorderBrush = Brushes.Green;
                    textBoxIndbetalt.BorderThickness = new Thickness(2);
                    betalt = Convert.ToInt32(textBoxIndbetalt.Text);
                    if (!string.IsNullOrWhiteSpace(textBoxTotalPris.Text))
                    {
                        int totalPris = Convert.ToInt32(textBoxTotalPris.Text);
                        if (betalt - totalPris < 0)
                            textBoxRetur.Text = "Ikke nok betalt";
                        else
                            textBoxRetur.Text = (betalt - totalPris).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Udfyld overstående skema først");
                    }
                }
            }
            else
            {
                textBoxIndbetalt.BorderBrush = Brushes.Red;
                textBoxIndbetalt.BorderThickness = new Thickness(2);
            }
        }
    }
}
