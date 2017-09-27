using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RygOgRejs.Bizz
{
    public class RygOgRejsBizz : INotifyPropertyChanged
    {
        #region Fields
        private string destination;
        private Journey journey = new Journey();
        private Payer payer = new Payer();
        private string macAddress = (from nic in NetworkInterface.GetAllNetworkInterfaces() where nic.OperationalStatus == OperationalStatus.Up select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
        Journey CJR = new Journey();
        Payer CPR = new Payer();
        Transactions CTA = new Transactions();
        PriceDetails CPD = new PriceDetails();
        MasterId CMI = new MasterId();
        private string journeyOrTransaction;
        ObservableCollection<Journey> journeys = new ObservableCollection<Journey>();
        ObservableCollection<Payer> payers = new ObservableCollection<Payer>();
        ObservableCollection<Transactions> transactions = new ObservableCollection<Transactions>();
        List<string> destinations = new List<string>();
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        public void ClearJourneys()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Code behind CreateJourney-button
        /// </summary>
        /// <param name="u"></param>
        public void CreateJourney()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Code behind DeleteJourney-button
        /// </summary>
        /// <param name="u"></param>
        public void DeleteJourney()
        {
        }

        /// <summary>
        /// Code behind EditJourney-button
        /// </summary>
        /// <param name="u"></param>
        public void EditJourney()
        {
            throw new NotImplementedException();
        }

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

        public Journey Journey { get => journey; set => journey = value; }
        public Payer Payer { get => payer; set => payer = value; }
        public string JourneyOrTransaction { get => journeyOrTransaction; set => journeyOrTransaction = value; }
        public string Destination { get => destination; set => destination = value; }
        #endregion

        #region Internal Classes
        internal class MasterId : IPersistable
        {
            private int id;
            public MasterId() { }
            public MasterId(int id)
            {
                this.id = id;
            }
            public int Id { get => id; set => id = value; }
        }
        #endregion
    }
}
