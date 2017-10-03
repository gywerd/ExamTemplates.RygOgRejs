using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class Payer : Master
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
        /// Constructor used, creating database entry
        /// </summary>
        /// <param name="firstName">string</param>
        /// <param name="lastName">string</param>
        /// <param name="mid">int</param>
        public Payer(string firstName, string lastName, int mid)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            base.Id = mid;
        }

        /// <summary>
        /// Constructor used, when reading from database
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="firstName">string</param>
        /// <param name="lastName">string</param>
        /// <param name="mid">int</param>
        public Payer(int id, string firstName,string lastName, int mid)
        {
            this.payerId = id;
            FirstName = firstName;
            LastName = lastName;
            base.Id = mid;
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
        public int MasterID { get => base.Id; set => base.Id = value; }

        #endregion
    }
}
