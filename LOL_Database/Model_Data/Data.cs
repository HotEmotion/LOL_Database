using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Model_Data;
namespace Model_Data
{
    public class Data
    {
        string strSQL;
        string Conn;
        public Data()
        {
            Conn = Model_Data.DBUtils.gerConn();
        }
        public string Name;
        public string NickName;
        public string IContent;
        public string Type;
        public string TypeId;
        public string Price;
        public string Image;
        public int Id;
        public DataSet getAllHero()
        {
            strSQL = "select * from Item where TypeId=5 or TypeId=6 or TypeId=7 or TypeId=8 or TypeId=9 or TypeId=10";
            DataSet ds;
            ds = SqlHelper.ExecuteDataset(Conn, CommandType.Text, strSQL);
            return ds;
        }
        public DataSet getHeroDataBytype(string type)
        {
            strSQL = "select * from Item where Type='"+type+"'";
            DataSet ds;
            ds = SqlHelper.ExecuteDataset(Conn, CommandType.Text, strSQL);
            return ds;
        }
        public DataSet getDetail(int Id)
        {
            strSQL = "select * from Hero_Table where ItemId='" + Id + "'";
            DataSet ds;
            ds = SqlHelper.ExecuteDataset(Conn, CommandType.Text, strSQL);
            return ds;
        }
        public string AddNew()
        {
            strSQL = "insert into Item(Name,NickName,IContent,Type,Price,Image,TypeId) values(";
            strSQL += "'" + Name + "',";
            strSQL += "'" + NickName + "',";
            strSQL += "'" + IContent + "',";
            strSQL += "'" + Type + "',";
            strSQL += "'" + Price + "',";
            strSQL += "'" + Image + "',";
            strSQL += "'" + TypeId + "')";
            SqlHelper.ExecuteNonQuery(Conn, CommandType.Text, strSQL);
            return "1";
        }
        public string Update()
        {
            strSQL = "update Item set Name=";
            strSQL += "'"+Name + "',";
            strSQL += "NickName=";
            strSQL += "'" + NickName + "',";
            strSQL += "IContent=";
            strSQL += "'" + IContent + "',";
            strSQL += "Type=";
            strSQL += "'" + Type + "',";
            strSQL += "Price=";
            strSQL += "'" + Price + "',";
            strSQL += "Image=";
            strSQL += "'" + Image + "',";
            strSQL += "TypeId=";
            strSQL += "'" + TypeId + "'";
            strSQL +=" where Id="+Id;
            SqlHelper.ExecuteNonQuery(Conn, CommandType.Text, strSQL);
            return "1";
        }
        public string Delete()
        {
            strSQL = "delete from Item where Id="+Id;
            SqlHelper.ExecuteNonQuery(Conn, CommandType.Text, strSQL);
            return "1";
        }

    }
}
