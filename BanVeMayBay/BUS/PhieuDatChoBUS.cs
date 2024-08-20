﻿using BanVeMayBay.DAO;
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
    public  class PhieuDatChoBUS
    {
        private PhieuDatChoDAO pdc;
        public PhieuDatChoBUS()
        {
            pdc = new PhieuDatChoDAO();

        }
        public void themPhieuDatCho(DanhSachPhieuDatCho bv1)
        {
            pdc.ThemPhieuDatCho(bv1);
        }
        public void SuaPhieuDatCho(DanhSachPhieuDatCho bv)
        {
            pdc.SuaPhieuDatCho(bv);
        }
        public DataTable SearchPhieuDatCho(string str)
        {
            return pdc.SearchPhieuDatCho(str);
        }
        public DataTable HienThiPhieuDatCho()
        {
            return pdc.hienthiPhieuDatCho();
        }
        public void XoaPhieuDatCho(string str,string str1)
        {
            pdc.XoaPhieuDatCho(str, str1);
        }
        public DataTable LayChuyenBay(string str)
        {
            return pdc.LayChuyenBay(str);
        }
        public DataTable LayChuyenBay1()
        {
            return pdc.LayChuyenBay1();
        }
        public DataTable TimKiemGhe(string str, DateTime d1, string d2)
        {
            return pdc.SearchSoGhe(str, d1, d2);
        }
    }
}
