
using BUS;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
//using Microsoft.Office.Interop.Excel;
//using Spire.Xls;
///using System.IO;


namespace BanVeMayBay
{
    public partial class frm_BanVe : Form
    {
        public string matuyen;
        public string s1;
        public string htoancuc;
        public string giodi;
        public string mahangve;
        public string machuyen, machuyenold;
       // public string soghe;
        public DateTime giodi1;
        public frm_BanVe()
        {
            InitializeComponent();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frm_NutChonHoTroBanVe f = new  frm_NutChonHoTroBanVe();
            f.TruyenData = new frm_NutChonHoTroBanVe.TruyenChoCha(LoadData);
            f.ShowDialog();
        }
        private void LoadData(string data,string data2)
        {
            txt_SoGhe.Text = data;
            string sample1 = data2;
            txt_HangGhe.Text = data2;
            string s2;
            s2 = string.Concat(mahangve,sample1);
            s2.Replace(" ","");
            machuyenold = mahangve;
            txt_MaHV.Text= s2;

            
        }
        private void XemViTri1()
        {
            BanVeBUS bvBUS = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bvBUS.HienThi();
            cb_NoiDen.DataSource = dt;
            cb_NoiDen.DisplayMember = "ViTri";
           
        }
        private void XemViTri2()
        {
            BanVeBUS bvBUS = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bvBUS.HienThi();
            cb_NoiDi.DataSource = dt;
            cb_NoiDi.DisplayMember = "ViTri";

        }        
        public void HienThiPhieuDatCho()
        {
            BanVeBUS bv = new BanVeBUS();
            //  NhanVienBUS nvBUS = new NhanVienBUS();
            DataTable dt = new DataTable();
            dt = bv.HienThiPhieuDatCho();
            dgv_PDC.DataSource = dt;
            dgv_PDC.Columns[0].HeaderText = "Mã Phiếu";
            dgv_PDC.Columns[1].HeaderText = "Thời gian đặt";
            dgv_PDC.Columns[2].HeaderText = "Số ghế";
            dgv_PDC.Columns[3].HeaderText = "Hạng ghế";
            dgv_PDC.Columns[4].HeaderText = "Mã Chuyến Bay";
            dgv_PDC.Columns[5].HeaderText = "Mã Khách Hàng";
            dgv_PDC.Columns[6].HeaderText = "Mã Hạng vé";
            dgv_PDC.Columns[7].HeaderText = "Khối lượng hành lí";
            dgv_PDC.Columns[0].Width = 130;
            dgv_PDC.Columns[1].Width = 130;
            dgv_PDC.Columns[2].Width = 50;
            dgv_PDC.Columns[3].Width = 50;
            dgv_PDC.Columns[4].Width = 160;
            dgv_PDC.Columns[5].Width = 70;
            dgv_PDC.Columns[6].Width = 160;
            dgv_PDC.Columns[7].Width = 50;

            dgv_PDC.AllowUserToAddRows = false;
            dgv_PDC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void frm_BanVe_Load(object sender, EventArgs e)
        {
            XemViTri1();
            XemViTri2();
            dtp_NgayBay.CustomFormat = "yyyy-MM-dd";
            HienThiPhieuDatCho();
            HienThiPhieuHoaDon();
        }      
        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void ThemPhieu()
        {
            string s = ranDomId();
            BanVeBUS nvBUS = new BanVeBUS();
            txt_MaPhieuDC.Text = s;
            BanVe bv1 = new BanVe(s, DateTime.Now, txt_SoGhe.Text, txt_HangGhe.Text,mahangve, txt_MaKH.Text, txt_MaHV.Text, txt_KhoiLuongHL.Text);
            nvBUS.themPhieuDatCho(bv1);
            HienThiPhieuDatCho();
        }
        private void btn_ThemSB_Click(object sender, EventArgs e)
        {
            ThemPhieu();
        }

        private void cb_NoiDi_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(cb_NoiDi.Text != " " && cb_NoiDi.Text.ToString() != cb_NoiDen.Text.ToString())
            {
                BanVeBUS nhanVienBUS = new BanVeBUS();
                BanVeBUS nv2 = new BanVeBUS();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                string d2 = dtp_NgayBay.ToString();
                try
                {
                    dt1 = nhanVienBUS.TimKiemTuyenBay(cb_NoiDi.Text.ToString(), cb_NoiDen.Text.ToString());
                    s1 = dt1.Rows[0].ItemArray[0].ToString();
                    dt2 = nv2.TimKiemKhungGioBay2(s1, dtp_NgayBay.Value);
                    cb_ThoiGianKH.DataSource = dt2;
                    cb_ThoiGianKH.DisplayMember = "GioKhoiHanh";
                }
                catch
                {

                }
              
            }    
        }
        private void cb_NoiDen_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        public void SuaPhieu()
        {           
            BanVeBUS nvBUS = new BanVeBUS();
            BanVe bv1 = new BanVe(txt_MaPhieuDC.Text, dtp_ThoiGianDat.Value, txt_SoGhe.Text, txt_HangGhe.Text,machuyen, txt_MaKH.Text, txt_MaHV.Text, txt_KhoiLuongHL.Text,machuyenold);
            nvBUS.SuaPhieuDatCho(bv1);
            HienThiPhieuDatCho();          
        }
        private void btn_SuaSB_Click(object sender, EventArgs e)
        {          
            SuaPhieu();
        }

