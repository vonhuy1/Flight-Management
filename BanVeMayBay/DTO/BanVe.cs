using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public  class BanVe
    {
        private string machuyenbay, soghe, hangghe, makhachhang, mahangve, tennv, mahoadon, maphieudatcho, thanhtien, maphieu; 
        private string khoiluonghanhli;
        private string matuyenbay, manhanvien;
        private string noidi, noiden;
        private string machuyenbayold;
        private DateTime thoigiandat,ngaydi,ngaylap;
        public BanVe() { }
        public BanVe(string mahoadon,string maphieudatcho,string thanhtien,DateTime ngaylap,string manhanvien,string makhachhang)
        {
            this.mahoadon = mahoadon;
            this.maphieudatcho = maphieudatcho;
            this.thanhtien = thanhtien;
            this.ngaylap = ngaylap;
            this.manhanvien = manhanvien;
            this.makhachhang = makhachhang;
        }
        public  BanVe(string maphieudatcho,DateTime thoigiandat,string soghe,string hangghe,string machuyenbay,string makhachhang,string mahangve,string khoiluonghanhli,string machuyenbayold)
        {
            //this.maphieu = maphieu;
            this.maphieudatcho = maphieudatcho;
            this.thoigiandat=thoigiandat;
            this.soghe = soghe;
            this.hangghe = hangghe;
            this.machuyenbay = machuyenbay;
            this.makhachhang = makhachhang;
            this.mahangve = mahangve;
            this.khoiluonghanhli = khoiluonghanhli;
            this.machuyenbayold = machuyenbayold;
        }
        public BanVe(string maphieudatcho, DateTime thoigiandat, string soghe, string hangghe, string machuyenbay, string makhachhang, string mahangve, string khoiluonghanhli)
        {
            //this.maphieu = maphieu;
            this.maphieudatcho = maphieudatcho;
            this.thoigiandat = thoigiandat;
            this.soghe = soghe;
            this.hangghe = hangghe;
            this.machuyenbay = machuyenbay;
            this.makhachhang = makhachhang;
            this.mahangve = mahangve;
            this.khoiluonghanhli = khoiluonghanhli;
         
        }
        public string Noidi { get => noidi; set => noidi = value; } 
        public string Noiden { get => noiden; set => noiden = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }
     
       /* public BanVe(string machuyenbay,string matuyenbay, string soghe, string hangghe, string makhachhang, string mahangve, string tennv, string mahoadon,string maphieudatcho,string thanhtien,string maphieu,int khoiluonghanhli,DateTime thoigiandat,DateTime ngaydi)
        {
            this.machuyenbay = machuyenbay;
            this.soghe = soghe;
            this.hangghe = hangghe;
            this.makhachhang = makhachhang;
            this.mahangve = mahangve;
            this.tennv = tennv;
            this.mahoadon = mahoadon;
            this.maphieu = maphieu;
            this.maphieudatcho = maphieudatcho;
            this.thanhtien = thanhtien;
            this.khoiluonghanhli = khoiluonghanhli;
            this.ngaydi = ngaydi;
            this.thoigiandat = thoigiandat;
            this.matuyenbay = matuyenbay;
        }
       */
        public string Machuyenbay { get => machuyenbay; set => machuyenbay = value; }

        public string Soghe { get => soghe; set => soghe = value; }
        public string Hangghe { get => hangghe; set => hangghe = value; }
        public string Makhachhang { get => makhachhang; set => makhachhang = value; }
        public string Tennv { get => tennv; set => tennv = value; }

        public string MaHangVe { get => mahangve; set => mahangve = value; }
        public string MaHoaDon { get => mahoadon; set => mahoadon = value; }
        public string Maphieu { get => maphieu; set => maphieu = value; }
        public string Maphieudatcho { get => maphieudatcho;set => maphieudatcho = value; }
        public string ThanhTien { get => thanhtien; set => thanhtien = value; }
        public string KhoiLuongHanhLi { get => khoiluonghanhli; set => khoiluonghanhli = value; }
        public DateTime NgayDi { get => ngaydi; set => ngaydi = value; }
        public DateTime ThoiGianDat { get => thoigiandat;set => thoigiandat = value; }
        public string MaTuyenBay { get => matuyenbay; set => matuyenbay = value; }
        public string Manhanvien { get => manhanvien; set => manhanvien = value; }
        public string Machuyenbayold { get => machuyenbayold; set => machuyenbayold = value; }
    }
}
