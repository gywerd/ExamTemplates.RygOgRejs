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
            #region Ordinary Fields
            private Totals dailyTotals; //object that holds data, that can be bound to left panel in MainWindow
            private string destination; //string that holds a destination
            private string journeyOrTransaction; //string that controls how UIInsertUpdate & UIPayment acts
            private Master master = new Master(); //object to store masterID within
            private Journey tempJourney = new Journey(); //object to temporarily store current journey information, before writing it to the database
            private Payer tempPayer = new Payer(); //object to temporarily store current payer information, before writing it to the database   
            private Transactions tempTransaction = new Transactions(); //string to temporarily store current transaction information, before writing it to the database
            private Transactions tempTransactionUpdate = new Transactions(); //string to temporarily store current transaction information, before writing it to the database
            private PriceDetails tempPriceDetails = new PriceDetails(); //string to temporarily store current pricedetails, to show on GUI
            private string macAddress = (from nic in NetworkInterface.GetAllNetworkInterfaces() where nic.OperationalStatus == OperationalStatus.Up select nic.GetPhysicalAddress().ToString()).FirstOrDefault(); //string where current macadress is stored
            #endregion

            #region Method Fields
            Destination CDE = new Destination();
            Journey CJE = new Journey(); //used to call methods
            JourneyEnquiries CJI = new JourneyEnquiries(); //used to call methods
            Payer CPaE = new Payer(); //used to call methods
            PayerEnquiries CPaI = new PayerEnquiries(); //used to call methods
            Price CPrE = new Price(); //used to call methods
            PriceEnquiries CPrI = new PriceEnquiries(); //used to call methods
            Transactions CTE = new Transactions(); //used to call methods
            TransactionEnquiries CTI = new TransactionEnquiries(); //used to call methods
            MasterId CMI = new MasterId(); //used to call methods
            MasterIdEnquiries CMIE = new MasterIdEnquiries(); //used to call methods
            #endregion

            #region List, Array And Collection Fields
            ObservableCollection<Journey> journeys = new ObservableCollection<Journey>(); //Collection containing journeys stored in database
            ObservableCollection<Payer> payers = new ObservableCollection<Payer>();  //Collection containing payers stored in database
            ObservableCollection<Transactions> transactions = new ObservableCollection<Transactions>(); //Collection containing trnsactions stored in database
            ObservableCollection<Price> prices = new ObservableCollection<Price>(); //Collection containing prices stored in database
            List<string> destinations = new List<string>(); //List containing available destinations to be viewed in DataViewJourneys
            List<Destination> newDestinations; //List containing available destinations to be viewed in DataViewJourneys
            #endregion
        #endregion

        #region Events
        /// <summary>
        /// Event, that handles updating fields in UserControl
        /// </summary>
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
        /// Adds row to Payers, Transactions and Journeys tables in DB
        /// </summary>
        /// <param name="u"></param>
        public void CreateJourney() //removed params from method
        {
            //MasterId is generated and added  to tempPayer, tempJourney & tempTransaction, when UIOpret is loaded
            //All data is written simutaneusly to tempPayer, tempJourney & tempTransaction, and price incl. VAT is calculated while manipulating GUI
            CPaI.AddPayer(tempPayer); //Writes Journey data to DB
            CJI.AddJourney(tempJourney);//Writes Journey data to DB
            tempJourney = CJI.GetJourney(master.Id);
            TempTransaction.JourneyId = TempJourney.JourneyId;
            CTI.AddTransaction(tempTransaction);  //Writes Transaction data to DB
            RefreshObservableCollections(); //Updates content of ObservableCollections from DB
            UpdateDailyTotals(); //updates content of dailyTotals
            ClearTemporaryFields(); //Clears content of tempPayer, tempJourney & tempTransaction
        }

        /// <summary>
        /// Code behind DeleteJourney-button
        /// Deletes row in Journeys and Transactions tables in DB
        /// </summary>
        /// <param name="u"></param>
        public void DeleteJourney()
        {
            CJI.DeleteJourney(tempJourney.JourneyId); //dis aint working - changed from GetJourney to DeleteJourney ;)
            CTI.DeleteTransaction(tempTransaction.TransactionId);
            UpdateDailyTotals(); //updates content of dailyTotals
            RefreshObservableCollections(); //Updates content of ObservableCollections from DB
            ClearTemporaryFields(); //Clears content of tempPayer, tempJourney & tempTransaction
            throw new NotImplementedException();
        }

        /// <summary>
        /// Code behind EditJourney-button
        /// Updates row in Journeys & Transactions tables in DB
        /// </summary>
        /// <param name="u"></param>
        public void EditJourney()
        {
            //MasterId is loaded into tempPayer, tempJourney & tempTransaction, when UIUpdate is loaded
            //All data is written simutaneusly to tempPayer, tempJourney & tempTransaction, and refund price incl. VAT is calculated while manipulating GUI
            CJI.UpdateJourney(tempJourney); //Writes content of tempJourney to Database
            CTI.UpdateTransaction(tempTransactionUpdate); //Writes content of tempJourney to Database
            UpdateDailyTotals(); //updates content of dailyTotals
            RefreshObservableCollections(); //Updates content of ObservableCollections from DB
            ClearTemporaryFields(); //Clears content of tempPayer, tempJourney & tempTransaction
            throw new NotImplementedException();
        }

        /// <summary>
        /// Code behind ExecutePayments-button
        /// Button removed from GUI - redundant after SCRUM-decision to edit UserControls
        /// </summary>
        public void ExecutePayment()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Code behind ExecuteRefusion-button
        /// Button removed from GUI - redundant after SCRUM-decision to edit UserControls
        /// </summary>
        public void ExecuteRefusion()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Method, that generates a list of destinations
        /// Redundant - replaced by GetAllDestinations
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
        /// Method that loads list of destinations with DestinationId from the PriceDetails table in DB
        /// Destinations can be shown in DataViewJourneys
        /// And connection in code between prices and destinations can be done by comparing DestinationId
        /// </summary>
        public void GetAllDestinations()
        {
            newDestinations = CPrI.GetAllDestinations();
        }

        /// <summary>
        /// Method, that invokes reading all rows in the Journeys table from database
        /// </summary>
        private void GetJourneys()
        {
            journeys = CJI.GetAll();
        }

        /// <summary>
        /// Method, that invokes reading all rows in the Payers table from database
        /// </summary>
        private void GetPayers()
        {
            payers = CPaI.GetAllPayers();
        }

        /// <summary>
        /// Method, that invokes reading all rows in the Pricedetails table from database
        /// </summary>
        /// <returns></returns>
        private void GetPrices()
        {
            prices = CPrI.GetAll();
        }

        /// <summary>
        /// Method, that invokes reading all rows in the Transactions table from database
        /// </summary>
        private void GetTransactions()
        {
            transactions = CTI.GetAll();
        }

        /// <summary>
        /// Loads content of selected payer and journey into tempPayer & tempJourney
        /// </summary>
        public void LoadTransactionAndJourney()
        {
            tempTransaction = CTI.GetTransaction(master.Id);
            tempJourney = CJI.GetJourney(master.Id);
        }

        /// <summary>
        /// Method that inserts a dummy entry in the dummy table Master in DB to create a MasterID - then removes the dummy entry
        /// </summary>
        public void CreateMasterid()
        {
            CMIE.CreateID(macAddress);
            master.Id = CMIE.GetId();
            CMIE.DeleteId(master.Id);
        }
        public void GiveMasterID(int id)
        {
            CMI.Id = id;
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


        public void UpdateDailyTotals()
        {
            //RefreshSoldTravels();
            dailyTotals.AmountOfSoldTravels = transactions.Count;
            //RefreshAmountPassengers();
            dailyTotals.AmountOfPassengers = transactions.Count * 5;
            //RefreshAmountOfCOfAdults();
            dailyTotals.AmountOfAdults = transactions.Count * 3;
            //RefreshAmountOfChildren();
            dailyTotals.AmountofChildren = transactions.Count * 2;
            //RefresTotalSaleAmount();
            dailyTotals.TotalSaleAmount = transactions.Count * 5432;
        }

        private void RefreshAmountOfCOfAdults()
        {
            throw new NotImplementedException();
        }

        private void RefresTotalSaleAmount()
        {
            throw new NotImplementedException();
        }

        private void RefreshAmountOfChildren()
        {
            throw new NotImplementedException();
        }

        private void RefreshAmountPassengers()
        {
            throw new NotImplementedException();
        }

        private void RefreshSoldTravels()
        {
            throw new NotImplementedException();
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
        public List<Destination> NewDestinations { get => newDestinations; set => newDestinations = value; }
        public Master Master { get => master; set => master = value; }
        public Transactions TempTransactionUpdate { get => tempTransactionUpdate; set => tempTransactionUpdate = value; }
        public Totals DailyTotals { get => dailyTotals; set => dailyTotals = value; }
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
