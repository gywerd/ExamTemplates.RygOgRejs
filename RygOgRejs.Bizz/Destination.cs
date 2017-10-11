using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class Destination
    {
        #region Fields
        private int destinationId;
        private string destinationName;
        private float adultPrice;
        private float childPrice;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Destination() { }

        /// <summary>
        /// Constructor used, when reading from Database
        /// </summary>
        /// <param name="destId"></param>
        /// <param name="destName"></param>
        public Destination(int destinationId, string destinationName, float adultaPrice, float childPrice)
        {
            DestinationId = destinationId;
            DestinationName = destinationName;
            AdultPrice = adultPrice;
            ChildPrice = childPrice;
        }
        #endregion


        #region Properties
        public int DestinationId
        {
            get => destinationId;
            set => destinationId = value;
        }

        public string DestinationName
        {
            get => destinationName;
            set => destinationName = value;
        }

        public float AdultPrice
        {
            get => adultPrice;
            set => adultPrice = value;
        }

        public float ChildPrice
        {
            get => childPrice;
            set => childPrice = value;
        }
        #endregion
    }
}
