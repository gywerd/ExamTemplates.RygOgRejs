using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RygOgRejs.Bizz.Entities;
using RygOgRejs.IO.DataAccess.General;
using System.Data;

namespace RygOgRejs.IO.DataAccess.App
{
    public class MasterIdEnquiries : DataEnquiries
    {
        public void CreateID(string macAddresss)
        {
            string query = $"INSERT INTO Master (MacAdress) VALUES ('{macAddresss}')";
            executor.ExecuteNonQuery(query);
        }
        public int GetId()
        {
            string query = $"SELECT * FROM Master";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            int id = 0;
            while(reader.Read())
            {
                id = Convert.ToInt32(reader["MasterId"]);
            }
            return id;
        }
        public void DeleteId(int id)
        {
            string query = $"DELETE FROM Master WHERE MasterId = {id}";
        }
    }
}
