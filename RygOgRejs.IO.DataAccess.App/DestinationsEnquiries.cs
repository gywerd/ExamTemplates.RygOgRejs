﻿using RygOgRejs.Bizz.Entities;
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
        /// <param name="price">Price</param>
        public void AddPrice(Destination price)
        {
            string query = $"INSERT INTO Price (DestinationName, AdultPrice, ChildrenPrice) VALUES ('{price.DestinationName}', {price.AdultPrice}, {price.ChildPrice})";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that removes a row from the database
        /// </summary>
        /// <param name="id">int</param>
        public void DeletePrices(int id)
        {
            string query = $"DELETE FROM Price WHERE DestintionId = {id}";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that loads all Prices from database
        /// </summary>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Destination> GetAll()
        {
            string query = "SELECT * FROM Price";
            ObservableCollection<Destination> priceList = new ObservableCollection<Destination>();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["DestinationId"]);
                string destination = reader["DestinationName"].ToString();
                float adult = Convert.ToSingle(reader["AdultPrice"]);
                float child = Convert.ToSingle(reader["ChildrenPrice"]); //nice spelling error xD old Name: ChildrenPricedd - spelling error in DB corrected
             //   Price p = new Price(id, destination, adult, child);
               // priceList.Add(p);
            }
            return priceList;
        }

        /// <summary>
        /// Method, that loads all Destinations from database
        /// </summary>
        /// <returns>ObservableCollection</returns>
        public List<DestinationList> GetDestinationList()
        {
            string query = "SELECT * FROM Price";
            List<DestinationList> destinationList = new List<DestinationList>();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["DestinationId"]);
                string destination = reader["DestinationName"].ToString();
                DestinationList d = new DestinationList(id, destination);
                destinationList.Add(d);
            }
            return destinationList;
        }

        /// <summary>
        /// Method that loads a specific row in the database 
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Price</returns>
        public Destination GetPrice(int id)
        {
            Destination p = new Destination();
            string query = $"SELECT * FROM Transaction WHERE DestinationId = {id}";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int destid = Convert.ToInt32(reader["DestinationId"]);
                string destination = reader["DestinationName"].ToString();
                float adult = Convert.ToSingle(reader["AdultPrice"]);
                float child = Convert.ToSingle(reader["ChildrenPrice"]);
                float first = Convert.ToSingle(reader["FirstClassPrice"]);
                float lug = Convert.ToSingle(reader["LuggagePrice"]);
                p = new Destination(destid, destination, adult, child, first, lug);
            }
            return p;
        }

        /// <summary>
        /// Method, that updates a row in the database from object
        /// </summary>
        /// <param name="price">Price</param>
        public void UpdatePrices(Destination price)
        {
            string query = $"INSERT INTO Price (DestinationName, AdultPrice, ChildrenPrice) VALUES({price.DestinationName}, {price.AdultPrice}, {price.ChildPrice}";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that updates a row in the database from data
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="destination">string</param>
        /// <param name="adults">int</param>
        /// <param name="child">int</param>
        /// <param name="first">bool</param>
        /// <param name="lug">float</param>
        public void UpdatePrices(int id, string destination, float adults, float child, float first, float lug) //find better way?
        {
           string query = $"UPDATE Price SET Destination = '{destination}', AdultPrice = {adults}, ChildrenPrice = {child}, FirstClassPrice = {first}, LuggagePrice = {lug}  WHERE DestinationId = {id}";
           executor.ExecuteNonQuery(query);
        }
        #endregion
    }
}
