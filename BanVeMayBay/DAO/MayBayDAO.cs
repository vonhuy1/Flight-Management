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
    public class MayBayDAO : DBConnection
    {
        public MayBayDAO() : base() { }
        public void ThemMB(MayBay mb)
        {
            const string sql = "ThemMayBay";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@MaMayBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(mb.Mamaybay);
            sqlParameters[1] = new SqlParameter("@LoaiMayBay", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(mb.Tenmaybay);
            sqlParameters[2] = new SqlParameter("@SoGhe", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToString(mb.Soghe);

            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaMB(String maMB)
        {
            const string sql = "XoaMayBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaMayBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maMB);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void SuaMB(MayBay mb)
        {
            const string sql = "SuaMayBay";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@MaMayBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(mb.Mamaybay);
            sqlParameters[1] = new SqlParameter("@LoaiMayBay", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(mb.Tenmaybay);
            sqlParameters[2] = new SqlParameter("@SoGhe", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToString(mb.Soghe);

           executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from XemMayBay";
            return executeDisplayQuery(sql);
        }
        public DataTable TimMB(String maMB)
        {
            const string sql = "TimMayBay @MaMayBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaMayBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maMB);
            return executeSearchQuery(sql, sqlParameters);
        }
    }
}
