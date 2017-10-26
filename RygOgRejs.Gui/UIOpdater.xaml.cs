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
        decimal Indbetalt;
        decimal TidligerBetalt;
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
            }
           
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            labelDestination.Content = Appbizz.TempTransaction.DestinationName;
            foreach (var ac in Appbizz.AnchillaryCharges)
            {
                Appbizz.TempPriceDetails.FirstClassPrice = (decimal)ac.FirstClassPrice;
                Appbizz.TempPriceDetails.Luggageprice = (decimal)ac.LuggagePriceOverlodKg;
            }
            Appbizz.TempPriceDetails.CalculateAmounts(Appbizz.TempTransaction, Appbizz.Transactions, Appbizz.Destinations); //data moved to updated tempPriceDetails
            textBoxTotalPris.Text = Appbizz.TempPriceDetails.AmountInclVat.ToString();
            textBoxPrisUdenMoms.Text = Appbizz.TempPriceDetails.AmountExclVat.ToString();
            textBoxPrisForMoms.Text = Appbizz.TempPriceDetails.VatOfAmount.ToString();
            textBoxIndbetalt.Text = Appbizz.TempTransaction.AmountInclVat.ToString();
            TidligerBetalt = Convert.ToDecimal(textBoxTotalPris.Text) - Convert.ToDecimal(Appbizz.TempTransaction.AmountInclVat);
            textBoxPrisUdenMoms.Text += " kr";
            textBoxPrisForMoms.Text += " kr";
            textBoxTotalPris.Text += " kr";
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
                if (isFirstClassOK == true || ChildrenOK == true || AdultsOK == true || LugageOK == true)
                {
                    try
                    {
                        Appbizz.EditJourney();
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
                else
                {
                    MessageBox.Show("Der er ingen ændringer!");
                }
            }
        }

        private void btnClickSlet(object sender, RoutedEventArgs e)
        {
            Appbizz.DeleteJourney();
            Appbizz.GetUpdate();
            MessageBox.Show("Rejsen blev sletted.");
        }

        private void IsFirstClassChanged(object sender, RoutedEventArgs e)
        {
            if (firstClassChecked.IsChecked != Appbizz.TempTransaction.IsFirstClass)
            {
                if (firstClassChecked.IsChecked == true)
                {
                    isFirstClassOK = true;
                    Appbizz.TempPriceDetails.CalculateAmounts(Appbizz.TempTransaction, Appbizz.Transactions, Appbizz.Destinations);
                    textBoxPrisUdenMoms.Text = Appbizz.TempPriceDetails.AmountExclVat.ToString();
                    textBoxPrisForMoms.Text = Appbizz.TempPriceDetails.VatOfAmount.ToString();
                    textBoxTotalPris.Text = Appbizz.TempPriceDetails.AmountInclVat.ToString();
                    textBoxPrisUdenMoms.Text += " kr";
                    textBoxPrisForMoms.Text += " kr";
                    textBoxTotalPris.Text += " kr";
                }
                else
                {
                    isFirstClassOK = false;
                    Appbizz.TempPriceDetails.CalculateAmounts(Appbizz.TempTransaction, Appbizz.Transactions, Appbizz.Destinations);
                    textBoxPrisUdenMoms.Text = Appbizz.TempPriceDetails.AmountExclVat.ToString();
                    textBoxPrisForMoms.Text = Appbizz.TempPriceDetails.VatOfAmount.ToString();
                    textBoxTotalPris.Text = Appbizz.TempPriceDetails.AmountInclVat.ToString();
                    textBoxPrisUdenMoms.Text += " kr";
                    textBoxPrisForMoms.Text += " kr";
                    textBoxTotalPris.Text += " kr";
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
                        textBoxAdults.CaretIndex = textBoxAdults.Text.Length;
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
                        textBoxPrisUdenMoms.Text += " kr";
                        textBoxPrisForMoms.Text += " kr";
                        textBoxTotalPris.Text += " kr";
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
                        textBoxChildren.CaretIndex = textBoxChildren.Text.Length;
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
                        textBoxTotalPris.Text = Appbizz.TempPriceDetails.AmountInclVat.ToString("N2");
                        textBoxPrisUdenMoms.Text = Appbizz.TempPriceDetails.AmountExclVat.ToString("N2");
                        textBoxPrisForMoms.Text = Appbizz.TempPriceDetails.VatOfAmount.ToString("N2");
                        textBoxPrisUdenMoms.Text += " kr";
                        textBoxPrisForMoms.Text += " kr";
                        textBoxTotalPris.Text += " kr";
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
                        textBoxBagage.CaretIndex = textBoxBagage.Text.Length;
                    }
                    if (textBoxBagage.Text.Length > 4)
                    {
                        MessageBox.Show("Vægten er for stor, Flyet kan ikke lætte, Max 9,999 Kg.");
                        textBoxBagage.Text = textBoxBagage.Text.Remove(textBoxBagage.Text.Length - 1);
                        textBoxBagage.CaretIndex = textBoxBagage.Text.Length;
                        gyldig = false;
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
                        textBoxTotalPris.Text = Appbizz.TempPriceDetails.AmountInclVat.ToString("N2");
                        textBoxPrisUdenMoms.Text = Appbizz.TempPriceDetails.AmountExclVat.ToString("N2");
                        textBoxPrisForMoms.Text = Appbizz.TempPriceDetails.VatOfAmount.ToString("N2");
                        textBoxPrisUdenMoms.Text += " kr";
                        textBoxPrisForMoms.Text += " kr";
                        textBoxTotalPris.Text += " kr";
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
            if (textBoxTotalPris.Text.Contains(" kr"))
            {
                textBoxTotalPris.Text = textBoxTotalPris.Text.Remove((textBoxTotalPris.Text.Length - 3));
            }
            textBoxRetur.Text = (Convert.ToDecimal(textBoxTotalPris.Text) - TidligerBetalt).ToString() + "  kr";
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
                        if (textBoxIndbetalt.Text.Trim().Length <= 0)
                        {
                            textBoxIndbetalt.Text = "0";
                        }
                    }
                    if (!char.IsDigit(c) && c != '+' && c != ',' && c != '.')
                    {
                        gyldig = false;
                        textBoxIndbetalt.BorderBrush = Brushes.Red;
                        textBoxIndbetalt.BorderThickness = new Thickness(2);
                        MessageBox.Show("må ikke indeholde ugyldige bogstaver eller tegn");
                        textBoxIndbetalt.Text = textBoxIndbetalt.Text.Remove(textBoxIndbetalt.Text.Length - 1);
                        textBoxIndbetalt.CaretIndex = textBoxIndbetalt.Text.Length;
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
                        if (decimal.TryParse(textBoxIndbetalt.Text, out decimal test))
                        {
                            if (test < decimal.MaxValue)
                            {
                                gyldig = true;
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
