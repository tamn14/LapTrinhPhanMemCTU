using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyDichBenh.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance; 

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }

        private AccountDAO() { }

        public bool login(string username, string password) 
        {
           string sql  = " USP_lg @username , @password ";  
           DataTable result = DataProvider.Instance.ExecuteQuery(sql , new object[]{username ,password} );
           return result.Rows.Count > 0;

        }

        public NguoiDung layNguoiDungTheoTenDangNhap(string tenDangNhap)
        {

            string query = "SELECT * FROM NguoiDung WHERE TenDangNhap = @TenDangNhap";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenDangNhap });


            if (data.Rows.Count > 0)
            {
               
                DataRow row = data.Rows[0];

                
                string tenDangNhapDb = row["TenDangNhap"].ToString();
                string matkhau = row["MatKhau"].ToString();
                int vaiTro = Convert.ToInt32(row["VaiTro"]);
                string tenHienThi = row["TenHienThi"].ToString();

               
                NguoiDung nguoidung = new NguoiDung(tenDangNhapDb, matkhau, vaiTro, tenHienThi);

                return nguoidung;
            }

            
            return null;
        }

        public int updateNguoidung(NguoiDung nguoiDung)
        {
            if (nguoiDung == null)
            {
                return 0;  
            }

            string query = "Update NguoiDung set TenHienThi = @TenHienThi , MatKhau = @MatKhau where tenDangNhap = @TenDangNhap";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[]
                {
                    nguoiDung.getTenHienThi(),
                    nguoiDung.getMatKhau(),
                    nguoiDung.getTenDangNhap()
                });
                return 1;
            }
            catch (Exception ex)
            {
                
                return 0;
            }


        }

        


    }
}
