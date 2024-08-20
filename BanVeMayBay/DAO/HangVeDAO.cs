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
    public class HangVeDAO : DBConnection
    {
        public HangVeDAO() : base() { }
        public void ThemHV(HangVe hv)
        {
            const string sql = "ThemHangVe";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(hv.Machuyenbay);
            sqlParameters[1] = new SqlParameter("@HangVe", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(hv.Tenhangve);
            sqlParameters[2] = new SqlParameter("@KhoiLuongToiDa", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToString(hv.Khoiluongtoida);
            sqlParameters[3] = new SqlParameter("@DonGia", SqlDbType.Money);
            sqlParameters[3].Value = Convert.ToString(hv.Dongia);

            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaHV(String maHV)
        {
            const string sql = "XoaHangVe";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaHangVe", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maHV);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void SuaHV(HangVe hv)
        {
            const string sql = "SuaHangVe";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@MaHangVe", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(hv.Mahangve);
            sqlParameters[1] = new SqlParameter("@KhoiLuongToiDa", SqlDbType.Int);
            sqlParameters[1].Value = Convert.ToString(hv.Khoiluongtoida);
            sqlParameters[2] = new SqlParameter("@DonGia", SqlDbType.Money);
            sqlParameters[2].Value = Convert.ToString(hv.Dongia);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from XemHangVe";
            return executeDisplayQuery(sql);
        }
        public DataTable TimHV(String maHV)
        {
            const string sql = "TimHangVe @MaHangVe";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaHangVe", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(maHV);

            return executeSearchQuery(sql, sqlParameters);
        }
    }
}
