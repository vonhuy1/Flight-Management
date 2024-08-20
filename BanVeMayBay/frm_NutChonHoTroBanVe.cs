using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;

namespace BanVeMayBay
{
    public partial class frm_NutChonHoTroBanVe : Form
    {
        int i;
        string S1,S2;
        public delegate void TruyenChoCha(string s1,string s2);
        public TruyenChoCha TruyenData;
       

        public frm_NutChonHoTroBanVe()
        {
            InitializeComponent();
        }

        private void Load1()
        {
            
            BanVeBUS bv1 = new BanVeBUS();
            DataTable dt8 = new DataTable();
            dt8 = bv1.LayGhe(Convert.ToInt32(Bientoancuc.soghe));
            dataGridView1.DataSource = dt8;
        }

        private void frm_NutChonHoTroBanVe_Load_1(object sender, EventArgs e)
        {
            Load1();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            i = dataGridView1.CurrentRow.Index;
            S1 =dataGridView1[0, i].Value.ToString();
            S2 =dataGridView1[1, i].Value.ToString();
            TruyenData(S1,S2);
            this.Close();


        }
    }
}