        private void dtp_NgayBay_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void cb_ThoiGianKH_SelectedValueChanged(object sender, EventArgs e)
        {
            htoancuc = cb_ThoiGianKH.Text.ToString();           
        }

        private void btn_SuaTB_Click(object sender, EventArgs e)
        {
            BanVeBUS bv1 = new BanVeBUS();
            BanVe bv = new BanVe(txt_MaHoaDon.Text, txt_MaPhieuDatCho.Text, txt_ThanhTien.Text, dtp_NgayTao.Value, txt_MaNV.Text, txt_MaKhachHang.Text);
            bv1.CapNhatHoaDon(bv);
            HienThiPhieuHoaDon();
           // frm_BanVe_Load(sender, e);
        }
        private void btn_TimKiemSB_Click(object sender, EventArgs e)
        {
            SearchPhieuDatCho();
        }
        private void txt_MaHV_TextChanged(object sender, EventArgs e)
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt1 = new DataTable();
            dt1 = bv.LayHangVe(txt_MaHV.Text.ToString().Trim());
            txt_KhoiLuongHL.Text = dt1.Rows[0].ItemArray[1].ToString();
        }

        private void cb_ThoiGianKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_ThoiGianKH.Text != " ")
            {
                BanVeBUS nhanVienBUS = new BanVeBUS();
                BanVeBUS nv2 = new BanVeBUS();
                BanVeBUS bv3 = new BanVeBUS();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                //string d2 = dtp_NgayBay.ToString();
                dt1 = nhanVienBUS.TimKiemTuyenBay(cb_NoiDi.Text.ToString(), cb_NoiDen.Text.ToString());
                s1 = dt1.Rows[0].ItemArray[0].ToString();
                giodi1 = Convert.ToDateTime(cb_ThoiGianKH.Text.ToString());
                giodi = giodi1.Hour.ToString() + ':' + giodi1.Minute.ToString() + ':' + giodi1.Second.ToString();
                dt3 = bv3.TimKiemGhe(s1, dtp_NgayBay.Value, giodi);
                Bientoancuc.soghe = Convert.ToString(dt3.Rows[0].ItemArray[2].ToString());
                mahangve = Convert.ToString(dt3.Rows[0].ItemArray[1].ToString());
                machuyenold = Convert.ToString(dt3.Rows[0].ItemArray[2].ToString());
                txt_HangGhe.Text = Bientoancuc.soghe;
            }    
        }

        private void cb_NoiDi_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_NoiDi.Text != " " && cb_NoiDi.Text.ToString() != cb_NoiDen.Text.ToString())
            {
                BanVeBUS nhanVienBUS = new BanVeBUS();
                BanVeBUS nv2 = new BanVeBUS();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                string d2 = dtp_NgayBay.ToString();
                try
                {
                    dt1 = nhanVienBUS.TimKiemTuyenBay(cb_NoiDi.Text.ToString(), cb_NoiDen.Text.ToString());
                    s1 = dt1.Rows[0].ItemArray[0].ToString();
                    dt2 = nv2.TimKiemKhungGioBay2(s1, dtp_NgayBay.Value);
                    cb_ThoiGianKH.DataSource = dt2;
                    cb_ThoiGianKH.DisplayMember = "GioKhoiHanh";
                }
                catch
                {
                    MessageBox.Show("Không tìm thấy");
                }
             
            }
        }

        private void cb_NoiDen_SelectedValueChanged(object sender, EventArgs e)
        {
           /* if (cb_NoiDen.Text != " " && cb_NoiDi.Text.ToString() != cb_NoiDen.Text.ToString())
           // {
            //    BanVeBUS nhanVienBUS = new BanVeBUS();
           ///    BanVeBUS nv2 = new BanVeBUS();
           //     DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                string d2 = dtp_NgayBay.ToString();
                dt1 = nhanVienBUS.TimKiemTuyenBay(cb_NoiDi.Text.ToString(), cb_NoiDen.Text.ToString());
                s1 = dt1.Rows[0].ItemArray[0].ToString();
                dt2 = nv2.TimKiemKhungGioBay2(s1, dtp_NgayBay.Value);
                cb_ThoiGianKH.DataSource = dt2;
                cb_ThoiGianKH.DisplayMember = "GioKhoiHanh";
            }
           */
        
        }

        public void LoadKhachHang(string data)
        {
            txt_MaKH.Text = data;

        }
        private void btn_ChonKH_Click(object sender, EventArgs e)
        {
            frm_ChonKhachHang f = new frm_ChonKhachHang();
            f.TruyenData = new frm_ChonKhachHang.TruyenChoCha(LoadKhachHang);
            f.ShowDialog();
        }

        private void dgv_PDC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_PDC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaPhieuDC.Text = dgv_PDC.CurrentRow.Cells[0].Value.ToString();
            txt_SoGhe.Text = dgv_PDC.CurrentRow.Cells[2].Value.ToString();
           txt_HangGhe.Text = dgv_PDC.CurrentRow.Cells[3].Value.ToString();
            txt_MaKhachHang.Text = dgv_PDC.CurrentRow.Cells[5].Value.ToString();
            dtp_ThoiGianDat.Value = Convert.ToDateTime(dgv_PDC.CurrentRow.Cells[1].Value.ToString());
            txt_MaHV.Text = dgv_PDC.CurrentRow.Cells[6].Value.ToString();
            txt_KhoiLuongHL.Text = dgv_PDC.CurrentRow.Cells[7].Value.ToString();
            machuyen = dgv_PDC.CurrentRow.Cells[4].Value.ToString().Trim();
            string s1 = dgv_PDC.CurrentRow.Cells[4].Value.ToString().Trim();
            BanVeBUS bv = new BanVeBUS();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            dt1 = bv.LayNguocHBay(s1);
            cb_ThoiGianKH.DataSource = dt1;
            cb_ThoiGianKH.DisplayMember = "GioKhoiHanh";
            string noidi1 = dt1.Rows[0].ItemArray[3].ToString();
            string noiden = dt1.Rows[0].ItemArray[2].ToString();
            dt2 = bv.LayNguocTenDenVaDI(noidi1);
            dt3 = bv.LayNguocTenDenVaDI(noiden);
            cb_NoiDi.Text = dt2.Rows[0].ItemArray[0].ToString();
            cb_NoiDen.Text = dt3.Rows[0].ItemArray[0].ToString();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchPhieuDatCho();
        }
        private void SearchPhieuDatCho()
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bv.SearchPhieuDatCho(txtSearch.Text);
            dgv_PDC.DataSource = dt;
            dgv_PDC.Columns[0].HeaderText = "Mã Phiếu";
            dgv_PDC.Columns[1].HeaderText = "Thời gian đặt";
            dgv_PDC.Columns[2].HeaderText = "Số ghế";
            dgv_PDC.Columns[3].HeaderText = "Hạng ghế";
            dgv_PDC.Columns[4].HeaderText = "Mã Chuyến Bay";
            dgv_PDC.Columns[5].HeaderText = "Mã Khách Hàng";
            dgv_PDC.Columns[6].HeaderText = "Mã Hạng vé";
            dgv_PDC.Columns[7].HeaderText = "Khối lượng hành lí";
            dgv_PDC.Columns[0].Width = 170;
            dgv_PDC.Columns[1].Width = 150;
            dgv_PDC.Columns[2].Width = 200;
            dgv_PDC.Columns[3].Width = 100;
            dgv_PDC.Columns[4].Width = 100;
            dgv_PDC.Columns[5].Width = 200;
            dgv_PDC.Columns[6].Width = 100;
            dgv_PDC.Columns[7].Width = 200;
            dgv_PDC.AllowUserToAddRows = false;
            dgv_PDC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void HienThiPhieuHoaDon()
        {
            BanVeBUS bv = new BanVeBUS();
            DataTable dt = new DataTable();
            dt = bv.HienThiPhieuHoaDon();
             dgv_PHD.DataSource = dt;
            dgv_PHD.Columns[0].HeaderText = "Mã Phiếu Hóa Đơn";
            dgv_PHD.Columns[1].HeaderText = "Mã Phiếu Đặt chỗ";
            dgv_PHD.Columns[2].HeaderText = "Thành Tiền";
            dgv_PHD.Columns[3].HeaderText = "Ngày Lập";
            dgv_PHD.Columns[4].HeaderText = "Mã Nhân Viên";
            dgv_PHD.Columns[5].HeaderText = "CMND";
            dgv_PHD.Columns[0].Width = 170;
            dgv_PHD.Columns[1].Width = 150;
            dgv_PHD.Columns[2].Width = 200;
            dgv_PHD.Columns[3].Width = 100;
            dgv_PHD.Columns[4].Width = 100;
            dgv_PHD.Columns[5].Width = 200;
            dgv_PHD.AllowUserToAddRows = false;
            dgv_PHD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void  LoadPhieuDatCho(string s)
        {
            txt_MaPhieuDatCho.Text = s;
            BanVeBUS bv = new BanVeBUS();
            BanVeBUS bv1 = new BanVeBUS();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1 = bv.LayThongTinTruyVanChoHoaDon(txt_MaPhieuDatCho.Text);
            string s1 = dt1.Rows[0].ItemArray[2].ToString().Trim();
            txt_MaKhachHang.Text = dt1.Rows[0].ItemArray[1].ToString();
            dt2 = bv1.LayThongTinGiaTienHoaDon(s1);
            txt_ThanhTien.Text = dt2.Rows[0].ItemArray[0].ToString();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frm_ChonHoaDoncs f = new frm_ChonHoaDoncs();
            f.TruyenData = new frm_ChonHoaDoncs.TruyenChoCha(LoadPhieuDatCho);
            f.ShowDialog();
        }

        private void btn_ThemTB_Click(object sender, EventArgs e)
        {
            string s = ranDomId();
            txt_MaHoaDon.Text = s;
            BanVeBUS bv1 = new BanVeBUS();
            BanVe bv = new BanVe(s,txt_MaPhieuDatCho.Text,txt_ThanhTien.Text,dtp_NgayTao.Value,txt_MaNV.Text,txt_MaKhachHang.Text);
            bv1.ThemHoaDon(bv);
            HienThiPhieuHoaDon();
        }

        private void dgv_PHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaPhieuDatCho.Text = dgv_PHD.CurrentRow.Cells[1].Value.ToString();
            txt_MaHoaDon.Text = dgv_PHD.CurrentRow.Cells[0].Value.ToString();
           txt_ThanhTien.Text = dgv_PHD.CurrentRow.Cells[2].Value.ToString();
           dtp_NgayTao.Value = Convert.ToDateTime(dgv_PHD.CurrentRow.Cells[3].Value);
            txt_MaNV.Text = dgv_PHD.CurrentRow.Cells[4].Value.ToString();
            txt_MaKhachHang.Text = dgv_PHD.CurrentRow.Cells[5].Value.ToString();

        }
     /*   public void InHoaDon()
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            Microsoft.Office.Interop.Excel.Application exApp;
            Microsoft.Office.Interop.Excel.Workbook workBook;
            Microsoft.Office.Interop.Excel.Worksheet workSheet;
            try
            {
                //Tạo đối tượng COM.
                exApp = new Microsoft.Office.Interop.Excel.Application();
                exApp.Visible = false;
                exApp.DisplayAlerts = false;
                //workBook = exApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

                workBook = exApp.Workbooks.Add(Type.Missing);
                workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Sheets["Sheet1"];

                workSheet.Name = "Hóa đơn đặt vé";
                workSheet.Cells.Style.Font.Size = 13;
                workSheet.Cells.Style.Font.Name = "Calibri";

                workSheet.Cells[1, 1].Value = "Hệ thống Bán vé máy bay  ";
                workSheet.Cells[1, 1].Font.Size = 14;
                workSheet.Cells[1, 1].Font.Bold = true;
                workSheet.Cells[2, 1].Value = "Địa Chỉ: Thủ Đức, Hồ Chí Minh";
                workSheet.Cells[3, 1].Value = "Điện thoại: 190012345";
                workSheet.Cells[4, 1].Value = "HÓA ĐƠN BÁN HÀNG";
                workSheet.Cells[4, 1].Font.Size = 16;
                workSheet.Cells[4, 1].Font.Bold = true;

              /*  for (int i = 1; i < dgv_PDC.ColumnCount; i++)
                {
                    workSheet.Cells[12, i] = dgv_PDC.Columns[i].HeaderText;
                    workSheet.Cells[12, i].Font.Bold = true;
                    workSheet.Cells[12, i].ColumnWidth = 10;
                    workSheet.Cells[12, i].Borders.LineStyle = true;
                }
              

              // int lasti = 0, lastj = 0;

                for (int i = 0; i < dgv_PDC.RowCount; i++)
                {
                    if (dgv_PDC.Rows[i].Cells[0].Value.ToString() == txt_MaPhieuDatCho.Text)
                    {
                        workSheet.Cells[10, 1] = "Ngày đặt: " + dgv_PDC.Rows[i].Cells[2].Value.ToString();
                        workSheet.Cells[11, 1] = "Mã Phiếu đặt chỗ : " + dgv_PHD.Rows[i].Cells[1].Value.ToString();
                        workSheet.Cells[12, 1] = "Khách hàng: " + dgv_PHD.Rows[i].Cells[3].Value.ToString();
                        workSheet.Cells[13, 1] = "Thu ngân: " + dgv_PHD.Rows[i].Cells[2].Value.ToString();
                        //   workSheet.Cells[10, 1] = "Mã Voucher: " + dgvDH.Rows[i].Cells[6].Value.ToString();
                        //  workSheet.Cells[lasti + 14, lastj] = dgvDH.Rows[i].Cells[7].Value.ToString();
                    }
                }


         
           //    workSheet.Cells[lasti + 14, lastj - 1] = "Tổng tiền:";
                for (int i = 0; i < dgv_PHD.RowCount; i++)
                {
                    if (dgv_PHD.Rows[i].Cells[0].Value.ToString() == txt_MaHoaDon.Text)
                    {
                        workSheet.Cells[6, 1] = "Mã hóa đơn: " + dgv_PHD.Rows[i].Cells[0].Value.ToString();
                        workSheet.Cells[7, 1] = "Mã Phiếu đặt chỗ : " + dgv_PHD.Rows[i].Cells[1].Value.ToString();
                        workSheet.Cells[8, 1] = "Mã Khách hàng: " + dgv_PHD.Rows[i].Cells[3].Value.ToString();
                        workSheet.Cells[9, 1] = "Mã Nhân viên: " + dgv_PHD.Rows[i].Cells[2].Value.ToString();
                     //   workSheet.Cells[10, 1] = "Mã Voucher: " + dgvDH.Rows[i].Cells[6].Value.ToString();
                      //  workSheet.Cells[lasti + 14, lastj] = dgvDH.Rows[i].Cells[7].Value.ToString();
                    }
                }
                workBook.Activate();
                workBook.SaveAs(filePath);
                workBook.Save();
                workBook.Close();
                exApp.Quit();
                bool flag = SaveAsPdf(filePath);
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workBook = null;
                workSheet = null;
            }
        }
        private bool SaveAsPdf(string saveAsLocation)
        {
            string saveas = (saveAsLocation.Split('.')[0]) + ".pdf";
            try
            {
                Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
                workbook.LoadFromFile(saveAsLocation);

                //Save the document in PDF format
                workbook.SaveToFile(saveas, Spire.Xls.FileFormat.PDF);
                System.Diagnostics.Process.Start(saveas);
                Path.GetTempPath();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        */  

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
           // InHoaDon();
        }

        private void txt_SoGhe_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_HangGhe_TextChanged(object sender, EventArgs e)
        {

        }

        public string ranDomId()
        {
            string id = "";
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                if (random.Next(0, 2) == 1)
                {
                    int num = random.Next(65, 91);
                    id += (char)num;
                }
                else
                {
                    int num = random.Next(48, 58);
                    id += (char)num;
                }
            }
            return id;

        }
    }
}
