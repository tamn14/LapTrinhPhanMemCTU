using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDichBenh.DAO
{
    public class DichBenhDAO
    {

        private static DichBenhDAO instance;

        public static DichBenhDAO Instance
        {
            get { if (instance == null) instance = new DichBenhDAO(); return DichBenhDAO.instance; }
            private set { DichBenhDAO.instance = value; }
        }

        private DichBenhDAO() { }


        public DataTable loadDichBenh()
        {
            return DataProvider.Instance.ExecuteQuery("Select ten  , mota  from DichBenh ");
        }

        public DataTable finđB(string str) 
        {
            string sql  =  "Select ten  , mota  from DichBenh where ten like @str";
            return DataProvider.Instance.ExecuteQuery(sql , new object[] { "%"+ str +  "%" });  
        }

        public DataTable loadAllDB(int page)
        {
            string sql = "exec USP_GetListDichBenh @page = @page";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] { page });
        }


        public DataTable loadAllDBForDS(int page)
        {
            string sql = "exec USP_GetListDB @page";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] { page });
        }

        public int getcount()
        {
            string sql = "SELECT count(*) as soluong FROM DichBenh d JOIN BienPhapXuLy b ON d.DichBenhID = b.DichBenhID ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow row in data.Rows)
            {
                int soluong = Convert.ToInt32(row["soluong"]);
                return soluong;


            }
            return -1;

        }


        public List<DichBenh> GetDichBenhs()
        {
            List<DichBenh> list = new List<DichBenh>();
            string sql = "SELECT DichBenhID, Ten, MoTa FROM DichBenh";
            DichBenh dichBenh = null; 
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                foreach (DataRow row in data.Rows)
                {
                    int dichBenhID = Convert.ToInt32(row["DichBenhID"]);
                    string ten = row["Ten"].ToString();
                    string moTa = row["MoTa"].ToString();

                    dichBenh = new DichBenh(dichBenhID, ten, moTa);
                    list.Add(dichBenh);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }

            return list;
        }


        public DataTable loadDichBenhTheoNguoiDung(NguoiDung nguoiDung)
        {
            if (nguoiDung == null)
            {
                Console.WriteLine("Người dùng không tồn tại");
                return null;
            }

            string tenDangNhap = nguoiDung.getTenDangNhap();
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                Console.WriteLine("Tên đăng nhập không hợp lệ");
                return null;
            }

            string query = " SELECT n.Ten as TenNhaNong,  r.Ten as TenRuong,   d.Ten as TenDichBenh,  g.TenGiong,   b.MucDo,  b.NgayBaoCao   FROM RuongLua r   JOIN NongDan n ON r.NongDanID = n.NongDanID   JOIN GiongLua g ON r.GiongLuaID = g.GiongLuaID   JOIN BaoCaoDichBenh b ON r.RuongLuaID = b.RuongLuaID    JOIN DichBenh d ON b.DichBenhID = d.DichBenhID   WHERE n.TenDangNhap = @tenDangNhap";


            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenDangNhap });
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khi thuc hien truy van : " + ex.Message);
                return null;
            }



        }


        public DataTable loadRuongChuaDichBenhTheoNguoiDung(NguoiDung nguoiDung)
        {
            if (nguoiDung == null)
            {
                Console.WriteLine("Người dùng không tồn tại");
                return null;
            }

            string tenDangNhap = nguoiDung.getTenDangNhap();
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                Console.WriteLine("Tên đăng nhập không hợp lệ");
                return null;
            }

            string query = "SELECT n.Ten AS TenNhaNong,    r.Ten AS TenRuong,     g.TenGiong,     NULL AS TenDichBenh,    NULL AS MucDo,     NULL AS NgayBaoCao FROM RuongLua r   JOIN NongDan n ON r.NongDanID = n.NongDanID   JOIN GiongLua g ON r.GiongLuaID = g.GiongLuaID  WHERE n.TenDangNhap = @TenDangNhap   AND r.RuongLuaID NOT IN (SELECT RuongLuaID FROM BaoCaoDichBenh);";


            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tenDangNhap });
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khi thuc hien truy van : " + ex.Message);
                return null;
            }



        }

        public DataTable find(string tendangnhap , string str)
        {
            string query = " SELECT n.Ten as TenNhaNong,  r.Ten as TenRuong,   d.Ten as TenDichBenh,  g.TenGiong,   b.MucDo,  b.NgayBaoCao   FROM RuongLua r   JOIN NongDan n ON r.NongDanID = n.NongDanID   JOIN GiongLua g ON r.GiongLuaID = g.GiongLuaID   JOIN BaoCaoDichBenh b ON r.RuongLuaID = b.RuongLuaID    JOIN DichBenh d ON b.DichBenhID = d.DichBenhID   WHERE n.TenDangNhap = @tenDangNhap and (r.ten like @str or d.Ten like @str  ) ;";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tendangnhap, "%" + str + "%"  });
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khi thuc hien truy van : " + ex.Message);
                return null;
            }

        }

        public DataTable find2(string tendangnhap, string str)
        {
            string query = "SELECT n.Ten AS TenNhaNong,    r.Ten AS TenRuong,     g.TenGiong,     NULL AS TenDichBenh,    NULL AS MucDo,     NULL AS NgayBaoCao FROM RuongLua r   JOIN NongDan n ON r.NongDanID = n.NongDanID   JOIN GiongLua g ON r.GiongLuaID = g.GiongLuaID  WHERE n.TenDangNhap = @TenDangNhap and (r.ten like @str   )   AND r.RuongLuaID NOT IN (SELECT RuongLuaID FROM BaoCaoDichBenh);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { tendangnhap, "%" + str + "%" });
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khi thuc hien truy van : " + ex.Message);
                return null;
            }

        }



        public DichBenh getIdByName(string name  )
        {
            string sql = "select * from DichBenh where Ten = @name  ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { name  });
            DichBenh dichBenh = null;
            foreach (DataRow row in data.Rows)
            {
                int id = Convert.ToInt32(row["DichBenhID"]);
                string tenGiong = row["Ten"].ToString();
                string MoTa = row["MoTa"].ToString();
                dichBenh = new DichBenh(id, tenGiong, MoTa);

            }
            return dichBenh;
        }

        


        public int insert( DichBenh dichBenh)
        {
            string ten = dichBenh.ten;
            string mota = dichBenh.moTa; 

            try {
                string sql = " Insert into DichBenh(ten , mota) values( @ten , @mota )";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { ten, mota });
                return data;  
            }
            catch (Exception e) {
                Console.WriteLine("Loi :  " + e);  
            
            }
            return -1; 
           
            

        }

        public int remove(int DichBenhID)
        {
            

            try
            {
                string sql = " Delete from DichBenh where DichBenhID = @DichBenhID";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { DichBenhID });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);

            }
            return -1;



        }

        public int update(DichBenh dichBenh)
        {
            int DichBenhID =  dichBenh.dichBenhID; 
            string ten = dichBenh.ten;
            string mota = dichBenh.moTa; 

            try
            {
                string sql = " Update  DichBenh set ten = @ten , mota  = @mota  where DichBenhID = @DichBenhID";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { ten , mota , DichBenhID });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);

            }
            return -1;



        }



        

        public int SelectAll(int DichBenhID)
        {
            

            try
            {
                string sql = " Select * from DichBenh where DichBenhID = @DichBenhID";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] {  DichBenhID });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);

            }
            return -1;



        }

        public DataTable getInfor()
        {
            string sql = "SELECT * FROM LayThongTinDichBenh();";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);


            return data;
        }

        public Dictionary<string, int> getDichBenhByRuongLua()
        {
            string sql = " select d.Ten , count(r.RuongLuaID ) as soluong from RuongLua r, BaoCaoDichBenh b, DichBenh d  " +
                            " where r.RuongLuaID = b.RuongLuaID and b.DichBenhID = d.DichBenhID group by  d.Ten ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            Dictionary<string, int> list = new Dictionary<string, int>();
            foreach (DataRow row in data.Rows)
            {
                string ten = row["Ten"].ToString();
                int cout = Convert.ToInt32(row["soluong"]);
                list.Add(ten, cout);
            }

            return list;


        }





        public int getCount()
        {
            string sql = "SELECT COUNT(*) AS Soluong FROM DichBenh;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["Soluong"]);
                return count;


            }
            return -1;
        }

        public List<string> getMaxByRuongLua()
        {
            string sql = "SELECT D.Ten, COUNT(B.DichBenhID) AS SoLuongXuatHien FROM DichBenh D " +
                           " JOIN BaoCaoDichBenh B ON D.DichBenhID = B.DichBenhID GROUP BY D.Ten HAVING COUNT(B.DichBenhID) = ( " +
                           " SELECT MAX(SoLuong) FROM ( SELECT COUNT(DichBenhID) AS SoLuong FROM BaoCaoDichBenh GROUP BY DichBenhID ) AS T); "
                ;
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listVitri = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string Vaitro = (row["Ten"]).ToString();
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

        public List<string> getMinByRuongLua()
        {
            string sql = "SELECT D.Ten, COUNT(B.DichBenhID) AS SoLuongXuatHien FROM DichBenh D " +
                           " JOIN BaoCaoDichBenh B ON D.DichBenhID = B.DichBenhID GROUP BY D.Ten HAVING COUNT(B.DichBenhID) = ( " +
                           " SELECT Min(SoLuong) FROM ( SELECT COUNT(DichBenhID) AS SoLuong FROM BaoCaoDichBenh GROUP BY DichBenhID ) AS T); "
                ;
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listVitri = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string Vaitro = (row["Ten"]).ToString();
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


        public DataTable find4(string str)
        {
            string sql = "SELECT d.RuongLuaID, d.ten AS TenRuong, d.vitri, d.dientich, g.tenGiong, db.ten AS tenDichBenh, bc.ngayBaoCao " +
                         "FROM NguoiDung a " +
                         "JOIN NongDan b ON a.TenDangNhap = b.TenDangNhap " +
                         "JOIN RuongLua d ON b.NongDanID = d.NongDanID " +
                         "JOIN GiongLua g ON d.GiongLuaID = g.GiongLuaID " +
                         "JOIN MuaVu m ON m.MuaVuID = g.MuaVuID " +
                         "JOIN BaoCaoDichBenh bc ON bc.RuongLuaID = d.RuongLuaID " +
                         "JOIN DichBenh db ON db.DichBenhID = bc.DichBenhID " +
                         "WHERE d.ten LIKE @str OR db.ten LIKE @str";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] { "%" + str + "%" });
        }
















    }
}
