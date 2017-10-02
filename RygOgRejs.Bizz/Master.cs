using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.Bizz.Entities
{
    public class Master
    {
        #region Fields
        private int id;
        private string macAdress;
        #endregion

        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Master() { }

        /// <summary>
        /// Method to create dummy entry in Database
        /// </summary>
        /// <param name="mac">string</param>
        public Master(string mac)
        {
            this.macAdress = mac;
        }

        /// <summary>
        /// Constructor used when reading dummy entry from Database
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="mac"></param>
        public Master(int mid, string mac)
        {
            this.id = mid;
        }
        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        id = value;
                    }
                }
                catch (Exception)
                {
                    throw;
                }   
            }
        }
        public string MacAdress { get => macAdress; set => macAdress = value; }
        #endregion
    }
}
