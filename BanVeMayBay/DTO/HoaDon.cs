using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        private string maHD, maPhieuDatCho, nhanVien_maNV, khachHang_CMND;
        private DateTime ngayLap;
        private long thanhTien;
        public HoaDon()
        { }

        public HoaDon(string maHD, string maPhieuDatCho, string nhanVien_maNV, string khachHang_CMND, DateTime ngayLap, long thanhTien)
        {
            this.maHD = maHD;
            this.maPhieuDatCho = maPhieuDatCho;
            this.nhanVien_maNV = nhanVien_maNV;
            this.khachHang_CMND = khachHang_CMND;
            this.ngayLap = ngayLap;
            this.thanhTien = thanhTien;
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaPhieuDatCho { get => maPhieuDatCho; set => maPhieuDatCho = value; }
        public string NhanVien_maNV { get => nhanVien_maNV; set => nhanVien_maNV = value; }
        public string KhachHang_CMND { get => khachHang_CMND; set => khachHang_CMND = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public long ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
