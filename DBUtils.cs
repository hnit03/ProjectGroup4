using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectGroup4
{
    class DBUtils
    {
        public static SqlConnection GetSqlConnection()
        {
            String cnStr = "Data Source=SE141072;Initial Catalog=QLSVien;User ID=sa;Password=hoangnhi";
            SqlConnection sqlConnection = new SqlConnection(cnStr);
            return sqlConnection;
        }
    }
}
