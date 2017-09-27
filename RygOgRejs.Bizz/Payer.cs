using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz
{
    public class Payer
    {
        #region Fields
        //this is how we wanted it right?
        private int payerId;
        private string firstName;
        private string lastName;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Payer() { }

        /// <summary>
        /// Constructor used, when getting MasterId = PayerId 
        /// </summary>
        /// <param name="mac">int</param>
        public Payer(string mac)
        {
            this.firstName = mac;
            this.lastName = mac;
        }

        /// <summary>
        /// Constructor used, when reading from database
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="firstName">string</param>
        /// <param name="lastName">string</param>
        public Payer(int id, string firstName,string lastName)
        {
            this.payerId = id;
            FirstName = firstName;
            LastName = lastName;
            
        }
        #endregion

        #region Properties
        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException();
                foreach(char c in value)
                    if(!char.IsLetter(c))
                        throw new ArgumentOutOfRangeException();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException();
                foreach (char c in value)
                    if (!char.IsLetter(c))
                        throw new ArgumentOutOfRangeException();
            }
        }
        public int PayerId { get => payerId; set => payerId = value; }
        #endregion
    }
}
