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
                int id = Convert.ToInt32(reader["DestinatonId"]);
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


        //reload list? also this should update the database 
        public void UpdatePriceDetails(PriceDetails p) //find better way?
        {
            //depature time might break it all xD
            string query = $"UPDATE Price SET Destination = '{p.DestinationName}', AdultPrice = {p.AdultPrice.ToString()}, ChildrenPrice = {p.ChildPrice.ToString()}, FirstClassPrice = {p.FirstClassPrice.ToString()}, LuggagePrice = {p.LuggagePrice.ToString()}  WHERE DestinationId = {p.DestinationId.ToString()}";
            executor.Execute(query);
        }
        //reload list? also this should update the database 
        public void UpdatePriceDetails(int id, string destination, float adults, float child, float first, float lug) //find better way?
        {
            //depature time might break it all xD
            string query = $"UPDATE Price SET Destination = '{destination}', AdultPrice = {adults.ToString()}, ChildrenPrice = {child.ToString()}, FirstClassPrice = {first.ToString()}, LuggagePrice = {lug.ToString()}  WHERE DestinationId = {id}";
            executor.Execute(query);
        }

        //load new list ?
        public void DeletePriceDetails(int id)
        {
            string query = $"DELETE FROM Price WHERE DestintionId = {id}";
            executor.Execute(query);
        }
    }
}
