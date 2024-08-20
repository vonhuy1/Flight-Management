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
    public class ChuyenBayDAO : DBConnection
    {
        public ChuyenBayDAO() : base() { }

        public void ThemCB(ChuyenBay cb)
        {
            const string sql = "ThemChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@NgayBay", SqlDbType.Date);
            sqlParameters[0].Value = Convert.ToString(cb.Ngaybay);
            sqlParameters[1] = new SqlParameter("@GioKhoiHanh", SqlDbType.Time);
            sqlParameters[1].Value = Convert.ToString(cb.Giokhoihanh);
            sqlParameters[2] = new SqlParameter("@ThoiGianBay", SqlDbType.Time);
            sqlParameters[2].Value = Convert.ToString(cb.Thoigianbay);
            sqlParameters[3] = new SqlParameter("@ThoiGianDen", SqlDbType.Time);
            sqlParameters[3].Value = Convert.ToString(cb.Thoigianden);
            sqlParameters[4] = new SqlParameter("@SoGheH1", SqlDbType.Int);
            sqlParameters[4].Value = Convert.ToString(cb.Soghehang1);
            sqlParameters[5] = new SqlParameter("@SoGheH2", SqlDbType.Int);
            sqlParameters[5].Value = Convert.ToString(cb.Soghehang2);
            sqlParameters[6] = new SqlParameter("@MaTuyenBay", SqlDbType.VarChar);
            sqlParameters[6].Value = Convert.ToString(cb.Matuyenbay);
            sqlParameters[7] = new SqlParameter("@MaMayBay", SqlDbType.VarChar);
            sqlParameters[7].Value = Convert.ToString(cb.Mamaybay);

            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaCB(String maCB)
        {
            const string sql = "XoaChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maCB);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void SuaCB(ChuyenBay cb)
        {
            const string sql = "SuaChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(cb.Machuyenbay);
            sqlParameters[1] = new SqlParameter("@ThoiGianBay", SqlDbType.Time);
            sqlParameters[1].Value = Convert.ToString(cb.Thoigianbay);
            sqlParameters[2] = new SqlParameter("@ThoiGianDen", SqlDbType.Time);
            sqlParameters[2].Value = Convert.ToString(cb.Thoigianden);
            sqlParameters[3] = new SqlParameter("@SoGheH1", SqlDbType.Int);
            sqlParameters[3].Value = Convert.ToString(cb.Soghehang1);
            sqlParameters[4] = new SqlParameter("@SoGheH2", SqlDbType.Int);
            sqlParameters[4].Value = Convert.ToString(cb.Soghehang2);
            sqlParameters[5] = new SqlParameter("@MaMayBay", SqlDbType.VarChar);
            sqlParameters[5].Value = Convert.ToString(cb.Mamaybay);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from XemChuyenBay";
            return executeDisplayQuery(sql);
        }
        public DataTable TimCB(String maCB)
        {
            const string sql = "TimChuyenBay @MaChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maCB);

            return executeSearchQuery(sql, sqlParameters);
        }
    }
}
