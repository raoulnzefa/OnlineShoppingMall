using MySql.Data.MySqlClient;
using onlinebusinessApi.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace onlinebusinessApi.modules
{
    public class Usr
    {
        public string username { get; set; }//用户名
        public string pass { get; set; }//密码

        public string phone { get; set; }//手机号(唯一）
        public static int AddUsr(string uname, string upass, string uphone)
        {
            var user = GetUsrList(uphone);
            if (user.Count == 0)
            {
                return SqlHelper.ExecuteNonQuery($"INSERT INTO usrinfo(username,pass,phone)VALUES(@username,@pass,@phone)",
                  new MySqlParameter("@username", uname),
                  new MySqlParameter("@pass", upass),
                  new MySqlParameter("@phone", uphone)
                  );
            }
            else return 0;
        }
        public static List<Usr> GetUsrList(string uphone)//通过手机号判断用户信息是否重复
        {
            List<Usr> users = new List<Usr>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM usrinfo WHERE phone=@phone", new MySqlParameter("@phone", uphone));

            foreach (DataRow dr in dt.Rows)
            {
                users.Add(dr.DtToMel<Usr>());
            }
            return users;
        }

        public static List<Usr> Login(string uname, string upass, string uphone)
        {
            List<Usr> users = new List<Usr>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM usrinfo WHERE username = @username AND pass = @pass AND phone = @phone",
                new MySqlParameter("@username", uname),
                new MySqlParameter("@pass", upass),
                new MySqlParameter("@phone", uphone));
            foreach (DataRow dr in dt.Rows)
            {
                users.Add(dr.DtToMel<Usr>());
            }
            return users;
        }
    }
}
