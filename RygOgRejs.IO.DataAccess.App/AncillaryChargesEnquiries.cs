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
    public class AncillaryChargesEnquiries : DataEnquiries
    {
        public ObservableCollection<AncillaryCharge> GetAllAncillaryCharges()
        {
            string query = "SELECT * FROM AncillaryCharges";
            ObservableCollection<AncillaryCharge> priceList = new ObservableCollection<AncillaryCharge>();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                decimal firstClassPrice = Convert.ToDecimal(reader["FirstClassPrice"]);
                decimal luggaPriceOverload = Convert.ToDecimal(reader["LuggagePricePerOverloadKg"]); //spelling error in DB corrected
                AncillaryCharge ancillaryCharge = new AncillaryCharge(id, Convert.ToDecimal(firstClassPrice), luggaPriceOverload);
                priceList.Add(ancillaryCharge);
            }
            return priceList;
        }

    }
}
