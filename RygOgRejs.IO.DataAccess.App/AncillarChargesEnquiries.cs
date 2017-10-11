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
        public ObservableCollection<AncillaryCharge> GetAllAncillaryCharge()
        {
            string query = "SELECT * FROM AncillarCharges";
            ObservableCollection<AncillaryCharge> priceList = new ObservableCollection<AncillaryCharge>();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["WaitngForName"]);
                float firstClassPrice = Convert.ToSingle(reader["FirstClassPrice"]);
                float luggaPriceOverload = Convert.ToSingle(reader["LuggagePricePerOverloadKg"]); //spelling error in DB corrected
                AncillaryCharge ancillaryCharge = new AncillaryCharge(id, firstClassPrice, luggaPriceOverload);
                priceList.Add(ancillaryCharge);
            }
            return priceList;
        }

    }
}
