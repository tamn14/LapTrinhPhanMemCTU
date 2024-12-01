using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DAO
{
    public class MuaVuDAO
    {
        private static MuaVuDAO instance;

        public static MuaVuDAO Instance
        {
            get { if (instance == null) instance = new MuaVuDAO(); return MuaVuDAO.instance; }
            private set { MuaVuDAO.instance = value; }
        }

        private MuaVuDAO() { }

        public List<MuaVu> getMuaVu ()
        {
            string sql = "Select * from MuaVu ";  
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            MuaVu muaVu = null;
            List<MuaVu> list  = new List<MuaVu> ();
            foreach (DataRow row in data.Rows)
            {
                int id = Convert.ToInt32(row["MuaVuID"]);
                string ten = row["TenMuaVu"].ToString();
                DateTime NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]);
                DateTime NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]);
                muaVu = new MuaVu(id , ten ,  NgayBatDau , NgayKetThuc);
                list.Add(muaVu);

            }
            return list ;
        }

        public DataTable loadMuaVu()
        {
            return DataProvider.Instance.ExecuteQuery("Select tenMuaVu , NgayBatDau, NgayKetThuc from muavu"); 

        }

        public MuaVu getIdByName(string name)
        {
            string sql = "select * from MuaVu where tenmuavu = @name";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { name });
            MuaVu MuaVu = new MuaVu(); 
            foreach (DataRow row in data.Rows)
            {
                int id = Convert.ToInt32(row["MuaVuID"]);
                string tenMuaVu = row["TenMuaVu"].ToString();
                MuaVu.tenMuaVu = tenMuaVu;
                MuaVu.MaMuaVu = id; 

            }
            return MuaVu;
        }

        public int insert(MuaVu muaVu)
        {
            int muaVuID = muaVu.MaMuaVu;  
            string ten = muaVu.tenMuaVu;
            DateTime ngayBatDau = muaVu.ngayBatDau;
            DateTime ngayKetThuc = muaVu.ngayKetThuc; 

            try
            {
                string sql = " Insert into MuaVu(tenMuaVu , NgayBatDau , NgayKetThuc) values( @ten , @ngayBatDau , @ngayKetThuc )";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { ten, ngayBatDau , ngayKetThuc });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);

            }
            return -1;



        }

        public int remove(int MuaVuID)
        {


            try
            {
                string sql = " Delete from MuaVu where MuaVuID = @MuaVuID";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { MuaVuID });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);

            }
            return -1;



        }

        public int update(MuaVu muaVu)
        {
            int muaVuID = muaVu.MaMuaVu;
            string ten = muaVu.tenMuaVu;
            DateTime ngayBatDau = muaVu.ngayBatDau;
            DateTime ngayKetThuc = muaVu.ngayKetThuc;

            try
            {
                string sql = " Update  MuaVu set tenMuaVu = @ten, NgayBatDau = @NgayBatDau , NgayKetThuc = @NgayKetThuc where MuaVuID = @MuaVuID ";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { ten, ngayBatDau, ngayKetThuc , muaVuID });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);

            }
            return -1;



        }

        

        public Dictionary<string, int> getMuaVuByGiongLua()
        {
            string sql = " select g.tenGiong , count(m.MuaVuID) as soluong from muavu m , GiongLua g  where m.MuaVuID = g.MuaVuID group by g.tenGiong";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            Dictionary<string, int> list = new Dictionary<string, int>();
            foreach (DataRow row in data.Rows)
            {
                string ten = row["tenGiong"].ToString();
                int cout = Convert.ToInt32(row["soluong"]);
                list.Add(ten, cout);
            }

            return list;


        }

        public int getCount()
        {
            string sql = "SELECT COUNT(*) AS Soluong FROM MuaVu;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["Soluong"]);
                return count;


            }
            return -1;
        }

        public List<string> getMaxByGiongLua()
        {
            string sql = "SELECT G.TenGiong, COUNT(R.GiongLuaID) AS SoLanGieo FROM GiongLua G JOIN RuongLua R ON G.GiongLuaID = R.GiongLuaID " +
                " GROUP BY G.TenGiong HAVING COUNT(R.GiongLuaID) = ( SELECT MAX(SoLan) FROM ( SELECT COUNT(GiongLuaID) AS SoLan" +
                " FROM RuongLua GROUP BY GiongLuaID ) AS T);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listVitri = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string Vaitro = (row["TenGiong"]).ToString();
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

        public List<string> getMinByGiongLua()
        {
            string sql = "SELECT G.TenGiong, COUNT(R.GiongLuaID) AS SoLanGieo FROM GiongLua G JOIN RuongLua R ON G.GiongLuaID = R.GiongLuaID " +
                " GROUP BY G.TenGiong HAVING COUNT(R.GiongLuaID) = ( SELECT Min(SoLan) FROM ( SELECT COUNT(GiongLuaID) AS SoLan" +
                " FROM RuongLua GROUP BY GiongLuaID ) AS T);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listVitri = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string Vaitro = (row["TenGiong"]).ToString();
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


        public DataTable find(string str)
        {
            string sql = "Select tenMuaVu, NgayBatDau, NgayKetThuc from muavu where tenMuaVu like @str ";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] { "%" + str + "%" });
        }


    }
}
