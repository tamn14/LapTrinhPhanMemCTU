using OpenQA.Selenium.DevTools.V127.Debugger;
using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDichBenh.DAO
{
    public class DongRuongDAO
    {
        private static DongRuongDAO instance;

        public static DongRuongDAO Instance
        {
            get { if (instance == null) instance = new DongRuongDAO(); return DongRuongDAO.instance; }
            private set { DongRuongDAO.instance = value; }
        }

        

        private DongRuongDAO() { }

        public DataTable loadDongRuong()
        {
            return DataProvider.Instance.ExecuteQuery("select r.ten, n.ten  , dientich , vitri , g.TenGiong, ngaygieo from RuongLua r , NongDan n , GiongLua g where r.NongDanID = n.NongDanID and r.GiongLuaID = g.GiongLuaID");
        }

        public DataTable loadAllDongRuong(int page)
        {
            string sql = "exec USP_GetlistDongRuong @page = @page";
            return DataProvider.Instance.ExecuteQuery(sql , new object[] {page});
        }

        public DataTable loadDongRuongForDS(int page)
        {
            string sql = "exec USP_GetListRuonglua @page";
            return DataProvider.Instance.ExecuteQuery(sql, new object[] { page });
        }

        public int getcount() {
            string sql = " SELECT  count(*) as soluong  FROM RuongLua r JOIN NongDan n ON r.NongDanID = n.NongDanID JOIN GiongLua g ON r.GiongLuaID = g.GiongLuaID JOIN MuaVu m ON g.MuaVuID = m.MuaVuID";
            DataTable data =  DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow row in data.Rows)
            {
                int soluong = Convert.ToInt32(row["soluong"]);
                return soluong;
              

            }
            return -1;

        }


        public int getIDByName(string name)
        {
            string sql = "select ruongluaID from RuongLua where ten = @name"; 
            DataTable data  = DataProvider.Instance.ExecuteQuery(sql , new object[] {name});
            if (data.Rows.Count > 0)
            {
              
                return Convert.ToInt32(data.Rows[0]["ruongluaID"]);
            }

            
            return -1;
        }



        public RuongLua getRuongLuaByName(string name)
        {
            string sql = "select ruongluaID, ten from RuongLua where ten = @name";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { name });
            RuongLua RuongLua = null;
            foreach (DataRow row in data.Rows)
            {
                int ruongluaID = Convert.ToInt32(row["ruongluaID"]);
                string ten = row["ten"].ToString();
                RuongLua = new RuongLua(ruongluaID, ten);

            }
            return RuongLua;
        }

        public DataTable loadDongRuongTheoNguoiDung(NguoiDung nguoiDung)
        {
            if (nguoiDung == null)
            {
                Console.WriteLine("Người dùng không tồn tại");
                return null;
            }

            string query = " SELECT b.Ten AS TenNhaNong, d.Ten AS TenRuong, d.ViTri, d.DienTich, g.TenGiong, d.NgayGieo FROM NguoiDung a JOIN NongDan b ON a.TenDangNhap = b.TenDangNhap JOIN RuongLua d ON b.NongDanID = d.NongDanID JOIN GiongLua g ON d.GiongLuaID = g.GiongLuaID WHERE a.TenDangNhap = @TenDangNhap ";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[]
                {
                    
                    nguoiDung.getTenDangNhap()
                });
                return data;

                

            }
            catch (Exception ex)
            {
                // Bắt lỗi và trả về 0 nếu có vấn đề
                return null;
            }
        }


        public List<RuongLua> getDongRuongByUserName(NguoiDung nguoiDung)
        {
            if (nguoiDung == null)
            {
                Console.WriteLine("Người dùng không tồn tại");
                return null;
            }
            string  tenDangNhap = nguoiDung.getTenDangNhap();
            List<RuongLua> list = new List<RuongLua>();
            string sql = "select r.RuongLuaID , r.Ten from RuongLua r, NongDan n where r.NongDanID = n.NongDanID and n.TenDangNhap = @tenDangNhap";
            RuongLua ruongLua = null;
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] {tenDangNhap});
                foreach (DataRow row in data.Rows)
                {
                    int RuongLuaID = Convert.ToInt32(row["RuongLuaID"]);
                    string ten = row["Ten"].ToString();
                    
                    ruongLua = new RuongLua(RuongLuaID, ten);
                    
                    list.Add(ruongLua);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }

            return list;
        }

        public int InsertData(int NongDanID, string Ten, string ViTri, double DienTich, int GiongLuaID, DateTime NgayGieo)
        {
            string sql = "INSERT INTO RuongLua (NongDanID, Ten, ViTri, DienTich, GiongLuaID, NgayGieo)  VALUES (@NongDanID, @ten, @vitri, @dientich, @gionglua, @ngaygieo)";
            return DataProvider.Instance.ExecuteNonQuery(sql, new object[] { NongDanID, Ten, ViTri, DienTich, GiongLuaID, NgayGieo });
        }

        public int Remove(int RuongLuaId)
        {
            string sql = "DELETE FROM RuongLua WHERE RuongLuaID = @RuongLuaId";
            return DataProvider.Instance.ExecuteNonQuery(sql, new object[] { RuongLuaId });
        }

        public int Update(RuongLua ruonglua) {
            string sql = "update RuongLua set ten = @name , vitri = @vitri , dientich = @dientich , GiongLuaId = @GiongLuaId , NgayGieo = @NgayGieo  WHERE RuongLuaID = @RuongLuaId";
            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery(sql, new object[] {
                                                                                    ruonglua.ten,
                                                                                    ruonglua.getViTri(),
                                                                                    ruonglua.getDienTich(),
                                                                                    ruonglua.getGiongLua().GiongLuaID,
                                                                                    ruonglua.getNgayGieo(),
                                                                                    ruonglua.ruongLuaID
                });
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return 0; 
            }

        }

        public int getCount()
        {
            string sql = "SELECT COUNT(*) AS Soluong FROM RuongLua;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["Soluong"]);
                return count;


            }
            return -1;
        }

        public List<string> getMaxByViTri()
        {
            string sql = "WITH ViTriCount AS ( SELECT vitri, COUNT(*) AS SoLuong FROM RuongLua GROUP BY vitri ) SELECT vitri, SoLuong FROM ViTriCount WHERE SoLuong = (SELECT max(SoLuong) FROM ViTriCount);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listVitri = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string Vaitro = (row["vitri"]).ToString();
                    listVitri.Add(Vaitro);




                }
                return listVitri;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }

        public List<string> getMinByViTri()
        {
            string sql = "WITH ViTriCount AS ( SELECT vitri, COUNT(*) AS SoLuong FROM RuongLua GROUP BY vitri ) SELECT vitri, SoLuong FROM ViTriCount WHERE SoLuong = (SELECT min(SoLuong) FROM ViTriCount);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listVitri = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string Vaitro = (row["vitri"]).ToString();
                    listVitri.Add(Vaitro);




                }
                return listVitri;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }

        public Dictionary<string, double> getMaxByDienTich()
        {
            string sql = " SELECT Ten, DienTich FROM RuongLua WHERE DienTich = (SELECT MAX(DienTich) FROM RuongLua);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                Dictionary<string, double> listTen = new Dictionary<string, double>();
                foreach (DataRow row in data.Rows)
                {
                    string Ten = (row["Ten"]).ToString();
                    double dienTich = Convert.ToDouble(row["DienTich"]) ;
                    listTen.Add(Ten, dienTich);




                }
                return listTen;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }

        public Dictionary<string, double> getMinByDienTich()
        {
            string sql = " SELECT Ten, DienTich FROM RuongLua WHERE DienTich = (SELECT Min(DienTich) FROM RuongLua);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                Dictionary<string, double> listTen = new Dictionary<string, double>();
                foreach (DataRow row in data.Rows)
                {
                    string Ten = (row["Ten"]).ToString();
                    double dienTich = Convert.ToDouble(row["DienTich"]);
                    listTen.Add(Ten, dienTich);




                }
                return listTen;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }

        public List<string> getMaxByGiongLua()
        {
            string sql = "SELECT G.TenGiong, COUNT(R.GiongLuaID) AS SoLuongGieo FROM RuongLua R" +
                            " JOIN GiongLua G ON R.GiongLuaID = G.GiongLuaID GROUP BY G.TenGiong" +
                            " HAVING COUNT(R.GiongLuaID) = ( SELECT MAX(SoLuong) FROM (" +
                            " SELECT COUNT(GiongLuaID) AS SoLuong FROM RuongLua GROUP BY GiongLuaID) AS T);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listData = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string tenGong = (row["TenGiong"]).ToString();
                    listData.Add(tenGong);




                }
                return listData;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }

        public List<string> getMinByGiongLua()
        {
            string sql = "SELECT G.TenGiong, COUNT(R.GiongLuaID) AS SoLuongGieo FROM RuongLua R" +
                            " JOIN GiongLua G ON R.GiongLuaID = G.GiongLuaID GROUP BY G.TenGiong" +
                            " HAVING COUNT(R.GiongLuaID) = ( SELECT Min(SoLuong) FROM (" +
                            " SELECT COUNT(GiongLuaID) AS SoLuong FROM RuongLua GROUP BY GiongLuaID) AS T);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listData = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string tenGong = (row["TenGiong"]).ToString();
                    listData.Add(tenGong);




                }
                return listData;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }

        public List<string> getMaxByNhaNong()
        {
            string sql = "SELECT N.Ten, COUNT(R.RuongLuaID) AS SoLuongRuong FROM NongDan N" +
                            " JOIN RuongLua R ON N.NongDanID = R.NongDanID GROUP BY N.Ten" +
                            " HAVING COUNT(R.RuongLuaID) = ( SELECT MAX(SoLuong) FROM (" +
                            " SELECT COUNT(RuongLuaID) AS SoLuong FROM RuongLua GROUP BY NongDanID) AS T);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listData = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string ten = (row["Ten"]).ToString();
                    listData.Add(ten);




                }
                return listData;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }
        public List<string> getMinByNhaNong()
        {
            string sql = "SELECT N.Ten, COUNT(R.RuongLuaID) AS SoLuongRuong FROM NongDan N" +
                            " JOIN RuongLua R ON N.NongDanID = R.NongDanID GROUP BY N.Ten" +
                            " HAVING COUNT(R.RuongLuaID) = ( SELECT Min(SoLuong) FROM (" +
                            " SELECT COUNT(RuongLuaID) AS SoLuong FROM RuongLua GROUP BY NongDanID) AS T);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listData = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string ten = (row["Ten"]).ToString();
                    listData.Add(ten);




                }
                return listData;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }











        public Dictionary<string, int> getRuongLuaByVitri()
        {
            string sql = " SELECT vitri, COUNT(RuongLuaID) AS SoLuongRuong FROM RuongLua GROUP BY vitri;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            Dictionary<string, int> list = new Dictionary<string, int>();
            foreach (DataRow row in data.Rows)
            {
                string vitri = row["vitri"].ToString();
                int cout = Convert.ToInt32(row["SoLuongRuong"]);
                list.Add(vitri, cout);
            }

            return list;


        }

        public Dictionary<string, int> getRuongLuaByNongDan()
        {
            string sql = " select n.Ten , count(RuongLuaID) as soluong from RuongLua r, NongDan n where r.NongDanID = n.NongDanID group by  n.Ten";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            Dictionary<string, int> list = new Dictionary<string, int>();
            foreach (DataRow row in data.Rows)
            {
                string ten = row["ten"].ToString();
                int cout = Convert.ToInt32(row["soluong"]);
                list.Add(ten, cout);
            }

            return list;


        }

        public Dictionary<string, int> getRuongLuaByGiongLua()
        {
            string sql = " select g.TenGiong , count(RuongLuaID) as soluong from RuongLua r, GiongLua g where r.GiongLuaID = g.GiongLuaID group by  g.TenGiong";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            Dictionary<string, int> list = new Dictionary<string, int>();
            foreach (DataRow row in data.Rows)
            {
                string ten = row["TenGiong"].ToString();
                int cout = Convert.ToInt32(row["soluong"]);
                list.Add(ten, cout);
            }

            return list;


        }

        public DataTable find(string tenDangNhap, string str)
        {
            string sql = "SELECT b.Ten AS TenNhaNong, d.Ten AS TenRuong, d.ViTri, d.DienTich, g.TenGiong, d.NgayGieo " +
                         "FROM NguoiDung a " +
                         "JOIN NongDan b ON a.TenDangNhap = b.TenDangNhap " +
                         "JOIN RuongLua d ON b.NongDanID = d.NongDanID " +
                         "JOIN GiongLua g ON d.GiongLuaID = g.GiongLuaID " +
                         "WHERE a.TenDangNhap = @TenDangNhap AND d.Ten LIKE @str";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] { tenDangNhap, "%" + str + "%" });
        }


        public DataTable find2( string str)
        {
            string sql = "SELECT b.Ten AS TenNhaNong, b.diachi , b.sodienthoai, d.ten As TenRuong , g.TenGiong , m.TenMuaVu " +
                         "FROM NguoiDung a " +
                         "JOIN NongDan b ON a.TenDangNhap = b.TenDangNhap " +
                         "JOIN RuongLua d ON b.NongDanID = d.NongDanID " +
                         "JOIN GiongLua g ON d.GiongLuaID = g.GiongLuaID " +
                         "Join MuaVu m on m.MuaVuiD = g.MuaVuID " + 
                         "WHERE  d.Ten LIKE @str or b.ten like @str ";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] {  "%" + str + "%" });
        }

        public DataTable find3( string str)
        {
            string sql = "SELECT  d.Ten AS TenRuong, b.Ten AS TenNhaNong ,  d.ViTri, d.DienTich, g.TenGiong, m.TenMuaVu , d.NgayGieo  " +
                         "FROM NguoiDung a " +
                         "JOIN NongDan b ON a.TenDangNhap = b.TenDangNhap " +
                         "JOIN RuongLua d ON b.NongDanID = d.NongDanID " +
                         "JOIN GiongLua g ON d.GiongLuaID = g.GiongLuaID " +
                         " join MuaVu m on m.MuaVuID = g.MuaVuID " + 
                         "WHERE a.TenDangNhap = b.TenDangNhap AND d.Ten LIKE @str ";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] { "%" + str + "%" });
        }









    }


}
