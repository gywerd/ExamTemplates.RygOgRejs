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
        private int BoolToBit(bool b)
        {
            int bit = 0;
            if (b == true)
            {
                bit = 1;
            }
            return bit;
        }

        public ObservableCollection<Journey> GetAll()
        {
            string query = "SELECT * FROM Journeys";
            ObservableCollection<Journey> journeyCol = new ObservableCollection<Journey>();
            DataSet data = executor.Execute(query); //ayy lmao
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
            string query = $"SELECT * FROM Journeys WHERE JourneyId = {id.ToString()}";
            Journey journey = new Journey();
            DataSet data = executor.Execute(query); //ayy lmao
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

        //reload list? also this should update the database 
        public void UpdateJourney(int id, string destination, DateTime depatureTime, int adults, int children, bool isFirstClass, int luggageAmount) //find better way?
        {
            //depature time might break it all xD
            string query = $"UPDATE Journeys SET Destination = '{destination}', DepartureTime = {depatureTime.ToString("yyyy-MM-dd")}, Adults = {adults.ToString()}, Children = {children.ToString()}, IsFirstClass = {BoolToBit(isFirstClass).ToString()}, LuggageAmount = {luggageAmount.ToString()}  WHERE JourneyId = {id.ToString()}";
            executor.Execute(query);
        }
        public void UpdateJourney(Journey j) //find better way?
        {
            //depature time might break it all xD
            string query = $"UPDATE Journeys SET Destination = '{j.Destination}', DepartureTime = {j.DepatureTime.ToString("yyyy-MM-dd")}, Adults = {j.Adults}, Children = {j.Children}, IsFirstClass = {BoolToBit(j.IsFirstClass).ToString()}, LuggageAmount = {j.LuggageAmount}  WHERE JourneyId = {j.JourneyId.ToString()}";
            executor.Execute(query);
        }

        //load new list ?
        public void DeleteJourney(int id)
        {
            string query = $"DELETE FROM Journeys WHERE JourneyId = {id}";
            executor.ExecuteNonQuery(query);
        }
    }
}
