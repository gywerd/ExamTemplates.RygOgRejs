using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class Transaction
    {
        #region Fields
        private int id;
        private DateTime transActionDate;
        private string destinationName;
        private bool isFirstClass;
        private int adults;
        private int children;
        private float luggageAmount;
        private string firstName;
        private string lastName;
        private int pricePaid;
        private float amountExclVat;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Transaction() { }

        /// <summary>
        /// Constructor used when generating transaction
        /// </summary>
        /// <param name="transActionDate">DateTime</param>
        /// <param name="destinationName"></param>
        /// <param name="isFirstClass">bool</param>
        /// <param name="adults">int</param>
        /// <param name="children">int</param>
        /// <param name="luggageAmount">float</param>
        /// <param name="firstName">string</param>
        /// <param name="lastName">string</param>
        /// <param name="amountExclVat">float</param>
        public Transaction(DateTime transActionDate, string destinationName, bool isFirstClass, int adults, int children, float luggageAmount, string firstName, string lastName, float amountExclVat)
        {
            TransActionDate = transActionDate;
            DestinationName = destinationName;
            IsFirstClass = isFirstClass;
            Adults = adults;
            Children = children;
            LuggageAmount = luggageAmount;
            FirstName = firstName;
            LastName = lastName;
            AmountExclVat = amountExclVat;
            pricePaid = 0;
        }

        /// <summary>
        /// Constructor used, when reding from database
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="transActionDate">DateTime</param>
        /// <param name="destinationName">string</param>
        /// <param name="isFirstClass">bool</param>
        /// <param name="adults">int</param>
        /// <param name="children">int</param>
        /// <param name="luggageAmount">float</param>
        /// <param name="firstName">string</param>
        /// <param name="lastName">string</param>
        /// <param name="amountExclVat"></param>
        public Transaction(int id, DateTime transActionDate, string destinationName, bool isFirstClass, int adults, int children, float luggageAmount, string firstName, string lastName, float amountExclVat) : this(transActionDate, destinationName, isFirstClass, adults, children, luggageAmount, firstName, lastName, amountExclVat)
        {
            TransactionId = id;
        }
        #endregion
       
        #region Properties
        //Validate not needed
        public int TransactionId
        {
            get => id;
            set => id = value;
        }

        public DateTime TransActionDate
        {
            get => transActionDate;
            set => transActionDate = value;
        }

        public string DestinationName
        {
            get => destinationName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                foreach (char c in value)
                    if (!char.IsLetter(c) && !char.IsPunctuation(c) && c != 32)
                        throw new ArgumentNullException();
                destinationName = value;
            }
        }

        public bool IsFirstClass
        {
            get => isFirstClass;
            set => isFirstClass = value;
        }

        public int Adults
        {
            get => adults;
            set => adults = value;
        }

        public int Children
        {
            get => children;
            set => children = value;
        }

        public float LuggageAmount
        {
            get => luggageAmount;
            set => luggageAmount = value;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                //if (string.IsNullOrWhiteSpace(value))
                //    throw new ArgumentNullException();
                //foreach (char c in value)
                //    if (!char.IsLetter(c))
                //        throw new ArgumentNullException();
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                //if (string.IsNullOrWhiteSpace(value))
                //    throw new ArgumentNullException();
                //foreach (char c in value)
                //    if (!char.IsLetter(c))
                //        throw new ArgumentNullException();
                lastName = value;
            }
        }

        public int PricePaid
        {
            get => pricePaid;
            set => pricePaid = value;
        }

        public float AmountExclVat
        {
            get => amountExclVat;
            set => amountExclVat = value;
        }
        #endregion
    }
}
