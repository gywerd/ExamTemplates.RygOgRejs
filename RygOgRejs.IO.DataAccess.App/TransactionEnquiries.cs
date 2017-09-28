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
    public class TransactionEnquiries : DataEnquiries
    {
        public void AddTransaction(float amount, int jid, int pid) //find better way?
        {
            //depature time might break it all xD
            string query = $"INSERT INTO Transaction (Amount, JourneyId, PayerID) VALUES({amount}, {jid}, {pid}";
            executor.ExecuteNonQuery(query);
        }
        public void AddTransaction(Transactions t) //find better way?
        {
            //depature time might break it all xD
            string query = $"INSERT INTOTransaction (Amount, JourneyId, PayerID) VALUES({t.Amount}, {t.JourneyId}, {t.PayerId})";
            executor.ExecuteNonQuery(query);
        }
        public ObservableCollection<Transactions> GetAll()
        {
            string query = "SELECT * FROM Transaction";
            ObservableCollection<Transactions> transCol = new ObservableCollection<Transactions>();
            DataSet data = executor.Execute(query); //ayy lmao
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int tid = Convert.ToInt32(reader["TransactionId"]);
                float amount = Convert.ToSingle(reader["Amount"]);
                int jid = Convert.ToInt32(reader["JourneyId"]);
                int pid = Convert.ToInt32(reader["PayerId"]);
                Transactions t = new Transactions(tid, amount, jid, pid);
                transCol.Add(t);
            }
            return transCol;
        }

        public Transactions GetTransaction(int id)
        {
            Transactions t = new Transactions();
            string query = $"SELECT * FROM Transaction Where TransactionID = '{id}'";
            DataSet data = executor.Execute(query); //ayy lmao
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int tid = Convert.ToInt32(reader["TransactionId"]);
                float amount = Convert.ToSingle(reader["Amount"]);
                int jid = Convert.ToInt32(reader["JourneyId"]);
                int pid = Convert.ToInt32(reader["PayerId"]);
                t = new Transactions(tid, amount, jid, pid);
            }
            return t;
        }

        //reload list? also this should update the database 
        public void UpdatePriceDetail(Transactions t) //find better way?
        {
            //depature time might break it all xD
            string query = $"UPDATE Transaction SET Amount = {t.Amount}, JourneyId = {t.JourneyId}, PayerId = {t.PayerId} WHERE TransactionId = {t.TransactionId}";
            executor.ExecuteNonQuery(query);
        }
        //reload list? also this should update the database 
        public void UpdatePriceDetails(int tid, float amount, int jid, int pid) //find better way?
        {
            //depature time might break it all xD
            string query = $"UPDATE Transaction SET Amount = {amount}, JourneyId = {jid}, PayerId = {pid} WHERE TransactionId = {tid}";
            executor.ExecuteNonQuery(query);
        }

        //load new list ?
        public void DeletePriceDetails(int tid)
        {
            string query = $"DELETE FROM Transaction WHERE TransactionId = {tid}";
            executor.ExecuteNonQuery(query);
        }
    }
}
