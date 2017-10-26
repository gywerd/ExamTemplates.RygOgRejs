using RygOgRejs.Bizz.App;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
                textBoxTotalPris.Text = textBoxTotalPris.Text.Remove(textBoxTotalPris.Text.Length -3);
                if (Convert.ToDecimal(textBoxIndbetalt.Text) >= Convert.ToDecimal(textBoxTotalPris.Text) && textBoxFirstName.Text.Length != 0 && textBoxLastName.Text.Length != 0)
                {
                    CAB.TempTransaction.TransActionDate = DateTime.Now;
                    //CAB.TempTransaction.AmountExclVat = Convert.ToSingle(textBoxIndbetalt.Text);
                    CAB.TempTransaction.AmountInclVat = Convert.ToDecimal(textBoxIndbetalt.Text);//substracted VAT
                    CAB.TempPriceDetails.AmountInclVat = CAB.TempTransaction.AmountInclVat;
                    //CAB.TempTransaction.PayerId = CAB.TempPayer.PayerId; obsolete code
                    CAB.CreateJourney();
                    MessageBox.Show("Rejsen Blevet Oprettet");
                    UC.Content = null;                    
                }
                else
                {
                    if (textBoxFirstName.Text.Length == 0)
                        MessageBox.Show("Udfyld Fornanv");
                    else if (textBoxLastName.Text.Length == 0)
                        MessageBox.Show("udfyld Efternavn");
                    else
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
            textBoxIndbetalt.Text = "";
            textBoxRetur.Text = "Der er ikke Betalt Nok";
            //yes Sir. jack
            if (firstClassChecked.IsChecked == true)
            {
                CAB.TempTransaction.IsFirstClass = true;
                CAB.TempPriceDetails.CalculateAmounts(CAB.TempTransaction, CAB.Transactions, CAB.Destinations); //data moved to updated tempPriceDetails
                textBoxPrisUdenMoms.Text = CAB.TempPriceDetails.AmountExclVat.ToString();
                textBoxPrisForMoms.Text = CAB.TempPriceDetails.VatOfAmount.ToString();
                textBoxTotalPris.Text = CAB.TempPriceDetails.AmountInclVat.ToString();
                textBoxPrisUdenMoms.Text += " kr";
                textBoxPrisForMoms.Text += " kr";
                textBoxTotalPris.Text += " kr";
            }
            else
            {
                CAB.TempTransaction.IsFirstClass = false;
                CAB.TempPriceDetails.CalculateAmounts(CAB.TempTransaction, CAB.Transactions, CAB.Destinations); //data moved to updated tempPriceDetails
                textBoxPrisUdenMoms.Text = CAB.TempPriceDetails.AmountExclVat.ToString();
                textBoxPrisForMoms.Text = CAB.TempPriceDetails.VatOfAmount.ToString();
                textBoxTotalPris.Text = CAB.TempPriceDetails.AmountInclVat.ToString();
                textBoxPrisUdenMoms.Text += " kr";
                textBoxPrisForMoms.Text += " kr";
                textBoxTotalPris.Text += " kr";
            }

                
        }
        //thx to jack for his validation #LAZY
        private void textBoxLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                bool gyldig = false;
                foreach (char c in textBoxLastName.Text)
                {
                    if (!char.IsLetter(c))
                    {
                        gyldig = false;
                        textBoxLastName.BorderBrush = Brushes.Red;
                        textBoxLastName.BorderThickness = new Thickness(2);
                        MessageBox.Show("Fornavn må ikke indeholde ugyldige tegn eller tal.");
                        textBoxLastName.Text = textBoxLastName.Text.Remove(textBoxLastName.Text.Length - 1);
                        textBoxLastName.CaretIndex = textBoxLastName.Text.Length;
                    }
                    if (textBoxLastName.Text.Length > 20)
                    {
                        MessageBox.Show("For mange bogstaver, Max 20 bogstaver.");
                        textBoxLastName.Text = textBoxLastName.Text.Remove(textBoxLastName.Text.Length - 1);
                        textBoxLastName.CaretIndex = textBoxLastName.Text.Length;
                        gyldig = false;
                    }
                    else
                    {
                        gyldig = true;
                        textBoxLastName.BorderBrush = Brushes.Transparent;
                        textBoxLastName.BorderThickness = new Thickness(1);
                    }
                }
                if (gyldig == true)
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
                    if (textBoxFirstName.Text.Length > 20)
                    {
                        MessageBox.Show("For mange bogstaver, Max 20 bogstaver.");
                        textBoxFirstName.Text = textBoxFirstName.Text.Remove(textBoxFirstName.Text.Length - 1);
                        textBoxFirstName.CaretIndex = textBoxFirstName.Text.Length;
                        gyldig = false;
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
            textBoxIndbetalt.Text = "";
            textBoxRetur.Text = "Der er ikke Betalt Nok";
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
                        MessageBox.Show("må ikke indeholde bogstaver eller tegn.");
                        textBoxAdults.Text = textBoxAdults.Text.Remove(textBoxAdults.Text.Length - 1);
                        textBoxAdults.CaretIndex = textBoxAdults.Text.Length; //amazing
                    }
                    if (textBoxAdults.Text.Length > 3)
                    {
                        MessageBox.Show("Tallet er for højt, Max 999 Voksne.");
                        textBoxAdults.Text = textBoxAdults.Text.Remove(textBoxAdults.Text.Length - 1);
                        textBoxAdults.CaretIndex = textBoxAdults.Text.Length;
                        gyldig = false;
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
                    CAB.TempPriceDetails.CalculateAmounts(CAB.TempTransaction, CAB.Transactions, CAB.Destinations); //data moved to updated tempPriceDetails
                    textBoxPrisUdenMoms.Text = CAB.TempPriceDetails.AmountExclVat.ToString();
                    textBoxPrisForMoms.Text = CAB.TempPriceDetails.VatOfAmount.ToString();
                    textBoxTotalPris.Text = CAB.TempPriceDetails.AmountInclVat.ToString();
                    textBoxPrisUdenMoms.Text += " kr";
                    textBoxPrisForMoms.Text += " kr";
                    textBoxTotalPris.Text += " kr";
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
            textBoxIndbetalt.Text = "";
            textBoxRetur.Text = "Der er ikke Betalt Nok";
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
                    if (textBoxChildren.Text.Length > 3)
                    {
                        MessageBox.Show("Tallet er for højt, Max 999 Børn.");
                        textBoxChildren.Text = textBoxChildren.Text.Remove(textBoxChildren.Text.Length - 1);
                        textBoxChildren.CaretIndex = textBoxChildren.Text.Length;
                        gyldig = false;
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
                    CAB.TempPriceDetails.CalculateAmounts(CAB.TempTransaction, CAB.Transactions, CAB.Destinations); //data moved to updated tempPriceDetails
                    textBoxPrisUdenMoms.Text = CAB.TempPriceDetails.AmountExclVat.ToString();
                    textBoxPrisForMoms.Text = CAB.TempPriceDetails.VatOfAmount.ToString();
                    textBoxTotalPris.Text = CAB.TempPriceDetails.AmountInclVat.ToString();
                    textBoxPrisUdenMoms.Text += " kr";
                    textBoxPrisForMoms.Text += " kr";
                    textBoxTotalPris.Text += " kr";
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
            textBoxIndbetalt.Text = "";
            textBoxRetur.Text = "Der er ikke Betalt Nok";
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
                    if (textBoxBagage.Text.Length > 4)
                    {
                        MessageBox.Show("Vægten er for stor, Flyet kan ikke lætte, Max 9,999 Ton.");
                        textBoxBagage.Text = textBoxBagage.Text.Remove(textBoxBagage.Text.Length - 1);
                        textBoxBagage.CaretIndex = textBoxBagage.Text.Length;
                        gyldig = false;
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
                    CAB.TempPriceDetails.CalculateAmounts(CAB.TempTransaction, CAB.Transactions, CAB.Destinations); //data moved to updated tempPriceDetails
                    textBoxPrisUdenMoms.Text = CAB.TempPriceDetails.AmountExclVat.ToString();
                    textBoxPrisForMoms.Text = CAB.TempPriceDetails.VatOfAmount.ToString();
                    textBoxTotalPris.Text = CAB.TempPriceDetails.AmountInclVat.ToString();
                    textBoxPrisUdenMoms.Text += " kr";
                    textBoxPrisForMoms.Text += " kr";
                    textBoxTotalPris.Text += " kr";
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
                CAB.TempPriceDetails.FirstClassPrice = (decimal)ac.FirstClassPrice;
                CAB.TempPriceDetails.Luggageprice = (decimal)ac.LuggagePriceOverlodKg;
            }
        }

        private void textBoxIndbetalt_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal betalt = 0;
            if (!string.IsNullOrEmpty(textBoxIndbetalt.Text))
            {
                bool gyldig = false;
                foreach (char c in textBoxIndbetalt.Text)
                {
                    
                    if (textBoxIndbetalt.Text.Contains("+") || textBoxIndbetalt.Text.Contains("-") || textBoxIndbetalt.Text.Contains("*") || textBoxIndbetalt.Text.Contains("/"))
                    {
                        textBoxIndbetalt.Text = textBoxIndbetalt.Text.Replace('+', ' ');
                        textBoxIndbetalt.Text = textBoxIndbetalt.Text.Replace('-', ' ');
                        textBoxIndbetalt.Text = textBoxIndbetalt.Text.Replace('*', ' ');
                        textBoxIndbetalt.Text = textBoxIndbetalt.Text.Replace('/', ' ');
                        if(textBoxIndbetalt.Text.Trim().Length <= 0)
                        {
                            textBoxIndbetalt.Text = "0";
                        }
                    }
                    if (!char.IsDigit(c) && c != '+' && c != ',' && c != '.' )
                    {
                        gyldig = false;
                        textBoxIndbetalt.BorderBrush = Brushes.Red;
                        textBoxIndbetalt.BorderThickness = new Thickness(2);
                        MessageBox.Show("må ikke indeholde ugyldige bogstaver eller tegn");
                        textBoxIndbetalt.Text = textBoxIndbetalt.Text.Remove(textBoxIndbetalt.Text.Length - 1);
                        textBoxIndbetalt.CaretIndex = textBoxIndbetalt.Text.Length; //amazing
                    }
                    if (textBoxIndbetalt.Text.Length > 10)
                    {
                        gyldig = false;
                        textBoxIndbetalt.BorderBrush = Brushes.Red;
                        textBoxIndbetalt.BorderThickness = new Thickness(2);
                        MessageBox.Show("Tallet er for stort, ikke overdrive ,max 10 tal");
                        textBoxIndbetalt.Text = textBoxIndbetalt.Text.Remove(textBoxIndbetalt.Text.Length - 1);
                        textBoxIndbetalt.CaretIndex = textBoxIndbetalt.Text.Length;
                    }
                    else
                    {
                        if(decimal.TryParse(textBoxIndbetalt.Text, out decimal test))
                        {
                            if (test < decimal.MaxValue)
                            {
                                gyldig = true;
                                //CAB.TempTransaction.PricePaid = Convert.ToInt32(textBoxIndbetalt.Text);
                                textBoxIndbetalt.BorderBrush = Brushes.Green;
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
                        else
                        {
                            gyldig = false;
                            textBoxIndbetalt.BorderBrush = Brushes.Red;
                            textBoxIndbetalt.BorderThickness = new Thickness(2);
                            MessageBox.Show("Værdien skal være et tal");
                        }
                    }
                }
                if (gyldig == true)
                {
                    textBoxIndbetalt.BorderBrush = Brushes.Green;
                    textBoxIndbetalt.BorderThickness = new Thickness(2);
                    betalt = Convert.ToDecimal(textBoxIndbetalt.Text);
                    if (!string.IsNullOrWhiteSpace(textBoxTotalPris.Text))
                    {
                        string Totalpris = textBoxTotalPris.Text;
                        if (Totalpris.Contains(" kr"))
                        {
                            Totalpris = Totalpris.Remove((Totalpris.Length - 3));
                        }
                        float pricething = Convert.ToSingle(Totalpris);
                        decimal totalPris = Convert.ToDecimal(pricething);
                        if (betalt - totalPris < 0)
                        {
                            textBoxRetur.Text = "Ikke nok betalt";
                        }
                        else
                        {
                            string PrisManglende = (betalt - totalPris).ToString();
                            textBoxRetur.Text = PrisManglende + " kr";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Udfyld overstående skema først");
                        textBoxIndbetalt.Text = textBoxIndbetalt.Text.Remove(textBoxIndbetalt.Text.Length - 1);
                        textBoxIndbetalt.CaretIndex = textBoxIndbetalt.Text.Length;
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
