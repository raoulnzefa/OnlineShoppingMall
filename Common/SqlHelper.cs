using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace onlinebusinessApi.Common
{
    public class SqlHelper
    {
        public static string ConStr { get; set; }
        public static DataTable ExecuteTable(string cmdText,params MySqlParameter[] mySqlParameters)
        {
            using(MySqlConnection con =new MySqlConnection(ConStr))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText,con);//管理员
                cmd.Parameters.AddRange(mySqlParameters);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);//推车
                DataSet ds = new DataSet();//卡车
                sda.Fill(ds);//装满
                return ds.Tables[0];//取第一个表

            }
            //获取数据
        }

        public static int ExecuteNonQuery(string cmdText, params MySqlParameter[] mySqlParameters)
        {
            using (MySqlConnection con = new MySqlConnection(ConStr))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(cmdText, con);//管理员
                cmd.Parameters.AddRange(mySqlParameters);
                int rows=cmd.ExecuteNonQuery();
                if (rows <= 0)
                    throw new Exception("数据库执行错误");
                return rows;

            }
        }
    }
}
