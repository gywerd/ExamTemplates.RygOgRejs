using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class AncillaryCharge
    {
        private int id;
        private float firstClassPrice;
        private float luggagePriceOverlodKg;
        public AncillaryCharge() { }

        public AncillaryCharge(int id, float firstClassPrice, float luggagePriceOverlodKg)
        {
            Id = id;
            this.firstClassPrice = firstClassPrice;
            this.luggagePriceOverlodKg = luggagePriceOverlodKg;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        //Readonly fordi vi ikke behøver og set værdien
        public float FirstClassPrice
        {
            get => firstClassPrice;
        }

        //Readonly fordi vi ikke behøver og set værdien
        public float LuggagePriceOverlodKg
        {
            get => luggagePriceOverlodKg;
        }
    }
}
