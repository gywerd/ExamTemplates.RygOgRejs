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
        private string iata;
        private string icao;
        private string countryCode;
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
        public DestinationList(int destId, string destName, string iata, string icao, string country)
        {
            this.destinationId = destId;
            this.destinationName = destName;
            this.iata = iata;
            this.icao = icao;
            this.countryCode = country;
        }
        #endregion


        #region Properties
        public int DestinationId { get => destinationId; set => destinationId = value; }
        public string DestinationName { get => destinationName; set => destinationName = value; }
        public string IATA { get => iata; set => iata = value; }
        public string ICAO { get => icao; set => icao = value; }
        public string CountryCode { get => countryCode; set => countryCode = value; }
        #endregion
    }
}
