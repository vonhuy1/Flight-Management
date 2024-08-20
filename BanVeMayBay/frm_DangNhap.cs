﻿using System;
using DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace BanVeMayBay
{
    public partial class frm_DangNhap : Form
    {
        public string str1,str2;
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            //abc
        }

        private void btn_Minimum_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void link_Forget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnl_ResetPassword.Visible = true;
            pnl_Login.Visible = false;
        }
        private void btn_ExitReset_Click(object sender, EventArgs e)
        {
            pnl_ResetPassword.Visible = false;
            pnl_Login.Visible = true;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();
            TaiKhoan tk = new TaiKhoan();
            str1 = txt_Username.Text;
            tk.tenTK = txt_Username.Text;
            tk.matKhau = txt_Password.Text;
            DataTable dt = new DataTable();
            dt = taiKhoanBUS.Login(tk);

            if (dt.Rows.Count == 1)
            {
                this.Hide();
                frm_Menu frm_Menu = new frm_Menu();
             //   frm_Menu.Role(dt.Rows[0].ItemArray[3].ToString());
                frm_Menu.DT = dt;
                frm_Menu.ShowDialog();
                this.Show();
            }

        }
    }
}
