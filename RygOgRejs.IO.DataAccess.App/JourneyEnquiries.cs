using RygOgRejs.Bizz.Entities;
using RygOgRejs.IO.DataAccess.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace RygOgRejs.IO.DataAccess.App
{
    public class JourneyEnquiries : DataEnquiries
    {
        #region Constructors
        public JourneyEnquiries() { }
        #endregion

        #region Methods
        /// <summary>
        /// Method, that inserts a row into the database
        /// </summary>
        /// <param name="jour">Journey</param>
        public void AddJourney(Journey jour)
        {

            string query = $"INSERT INTO Journeys (Destination, DepartureTime, Adults,Children,IsFirstClass,LuggageAmount) VALUES ('{jour.Destination}', '{jour.DepatureTime}', {jour.Adults}, {jour.Children},' {jour.IsFirstClass}', {jour.LuggageAmount})";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that removes a row from the database
        /// </summary>
        /// <param name="id">int</param>
        public void DeleteJourney(int id)
        {
            string query = $"DELETE FROM Journeys WHERE JourneyId = {id}";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that loads all Journeys from database
        /// </summary>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Journey> GetAll()
        {
            string query = "SELECT * FROM Journeys";
            ObservableCollection<Journey> journeyCol = new ObservableCollection<Journey>();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader(); //best
            while(reader.Read())
            {
                int id = Convert.ToInt32(reader["JourneyId"]);
                string destination = reader["Destination"].ToString();
                DateTime depatureTime = Convert.ToDateTime(reader["DepartureTime"]);
                int adults = Convert.ToInt32(reader["Adults"]);
                int children = Convert.ToInt32(reader["Children"]);
                bool isFirstClass = Convert.ToBoolean(reader["IsFirstClass"]);
                int luggageAmount = Convert.ToInt32(reader["LuggageAmount"]);
                Journey journey = new Journey(id,destination, depatureTime, adults, children, isFirstClass, luggageAmount);
                journeyCol.Add(journey);
            }
            return journeyCol;
        }

        /// <summary>
        /// Method that loads a specific row in the database 
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Journey</returns>
        public Journey GetJourney(int id)
        {
            string query = $"SELECT * FROM Journeys WHERE JourneyId = {id}";
            Journey journey = new Journey();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int jid = Convert.ToInt32(reader["JourneyId"]);
                string destination = reader["Destination"].ToString();
                DateTime depatureTime = Convert.ToDateTime(reader["DepartureTime"]);
                int adults = Convert.ToInt32(reader["Adults"]);
                int children = Convert.ToInt32(reader["Children"]);
                bool isFirstClass = Convert.ToBoolean(reader["IsFirstClass"]);
                int luggageAmount = Convert.ToInt32(reader["LuggageAmount"]);
                journey = new Journey(jid, destination, depatureTime, adults, children, isFirstClass, luggageAmount); 
            }
            return journey;
        }

        /// <summary>
        /// Method, that updates a row in the database
        /// </summary>
        /// <param name="j">Journey</param>
        public void UpdateJourney(Journey j)
        {

            string query = $"UPDATE Journeys SET Destination = '{j.Destination}', DepartureTime = {j.DepatureTime.ToString("yyyy-MM-dd")}, Adults = {j.Adults}, Children = {j.Children}, IsFirstClass = {j.IsFirstClass}, LuggageAmount = {j.LuggageAmount}  WHERE JourneyId = {j.JourneyId}";
            executor.ExecuteNonQuery(query);
        }

        #endregion
    }
}
