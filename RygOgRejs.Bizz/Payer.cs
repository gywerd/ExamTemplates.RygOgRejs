using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz
{
    public class Payer
    {
        //this is how we wanted it right?
        private int id;
        private string firstName;
        private string lastName;
        private string macAddress;
        public Payer(string macAddress)
        {
            this.macAddress = macAddress;
        }

        public Payer(int id, string firstName,string lastName)
        {
            this.id = id;
            FirstName = firstName;
            LastName = lastName;
            
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException();
                foreach(char c in value)
                    if(!char.IsLetter(c))
                        throw new ArgumentOutOfRangeException();
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException();
                foreach (char c in value)
                    if (!char.IsLetter(c))
                        throw new ArgumentOutOfRangeException();
            }
        }
    }
}
