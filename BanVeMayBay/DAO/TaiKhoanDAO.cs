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
    public class TaiKhoanDAO : DBConnection
    {
        public void DoiMatKhau(TaiKhoan tk, string matKhauMoi, string matKhauMoiNL)
        {
            const string sql = "DOIMATKHAU";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@tenTaiKhoan", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(tk.tenTK);
            sqlParameters[1] = new SqlParameter("@matKhau", SqlDbType.Char);
            sqlParameters[1].Value = Convert.ToString(tk.matKhau);

            sqlParameters[2] = new SqlParameter("@matKhauMoi", SqlDbType.Char);
            sqlParameters[2].Value = Convert.ToString(matKhauMoi);
            sqlParameters[3] = new SqlParameter("@matKhauMoiNL", SqlDbType.Char);
            sqlParameters[3].Value = Convert.ToString(matKhauMoiNL);
            executeDMKQuery(sql, sqlParameters);
        }
        public void showInformation(TaiKhoan tk,DataTable dt)
        {
            const string sql = "SHOWINFORMATION";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@tenTaiKhoan", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(tk.tenTK);

            executeShowInformation(sql, sqlParameters,dt);
        }    
        public DataTable Login(TaiKhoan tk)
        {
            string sql = "select * from Dang_Nhap(@Username,@Password)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Username", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(tk.tenTK);
            sqlParameters[1] = new SqlParameter("@Password", SqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(tk.matKhau);

            return executeSearchQuery(sql,sqlParameters);
        }
    }
}
