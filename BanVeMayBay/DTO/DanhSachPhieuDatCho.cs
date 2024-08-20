﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class DanhSachPhieuDatCho
    {
        public string maphieu, soghe, hangghe, machuyenbay, makhachhang, mahangve, khoiluonghanhli, machuyenbayold;
         DateTime ngaydat;
        public DanhSachPhieuDatCho() { }
        public DanhSachPhieuDatCho(string maphieu, DateTime ngaydat, string soghe, string hangghe, string machuyenbay, string makhachhang, string mahangve, string khoiluonghanhli, string machuyenbayold)
        {
            //this.maphieu = maphieu;
            this.maphieu = maphieu;
            this.ngaydat = ngaydat;
            this.soghe = soghe;
            this.hangghe = hangghe;
            this.makhachhang = makhachhang;
            this.machuyenbay = machuyenbay;
            this.mahangve = mahangve;
            this.khoiluonghanhli = khoiluonghanhli;
            this.machuyenbayold = machuyenbayold;
        }
        public DanhSachPhieuDatCho(string maphieu,DateTime ngaydat,string soghe,string hanghe,string machuyenbay,string makhachhang,string mahangve,string khoiluonghanhli)
        {
            this.maphieu = maphieu;
            this.ngaydat = ngaydat;
            this.soghe = soghe;
            this.hangghe = hanghe;
            this.makhachhang = makhachhang;
            this.machuyenbay = machuyenbay;
            this.mahangve = mahangve;
            this.khoiluonghanhli = khoiluonghanhli;
        }
        public string Machuyenbay { get => machuyenbay; set => machuyenbay = value; }

        public string Soghe { get => soghe; set => soghe = value; }
        public string Hangghe { get => hangghe; set => hangghe = value; }
        public string Makhachhang { get => makhachhang; set => makhachhang = value; }

        public string MaHangVe { get => mahangve; set => mahangve = value; }
        public string Maphieu { get => maphieu; set => maphieu = value; }
        public string KhoiLuongHanhLi { get => khoiluonghanhli; set => khoiluonghanhli = value; }
        public string MaChuyenbayold { get => machuyenbayold;set => machuyenbayold = value; }
        public DateTime NgayDat { get => ngaydat; set => ngaydat = value; }

    }
}
