﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class Total : INotifyPropertyChanged
    {
        #region Fields
        private int amountOfSoldJourneys;
        private int amountOfFirstClassJourneys;
        private int amountOfStandardJourneys;
        private int amountOfPassengers;
        private int amountOfAdults;
        private int amountOfChildren;
        private decimal totalSaleAmount;
        #endregion

        #region Events
        /// <summary>
        /// Event, that handles updating fields in UserControl
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
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
        public Total(int soldtravels, int passengers, int adults, int children, decimal saleAmount)
        {
            amountOfSoldJourneys = soldtravels;
            amountOfPassengers = passengers;
            amountOfAdults = adults;
            amountOfChildren = children;
            totalSaleAmount = saleAmount;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that Notifies an instance of ClassPersonData, when an entry is entered in a textbox
        /// </summary>
        /// <param name="propertyName"></param>
        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void UpdateTotals(ObservableCollection<Transaction> t)
        {
            AmountOfSoldJourneys = GetAmountOfSoldjourneys(t);
            AmountOfFirstClassJourneys = GetAmountOfFirstClassJourneys(t);
            AmountOfStandardJourneys = amountOfSoldJourneys - amountOfFirstClassJourneys;
            AmountOfAdults = GetAmountOfAdults(t);
            AmountOfChildren = GetAmountOfChildren(t);
            AmountOfPassengers = amountOfChildren + amountOfAdults;
            TotalSaleAmount = GetTotalSaleAmount(t);
        }

        private int GetAmountOfSoldjourneys(ObservableCollection<Transaction> t)
        {
            int soldJourneys = 0;
            foreach (Transaction trans in t)
            {
                if (trans.TransActionDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    soldJourneys = soldJourneys + 1;
                }
            }

            return soldJourneys;
        }

        private int GetAmountOfFirstClassJourneys(ObservableCollection<Transaction> t)
        {
            int firstClassJourneys = 0;
            foreach (Transaction trans in t)
            {
                if (trans.TransActionDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    if (trans.IsFirstClass)
                    {
                        firstClassJourneys = firstClassJourneys + 1;
                    }
                }
            }

            return firstClassJourneys;
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

        private decimal GetTotalSaleAmount(ObservableCollection<Transaction> t)
        {
            decimal totalSale = 0;
            foreach (Transaction trans in t)
            {
                if (trans.TransActionDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    totalSale += trans.AmountInclVat;
                }
            }
            return totalSale;
        }
        #endregion

        #region Properties
        public int AmountOfAdults
        {
            get => amountOfAdults;
            set
            {
                if (value != amountOfAdults)
                {
                    amountOfAdults = value;
                    Notify("AmountOfAdults");
                }
            }
        }

        public int AmountOfChildren
        {
            get => amountOfChildren;
            set
            {
                if (value != amountOfChildren)
                {
                    amountOfChildren = value;
                    Notify("AmountOfChildren");
                }
            }
        }
        public int AmountOfFirstClassJourneys
        {
            get => amountOfFirstClassJourneys;
            set
            {
                if (value != amountOfFirstClassJourneys)
                {
                    amountOfFirstClassJourneys = value;
                    Notify("AmountOfFirstClassJourneys");
                }
            }
        }

        public int AmountOfPassengers
        {
            get => amountOfPassengers;
            set
            {
                if (value != amountOfPassengers)
                {
                    amountOfPassengers = value;
                    Notify("AmountOfPassengers");
                }
            }
        }

        public int AmountOfSoldJourneys
        {
            get => amountOfSoldJourneys;
            set
            {
                if (value != amountOfSoldJourneys)
                {
                    amountOfSoldJourneys = value;
                    Notify("AmountOfSoldJourneys");
                }
            }
        }

        public decimal TotalSaleAmount
        {
            get => totalSaleAmount;
            set
            {
                if (value != totalSaleAmount)
                {
                    totalSaleAmount = value;
                    Notify("TotalSaleAmount");
                }
            }
        }

        public int AmountOfStandardJourneys
        {
            get => amountOfStandardJourneys;
            set
            {
                if (value != amountOfStandardJourneys)
                {
                    amountOfStandardJourneys = value;
                    Notify("AmountOfStandardJourneys");
                }
            }
        }
        #endregion
    }
}
