using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class Total
    {
        #region Fields
        private int amountOfSoldJourneys;
        private int amountOfFirstClassJourneys;
        private int amountOfStandardTravels;
        private int amountOfPassengers;
        private int amountOfAdults;
        private int amountOfChildren;
        private double totalSaleAmount;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor 
        /// </summary>
        public Total() { }

        /// <summary>
        /// Constructor taking five prams
        /// </summary>
        /// <param name="soldtravels">int</param>
        /// <param name="passengers">int</param>
        /// <param name="adults">int</param>
        /// <param name="children">int</param>
        /// <param name="saleAmount">float</param>
        public Total(int soldtravels, int passengers, int adults, int children, float saleAmount)
        {
            amountOfSoldJourneys = soldtravels;
            amountOfPassengers = passengers;
            amountOfAdults = adults;
            amountOfChildren = children;
            totalSaleAmount = saleAmount;
        }
        #endregion

        #region Methods
        public void UpdateTotals(ObservableCollection<Transaction> t)
        {
            amountOfSoldJourneys = t.Count;
            amountOfFirstClassJourneys = GetAmountOfAdultsFirstClassTravels(t);
            amountOfStandardTravels = amountOfSoldJourneys - amountOfFirstClassJourneys;
            amountOfAdults = GetAmountOfAdults(t);
            amountOfChildren = GetAmountOfChildren(t);
            amountOfPassengers = amountOfChildren + amountOfAdults;
            totalSaleAmount = GetTotalSaleAmount(t);
        }

        private int GetAmountOfAdultsFirstClassTravels(ObservableCollection<Transaction> t)
        {
            int firstClassTravels = 0;
            foreach (Transaction trans in t)
            {
                if (trans.TransActionDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    if (trans.IsFirstClass)
                    {
                        firstClassTravels = firstClassTravels + 1;
                    }
                }
            }

            return firstClassTravels;
        }

        private int GetAmountOfAdults(ObservableCollection<Transaction> t)
        {
            int adults = 0;
                foreach (Transaction trans in t)
                {
                    if (trans.TransActionDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        adults += trans.Adults;
                    }
                }
            return adults;
        }

        private int GetAmountOfChildren(ObservableCollection<Transaction> t)
        {
            int children = 0;
            foreach (Transaction trans in t)
            {
                if (trans.TransActionDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    children += trans.Children;
                }
            }

            return children;
        }

        private float GetTotalSaleAmount(ObservableCollection<Transaction> t)
        {
            float totalSale = 0;
            foreach (Transaction trans in t)
            {
                if (trans.TransActionDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    totalSale += trans.AmountExclVat;
                }
            }
            return totalSale;
        }
        #endregion

        #region Properties
        public int AmountOfAdults { get => amountOfAdults; set => amountOfAdults = value; }
        public int AmountofChildren { get => amountOfChildren; set => amountOfChildren = value; }
        public int AmountOfFirstClassJourneys { get => amountOfFirstClassJourneys; set => amountOfFirstClassJourneys = value; }
        public int AmountOfPassengers { get => amountOfPassengers; set => amountOfPassengers = value; }
        public int AmountOfSoldJourneys { get => amountOfSoldJourneys; set => amountOfSoldJourneys = value; }
        public double TotalSaleAmount { get => totalSaleAmount; set => totalSaleAmount = value; }
        public int AmountOfStandardJourneys { get => amountOfStandardTravels; set => amountOfStandardTravels = value; }
        #endregion
    }
}
