using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;

namespace DAO
{
    public class HoaDonDAO:DBConnection
    {
        public void ThongKe(DateTime d1, DateTime d2, DataTable dt)
        {
            const string sql = "THONGKE";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@d1", SqlDbType.Date);
            sqlParameters[0].Value = Convert.ToDateTime(d1);
            sqlParameters[1] = new SqlParameter("@d2", SqlDbType.Date);
            sqlParameters[1].Value = Convert.ToDateTime(d2);
            executeThongKeQuery(sql, sqlParameters, dt);
        }
    }
}
