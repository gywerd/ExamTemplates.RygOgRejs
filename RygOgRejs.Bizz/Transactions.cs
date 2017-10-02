using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class Transactions : Master
    {
        #region Fields
        private float amount;
        private int journeyId;
        private int payerId;
        private int transactionId;
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
        public Transactions(float amount, int jid, int pid, int mid)
        {
            this.amount = amount;
            this.journeyId = jid;
            this.payerId = pid;
            base.Id = mid;
        }

        /// <summary>
        /// Constructor used, when reding from database
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="amount">float</param>
        /// <param name="jid">int</param>
        /// <param name="pid">int</param>
        /// <param name="mid">int</param>
        public Transactions(int tid, float amount, int jid, int pid, int mid)
        {
            this.transactionId = tid;
            this.amount = amount;
            this.journeyId = jid;
            this.payerId = pid;
            base.Id = mid;
        }
        #endregion

        #region Properties
        public float Amount { get => amount; set => amount = value; }
        public int JourneyId { get => journeyId; set => journeyId = value; }
        public int PayerId { get => payerId; set => payerId = value; }
        public int TransactionId { get => transactionId; set => transactionId = value; }
        public int MasterId { get => base.Id; set => base.Id = value;}
        #endregion
    }
}
