using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RygOgRejs.IO.DataAccess.General;
using RygOgRejs.Bizz;
using System.Collections.ObjectModel;

namespace RygOgRejs.IO.DataAccess.App
{
    public class JourneyEnquiries : DataEnquiries
    {
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

        public void AddJourney(Journey journ)
        {

            string query = $"INSERT INTO Journeys (Destination, DepartureTime, Adults,Children,IsFirstClass,LuggageAmount) VALUES ('{journ.Destination}', {journ.DepatureTime.ToString("yyyy-MM-dd")}, {journ.Adults}, {journ.Children},' {journ.IsFirstClass}', {journ.LuggageAmount})";
            executor.ExecuteNonQuery(query);
        }

        public void UpdateJourney(Journey j)
        {

            string query = $"UPDATE Journeys SET Destination = '{j.Destination}', DepartureTime = {j.DepatureTime.ToString("yyyy-MM-dd")}, Adults = {j.Adults}, Children = {j.Children}, IsFirstClass = {j.IsFirstClass}, LuggageAmount = {j.LuggageAmount}  WHERE JourneyId = {j.JourneyId}";
            executor.ExecuteNonQuery(query);
        }


        public void DeleteJourney(int id)
        {
            string query = $"DELETE FROM Journeys WHERE JourneyId = {id}";
            executor.ExecuteNonQuery(query);
        }
    }
}
