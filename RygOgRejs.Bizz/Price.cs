using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz
{
    public class Price
    {
        #region Fields
        private int destinationId;
        private string destinationName;
        private float adultPrice;
        private float childPrice;
        private float firstClassPrice;
        private float luggagePrice;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Price() { }

        /// <summary>
        /// Constructor used, when reading the database
        /// </summary>
        /// <param name="destinationId">int</param>
        /// <param name="destinationName">string</param>
        /// <param name="adultPrice">float</param>
        /// <param name="childPrice">float</param>
        /// <param name="firstclassPrice">float</param>
        /// <param name="luggagePrice">float</param>
        public Price(int destId, string destName, float adultPrice, float childPrice, float firstClassPrice, float luggagePrice)
        {
            this.destinationId = destId;
            this.destinationName = destName;
            this.adultPrice = adultPrice;
            this.childPrice = childPrice;
            this.firstClassPrice = firstClassPrice;
            this.luggagePrice = luggagePrice;
        }
        #endregion

        #region Methods

        #endregion

        #region Properties
        public int DestinationId { get => destinationId; set => destinationId = value; }
        public string DestinationName { get => destinationName; set => destinationName = value; }
        public float AdultPrice { get => adultPrice; set => adultPrice = value; }
        public float ChildPrice { get => childPrice; set => childPrice = value; }
        public float FirstClassPrice { get => firstClassPrice; set => firstClassPrice = value; }
        public float LuggagePrice { get => luggagePrice; set => luggagePrice = value; }
        #endregion
    }
}
