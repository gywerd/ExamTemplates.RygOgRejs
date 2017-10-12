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
        private float destinationPrice;
        private float firstClassPrice;
        private float luggagePrice;
        private float taxRate = 0.25F;
        AncillaryCharge AC;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public PriceDetails() { }

        public PriceDetails(AncillaryCharge AC)
        {
            this.AC = AC;
        }
        /// <summary>
        /// Ordinary constructor
        /// </summary>
        /// <param name="destinationId">int</param>
        /// <param name="destinationName">string</param>
        /// <param name="adultPrice">float</param>
        /// <param name="childPrice">float</param>
        /// <param name="firstclassPrice">float</param>
        /// <param name="luggagePrice">float</param>
        public PriceDetails(float destPrice, float firstClPrice, float lugPrice, float taxRate = 0.25F)
        {
            this.destinationPrice = destPrice;
            this.firstClassPrice = firstClPrice;
            this.luggagePrice = lugPrice;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds two integers together
        /// </summary>
        /// <param name="j">Journey</param>
        /// <returns></returns>
        private int AddPersons(Transaction j)
        {
            return j.Adults + j.Children;
        }

        /// <summary>
        /// Differnets two integers
        /// </summary>
        /// <param name="n1">int</param>
        /// <param name="n2">int</param>
        /// <returns></returns>
        private int DifferntiateInts(int n1, int n2)
        {
            return n1 - n2;
        }

        /// <summary>
        /// Retrieves adult price to destination
        /// </summary>
        /// <param name="j">Journey</param>
        /// <param name="p">ObservableCollection<PriceDetails></param>
        /// <returns></returns>
        private float GetAdultPrice(Transaction j, ObservableCollection<Destination> p)
        {
            float adultPrice = 0;
            foreach (Destination price in p)
            {
                if (j.DestinationName == price.DestinationName)
                {
                    adultPrice = price.AdultPrice;
                }
            }
            return adultPrice;
        }

        /// <summary>
        /// Retrieves ChildrenPrice to destination
        /// </summary>
        /// <param name="j">Journey</param>
        /// <param name="p">ObservableCollection<PriceDetails></param>
        /// <returns></returns>
        private float GetChildrenPrice(Transaction j, ObservableCollection<Destination> p)
        {
            float childrenPrice = 0;
            foreach (Destination price in p)
            {
                if (j.DestinationName == price.DestinationName)
                {
                    childrenPrice = price.ChildPrice;
                }
            }
            return childrenPrice;
        }

        /// <summary>
        /// Retrieves firstClassPrice to destination
        /// </summary>
        /// <param name="j">Journey</param>
        /// <param name="p">ObservableCollection<PriceDetails></param>
        /// <returns></returns>
        private float GetFirstClassPrice()
        {
            return firstClassPrice;
        }

        /// <summary>
        /// Calculates luggageOverload
        /// </summary>
        /// <param name="j">Journey</param>
        /// <returns></returns>
        private int GetLuggageOverloadWeight(Transaction j, ObservableCollection<Destination> p)
        {
            int lugWeight = Convert.ToInt32(j.LuggageAmount);
            int persons = AddPersons(j);
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
        /// </summary>
        /// <param name="j">Journey</param>
        /// <param name="p">ObservableCollection<PriceDetails></param>
        /// <returns></returns>
        private float GetLuggagePrice(Transaction j, ObservableCollection<Destination> p)
        {
           return luggagePrice;
        }

        /// <summary>
        /// Method calculates VAT from net amount
        /// </summary>
        /// <param name="amount">float</param>
        /// <returns></returns>
        public float GetTaxAmount(float amount)
        {
            return amount * 0.25F;
        }

        /// <summary>
        /// Calculates net price
        /// </summary>
        /// <param name="tempt">Journey</param>
        /// <param name="tcol">Transactions</param>
        /// <param name="d">ObservableCollection<PriceDetails></param>
        /// <returns></returns>
        public float GetTotalWithoutTax(Transaction tempt, ObservableCollection<Transaction> tcol, ObservableCollection<Destination> d)
        {
            float accumulatedPrice = 0;
            float adultsAccumulatedPrice = MultiplyFloat(tempt.Adults, GetAdultPrice(tempt, d));
            accumulatedPrice = accumulatedPrice + adultsAccumulatedPrice;
            float childAccumulatedPrice = MultiplyFloat(tempt.Children, GetChildrenPrice(tempt, d));
            accumulatedPrice = accumulatedPrice + childAccumulatedPrice;
            float firstClassAccumulatedPrice = 0;
            if (tempt.IsFirstClass)
            {
                firstClassAccumulatedPrice = MultiplyFloat(AddPersons(tempt), GetFirstClassPrice());
            }
            else
                firstClassAccumulatedPrice = 0;
            accumulatedPrice = accumulatedPrice + firstClassAccumulatedPrice;
            float luggageAccumulatedPrice = MultiplyFloat(GetLuggageOverloadWeight(tempt,d), GetLuggagePrice(tempt, d));
            accumulatedPrice = accumulatedPrice + luggageAccumulatedPrice;
            //Not Implemented Yet
            return accumulatedPrice;
        }

        /// <summary>
        /// Calculates gross price
        /// </summary>
        /// <param name="j"></param>
        /// <param name="t"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public float GetTotalWithTax(Transaction j, ObservableCollection<Transaction> t, ObservableCollection<Destination> p)
        {
            float total = 0;
            total = total + GetTotalWithoutTax(j, t, p);
            total = total + GetTaxAmount(GetTotalWithoutTax(j, t, p));
            return total;
        }

        /// <summary>
        /// Multiplies two floats
        /// </summary>
        /// <param name="f1">float</param>
        /// <param name="f2">float</param>
        /// <returns></returns>
        private float MultiplyFloat(float f1, float f2)
        {
            return f1 * f2;
        }
        #endregion

        #region Properties
        public float DestinationPrice { get => destinationPrice; set => destinationPrice = value; }
        public float FirstClassPrice { get => firstClassPrice; set => firstClassPrice = value; }
        public float Luggageprice { get => luggagePrice; set => luggagePrice = value; }
        public float TaxRate { get => taxRate; set => taxRate = value; }
        #endregion
    }
}
