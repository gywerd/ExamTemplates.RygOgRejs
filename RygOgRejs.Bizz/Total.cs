﻿using System;
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
            this.amountOfSoldTravels = soldtravels;
            this.amountOfPassengers = passengers;
            this.amountOfAdults = adults;
            this.amountOfChildren = children;
            this.totalSaleAmount = saleAmount;
        }
        #endregion

        #region Methods
        public void UpdateTotals(ObservableCollection<Transaction> t)
        {
            this.amountOfSoldTravels = t.Count;
            this.amountOfAdults = GetAmountOfAdults(t);
            this.amountOfChildren = GetAmountOfChildren(t);
            this.amountOfPassengers = amountOfChildren + amountOfAdults;
            this.totalSaleAmount = GetTotalSaleAmount(t);
        }

        private int GetAmountOfAdults(ObservableCollection<Transaction> t)
        {
            int adults = 0;
            foreach (Transaction trans in t)
            {
                adults = adults + trans.Adults;
            }
            return adults;
        }

        private int GetAmountOfChildren(ObservableCollection<Transaction> t)
        {
            int children = 0;
            foreach (Transaction trans in t)
            {
                children = children + trans.Children;
            }
            return children;
        }

        private float GetTotalSaleAmount(ObservableCollection<Transaction> t)
        {
            float totalSale = 0;
            foreach (Transaction trans in t)
            {
                totalSale = totalSale + trans.AmountExclVat;
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
