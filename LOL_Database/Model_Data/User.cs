using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Model_Data
{
    public class User
    {
        string conn;
        public User()
        {
            conn = DBUtils.gerConn();
        }
        public string Login(string UserID, string Pass)
        {
            //string conn = "server=.;uid=sa;pwd=sql;database=项目教学";
            string strSql = "select * from User_Table where Name='" + UserID + "'";
            SqlDataReader dr;
            dr = SqlHelper.ExecuteReader(conn, CommandType.Text, strSql);
            string strReturn;
            if (dr.Read())
            {
                if (dr["Password"].ToString() == System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(UserID.ToUpper() + Pass, "md5"))
                    strReturn = "1";
                else
                    strReturn = "-1";
            }
            else
                strReturn = "-2";
            dr.Close();
            return strReturn;
        }
        public string Register(string UserID, string Pass,string Email)
        {
            string miPass= System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(UserID.ToUpper() + Pass, "md5");
            // insert into User_Table(Name,Email,Password) values('asfasf','asdgsdg','dfghdfh')
            string strSql = "insert into User_Table(Name, Password,Email) values ('" + UserID;
            strSql += "','"+ miPass;
            strSql += "','" + Email;
            strSql += "')";
            int flag;
            flag = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, strSql);
            string strReturn;
            if (flag > 0)
                strReturn = "1";
            else
                strReturn = "-1";
            return strReturn;
        }
    }
}
