﻿using RygOgRejs.Bizz.Entities;
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
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                float firstClassPrice = Convert.ToSingle(reader["FirstClassPrice"]);
                float luggaPriceOverload = Convert.ToSingle(reader["LuggagePricePerOverloadKg"]);
                AncillaryCharge ancillaryCharge = new AncillaryCharge(id, firstClassPrice, luggaPriceOverload);
                priceList.Add(ancillaryCharge);
            }
            return priceList;
        }

    }
}
