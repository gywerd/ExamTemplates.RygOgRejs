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
        private Journey tempJourney = new Journey();
        private Payer tempPayer = new Payer();
        private Transactions tempTransaction = new Transactions();
        private PriceDetails tempPriceDetails = new PriceDetails();
        private string macAddress = (from nic in NetworkInterface.GetAllNetworkInterfaces() where nic.OperationalStatus == OperationalStatus.Up select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
        Journey CJE = new Journey();
        JourneyEnquiries CJI = new JourneyEnquiries();
        Payer CPaE = new Payer();
        PayerEnquiries CPaI = new PayerEnquiries();
        Price CPrE = new Price();
        PriceEnquiries CPrI = new PriceEnquiries();
        Transactions CTE = new Transactions();
        TransactionEnquiries CTI = new TransactionEnquiries();
        MasterId CMI = new MasterId();
        ObservableCollection<Journey> journeys = new ObservableCollection<Journey>();
        ObservableCollection<Payer> payers = new ObservableCollection<Payer>();
        ObservableCollection<Transactions> transactions = new ObservableCollection<Transactions>();
        ObservableCollection<Price> prices = new ObservableCollection<Price>();
        List<string> destinations = new List<string>();
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        /// <summary>
        /// Code that clears journey, payer & transaction fields after completed sale
        /// </summary>
        public void ClearTemporaryFields()
        {
            tempJourney = new Journey();
            tempPayer = new Payer();
            tempTransaction = new Transactions();
            tempPriceDetails = new PriceDetails();
        }

        /// <summary>
        /// Code behind CreateJourney-button
        /// </summary>
        /// <param name="u"></param>
        public void CreateJourney()
        {
            Journey kage = new Journey("LEPA - PALMA DE MALLORCA, Spain", DateTime.Now, 2, 3, true, 23);
            CJI.AddJourney(kage);
//            throw new NotImplementedException();
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
        /// Code behind ExecutePayments-button
        /// </summary>
        public void ExecutePayment()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Code behind ExecuteRefusion-button
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
            ObservableCollection<Price> PriceDetailEnq = CPrI.GetAll();
            foreach (Price price in PriceDetailEnq)
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
            payers = CPaI.GetAllPayers();
        }

        /// <summary>
        /// Method, that invokes reading pricedetails from database
        /// </summary>
        /// <returns></returns>
        private void GetPrices()
        {
            prices = CPrI.GetAll();
        }

        /// <summary>
        /// Method, that invokes reading transactions from database
        /// </summary>
        private void GetTransactions()
        {
            transactions = CTI.GetAll();
        }

        /// <summary>
        /// Code that clears and reloads content of ObservAbleCollections
        /// </summary>
        public void RefreshObservableCollections()
        {
            journeys.Clear();
            payers.Clear();
            prices.Clear();
            transactions.Clear();
            GetJourneys();
            GetPayers();
            GetPrices();
            GetTransactions();
        }

        #endregion

        #region Properties
        public string Destination { get => destination; set => destination = value; }
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
        public Journey Journey { get => tempJourney; set => tempJourney = value; }
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
        public string JourneyOrTransaction { get => journeyOrTransaction; set => journeyOrTransaction = value; }
        public Payer Payer { get => tempPayer; set => tempPayer = value; }
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
        public PriceDetails PriceDetails { get => tempPriceDetails; set => tempPriceDetails = value; }
        public ObservableCollection<Price> Prices
        {
            get
            {
                if (prices.Count <= 0)
                {
                    GetPrices();
                }
                return prices;
            }
            set => prices = value;
        }
        public ObservableCollection<Transactions> Transactions
        {
            get
            {
                if (transactions.Count <= 0)
                {
                    GetTransactions();
                }
                return transactions;
            }
            set => transactions = value;
        }
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
