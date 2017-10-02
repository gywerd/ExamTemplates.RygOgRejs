using RygOgRejs.Bizz.Entities;
using RygOgRejs.IO.DataAccess.App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.App
{
    public class AppBizz : INotifyPropertyChanged
    {
        #region Fields
        private string destination; //string that holds a destination
        private string journeyOrTransaction; //string that controls how UIInsertUpdate & UIPayment acts
        private Master master;
        private Journey tempJourney = new Journey(); //string to temporarily store current journey information, before writing it to the database
        private Payer tempPayer = new Payer(); //string to temporarily store current payer information, before writing it to the database
        private Transactions tempTransaction = new Transactions(); //string to temporarily store current transaction information, before writing it to the database
        private PriceDetails tempPriceDetails = new PriceDetails(); //string to temporarily store current pricedetails, to show on GUI
        //string where current macadress is stored
        private string macAddress = (from nic in NetworkInterface.GetAllNetworkInterfaces() where nic.OperationalStatus == OperationalStatus.Up select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
        Journey CJE; //used to call methods

        JourneyEnquiries CJI = new JourneyEnquiries(); //used to call methods
        Payer CPaE = new Payer(); //used to call methods
        PayerEnquiries CPaI = new PayerEnquiries(); //used to call methods
        Price CPrE = new Price(); //used to call methods
        PriceEnquiries CPrI = new PriceEnquiries(); //used to call methods
        Transactions CTE = new Transactions(); //used to call methods
        TransactionEnquiries CTI = new TransactionEnquiries(); //used to call methods
        MasterId CMI = new MasterId(); //used to call methods
        ObservableCollection<Journey> journeys = new ObservableCollection<Journey>(); //Collection containing journeys stored in database
        ObservableCollection<Payer> payers = new ObservableCollection<Payer>();  //Collection containing payers stored in database
        ObservableCollection<Transactions> transactions = new ObservableCollection<Transactions>(); //Collection containing trnsactions stored in database
        ObservableCollection<Price> prices = new ObservableCollection<Price>(); //Collection containing prices stored in database
        List<string> destinations = new List<string>(); //List containing available destinations to be viewed in DataViewJourneys
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        /// <summary>
        /// Code that clears temporary journey, payer & transaction fields after completed sale
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
        public void CreateJourney(int AntalAdults, int AntalChildren, int AntalLuggage, bool IsFirstclass)
        {
            Journey kage = new Journey(TempJourney.Destination, DateTime.Now, AntalAdults, AntalChildren, IsFirstclass,AntalLuggage, master.Id); //Added masterId to code /daniel
            CJI.AddJourney(kage);
        }

        /// <summary>
        /// Code behind DeleteJourney-button
        /// </summary>
        /// <param name="u"></param>
        public void DeleteJourney()
        {
            CJI.GetJourney(CJE.JourneyId); //dis aint working
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

        public void CreateMasterid(AppBizz kage)
        {

        }

        /// <summary>
        /// Code that clears & reloads content of ObservAbleCollections - used after saving to the database
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
        public Journey TempJourney { get => tempJourney; set => tempJourney = value; } 
        public Payer TempPayer { get => tempPayer; set => tempPayer = value; } //Corrected name
        public PriceDetails TempPriceDetails { get => tempPriceDetails; set => tempPriceDetails = value; } //Corrected name
        public Transactions TempTransaction { get => tempTransaction; set => tempTransaction = value; }
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
