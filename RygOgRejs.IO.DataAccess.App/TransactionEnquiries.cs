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
            string query = $"INSERT INTO Transactions (TransactionDate, DestinationName, IsFirstClass, Adults,Children,LuggageAmount,FirstName,LastName,AmountExclVat) VALUES ('{t.TransActionDate.ToString("yyyy-MM-dd")}', '{t.DestinationName}', '{t.IsFirstClass}', {t.Adults}, {t.Children},{t.LuggageAmount}, '{t.FirstName}', '{t.LastName}', {t.AmountExclVat}";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that removes a row from the database
        /// </summary>
        /// <param name="id">int</param>
        public void DeleteTransaction(int tid)
        {
            string query = $"DELETE FROM Transactions WHERE Id = {tid}";
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
                int tid = Convert.ToInt32(reader["Id"]); //transActionID
                DateTime depatureTime = Convert.ToDateTime(reader["TransactionDate"]);
                bool isFirstClass = Convert.ToBoolean(reader["IsFirstClass"]);
                int adults = Convert.ToInt32(reader["Adults"]);
                int children = Convert.ToInt32(reader["Children"]);
                float luggaeAmount = Convert.ToSingle(reader["LuggageAmount"]);
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                string destinationName = reader["DestinationName"].ToString();
                float ammountExclVat = Convert.ToSingle(reader["AmountExclVat"]);
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
            string query = $"SELECT * FROM Transactions WHERE Id = {Id}";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader();
            while (reader.Read())
            {
                int tid = Convert.ToInt32(reader["Id"]); //transActionID
                DateTime depatureTime = Convert.ToDateTime(reader["TransactionDate"]);
                bool isFirstClass = Convert.ToBoolean(reader["IsFirstClass"]);
                int adults = Convert.ToInt32(reader["Adults"]);
                int children = Convert.ToInt32(reader["Children"]);
                float luggaeAmount = Convert.ToSingle(reader["LuggageAmount"]);
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                string destinationName = reader["DestinationName"].ToString();
                float ammountExclVat = Convert.ToSingle(reader["AmountExclVat"]);
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
            string query = $"UPDATE Transactions SET TransactionDate = '{t.TransActionDate}', DestinationName = '{t.DestinationName}', IsFirstClass = '{t.IsFirstClass}', Adults = {t.Adults}, Children = {t.Children}, LuggageAmount = {t.LuggageAmount}, FirstName = '{t.FirstName}', LastName = {t.LastName}, AmountExclVat = {t.AmountExclVat} WHERE Id = {t.TransactionId}";
            executor.ExecuteNonQuery(query);
        }
        #endregion
    }
}
