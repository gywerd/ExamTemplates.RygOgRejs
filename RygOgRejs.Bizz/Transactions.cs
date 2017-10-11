using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class Transactions
    {
        #region Fields
        private int id;
        private DateTime transAction;
        private bool isFirstClass;
        private int adults;
        private int children;
        private float luggageAmount;
        private string firstName;
        private string lastName;
        private string destinationName;
        private float amountPaid;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Transactions() { }

        /// <summary>
        /// Constructor used when generating transaction
        /// </summary>
        /// <param name="amount">float</param>
        /// <param name="jid">int</param>
        /// <param name="pid">int</param>
        /// <param name="mid">int</param>
        public Transactions(DateTime transAction, bool isFirstClass, int adults, int children, float luggageAmount, string firstName, string lastName, string destinationName, float amountPaid)
        {
            TransAction = transAction;
            IsFirstClass = isFirstClass;
            Adults = adults;
            Children = children;
            LuggageAmount = luggageAmount;
            FirstName = firstName;
            LastName = lastName;
            DestinationName = destinationName;
            AmountPaid = amountPaid;

        }

        /// <summary>
        /// Constructor used, when reding from database
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="amount">float</param>
        /// <param name="jid">int</param>
        /// <param name="pid">int</param>
        /// <param name="mid">int</param>
        public Transactions(int id, DateTime transAction, bool isFirstClass, int adults, int children, float luggageAmount, string firstName, string lastName, string destinationName, float amountPaid) : this(transAction,isFirstClass,adults,children,luggageAmount,firstName,lastName,destinationName,amountPaid)
        {
            Id = id;
        }
        #endregion
       
        #region Properties
        //Validate not needed
        public int Id
        {
            get => id;
            set => id = value;
        }

        public DateTime TransAction
        {
            get => transAction;
            set => transAction = value;
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
            set => LuggageAmount = value;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                foreach (char c in value)
                    if (!char.IsLetter(c))
                        throw new ArgumentNullException();
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                foreach (char c in value)
                    if (!char.IsLetter(c))
                        throw new ArgumentNullException();
                lastName = value;
            }
        }

        public string DestinationName
        {
            get => destinationName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                foreach (char c in value)
                    if (!char.IsLetter(c))
                        throw new ArgumentNullException();
                destinationName = value;
            }
        }

        public float AmountPaid
        {
            get => amountPaid;
            set => amountPaid = value;
        }
        #endregion
    }
}
