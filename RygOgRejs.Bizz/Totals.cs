using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class Totals
    {
        #region Fields
        private int amountOfSoldTravels;
        private int amountOfPassengers;
        private int amountOfAdults;
        private int amountofChildren;
        private float totalSaleAmount;
        #endregion

        #region Properties
        public int AmountOfAdults { get => amountOfAdults; set => amountOfAdults = value; }
        public int AmountofChildren { get => amountofChildren; set => amountofChildren = value; }
        public int AmountOfPassengers { get => amountOfPassengers; set => amountOfPassengers = value; }
        public int AmountOfSoldTravels { get => amountOfSoldTravels; set => amountOfSoldTravels = value; }
        public float TotalSaleAmount { get => totalSaleAmount; set => totalSaleAmount = value; }
        #endregion
    }
}
