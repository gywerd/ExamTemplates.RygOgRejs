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
        public ObservableCollection<Price> GetAll()
        {
            string query = "SELECT * FROM Price";
            ObservableCollection<Price> priceList = new ObservableCollection<Price>();
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
                Price p = new Price(id, destination, adult, child, first, lug);
                priceList.Add(p);
            }
            return priceList;
        }

        //reload list? also this should update the database 
        public void UpdatePrices(Price p) //wat
        {
            //depature time might break it all xD
         //   string query = $"INSERT INTO Price (DestinationName, AdultPrice, ChildrenPrice,FirstClassPrice,LuggagePrice) VALUES({price.DestinationName}, {price.AdultPrice}, {price.ChildPrice}, {price.FirstClassPrice}, {price.LuggagePrice}";
           // executor.ExecuteNonQuery(query);
        }

        //reload list? also this should update the database 
        public void UpdatePrices(int id, string destination, float adults, float child, float first, float lug) //find better way?
        {
            //depature time might break it all xD
           // string query = $"UPDATE Price SET Destination = '{p.DestinationName}', AdultPrice = {p.AdultPrice}, ChildrenPrice = {p.ChildPrice}, FirstClassPrice = {p.FirstClassPrice}, LuggagePrice = {p.LuggagePrice}  WHERE DestinationId = {p.DestinationId}";
           // executor.ExecuteNonQuery(query);
        }

        //load new list ?
        public void DeletePrices(int id)
        {
            string query = $"DELETE FROM Price WHERE DestintionId = {id}";
            executor.ExecuteNonQuery(query);
        }
    }
}
