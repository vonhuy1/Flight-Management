
using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BanVeBUS
    {
        private BanVeDAO bv1DAO;
        public BanVeBUS()
        {
            bv1DAO = new BanVeDAO();
        }
      
        public DataTable HienThi()
        {
            return bv1DAO.hienthiNoiBay();
        }
        public DataTable TimKiemTuyenBay(string str,string str2)
        {
          //  return nvDAO.Search(str);
            return bv1DAO.TimKiemTuyenBay(str, str2);
        }
        public DataTable TimKiemKhungGioBay2(string str, DateTime d1)
        {
            return bv1DAO.TimKiemGioBay2(str, d1);
        }
        public DataTable TimKiemGhe(string str, DateTime d1,string d2)
        { 
           return bv1DAO.SearchSoGhe(str, d1, d2);
        }
      
        public DataTable LayGhe(int soghe)
        {
            return bv1DAO.LayGhe(soghe);
        }
        public DataTable LayHangVe(string str1)
        {
            return bv1DAO.LayHangVe(str1);
        }
        public DataTable xemKhachHang()
        {
            return bv1DAO.hienthiKhachHang();   
        }
        public DataTable HienThiPhieuDatCho()
        {
            return bv1DAO.hienthiPhieuDatCho(); 
        }
        public DataTable HienThiPhieuHoaDon()
        {
            return bv1DAO.hienthiPhieuHoaDon();
        }
        public DataTable LayNguocHBay(string str)
        {
            return bv1DAO.LayNguocGioMayBayvaMaSanBay(str);
                
                }
        public DataTable LayNguocTenDenVaDI(string str)
        {
            return bv1DAO.LayNguocGioKhoiHanh_1(str);
        }
        public void themPhieuDatCho(BanVe bv)
        {
            bv1DAO.ThemPhieuDatCho(bv);
        }
        public void SuaPhieuDatCho(BanVe bv)
        {
            bv1DAO.SuaPhieuDatCho(bv);
        }
        public DataTable SearchPhieuDatCho(string str)
        {
            return bv1DAO.SearchPhieuDatCho(str);
        }
        public DataTable LayPhieuDatChotoHoaDon()
        {
            return bv1DAO.LayPhieuDatChotoHoaDon();
        }
        public DataTable LayThongTinTruyVanChoHoaDon(string str)
        {
            return bv1DAO.LayThongTinTruyVanChoHoaDon(str);
        }
        public DataTable LayThongTinGiaTienHoaDon(string str)
        {
            return bv1DAO.LayThongTinGiaTienHoaDon(str);
        }
        public void ThemHoaDon(BanVe bv)
        {
            bv1DAO.ThemHoaDon(bv);
        }
        public void CapNhatHoaDon(BanVe bv)
        {
            bv1DAO.CapNhatHoaDon(bv);
        }
    }
}
