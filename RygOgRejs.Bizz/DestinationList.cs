using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class DestinationList
    {
        #region Fields
        private int destinationId;
        private string destinationName;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public DestinationList() { }

        /// <summary>
        /// Constructor used, when reading from Database
        /// </summary>
        /// <param name="destId"></param>
        /// <param name="destName"></param>
        public DestinationList(int destId, string destName)
        {
            this.destinationId = destId;
            this.destinationName = destName;
        }
        #endregion


        #region Properties
        public int DestinationId { get => destinationId; set => destinationId = value; }
        public string DestinationName { get => destinationName; set => destinationName = value; }
        #endregion
    }
}
