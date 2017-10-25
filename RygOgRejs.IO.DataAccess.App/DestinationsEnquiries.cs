using RygOgRejs.Bizz.Entities;
using RygOgRejs.IO.DataAccess.General;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.IO.DataAccess.App
{
    public class DestinationsEnquiries : DataEnquiries
    {
        #region Constructors
        public DestinationsEnquiries() { }
        #endregion

        #region Methods
        /// <summary>
        /// Method, that inserts a row into the database
        /// </summary>
        /// <param name="destination">Price</param>
        public void AddDestination(Destination destination)
        {
            string query = $"INSERT INTO Destinations (DestinationName, AdultPrice, ChildrenPrice) VALUES ('{destination.DestinationName}', {destination.AdultPrice}, {destination.ChildPrice})";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that removes a row from the database
        /// </summary>
        /// <param name="id">int</param>
        public void DeleteDestination(int id)
        {
            string query = $"DELETE FROM Destinations WHERE DestinationId = {id}";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that loads all Prices from database
        /// </summary>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Destination> GetAll()
        {
            string query = "SELECT * FROM Destinations";
            ObservableCollection<Destination> priceList = new ObservableCollection<Destination>();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["DestinationId"]);
                string destination = reader["DestinationName"].ToString();
                string iata = reader["IATA"].ToString();
                string icao = reader["ICAO"].ToString();
                string country = reader["CountryCode"].ToString();
                decimal adult = Convert.ToDecimal(reader["AdultPrice"]);
                decimal child = Convert.ToDecimal(reader["ChildrenPrice"]); //nice spelling error xD old Name: ChildrenPricedd - spelling error in DB corrected
                Destination d = new Destination(id, destination, iata, icao, country, adult, child);
                priceList.Add(d);
            }
            return priceList;
        }

        /// <summary>
        /// Method, that loads all Destinations from database
        /// </summary>
        /// <returns>ObservableCollection</returns>
        public List<DestinationList> GetDestinationList()
        {
            string query = "SELECT * FROM Destinations";
            List<DestinationList> destinationList = new List<DestinationList>();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["DestinationId"]);
                string destination = reader["DestinationName"].ToString();
                string iata = reader["IATA"].ToString();
                string icao = reader["ICAO"].ToString();
                string country = reader["CountryCode"].ToString();
                DestinationList d = new DestinationList(id, destination, iata, icao, country);
                destinationList.Add(d);
            }
            return destinationList;
        }

        /// <summary>
        /// Method, that updates a row in the database from object
        /// </summary>
        /// <param name="destination">Price</param>
        public void UpdateDestination(Destination destination)
        {
            string query = $"INSERT INTO Destinations (DestinationName, AdultPrice, ChildrenPrice) VALUES({destination.DestinationName}, {destination.AdultPrice}, {destination.ChildPrice} WHERE DestinationId = {destination.DestinationId}";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that updates a row in the database from data, plz dont use remove at somepoint
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="destination">string</param>
        /// <param name="adults">int</param>
        /// <param name="child">int</param>
        /// <param name="first">bool</param>
        /// <param name="lug">decimal</param>
        public void UpdatePrices(int id, string destination, decimal adults, decimal child, decimal first, decimal lug) //find better way?
        {
           string query = $"UPDATE Price SET Destination = '{destination}', AdultPrice = {adults}, ChildrenPrice = {child}, FirstClassPrice = {first}, LuggagePrice = {lug}  WHERE DestinationId = {id}";
           executor.ExecuteNonQuery(query);
        }
        #endregion
    }
}
