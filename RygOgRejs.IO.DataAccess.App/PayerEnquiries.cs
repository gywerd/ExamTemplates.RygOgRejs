using RygOgRejs.Bizz;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RygOgRejs.IO.DataAccess.General;
namespace RygOgRejs.IO.DataAccess.App
{
    public class PayerEnquiries : DataEnquiries
    {
        #region Constructors
        public PayerEnquiries() { }
        #endregion

        #region Methods
        /// <summary>
        /// Method, that inserts a row into the database
        /// </summary>
        /// <param name="payer">Payer</param>
        public void AddPayer(Payer payer)
        {
            string query = $"INSERT INTO Payers (FirstName, LastName) VALUES( '{payer.FirstName}', '{payer.LastName}')";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that removes a row from the database
        /// </summary>
        /// <param name="id">int</param>
        public void DeletePayer(int id)
        {
            string query = $"DELETE FROM Payers WHERE PayerId = {id}";
            executor.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Method, that loads all Payers from database
        /// </summary>
        /// <returns>ObservableCollection</returns>
        public ObservableCollection<Payer> GetAllPayers()
        {
            string query = "SELECT * FROM Payers";
            ObservableCollection<Payer> priceCol = new ObservableCollection<Payer>();
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["PayerId"]);
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                Payer payer = new Payer(id, firstName, lastName);
                priceCol.Add(payer);
            }
            return priceCol;
        }

        /// <summary>
        /// Method that loads a specific row in the database 
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Payer</returns>
        public Payer GetPayerWithId(int id)
        {
            Payer payer = new Payer();
            string query = $"SELECT * FROM Payers Where PayerId = {id}";
            DataSet data = executor.Execute(query);
            DataTableReader reader = data.CreateDataReader(); //best
            while (reader.Read())
            {
                int tid = Convert.ToInt32(reader["TransactionId"]);
                string firstName = reader["FirstName"].ToString();
                string lastName = reader["LastName"].ToString();
                payer = new Payer(tid, firstName, lastName);
            }
            return payer;
        }

        /// <summary>
        /// Method, that updates a row in the database
        /// </summary>
        /// <param name="payer">Payer</param>
        public void UpdatePayer(Payer payer)
        {

            string query = $"UPDATE Payers SET FirstName = '{payer.FirstName}', LastName = '{payer.LastName}' WHERE PayerId = {payer.PayerId}";
            executor.ExecuteNonQuery(query);
        }
        #endregion
    }
}
