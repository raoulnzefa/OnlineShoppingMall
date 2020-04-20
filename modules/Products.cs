using onlinebusinessApi.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace onlinebusinessApi.modules
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string productImageUrl { get; set; }
        public string productDetailImageUrl { get; set; }
        public double price{ get; set; }
        public double OrgPrice { get; set; }

        public string Decoration { get; set; }

        public double ClickTimes { get; set; }

        public double SaleTimes { get; set; }
        public bool isDel { get; set; }

        public static List<Products> GetProductList()
        {

           DataTable dt=SqlHelper.ExecuteTable("SELECT * FROM productlist");
            List<Products> products = new List<Products>();
           foreach(DataRow dr in dt.Rows)
            {
                products.Add(dr.DtToMel<Products>());
            }
            return products;
        }
       
    }
}
