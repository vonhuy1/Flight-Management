using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TuyenBayDAO : DBConnection
    {
        public TuyenBayDAO() : base() { }
        public void ThemTB(TuyenBay tb)
        {
            String sql;
            SqlParameter[] sqlParameters;
            sql = "ThemTuyenBay";
            sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@MaSanBayDi", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(tb.Masanbaydi);
            sqlParameters[1] = new SqlParameter("@MaSanBayDen", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(tb.Masanbayden);
            sqlParameters[2] = new SqlParameter("@MaSanBayTG", SqlDbType.VarChar);
           
            if (tb.Masanbaytg != "")
            {
                sqlParameters[2].Value = Convert.ToString(tb.Masanbaytg);
            }
            else
            {
                sqlParameters[2].Value = DBNull.Value;
            }
            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaTB(String maTB)
        {
            const string sql = "XoaTuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maTB);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from XemTuyenBay";
            return executeDisplayQuery(sql);
        }
        public DataTable TimTB(String maTB)
        {
            const string sql = "TimTuyenBay @MaTuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maTB);

            return executeSearchQuery(sql, sqlParameters);
        }
    }
}
