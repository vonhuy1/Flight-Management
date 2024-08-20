using BUS;
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
    public partial class frm_ChonChuyenBay : Form
    {
        public frm_ChonChuyenBay()
        {
            InitializeComponent();
        }
        public delegate void TruyenChoCha(string s1);
        public TruyenChoCha TruyenData;
        public void XemPhieuDatCho()
        {
            PhieuDatChoBUS pdc = new PhieuDatChoBUS();
            //  NhanVienBUS nvBUS = new NhanVienBUS();
            DataTable dt = new DataTable();
            dt = pdc.LayChuyenBay1();
            dgv_PDC.DataSource = dt;
            dgv_PDC.Columns[0].HeaderText = "Mã chuyến bay";
            dgv_PDC.Columns[1].HeaderText = "Ngày bay";
            dgv_PDC.Columns[2].HeaderText = "Thời gian";




            dgv_PDC.Columns[0].Width = 170;
            dgv_PDC.Columns[1].Width = 170;
            dgv_PDC.Columns[2].Width = 170;



            dgv_PDC.AllowUserToAddRows = false;
            dgv_PDC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void frm_ChonChuyenBay_Load(object sender, EventArgs e)
        {
            XemPhieuDatCho();
        }

        private void btn_Chon_Click(object sender, EventArgs e)
        {
            int i;
            i = dgv_PDC.CurrentRow.Index;
            string S1 = dgv_PDC[0, i].Value.ToString();
            TruyenData(S1);
            this.Close();
        }
    }
}
