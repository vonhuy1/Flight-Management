using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;
using BanVeMayBay;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace DAO
{
    public class BanVeDAO : DBConnection
    {
        public BanVeDAO() : base() { }

        public DataTable hienthiNoiBay()
        {
            const string sql = "select ViTri from SANBAY";
            return executeDisplayQuery(sql);
        }
        // public DataTable LayTuyenBay()
        //  {
        //     const string sql = "";
        //  }

        public DataTable hienthiKhachHang()
        {
            const string sql = "select * from KHACHHANG";
            return executeDisplayQuery(sql);
        }
        public DataTable hienthiPhieuDatCho()
        {
            const string sql = "select * from PHIEUDATCHO";
            return executeDisplayQuery(sql);
        }
        public DataTable hienthiPhieuHoaDon()
        {
            const string sql = "select * from HOADON";
            return executeDisplayQuery(sql);
        }
        public DataTable TimKiemTuyenBay(string str, string str2)
        {
            string sql = "select * from TimKiem_TuyenBay11(@str,@str2)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@str", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(str);
            sqlParameters[1] = new SqlParameter("@str2", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(str2);
            // sqlParameters[2] = new SqlParameter("@ngaybay", SqlDbType.DateTime);
            // sqlParameters[1].Value = Convert.ToDateTime(date);

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable TimKiemGioBay2(string str, DateTime date)
        {
            string sql = "select * from TimKiemKhungGioBay9(@ngaybay,@matuyenbay)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ngaybay", SqlDbType.Date);
            sqlParameters[0].Value = date;
            sqlParameters[1] = new SqlParameter("@matuyenbay", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);

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
        public DataTable LayGhe(int soghe1)
        {
            string sql = "LayGhe3 @soghe";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@soghe", SqlDbType.Int);
            sqlParameters[0].Value = soghe1;

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable LayHangVe(string str1)
        {
            string sql = "select * from LayHangVe_15(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str1);

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable LayNguocGioMayBayvaMaSanBay(string str)
        {
            string sql = "select * from LayNguocGioBayvaMaSanBay(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable LayNguocGioKhoiHanh_1(string str)
        {
            string sql = "select * from LayNguocGioKhoiHanh_1(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
        public void ThemPhieuDatCho(BanVe bv)
        {
            //@MaPhieu,@ThoiGianDat,@Soghe,@HangGhe,@MaChuyenBay,@CMND,@MaHangVe,@KhoiLuongHanhLi
            string sql = "ThemPhieuDatCho";
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@MaPhieu", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.Maphieudatcho);
            sqlParameters[1] = new SqlParameter("@ThoiGianDat", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(bv.ThoiGianDat);
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
        public void SuaPhieuDatCho(BanVe bv)
        {
            string sql = "SuaPhieuDatCho_5";
            SqlParameter[] sqlParameters = new SqlParameter[9];
            sqlParameters[0] = new SqlParameter("@MaPhieu", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.Maphieudatcho);
            sqlParameters[1] = new SqlParameter("@ThoiGianDat", SqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToDateTime(bv.ThoiGianDat);
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
            sqlParameters[8].Value = Convert.ToString(bv.Machuyenbayold);

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

        public DataTable LayPhieuDatChotoHoaDon()
        {
            string sql = "select * from LayPhieuDatCho()";
            return executeDisplayQuery(sql);
        }
        public DataTable LayThongTinTruyVanChoHoaDon(string str)
        {
            string sql = "select * from  LayThongTinTruyVanchoHoaDon(@str1)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str1", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
        public DataTable LayThongTinGiaTienHoaDon(string str)
        {
            string sql = "select * from  LayThongTinGiaTienHoaDon(@str)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(str);

            return executeSearchQuery(sql, sqlParameters);
        }
        public void ThemHoaDon(BanVe bv)
        {
            string sql = "ThemHoaDon_1";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@MaHoaDon", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.MaHoaDon);
            sqlParameters[1] = new SqlParameter("@MaPhieuDatCho", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(bv.Maphieudatcho);
            sqlParameters[2] = new SqlParameter("@ThanhTien", SqlDbType.Money);
            sqlParameters[2].Value = Convert.ToDecimal(bv.ThanhTien);
            sqlParameters[3] = new SqlParameter("@NgayLap", SqlDbType.DateTime);
            sqlParameters[3].Value = Convert.ToString(bv.Ngaylap);
            sqlParameters[4] = new SqlParameter("@MaNhanVien", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(bv.Manhanvien);
            sqlParameters[5] = new SqlParameter("CMND", SqlDbType.NVarChar);
            sqlParameters[5].Value = Convert.ToString(bv.Makhachhang);
            executeInsertQuery(sql, sqlParameters);
        }
        public void CapNhatHoaDon(BanVe bv)
        {
            string sql = "SuaHoaDon_1";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@MaHD", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(bv.MaHoaDon);
            sqlParameters[1] = new SqlParameter("@MaPhieuDatCho", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(bv.Maphieudatcho);
            sqlParameters[2] = new SqlParameter("@ThanhTien", SqlDbType.Money);
            sqlParameters[2].Value = Convert.ToDecimal(bv.ThanhTien);
            sqlParameters[3] = new SqlParameter("@NgayLap", SqlDbType.DateTime);
            sqlParameters[3].Value = Convert.ToDateTime(bv.Ngaylap);
            sqlParameters[4] = new SqlParameter("@MaNhanVien", SqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(bv.Manhanvien);
            sqlParameters[5] = new SqlParameter("CMND", SqlDbType.NVarChar);
            sqlParameters[5].Value = Convert.ToString(bv.Makhachhang);
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
    }

}
