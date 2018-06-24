using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Data
{
    class DBUtils
    {
        public static string gerConn()
        {   //Data Source=DESKTOP-71FFAUM;Initial Catalog=LOL_Data;Integrated Security=True
            string strConn= "";
            strConn = "server=" + System.Configuration.ConfigurationManager.AppSettings["Server"];
            strConn += ";UID=" + Model_Data.Security.Decrypt("mJL9u+8lvRD3FD5dzOyNZW1mk2h+Wg/KeQwAwxN9Dne8WeMqIeHnWqcJ8G5a6GRwzu/zCItdoyyj3JC5eYVfQpbrsmHHwEWXlHFf3XRl4PLvlhQeqw1JCpsB702osn+XTccrlJ80Jtd3nSlkY21rVIUnW74bkqHvhGs4FWAyG7w=");
            strConn += ";PWD=" + Model_Data.Security.Decrypt("M3YexY/ZEcgVTN+WdQaaReZj2d2r8r0w4YglTZbf0L+uMHZpIFtLPW31OTLQP0Ve7CSaJjLNSWItB2eqv+FutP1oI+1sAgbQOGEWkjH93s/K+ShI9Q3VFNq3C423gJVlxjppSYy5OQk1eZBP/UVFZiKXpCH4DmS2M7BmgYdgvC0=");
            strConn += ";Database=" + System.Configuration.ConfigurationManager.AppSettings["Database"];
            return strConn;
        }
    }
}
