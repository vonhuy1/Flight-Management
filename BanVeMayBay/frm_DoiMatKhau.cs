﻿using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;
using System.Data.SqlClient;

namespace BanVeMayBay
{
    public partial class frm_DoiMatKhau : Form
    {
        public frm_DoiMatKhau()
        {
            InitializeComponent();
        }
        private DataTable dt;
        public DataTable DT { set => dt = value; }
        private void frm_DoiMatKhau_Load(object sender, EventArgs e)
        {
            LoadTK();
        }
        public void LoadTK()
        {
            NhanVienBUS nhanVienBUS = new NhanVienBUS();
            DataTable dt1 = new DataTable();
            dt1 = nhanVienBUS.Search(dt.Rows[0].ItemArray[2].ToString());
            lb_Username.Text = dt.Rows[0].ItemArray[0].ToString();
            lb_Password.Text = dt.Rows[0].ItemArray[1].ToString();
            lb_EmployeeName.Text = dt1.Rows[0].ItemArray[2].ToString();
            lb_Role.Text = dt.Rows[0].ItemArray[3].ToString();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            TaiKhoan TK = new TaiKhoan();
            TK.tenTK = txt_Username.Text;
            TK.matKhau = txt_Password.Text;

            TaiKhoanBUS tkbus=new TaiKhoanBUS();
            tkbus.DMK(TK, txt_NewPassword.Text, txt_RetypePassword.Text);
            showInformation();
            resettextbox();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void resettextbox()
        {
            txt_Username.Text = "";
            txt_Password.Text = "";
            txt_NewPassword.Text = "";
            txt_RetypePassword.Text = "";
        }
        private void showInformation()
        {
            TaiKhoan TK =new TaiKhoan();
            TK.tenTK=txt_Username.Text;

            TaiKhoanBUS TKBUS=new TaiKhoanBUS();
            DataTable dt1=new DataTable();
            TKBUS.SI(TK,dt1);
            lb_Username.Text = Convert.ToString(dt1.Rows[0].ItemArray[0]);
            lb_Password.Text = Convert.ToString(dt1.Rows[0].ItemArray[1]);
            lb_Role.Text = Convert.ToString(dt1.Rows[0].ItemArray[2]);
            lb_EmployeeName.Text = Convert.ToString(dt1.Rows[0].ItemArray[3]);

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
