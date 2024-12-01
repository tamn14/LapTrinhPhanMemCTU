using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DAO
{
    public class NguoiDungDAO
    {
        private static NguoiDungDAO instance;

        public static NguoiDungDAO Instance
        {
            get { if (instance == null) instance = new NguoiDungDAO(); return NguoiDungDAO.instance; }
            private set { NguoiDungDAO.instance = value; }
        }



        private NguoiDungDAO() { }

        public DataTable loadNguoiDung ()
        {
            string sql = "select TenDangNhap , MatKhau , VaiTro , TenHienThi from NguoiDung";
            return DataProvider.Instance.ExecuteQuery(sql); 
        }

        public DataTable find(string str)
        {
            string sql = "select TenDangNhap , MatKhau , VaiTro , TenHienThi from NguoiDung where TenDangNhap like @str ";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] { "%" + str + "%" });
        }

        public DataTable loadNguoiDungForDS(int page)
        {
            string sql = "exec USP_GetListNguoiDung @page";
            return DataProvider.Instance.ExecuteQuery(sql, new object[] {page});
        }

        public int getCount()
        {
            string sql = "SELECT COUNT(*) AS VaiTRo FROM NguoiDung;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["VaiTRo"]);
                return count;


            }
            return -1;
        }

        public List<string> getMax()
        {
            string sql = "WITH VaiTroCount AS ( SELECT VaiTro, COUNT(*) AS SoLuong FROM NguoiDung GROUP BY VaiTro )" +
                            " SELECT Vaitro, SoLuong FROM VaiTroCount WHERE SoLuong = (SELECT Max(SoLuong) FROM VaiTroCount);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listVaiTro = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string Vaitro = (row["Vaitro"]).ToString();
                    listVaiTro.Add(Vaitro);




                }
                return listVaiTro;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }

        public List<string> getMin()
        {
            string sql = "WITH VaiTroCount AS ( SELECT VaiTro, COUNT(*) AS SoLuong FROM NguoiDung GROUP BY VaiTro )" +
                            " SELECT Vaitro, SoLuong FROM VaiTroCount WHERE SoLuong = (SELECT Min(SoLuong) FROM VaiTroCount);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listVaiTro = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string Vaitro = (row["Vaitro"]).ToString();
                    listVaiTro.Add(Vaitro);




                }
                return listVaiTro;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }

        public Dictionary<string, int> getNguoiDungByVaiTro()
        {
            string sql = " SELECT vaitro, COUNT(TenDangNhap) AS SoLuongNguoiDung FROM NguoiDung GROUP BY vaitro;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            Dictionary<string, int> list = new Dictionary<string, int>();
            foreach (DataRow row in data.Rows)
            {
                string VaiTro = row["vaitro"].ToString();
                int cout = Convert.ToInt32(row["SoLuongNguoiDung"]);
                list.Add(VaiTro, cout);
            }

            return list;


        }



    }
}
