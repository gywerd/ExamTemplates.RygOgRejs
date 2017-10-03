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
    public class TransactionEnquiries : DataEnquiries
    {
        #region Constructors
        public TransactionEnquiries() { }
        #endregion

        #region Methods
        /// <summary>
        /// Method, that inserts a row into the database
        /// </summary>
        /// <param name="t">Transactions</param>
        public void AddTransaction(Transactions t)
        {
            string query = $"INSERT INTO Transaction (Amount, JourneyId, PayerID, MasterId) VALUES ({t.Amount}, {t.JourneyId}, {t.PayerId}, {t.MasterId})";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that removes a row from the database
        /// </summary>
        /// <param name="id">int</param>
        public void DeleteTransaction(int tid)
        {
            string query = $"DELETE FROM Transaction WHERE TransactionId = {tid}";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that loads all Transactions from database
        /// </summary>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Transactions> GetAll()
        {
            string query = "SELECT * FROM Transaction";
            ObservableCollection<Transactions> transCol = new ObservableCollection<Transactions>();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int tid = Convert.ToInt32(reader["TransactionId"]);
                float amount = Convert.ToSingle(reader["Amount"]);
                int jid = Convert.ToInt32(reader["JourneyId"]);
                int pid = Convert.ToInt32(reader["PayerId"]);
                int mid = Convert.ToInt32(reader["MasterId"]);
                Transactions t = new Transactions(tid, amount, jid, pid, mid);
                transCol.Add(t);
            }
            return transCol;
        }

        /// <summary>
        /// Method that loads a specific row in the database 
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Transaction</returns>
        public Transactions GetTransaction(int id)
        {
            Transactions t = new Transactions();
            string query = $"SELECT * FROM Transaction WHERE TransactionID = {id}";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int tid = Convert.ToInt32(reader["TransactionId"]);
                float amount = Convert.ToSingle(reader["Amount"]);
                int jid = Convert.ToInt32(reader["JourneyId"]);
                int pid = Convert.ToInt32(reader["PayerId"]);
                int mid = Convert.ToInt32(reader["MasterId"]);
                t = new Transactions(tid, amount, jid, pid, mid);
            }
            return t;
        }

        /// <summary>
        /// Method, that updates a row in the database from object
        /// </summary>
        /// <param name="t">Transactions</param>
        public void UpdateTransaction(Transactions t)
        {
            string query = $"UPDATE Transaction SET Amount = {t.Amount}, JourneyId = {t.JourneyId}, PayerId = {t.PayerId} WHERE TransactionId = {t.TransactionId}";
            executor.ExecuteNonQuery(query);
        }
        #endregion
    }
}
