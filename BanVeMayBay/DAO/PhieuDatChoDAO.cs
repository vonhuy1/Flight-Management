using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BanVeMayBay.DAO
{
   public class PhieuDatChoDAO : DBConnection
    {
        public PhieuDatChoDAO() : base() { }
        public DataTable LayChuyenBay(string str)
        {
            string sql = "select * from LayChuyenBay_1(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);

        }
        public DataTable LayChuyenBay1()
        {
            string sql = "select * from CHUYENBAY";
            return executeDisplayQuery(sql);
        }
        public void ThemPhieuDatCho(DanhSachPhieuDatCho bv)
        {
            //@MaPhieu,@ThoiGianDat,@Soghe,@HangGhe,@MaChuyenBay,@CMND,@MaHangVe,@KhoiLuongHanhLi
            string sql = "ThemPhieuDatCho";
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@MaPhieu", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.Maphieu);
            sqlParameters[1] = new SqlParameter("@ThoiGianDat", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(bv.NgayDat);
            sqlParameters[2] = new SqlParameter("@Soghe", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(bv.Soghe);
            sqlParameters[3] = new SqlParameter("@HangGhe", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(bv.Hangghe);
            sqlParameters[4] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(bv.Machuyenbay);
            sqlParameters[5] = new SqlParameter("CMND", SqlDbType.NVarChar);
            sqlParameters[5].Value = Convert.ToString(bv.Makhachhang);
            sqlParameters[6] = new SqlParameter("@MaHangVe", SqlDbType.NVarChar);
            sqlParameters[6].Value = Convert.ToString(bv.MaHangVe);
            sqlParameters[7] = new SqlParameter("@KhoiLuongHanhLi", SqlDbType.Int);
            sqlParameters[7].Value = Convert.ToInt32(bv.KhoiLuongHanhLi);

            executeInsertQuery(sql, sqlParameters);
        }
        public void SuaPhieuDatCho(DanhSachPhieuDatCho bv)
        {
            string sql = "SuaPhieuDatCho_3";
            SqlParameter[] sqlParameters = new SqlParameter[9];
            sqlParameters[0] = new SqlParameter("@MaPhieu", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.Maphieu);
            sqlParameters[1] = new SqlParameter("@ThoiGianDat", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(bv.NgayDat);
            sqlParameters[2] = new SqlParameter("@Soghe", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(bv.Soghe);
            sqlParameters[3] = new SqlParameter("@HangGhe", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(bv.Hangghe);
            sqlParameters[4] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(bv.Machuyenbay);
            sqlParameters[5] = new SqlParameter("CMND", SqlDbType.NVarChar);
            sqlParameters[5].Value = Convert.ToString(bv.Makhachhang);
            sqlParameters[6] = new SqlParameter("@MaHangVe", SqlDbType.NVarChar);
            sqlParameters[6].Value = Convert.ToString(bv.MaHangVe);
            sqlParameters[7] = new SqlParameter("@KhoiLuongHanhLi", SqlDbType.Int);
            sqlParameters[7].Value = Convert.ToInt32(bv.KhoiLuongHanhLi);
            sqlParameters[8] = new SqlParameter("@MaChuyenBayold", SqlDbType.NVarChar);
            sqlParameters[8].Value = Convert.ToString(bv.MaChuyenbayold);
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void XoaPhieuDatCho(string str,string str1)
        {
            string sql = "XoaPhieuDatCho_1";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@MaPhieu", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);
            sqlParameters[1] = new SqlParameter("@MaChuyenBay", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(str1);

            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable SearchPhieuDatCho(string str)
        {
            string sql = "select * from  SearchPhieuDatCho(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable hienthiPhieuDatCho()
        {
            const string sql = "select * from PHIEUDATCHO";
            return executeDisplayQuery(sql);
        }
        public DataTable SearchSoGhe(string str, DateTime date, string time)
        {
            string sql = "select * from LaySoGhe4(@ngaybay,@matuyenbay,@giokhoihanh)";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@ngaybay", SqlDbType.Date);
            sqlParameters[0].Value = date;
            sqlParameters[1] = new SqlParameter("@matuyenbay", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(str);
            sqlParameters[2] = new SqlParameter("@giokhoihanh", DbType.Time);
            sqlParameters[2].Value = Convert.ToString(time);
            return executeSearchQuery(sql, sqlParameters);
        }
    }
}
