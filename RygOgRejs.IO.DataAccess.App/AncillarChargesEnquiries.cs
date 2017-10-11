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
    class AncillarChargesEnquiries : DataEnquiries
    {
        public void GetAll()
        {
            string query = "SELECT * FROM AncillarCharges";
            ObservableCollection<Price> priceList = new ObservableCollection<Price>();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["WaitngForName"]);
                float firstClassPrice = Convert.ToSingle(reader["WaitingForName"]);
                float luggaPriceOverload = Convert.ToSingle(reader["WaitingForName"]); //nice spelling error xD old Name: ChildrenPricedd - spelling error in DB corrected
                //price prices = new price(id,FirstClassPrice,LuggaPriceOverload)
            }
        }

    }
}
