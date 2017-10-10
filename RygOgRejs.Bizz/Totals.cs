using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class Totals
    {
        #region Fields
        private int amountOfSoldTravels;
        private int amountOfPassengers;
        private int amountOfAdults;
        private int amountOfChildren;
        private float totalSaleAmount;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor 
        /// </summary>
        public Totals() { }

        /// <summary>
        /// Constructor taking five prams
        /// </summary>
        /// <param name="soldtravels">int</param>
        /// <param name="passengers">int</param>
        /// <param name="adults">int</param>
        /// <param name="children">int</param>
        /// <param name="saleAmount">float</param>
        public Totals(int soldtravels, int passengers, int adults, int children, float saleAmount)
        {
            this.amountOfSoldTravels = soldtravels;
            this.amountOfPassengers = passengers;
            this.amountOfAdults = adults;
            this.amountOfChildren = children;
            this.totalSaleAmount = saleAmount;
        }
        #endregion

        #region Methods
        public void UpdateTotals(ObservableCollection<Journey> j, ObservableCollection<Transactions> t)
        {
            this.amountOfSoldTravels = j.Count;
            this.amountOfAdults = GetAmountOfAdults(j);
            this.amountOfChildren = GetAmountOfChildren(j);
            this.amountOfPassengers = amountOfChildren + amountOfAdults;
            this.totalSaleAmount = GetTotalSaleAmount(t);
        }

        private int GetAmountOfAdults(ObservableCollection<Journey> j)
        {
            int adults = 0;
            foreach (Journey jour in j)
            {
                adults = adults + jour.Adults;
            }
            return adults;
        }

        private int GetAmountOfChildren(ObservableCollection<Journey> j)
        {
            int children = 0;
            foreach (Journey jour in j)
            {
                children = children + jour.Children;
            }
            return children;
        }

        private float GetTotalSaleAmount(ObservableCollection<Transactions> t)
        {
            float totalSale = 0;
            foreach (Transactions trans in t)
            {
                totalSale = totalSale + trans.Amount;
            }
            return totalSale;
        }
        #endregion

        #region Properties
        public int AmountOfAdults { get => amountOfAdults; set => amountOfAdults = value; }
        public int AmountofChildren { get => amountOfChildren; set => amountOfChildren = value; }
        public int AmountOfPassengers { get => amountOfPassengers; set => amountOfPassengers = value; }
        public int AmountOfSoldTravels { get => amountOfSoldTravels; set => amountOfSoldTravels = value; }
        public float TotalSaleAmount { get => totalSaleAmount; set => totalSaleAmount = value; }
        #endregion
    }
}
