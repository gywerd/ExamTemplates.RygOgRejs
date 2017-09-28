using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RygOgRejs.IO.DataAccess.General;
using RygOgRejs.Bizz;
using System.Data;

namespace RygOgRejs.IO.DataAccess.App
{
    public class JourneyEnquiries : DataEnquiries
    {
        public List<Journey> GetAll()
        {
            string query = "SELECT * FROM Journeys";
            List<Journey> journeyList = new List<Journey>();
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
                int luggaAmount = Convert.ToInt32(reader["LuggageAmount"]);
                Journey journey = new Journey(id,destination, depatureTime, adults, children, isFirstClass, luggaAmount);
                journeyList.Add(journey);
            }
            return journeyList;
        }


        //reload list? also this should update the database 
        public void UpdateJourney(int id, string destination, DateTime depatureTime, int adults, int children, bool isFirstClass, int luggaAmount) //find better way?
        {
            //depature time might break it all xD
            string query = $"UPDATE Journeys SET Destination = '{destination}', DepartureTime = {depatureTime}, Adults = {adults}, Children = {children}, IsFirstClass = {isFirstClass}, LuggageAmount = {luggaAmount}  WHERE JourneyId = {id}";
            executor.ExecuteNonQuery(query);
        }

        //load new list ? alas dis works
        public void DeleteJounry(int id)
        {
            string query = $"DELETE FROM Journeys WHERE JourneyId = {id}";
            executor.ExecuteNonQuery(query);
        }
    }
}
