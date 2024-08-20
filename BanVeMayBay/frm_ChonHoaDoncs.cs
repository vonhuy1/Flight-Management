using BUS;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanVeMayBay
{
    public partial class frm_ChonHoaDoncs : Form
    {
        public delegate void TruyenChoCha(string s1);
        public TruyenChoCha TruyenData;
        public frm_ChonHoaDoncs()
        {
            InitializeComponent();
        }
        public void XemPhieuDatCho()
        {
            BanVeBUS bv = new BanVeBUS();
            //  NhanVienBUS nvBUS = new NhanVienBUS();
            DataTable dt = new DataTable();
            dt = bv.LayPhieuDatChotoHoaDon();
            dgv_PHD.DataSource = dt;
            dgv_PHD.Columns[0].HeaderText = "Mã phiếu đặt";
           


            dgv_PHD.Columns[0].Width = 170;
        

            dgv_PHD.AllowUserToAddRows = false;
            dgv_PHD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void frm_ChonHoaDoncs_Load(object sender, EventArgs e)
        {
            XemPhieuDatCho();
        }

        private void btn_Chọn_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_PHD.CurrentRow.Index;
            string S1 = dgv_PHD[0, i].Value.ToString();
            TruyenData(S1);
            this.Close();   
        }
    }
}
