using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DTO;

namespace DAO
{
    public class NhanVienDAO : DBConnection
    {
        public NhanVienDAO() : base() { }
        public void ThemNV(NhanVien nv)
        {
            const string sql = "ThemNV";
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@MaNV", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(nv.Manv);
            sqlParameters[1] = new SqlParameter("@CMND", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(nv.Cmnd);
            sqlParameters[2] = new SqlParameter("@TenNV", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(nv.Tennv);
            sqlParameters[3] = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(nv.Gioitinh);
            sqlParameters[4] = new SqlParameter("@NgaySinh", SqlDbType.DateTime);
            sqlParameters[4].Value = Convert.ToString(nv.Ngaysinh);
            sqlParameters[5] = new SqlParameter("@SDT", SqlDbType.NVarChar);
            sqlParameters[5].Value = Convert.ToString(nv.Sdt);
            sqlParameters[6] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            sqlParameters[6].Value = Convert.ToString(nv.Diachi);
            executeInsertQuery(sql, sqlParameters);
        }
        public void XoaNV(String maNV)
        {
            const string sql = "XoaNV";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaNV", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(maNV);
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public void SuaNV(NhanVien nv)
        {
            const string sql = "ChinhSuaNV";
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@MaNV", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(nv.Manv);
            sqlParameters[1] = new SqlParameter("@CMND", SqlDbType.NVarChar);
            sqlParameters[1].Value = Convert.ToString(nv.Cmnd);
            sqlParameters[2] = new SqlParameter("@TenNV", SqlDbType.NVarChar);
            sqlParameters[2].Value = Convert.ToString(nv.Tennv);
            sqlParameters[3] = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
            sqlParameters[3].Value = Convert.ToString(nv.Gioitinh);
            sqlParameters[4] = new SqlParameter("@NgaySinh", SqlDbType.DateTime);
            sqlParameters[4].Value = Convert.ToString(nv.Ngaysinh);
            sqlParameters[5] = new SqlParameter("@SDT", SqlDbType.NVarChar);
            sqlParameters[5].Value = Convert.ToString(nv.Sdt);
            sqlParameters[6] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            sqlParameters[6].Value = Convert.ToString(nv.Diachi);
            executeUpdateOrDeleteQuery(sql, sqlParameters);
        }
        public DataTable HienThi()
        {
            const string sql = "select * from XEMNHANVIEN";
            return executeDisplayQuery(sql);
        }
        public DataTable Search(string str)
        {
            string sql = "select * from TimKiem_NV(@str)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@str", SqlDbType.NVarChar);
            sqlParameters[0].Value = Convert.ToString(str);
            return executeSearchQuery(sql,sqlParameters);
        }
    }
}