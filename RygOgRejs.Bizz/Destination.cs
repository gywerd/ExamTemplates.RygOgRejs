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
        private string iata;
        private string icao;
        private string countryCode;
        private decimal adultPrice;
        private decimal childPrice;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Destination() { }

        /// <summary>
        /// Constructor used, when reading the database
        /// </summary>
        /// <param name="destinationId">int</param>
        /// <param name="destinationName">string</param>
        /// <param name="adultPrice">decimal</param>
        /// <param name="childPrice">decimal</param>
        public Destination(int destinationId, string destinationName, string iata, string icao, string country, decimal adultPrice, decimal childPrice)
        {
            this.destinationId = destinationId;
            this.destinationName = destinationName;
            this.iata = iata;
            this.icao = iata;
            this.countryCode = country;
            this.adultPrice = adultPrice;
            this.childPrice = childPrice;
        }
        #endregion

        #region Properties
        public int DestinationId { get => destinationId; set => destinationId = value; }
        public string DestinationName { get => destinationName; set => destinationName = value; }
        public string IATA { get => iata; set => iata = value; }
        public string ICAO { get => icao; set => icao = value; }
        public string CountryCode { get => countryCode; set => countryCode = value; }
        public decimal AdultPrice { get => adultPrice; set => adultPrice = value; }
        public decimal ChildPrice { get => childPrice; set => childPrice = value; }
        #endregion
    }
}
