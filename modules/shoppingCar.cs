using MySql.Data.MySqlClient;
using onlinebusinessApi.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace onlinebusinessApi.modules
{
    public class shoppingCar
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }
        public int count { get; set; }
       
        public double price { get; set; }
       
        public bool isDel { get; set; }

        public static int Addcart(int pid,string pName,string pImg,int count)
        {
            // return SqlHelper.ExecuteNonQuery($"INSERT INTO shoppingCarts(count,ProductId)VALUES('{count}','{pid}')");
            var carts = GetCarList();
            var cart = carts.Find(m => m.ProductId == pid);
            if(cart!=null)
            {
                cart.count += count;
                return SqlHelper.ExecuteNonQuery("UPDATE shoppingcarts SET ProductId=@ProductId,productName=@productName,productImage=@productImage,count=@count,isDel=@isDel WHERE Id=@Id",
                    new MySqlParameter("@Id", cart.Id),
                    new MySqlParameter("@ProductId", cart.ProductId),
                   
                    new MySqlParameter("@productName", cart.productName),
                    new MySqlParameter("@productImage", cart.productImage),
                   new MySqlParameter("@count", cart.count),

                    new MySqlParameter("@isDel", cart.isDel)
                    );
            }
            else
            {
                return SqlHelper.ExecuteNonQuery($"INSERT INTO shoppingcarts(ProductId,productName,productImage,count,isDel)VALUES(@ProductId,@productName,@productImage,@count,@isDel)",
                     new MySqlParameter("@ProductId", pid),
                    
                    new MySqlParameter("@productName", pName),
                    new MySqlParameter("@productImage",pImg),
                   new MySqlParameter("@count", count),

                    new MySqlParameter("@isDel", false));
            }
        }
        public static List<shoppingCar> GetCarList()
        {
            List<shoppingCar> shoppingCars = new List<shoppingCar>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM shoppingcarts");
            
           foreach(DataRow dr in dt.Rows)
            {
                shoppingCars.Add(dr.DtToMel<shoppingCar>());
            }
            return shoppingCars;
        }
       
        public static List<shoppingCar> listAllJoin()
        {
            List<shoppingCar> shoppingCars = new List<shoppingCar>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM shoppingcarts s LEFT JOIN productlist p ON s.ProductId=p.Id");
            foreach (DataRow dr in dt.Rows)
            {
                shoppingCars.Add(dr.DtToMel<shoppingCar>());
            }
            return shoppingCars;
        }
    }
}
