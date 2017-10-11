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
        public void AddTransaction(Transaction t)
        {
    //        string query = $"INSERT INTO Transactions (Amount, JourneyId, PayerID, MasterId) VALUES ({t.Amount}, {t.JourneyId}, {t.PayerId}, {t.MasterId})";
      //      executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that removes a row from the database
        /// </summary>
        /// <param name="id">int</param>
        public void DeleteTransaction(int tid)
        {
            string query = $"DELETE FROM Transactions WHERE MasterId = {tid}";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that loads all Transactions from database
        /// </summary>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Transaction> GetAll()
        {
            string query = "SELECT * FROM Transactions";
            ObservableCollection<Transaction> transCol = new ObservableCollection<Transaction>();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int tid = Convert.ToInt32(reader["TransactionId"]);
                DateTime depatureTime = Convert.ToDateTime(reader["InserNameHere"]);
                bool isFirstClass = Convert.ToBoolean(reader["ÍnsertNameHere"]);
                int adults = Convert.ToInt32(reader["ÍnsertNameHere"]);
                int children = Convert.ToInt32(reader["ÍnsertNameHere"]);
                float luggaeAmount = Convert.ToSingle(reader["ÍnsertNameHere"]);
                string firstName = reader["ÍnsertNameHere"].ToString();
                string lastName = reader["ÍnsertNameHere"].ToString();
                string destinationName = reader["ÍnsertNameHere"].ToString();
                float ammountExclVat = Convert.ToSingle(reader["ÍnsertNameHere"]);
                Transaction t = new Transaction(tid,depatureTime,destinationName,isFirstClass,adults,children,luggaeAmount,firstName,lastName,ammountExclVat); //use this when the class has been made for it
                transCol.Add(t);
            }
            return transCol;
        }

        /// <summary>
        /// Method that loads a specific row in the database
        /// </summary>
        /// <param name="masterId">int</param>
        /// <returns>Transaction if it worked null if it failed</returns>
        public Transaction GetTransaction(int Id)
        {
            Transaction t = default(Transaction);
            string query = $"SELECT * FROM Transactions WHERE MasterID = {Id}";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int tid = Convert.ToInt32(reader["TransactionId"]);
                DateTime depatureTime = Convert.ToDateTime(reader["InserNameHere"]);
                bool isFirstClass = Convert.ToBoolean(reader["ÍnsertNameHere"]);
                int adults = Convert.ToInt32(reader["ÍnsertNameHere"]);
                int children = Convert.ToInt32(reader["ÍnsertNameHere"]);
                float luggaeAmount = Convert.ToSingle(reader["ÍnsertNameHere"]);
                string firstName = reader["ÍnsertNameHere"].ToString();
                string lastName = reader["ÍnsertNameHere"].ToString();
                string destinationName = reader["ÍnsertNameHere"].ToString();
                float ammountExclVat = Convert.ToSingle(reader["ÍnsertNameHere"]);
                t = new Transaction(tid, depatureTime, destinationName, isFirstClass, adults, children, luggaeAmount, firstName, lastName, ammountExclVat); //use this when the class has been made for it
            }
            return t;
        }

        /// <summary>
        /// Method, that updates a row in the database from object
        /// </summary>
        /// <param name="t">Transactions</param>
        public void UpdateTransaction(Transaction t)
        {
    //        string query = $"UPDATE Transactions SET Amount = {t.Amount}, JourneyId = {t.JourneyId}, PayerId = {t.PayerId} WHERE TransactionId = {t.TransactionId}";
    //        executor.ExecuteNonQuery(query);
        }
        #endregion
    }
}
