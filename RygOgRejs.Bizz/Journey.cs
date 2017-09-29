﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz
{
    public class Journey
    {
        #region Fields
        private int journeyId; //Database field
        private string destination; //Database field
        private DateTime departureTime; //Database field
        private int adults; //Database field
        private int children; //Database field
        private bool isFirstClass; //Database field
        private float luggageAmount; //Database field
        ObservableCollection<PriceDetails> priceDetails = new ObservableCollection<PriceDetails>(); //Unused. Deletion???
        #endregion

        #region constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Journey() { }

        /// <summary>
        /// Constructor used, when creating the journey
        /// </summary>
        /// <param name="destination">string</param>
        /// <param name="departureTime">DateTime</param>
        /// <param name="adults">int</param>
        /// <param name="children">int</param>
        /// <param name="isFirstClass">bool</param>
        /// <param name="luggageAmount">float</param>
        public Journey(string destination, DateTime departureTime, int adults, int children, bool isFirstClass, float luggageAmount)
        {
            this.destination = destination; //not using the enum :thinking:
            this.departureTime = departureTime;
            this.adults = adults;
            this.children = children;
            this.isFirstClass = isFirstClass; //lel fristClass emil plz
            this.luggageAmount = luggageAmount;
        }

        /// <summary>
        /// Constructor used, when reading journeys from the database
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="destination">string</param>
        /// <param name="departureTime">DateTime</param>
        /// <param name="adults">int</param>
        /// <param name="children">int</param>
        /// <param name="isFirstClass">bool</param>
        /// <param name="luggageAmount">float</param> why is this a int here but a float everywhere els?
        public Journey(int id, string destination, DateTime departureTime, int adults, int children, bool isFirstClass, float luggageAmount)
        {
            this.journeyId = id;
            this.destination = destination; //not using the enum :thinking:
            this.departureTime = departureTime;
            this.adults = adults;
            this.children = children;
            this.isFirstClass = isFirstClass; //lel fristClass emil plz
            this.luggageAmount = luggageAmount;
        }
        #endregion

        #region Methods
        #endregion

        #region Properties
        public string Destination { get => destination; set => destination = value; } //ingen error checking FeelsBadMan
        public DateTime DepatureTime
        {
            get => departureTime;
            set
            {
                if (DateTime.TryParse(value.ToString(), out DateTime checkTime))
                    departureTime = value;
            }
        }
        public int Adults { get => adults; set => adults = value; }
        public int Children { get => children; set => children = value; }
        public bool IsFirstClass { get => isFirstClass; set => isFirstClass = value; }
        public float LuggageAmount { get => luggageAmount; set => luggageAmount = value; }
        public ObservableCollection<PriceDetails> PriceDetails { get => PriceDetails; set => PriceDetails = value; }
        public int JourneyId { get => journeyId; set => journeyId = value; }
        #endregion
    }
}

//server stuff will delete later
//adgang til database 10.205.44.39,49172 Aspit, Server2012 