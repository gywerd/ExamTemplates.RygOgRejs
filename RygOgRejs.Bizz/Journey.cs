using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz
{
    public class Journey
    {
        private string destination;
        private DateTime departureTime;
        private int adults;
        private int children;
        private bool isFristClass;
        private int luggaAmount;

        public Journey(string destination, DateTime depatureTime, int adults, int children, bool isFristClass, int luggaAmount)
        {
            Destionation = destination; //not using the enum :thinking:
            DepaturTime = depatureTime;
            Adults = adults;
            Children = children;
            IsFirstClass = isFristClass; //lel fristClass emil plz
            LuggaAmount = luggaAmount;
        }

        public string Destionation
        {
            get
            {
                return destination;
            }
            set
            {
                //ingen error checking FeelsBadMan
                destination = value;
            }
        }

        public DateTime DepaturTime
        {
            get
            {
                return departureTime;
            }
            set
            {
                if (DateTime.TryParse(value.ToString(), out DateTime checkTime))
                    departureTime = value;
            }
        }

        public int Adults
        {
            get
            {
                return adults;
            }
            set
            {
                adults = value;
            }
        }

        public void CreateJourney(Journey journey, Payer payer)
        {
            throw new NotImplementedException();
        }

        public int Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }

        public bool IsFirstClass
        {
            get
            {
                return isFristClass;
            }
            set
            {
                isFristClass = value;
            }
        }

        public int LuggaAmount
        {
            get
            {
                return luggaAmount;
            }
            set
            {
                luggaAmount = value;
            }
        }
    }
}

//server stuff will delete later
//adgang til database 10.205.44.39,49172 Aspit, Sever2012
//Data Source=10.205.44.39,49172;Initial Catalog=RygOgRejs;Integrated Security=False;User ID=Aspit;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False