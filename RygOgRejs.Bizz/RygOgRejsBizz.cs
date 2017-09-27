﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz
{
    public class RygOgRejsBizz
    {
        #region Fields
        Journey CJR = new Journey();
        Payer CPR = new Payer();
        Transactions CTA = new Transactions();
        PriceDetails CPD = new PriceDetails();
        ObservableCollection<Journey> journeys = new ObservableCollection<Journey>();
        ObservableCollection<Payer> payers = new ObservableCollection<Payer>();
        ObservableCollection<Transactions> transactions = new ObservableCollection<Transactions>();
        List<string> destinations = new List<string>();
        #endregion

        #region Methods
        /// <summary>
        /// Method, that execute payments
        /// </summary>
        public void ExecutePayment()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method, that execute refusion
        /// </summary>
        public void ExecuteRefusion()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method, that invokes reading journeys from database
        /// </summary>
        private void GetJourneys()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method, that generates a list of destinations
        /// </summary>
        private void GetDestinations()
        {
            ObservableCollection<PriceDetails> prices = GetPricetails();
            foreach (PriceDetails price in prices)
            {
                destinations.Add(price.DestinationName);
            }
        }

        /// <summary>
        /// Method, that invokes reading payers from database
        /// </summary>
        private void GetPayers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method, that invokes reading pricedetails from database
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<PriceDetails> GetPricetails()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method, that invokes reading transactions from database
        /// </summary>
        private void GetTransactions()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Properties
        public List<string> Destinations
        {
            get
            {
                if (destinations.Count == 0)
                {
                    GetDestinations();
                }
                return destinations;
            }
            set => destinations = value;
        }
        public ObservableCollection<Journey> Journeys
        {
            get
            {
                if (journeys.Count == 0)
                {
                    GetJourneys();
                }
                return journeys;
            }
            set => journeys = value;
        }
        public ObservableCollection<Payer> Payers
        {
            get
            {
                if (payers.Count == 0)
                {
                    GetPayers();
                }
                return payers;
            }
            set => payers = value;
        }
        public ObservableCollection<Transactions> Transactions
        {
            get
            {
                if (transactions.Count == 0)
                {
                    GetTransactions();
                }
                return transactions;
            }
            set => transactions = value;
        }
        #endregion
    }
}