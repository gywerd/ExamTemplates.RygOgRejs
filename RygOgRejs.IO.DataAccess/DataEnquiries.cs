using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.IO.DataAccess.General
{
    public class DataEnquiries
    {
        #region Fields
        protected QueryExecutor executor;
        #endregion

        #region Constructors
        public DataEnquiries()
        {
            executor = new QueryExecutor();
        }
        #endregion
    }
}
