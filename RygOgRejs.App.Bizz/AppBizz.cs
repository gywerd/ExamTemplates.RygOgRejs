using RygOgRejs.Bizz;
using RygOgRejs.IO.DataAccess.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.App.Bizz
{
    public class AppBizz : INotifyPropertyChanged
    {
        #region Fields
        private string destination;
        private string journeyOrTransaction;
        private Journey journey = new Journey();
        private Payer payer = new Payer();
        private string macAddress = (from nic in NetworkInterface.GetAllNetworkInterfaces() where nic.OperationalStatus == OperationalStatus.Up select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
        Journey CJE = new Journey();
        JourneyEnquiries CJI = new JourneyEnquiries();
        Payer CPaE = new Payer();
        PayerEnquiries CPaI = new PayerEnquiries();
        PriceDetails CPrE = new PriceDetails();
        PriceEnquiries CPrI = new PriceEnquiries();
        Transactions CTE = new Transactions();
        TransactionEnquiries CTI = new TransactionEnquiries();
        MasterId CMI = new MasterId();
        ObservableCollection<Journey> journeys = new ObservableCollection<Journey>();
        ObservableCollection<Payer> payers = new ObservableCollection<Payer>();
        ObservableCollection<Transactions> transactions = new ObservableCollection<Transactions>();
        List<string> destinations = new List<string>();
        ObservableCollection<PriceDetails> priceDetails;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        /// <summary>
        /// Code behind that clears and reloads content of ObservAbleCollections
        /// </summary>
        public void RefreshObservableCollections()
        {
            journeys.Clear();
            payers.Clear();
            priceDetails.Clear();
            transactions.Clear();
            GetJourneys();
            GetPayers();
            GetPricetails();
            GetTransactions();
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
            throw new NotImplementedException();
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
        /// Method, that generates a list of destinations
        /// </summary>
        private void GetDestinations()
        {
            var PriceDetailEnq = CPrI.GetAll();
            foreach (PriceDetails price in PriceDetailEnq)
            {
                destinations.Add(price.DestinationName);
            }
        }

        /// <summary>
        /// Method, that invokes reading journeys from database
        /// </summary>
        private void GetJourneys()
        {
            journeys = CJI.GetAll();
        }

        /// <summary>
        /// Method, that invokes reading payers from database
        /// </summary>
        private void GetPayers()
        {
            payers = CPaI.GetAll(); ;
        }

        /// <summary>
        /// Method, that invokes reading pricedetails from database
        /// </summary>
        /// <returns></returns>
        private void GetPricetails()
        {
            priceDetails = CPrI.GetAll();
        }

        /// <summary>
        /// Method, that invokes reading transactions from database
        /// </summary>
        private void GetTransactions()
        {
            transactions = CTI.GetAll();
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
        public ObservableCollection<PriceDetails> PriceDetails { get => priceDetails; set => priceDetails = value; }
        #endregion

        #region Internal Classes
        internal class MasterId : IPersistable
        {
            private int id;
            public MasterId() { }
            public MasterId(int id)
            {
                Id = id;
            }
            public int Id { get => id; set => id = value; }
        }
        #endregion

    }
}
