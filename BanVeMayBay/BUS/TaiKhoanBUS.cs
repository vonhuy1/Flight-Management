﻿using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private TaiKhoanDAO tkDAO;

        public TaiKhoanBUS()
        {
            tkDAO = new TaiKhoanDAO();
        }
        public void DMK(TaiKhoan TK,string matKhauMoi, string matKhauMoiNL)
        {
            tkDAO.DoiMatKhau(TK,matKhauMoi,matKhauMoiNL);
        }
        public void SI(TaiKhoan TK,DataTable dt)
        {
            tkDAO.showInformation(TK,dt);
        }
        public DataTable Login(TaiKhoan tk)
        {
            return tkDAO.Login(tk);
        }

    }
}
