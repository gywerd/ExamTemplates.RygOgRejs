﻿using System;
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
        private float firstClassPrice;
        private float luggagePrice;
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
        /// <param name="adultPrice">float</param>
        /// <param name="childPrice">float</param>
        public Destination(int destinationId, string destinationName, float adultPrice, float childPrice)
        {
            this.destinationId = destinationId;
            this.destinationName = destinationName;
            this.adultPrice = adultPrice;
            this.childPrice = childPrice;
        }
        #endregion

        #region Methods

        #endregion

        #region Properties
        public int DestinationId { get => destinationId; }
        public string DestinationName { get => destinationName;}

        public float AdultPrice
        {
            get => adultPrice;
        }

        public float ChildPrice
        {
            get => childPrice;
        }
        #endregion
    }
}
