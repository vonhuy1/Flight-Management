using BUS;
using DTO;
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
    public partial class frm_ChuyenBay : Form
    {
        ChuyenBay cb;
        public frm_ChuyenBay()
        {
            InitializeComponent();
        }
        public void XemChuyenBay()
        {
            ChuyenBayBUS cbBUS = new ChuyenBayBUS();
            DataTable dt = new DataTable();
            dt = cbBUS.HienThi();
            dgvCB.DataSource = dt;
            dgvCB.Columns[0].HeaderText = "Mã chuyến bay";
            dgvCB.Columns[1].HeaderText = "Ngày bay";
            dgvCB.Columns[2].HeaderText = "Giờ khởi hành";
            dgvCB.Columns[3].HeaderText = "Thời gian bay";
            dgvCB.Columns[4].HeaderText = "Thời gian dự kiến đến";
            dgvCB.Columns[5].HeaderText = "Số ghế hạng 1";
            dgvCB.Columns[6].HeaderText = "Số ghế hạng 2";
            dgvCB.Columns[7].HeaderText = "Mã tuyến bay";
            dgvCB.Columns[8].HeaderText = "Mã máy bay";

            dgvCB.Columns[0].Width = 200;
            dgvCB.Columns[1].Width = 100;
            dgvCB.Columns[2].Width = 100;
            dgvCB.Columns[3].Width = 100;
            dgvCB.Columns[4].Width = 100;
            dgvCB.Columns[5].Width = 90;
            dgvCB.Columns[6].Width = 90;
            dgvCB.Columns[7].Width = 150;
            dgvCB.Columns[8].Width = 100;
            dgvCB.AllowUserToAddRows = false;
            dgvCB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadComboBoxTuyenBay()
        {
            TuyenBayBUS tbBUS = new TuyenBayBUS();
            DataTable dt = new DataTable();
            dt = tbBUS.HienThi();
            cb_MaTuyenBay.DisplayMember = "MaTuyenBay";
            cb_MaTuyenBay.ValueMember = "MaTuyenBay";
            cb_MaTuyenBay.DataSource = dt;
        }
        private void LoadComboBoxMayBay()
        {
            MayBayBUS mbBUS = new MayBayBUS();
            DataTable dt = new DataTable();
            dt = mbBUS.HienThi();
            cb_MaMayBay.DisplayMember = "MaMayBay";
            cb_MaMayBay.ValueMember = "MaMayBay";
            cb_MaMayBay.DataSource = dt;
        }
        private void frm_ChuyenBay_Load(object sender, EventArgs e)
        {
            XemChuyenBay();
            LoadComboBoxTuyenBay();
            LoadComboBoxMayBay();
            cb_MaTuyenBay.SelectedIndex = -1;
            cb_MaMayBay.SelectedIndex = -1;
            txt_MaChuyenBay.Enabled = false;
        }
        private void dgvCB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dgvCB.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                txt_MaChuyenBay.Text = row.Cells[0].Value.ToString();
                dtp_NgayBay.Text = row.Cells[1].Value.ToString();
                dtp_ThoiGianKH.Text = row.Cells[2].Value.ToString();
                txt_ThoiGianBay.Text = row.Cells[3].Value.ToString();
                dtp_ThoiGianDuKienDen.Text = row.Cells[4].Value.ToString();
                txt_SoGheHang1.Text = row.Cells[5].Value.ToString();
                txt_SoGheHang2.Text = row.Cells[6].Value.ToString();
                cb_MaTuyenBay.Text = row.Cells[7].Value.ToString();
                cb_MaMayBay.Text = row.Cells[8].Value.ToString();

                //Không cho phép sửa trường MaNV
                txt_MaChuyenBay.Enabled = false;
                dtp_NgayBay.Enabled = false;
                dtp_ThoiGianKH.Enabled = false;
                cb_MaTuyenBay.Enabled = false;
            }
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public bool CheckNhapCB()
        {
            if (txt_ThoiGianBay.Text == "")
            {
                MessageBox.Show("Nhập thời gian bay!");
                txt_ThoiGianBay.Focus();
                return false;
            }
            if (txt_ThoiGianBay.Text != "")
            {
                if (txt_ThoiGianBay.Text.Contains(":") == false)
                {
                    MessageBox.Show("Nhập thời gian bay theo format: HH:MM:SS");
                    txt_ThoiGianBay.Focus();
                    return false;
                }    
            }    
            if (txt_SoGheHang1.Text == "")
            {
                MessageBox.Show("Nhập số ghế hạng 1!");
                txt_SoGheHang1.Focus();
                return false;
            }
            if (IsNumber(txt_SoGheHang1.Text) != true)
            {
                MessageBox.Show("Số ghế chỉ được nhập số nguyên!");
                txt_SoGheHang1.Focus();
                return false;
            }
            if (txt_SoGheHang2.Text == "")
            {
                MessageBox.Show("Nhập số ghế hạng 2!");
                txt_SoGheHang2.Focus();
                return false;
            }        
            if (IsNumber(txt_SoGheHang2.Text) != true)
            {
                MessageBox.Show("Số ghế chỉ được nhập số nguyên!");
                txt_SoGheHang2.Focus();
                return false;
            }
            if (cb_MaTuyenBay.Text == "")
            {
                MessageBox.Show("Chọn mã tuyến bay!");
                cb_MaTuyenBay.Focus();
                return false;
            }
            if (cb_MaMayBay.Text == "")
            {
                MessageBox.Show("Chọn mã máy bay!");
                cb_MaMayBay.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Reset()
        {
            txt_MaChuyenBay.ResetText();
            txt_ThoiGianBay.ResetText();
            txt_SoGheHang1.ResetText();
            txt_SoGheHang2.ResetText();
            cb_MaTuyenBay.ResetText();
            cb_MaMayBay.ResetText();
            dtp_ThoiGianDuKienDen.ResetText();
            dtp_NgayBay.Enabled = true;
            cb_MaTuyenBay.Enabled = true;
            dtp_ThoiGianKH.Enabled = true;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            string thoigianKH, thoigianden;
            ChuyenBayBUS cbBUS = new ChuyenBayBUS();
            if (CheckNhapCB())
            {
                thoigianKH = dtp_ThoiGianKH.Value.Hour.ToString() + ':' + dtp_ThoiGianKH.Value.Minute.ToString() + ':' + dtp_ThoiGianKH.Value.Second.ToString();
                thoigianden = dtp_ThoiGianDuKienDen.Value.Hour.ToString() + ':' + dtp_ThoiGianDuKienDen.Value.Minute.ToString() + ':' + dtp_ThoiGianDuKienDen.Value.Second.ToString();
                cb = new ChuyenBay(txt_MaChuyenBay.Text, cb_MaTuyenBay.Text, cb_MaMayBay.Text, dtp_NgayBay.Value, thoigianKH, txt_ThoiGianBay.Text, thoigianden, Convert.ToInt32(txt_SoGheHang1.Text), Convert.ToInt32(txt_SoGheHang2.Text));
                cbBUS.ThemCB(cb);
                //MessageBox.Show("Thêm chuyến bay mới thành công!");
                Reset();
                XemChuyenBay();
            }
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            ChuyenBayBUS cbBUS = new ChuyenBayBUS();
            if (txt_MaChuyenBay.Text == "")
            {
                MessageBox.Show("Vui lòng chọn chuyến bay muốn xóa!");
            }
            else
            {
                cbBUS.XoaCB(txt_MaChuyenBay.Text);
                //MessageBox.Show("Xóa chuyến bay thành công!");
                Reset();
                XemChuyenBay();
            }
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string thoigianKH, thoigianden;
            ChuyenBayBUS cbBUS = new ChuyenBayBUS();
            if (txt_MaChuyenBay.Text == "")
            {
                MessageBox.Show("Vui lòng chọn chuyến bay muốn sửa!");
            }
            else
            {
                thoigianKH = dtp_ThoiGianKH.Value.Hour.ToString() + ':' + dtp_ThoiGianKH.Value.Minute.ToString() + ':' + dtp_ThoiGianKH.Value.Second.ToString();
                thoigianden = dtp_ThoiGianDuKienDen.Value.Hour.ToString() + ':' + dtp_ThoiGianDuKienDen.Value.Minute.ToString() + ':' + dtp_ThoiGianDuKienDen.Value.Second.ToString();
                cb = new ChuyenBay(txt_MaChuyenBay.Text, cb_MaTuyenBay.Text, cb_MaMayBay.Text, dtp_NgayBay.Value, thoigianKH, txt_ThoiGianBay.Text, thoigianden, Convert.ToInt32(txt_SoGheHang1.Text), Convert.ToInt32(txt_SoGheHang2.Text));

                cbBUS.SuaCB(cb);
                //MessageBox.Show("Cập nhật chuyến bay thành công!");
                Reset();
                XemChuyenBay();
            }
        }
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (txt_TimKiemMaCB.Text == "")
            {
                MessageBox.Show("Nhập mã chuyến bay muốn tìm!");
                txt_TimKiemMaCB.Focus();
            }
            else
            {
                ChuyenBayBUS cbBUS = new ChuyenBayBUS();
                DataTable dt = new DataTable();
                dt = cbBUS.TimCB(txt_TimKiemMaCB.Text);
                txt_TimKiemMaCB.ResetText();
                if (dt.Rows.Count > 0)
                {
                    dgvCB.DataSource = dt;
                    dgvCB.Columns[0].HeaderText = "Mã chuyến bay";
                    dgvCB.Columns[1].HeaderText = "Ngày bay";
                    dgvCB.Columns[2].HeaderText = "Giờ khởi hành";
                    dgvCB.Columns[3].HeaderText = "Thời gian bay";
                    dgvCB.Columns[4].HeaderText = "Thời gian dự kiến đến";
                    dgvCB.Columns[5].HeaderText = "Số ghế hạng 1";
                    dgvCB.Columns[6].HeaderText = "Số ghế hạng 2";
                    dgvCB.Columns[7].HeaderText = "Mã tuyến bay";
                    dgvCB.Columns[8].HeaderText = "Mã máy bay";

                    dgvCB.Columns[0].Width = 200;
                    dgvCB.Columns[1].Width = 100;
                    dgvCB.Columns[2].Width = 100;
                    dgvCB.Columns[3].Width = 100;
                    dgvCB.Columns[4].Width = 100;
                    dgvCB.Columns[5].Width = 90;
                    dgvCB.Columns[6].Width = 90;
                    dgvCB.Columns[7].Width = 150;
                    dgvCB.Columns[8].Width = 100;
                    dgvCB.AllowUserToAddRows = false;
                    dgvCB.EditMode = DataGridViewEditMode.EditProgrammatically;
                    MessageBox.Show("Tìm chuyến bay thành công!");
                } 
                else
                {
                    MessageBox.Show("Không tìm thấy chuyến bay!");
                }
            }
        }
    }
}
