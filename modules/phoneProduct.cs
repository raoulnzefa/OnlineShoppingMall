using onlinebusinessApi.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace onlinebusinessApi.modules
{
    public class phoneProduct
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public string productImageUrl { get; set; }

        public double price { get; set; }
        public double ClickTimes { get; set; }

        public double SaleTimes { get; set; }
        public static List<phoneProduct> GetphoneProductList()
        {
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM phonelist");
            List<phoneProduct> phoneproducts = new List<phoneProduct>();
            foreach (DataRow dr in dt.Rows)
            {
                phoneproducts.Add(dr.DtToMel<phoneProduct>());
            }
            return phoneproducts;
        }
    }
}
