using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class TaiKhoan
    {
        private string TenTK, MatKhau, LoaiTK, IDNhanVien;

        public TaiKhoan()
        {
        }

        public TaiKhoan(string tenTK, string matKhau, string loaiTK, string iDNhanVien)
        {
            TenTK = tenTK;
            MatKhau = matKhau;
            LoaiTK = loaiTK;
            IDNhanVien = iDNhanVien;
        }

        public string tenTK { get => TenTK; set => TenTK = value; }
        public string matKhau { get => MatKhau; set => MatKhau = value; }
        public string loaiTK { get => LoaiTK; set => LoaiTK = value; }
        public string iDNhanVien { get => IDNhanVien; set => IDNhanVien = value; }

    }
}
