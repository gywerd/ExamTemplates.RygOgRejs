using RygOgRejs.Bizz;
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
    public class PriceEnquiries : DataEnquiries
    {
        public ObservableCollection<PriceDetails> GetAll()
        {
            string query = "SELECT * FROM Price";
            ObservableCollection<PriceDetails> priceList = new ObservableCollection<PriceDetails>();
            DataSet data = executor.Execute(query); //ayy lmao
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["DestinationId"]);
                string destination = reader["DestinationName"].ToString();
                float adult = Convert.ToSingle(reader["AdultPrice"]);
                float child = Convert.ToSingle(reader["ChildrenPrice"]);
                float first = Convert.ToSingle(reader["FirstClassPrice"]);
                float lug = Convert.ToSingle(reader["LuggagePrice"]);
                PriceDetails p = new PriceDetails(id, destination, adult, child, first, lug);
                priceList.Add(p);
            }
            return priceList;
        }

        //kun vis vi ændre priser
        public void AddPrice(PriceDetails price) //find better way?
        {
            //depature time might break it all xD
            string query = $"INSERT INTO Price (DestinationName, AdultPrice, ChildrenPrice,FirstClassPrice,LuggagePrice) VALUES({price.DestinationName}, {price.AdultPrice}, {price.ChildPrice}, {price.FirstClassPrice}, {price.LuggagePrice}";
            executor.ExecuteNonQuery(query);
        }
        //reload list? also this should update the database 
        public void UpdatePriceDetails(PriceDetails p) //find better way?
        {
            //depature time might break it all xD
            string query = $"UPDATE Price SET Destination = '{p.DestinationName}', AdultPrice = {p.AdultPrice}, ChildrenPrice = {p.ChildPrice}, FirstClassPrice = {p.FirstClassPrice}, LuggagePrice = {p.LuggagePrice}  WHERE DestinationId = {p.DestinationId}";
            executor.ExecuteNonQuery(query);
        }
        //reload list? also this should update the database 
        public void UpdatePriceDetails(int id, string destination, float adults, float child, float first, float lug) //find better way?
        {
            //depature time might break it all xD
            string query = $"UPDATE Price SET Destination = '{destination}', AdultPrice = {adults}, ChildrenPrice = {child}, FirstClassPrice = {first}, LuggagePrice = {lug}  WHERE DestinationId = {id}";
            executor.ExecuteNonQuery(query);
        }

        //load new list ?
        public void DeletePriceDetails(int id)
        {
            string query = $"DELETE FROM Price WHERE DestintionId = {id}";
            executor.ExecuteNonQuery(query);
        }
    }
}
