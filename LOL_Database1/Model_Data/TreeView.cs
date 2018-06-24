using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model_Data
{
    public class TreeView
    {
        string Conn;
        string strSQL;
        public TreeView()
        {
            Conn = DBUtils.gerConn();
        }

        public string getTreeView()
        {
            System.Text.StringBuilder myJson = new StringBuilder();//保存构建的json格式的数据
            DataTable dt;
            strSQL = "select * from Item order by Id";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, strSQL).Tables[0];
            dt.DefaultView.RowFilter = "TypeId='0'";//筛选(过滤)父节点id为0的节点，即顶级节点

            myJson.Append("[");
            int i;
            for (i = 0; i <= dt.DefaultView.Count - 1; i++)  //  Count为过滤后的记录数
            {
                if (myJson.ToString() == "[")
                    myJson.Append("{\"text\":\"" + dt.DefaultView[i]["Name"].ToString() + "\"");
                else
                    myJson.Append(",{\"text\":\"" + dt.DefaultView[i]["Name"].ToString() + "\"");


                DataTable dtChildren;
                dtChildren = dt.Copy();   //子节点表，为每个顶级节点的子节点建一张表
                dtChildren.DefaultView.RowFilter = "TypeId=\'" + dt.DefaultView[i]["Id"].ToString() + "\'";
                //判断该节点是否有子节点
                if (dtChildren.DefaultView.Count > 0)
                {
                    //调用addChildren（）递归添加子节点
                    myJson.Append(",\"nodes\":[");
                    myJson.Append(addChildren(dtChildren, dt.DefaultView[i]["Id"].ToString()));
                    myJson.Append("]");
                    myJson.Append("}");
                }
                else
                { //没有子节点,则是叶子节点

                    myJson.Append("}");
                }
            }
            myJson.Append("]");
            return myJson.ToString();
        }

        public string addChildren(DataTable dt, string pMenuID)
        {
            System.Text.StringBuilder pmyJson = new StringBuilder();
            int i = 0;
            bool b = true;      //用来区分是不是第一个键值对
            dt.DefaultView.RowFilter = "TypeId=\'" + pMenuID + "\'";
            for (i = 0; i <= dt.DefaultView.Count - 1; i++)
            {
                if (b == true)
                {
                    pmyJson.Append("{\"text\":\"" + dt.DefaultView[i]["Name"].ToString() + "\"");
                    b = false;
                }
                else
                    pmyJson.Append(",{\"text\":\"" + dt.DefaultView[i]["Name"].ToString() + "\"");

                DataTable dtChildren = default(DataTable);
                dtChildren = dt.Copy();
                dtChildren.DefaultView.RowFilter = "TypeId=\'" + dt.DefaultView[i]["Id"].ToString() + "\'";
                if (dtChildren.DefaultView.Count > 0)
                {
                    pmyJson.Append(",\"nodes\":[");
                    pmyJson.Append(addChildren(dtChildren, dt.DefaultView[i]["Id"].ToString()));
                    pmyJson.Append("]");
                    pmyJson.Append("}");
                }
                else
                {
                    pmyJson.Append("}");
                }
            }
            return pmyJson.ToString();
        }
    }
}
