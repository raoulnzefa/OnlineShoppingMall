using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlinebusinessApi.modules;

namespace onlinebusinessApi.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]/[action]")]
   
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<Products> GetProducts()
        {
            var productlist= Products.GetProductList();
            return productlist;
        }
        [HttpGet]
        public Products getProductById(int id)
        {
          List<Products> productlist = Products.GetProductList();
          return productlist.Find(m => m.Id == id);
           
        }

        [HttpGet]
        public List<phoneProduct> GetPhoneProducts()
        {
            var phoneproductlist = phoneProduct.GetphoneProductList();
            return phoneproductlist;
        }
        [HttpGet]
        public phoneProduct getphoneProductById(int id)
        {
            List<phoneProduct> productlist = phoneProduct.GetphoneProductList();
            return productlist.Find(m => m.Id == id);

        }

        [HttpPost]
        public string AddCart(int pid,string pName, string pImg, int count)
        {
           int rows= shoppingCar.Addcart(pid,pName,pImg,count);
            if(rows>0)
            {
                return "success";            }
            else
            {
                return "err";
            }
        }

        [HttpGet]
        public IActionResult GetShoppingcarts()
        {
            var carlist = shoppingCar.listAllJoin();
            return new JsonResult(carlist);
        }

        [HttpPost]
        public string AddUsr(string uname, string upass,string uphone)
        {
            int rows = Usr.AddUsr(uname,upass,uphone);
            if (rows > 0)
            {
                return "success";
            }
            else
            {
                return "err";
            }
        }
        [HttpPost]
        public string Login(string uname, string upass, string uphone)
        {
           var rows = Usr.Login(uname, upass, uphone);
            if (rows.Count == 0)
            {
                return "err";
            }
            else
            {
                return "success";
            }
        }
    }
}