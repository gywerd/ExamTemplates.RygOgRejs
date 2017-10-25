using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class PriceDetails
    {
        #region Fields
        private decimal destinationPrice;
        private decimal firstClassPrice;
        private decimal luggagePrice;
        private decimal taxRate = Convert.ToDecimal("0.25");
        private decimal amountExclVat;
        private decimal amountInclVat;
        private decimal vatOfAmount;
        AncillaryCharge ancillaryCharges;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public PriceDetails() { }

        /// <summary>
        /// Constructor adds info on additional prices
        /// </summary>
        /// <param name="AC">AncillaryCharge</param>
        public PriceDetails(AncillaryCharge AC)
        {
            this.ancillaryCharges = AC;
        }

        /// <summary>
        /// Ordinary constructor
        /// </summary>
        /// <param name="destPrice">decimal</param>
        /// <param name="firstClPrice">decimal</param>
        /// <param name="lugPrice">decimal</param>
        public PriceDetails(decimal destPrice, decimal firstClPrice, decimal lugPrice)
        {
            this.destinationPrice = destPrice;
            this.firstClassPrice = firstClPrice;
            this.luggagePrice = lugPrice;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds two integers together from inside an object
        /// </summary>
        /// <param name="t">Transaction</param>
        /// <returns></returns>
        private int AddPersons(Transaction t)
        {
            return t.Adults + t.Children;
        }

        /// <summary>
        /// Difference between two integers
        /// </summary>
        /// <param name="n1">int</param>
        /// <param name="n2">int</param>
        /// <returns></returns>
        private int DifferntiateInts(int n1, int n2)
        {
            if (n1 >= n2)
            {
                return n1 - n2;

            }
            else
            {
                return n2 - n1;
            }
        }

        /// <summary>
        /// Retrieves adult price to destination
        /// </summary>
        /// <param name="t">Transaction</param>
        /// <param name="dcol">ObservableCollection<Destination></param>
        /// <returns></returns>
        private decimal GetAdultPrice(Transaction t, ObservableCollection<Destination> dcol)
        {
            decimal adultPrice = 0;
            foreach (Destination price in dcol)
            {
                if (t.DestinationName == price.DestinationName)
                {
                    adultPrice = price.AdultPrice;
                }
            }
            return adultPrice;
        }

        /// <summary>
        /// Retrieves ChildrenPrice to destination
        /// </summary>
        /// <param name="t">Journey</param>
        /// <param name="dcol">ObservableCollection<PriceDetails></param>
        /// <returns></returns>
        private decimal GetChildrenPrice(Transaction t, ObservableCollection<Destination> dcol)
        {
            decimal childrenPrice = 0;
            foreach (Destination price in dcol)
            {
                if (t.DestinationName == price.DestinationName)
                {
                    childrenPrice = price.ChildPrice;
                }
            }
            return childrenPrice;
        }

        /// <summary>
        /// Retrieves firstClassPrice to destination
        /// </summary>
        /// <returns></returns>
        private decimal GetFirstClassPrice()
        {
            return firstClassPrice;
        }

        /// <summary>
        /// Calculates luggageOverload
        /// </summary>
        /// <param name="t">Journey</param>
        /// <returns></returns>
        private int GetLuggageOverloadWeight(Transaction t, ObservableCollection<Destination> dcol)
        {
            int lugWeight = Convert.ToInt32(t.LuggageAmount);
            int persons = AddPersons(t);
            int lugMaxWeight = persons * 25;
            int lugOverload = 0;
            if (lugWeight > lugMaxWeight)
            {
                lugOverload = DifferntiateInts(lugWeight, lugMaxWeight);
            }
            return lugOverload;
        }

        /// <summary>
        /// Retrieves luggagePrice per extra kg to destination
        /// What is the params used for?!? Why are they Needed?!?
        /// </summary>
        /// <param name="t">Journey</param>
        /// <param name="dcol">ObservableCollection<PriceDetails></param>
        /// <returns></returns>
        private decimal GetLuggagePrice(Transaction t, ObservableCollection<Destination> dcol)
        {
           return luggagePrice;
        }

        /// <summary>
        /// Method calculates VAT from net amount
        /// </summary>
        /// <param name="amount">decimal</param>
        /// <returns></returns>
        public decimal GetTaxAmount(decimal amount)
        {
            return amount * taxRate;
        }

        public decimal GetPaidAmount(decimal amount)
        {
            return (amount * (decimal)taxRate) + amount;
        }

        /// <summary>
        /// Calculates net price
        /// </summary>
        /// <param name="t">Transaction</param>
        /// <param name="tcol">ObservableCollection<Transaction></param>
        /// <param name="d">ObservableCollection<Destination></param>
        /// <returns></returns>
        public decimal GetTotalWithoutTax(Transaction t, ObservableCollection<Transaction> tcol, ObservableCollection<Destination> d)
        {
            decimal accumulatedPrice = 0;
            decimal adultsAccumulatedPrice = Multiplydecimal(t.Adults, GetAdultPrice(t, d));
            accumulatedPrice = accumulatedPrice + adultsAccumulatedPrice;
            decimal childAccumulatedPrice = Multiplydecimal(t.Children, GetChildrenPrice(t, d));
            accumulatedPrice = accumulatedPrice + childAccumulatedPrice;
            decimal firstClassAccumulatedPrice = 0;
            if (t.IsFirstClass)
            {
                firstClassAccumulatedPrice = Multiplydecimal(AddPersons(t), GetFirstClassPrice());
            }
            else
                firstClassAccumulatedPrice = 0;
            accumulatedPrice = accumulatedPrice + firstClassAccumulatedPrice;
            decimal luggageAccumulatedPrice = Multiplydecimal(GetLuggageOverloadWeight(t,d), GetLuggagePrice(t, d));
            accumulatedPrice = accumulatedPrice + luggageAccumulatedPrice;
            //Not Implemented Yet
            return accumulatedPrice;
        }

        /// <summary>
        /// Calculates gross price
        /// </summary>
        /// <param name="t">Transaction</param>
        /// <param name="tcol">ObservableCollection<Transaction></param>
        /// <param name="dcol">ObservableCollection<Destination></param>
        /// <returns></returns>
        public decimal GetTotalWithTax(Transaction t, ObservableCollection<Transaction> tcol, ObservableCollection<Destination> dcol)
        {
            decimal total = 0;
            total = total + GetTotalWithoutTax(t, tcol, dcol);
            total = total + GetTaxAmount(GetTotalWithoutTax(t, tcol, dcol));
            return total;
        }

        /// <summary>
        /// Multiplies two decimals
        /// </summary>
        /// <param name="f1">decimal</param>
        /// <param name="f2">decimal</param>
        /// <returns></returns>
        private decimal Multiplydecimal(decimal f1, decimal f2)
        {
            return f1 * f2;
        }
        #endregion

        #region Properties
        public decimal DestinationPrice { get => destinationPrice; set => destinationPrice = value; }
        public decimal FirstClassPrice { get => firstClassPrice; set => firstClassPrice = value; }
        public decimal Luggageprice { get => luggagePrice; set => luggagePrice = value; }
        public decimal TaxRate { get => taxRate; set => taxRate = value; }
        public decimal AmountExclVat { get => amountExclVat; set => amountExclVat = value; }
        public decimal AmountInclVat { get => amountInclVat; set => amountInclVat = value; }
        public decimal VatOfAmount { get => vatOfAmount; set => vatOfAmount = value; }
        #endregion
    }
}
