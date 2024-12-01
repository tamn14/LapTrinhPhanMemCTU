using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DAO
{
    internal class ChuyenGiaDAO
    {

        private static ChuyenGiaDAO instance;

        public static ChuyenGiaDAO Instance
        {
            get { if (instance == null) instance = new ChuyenGiaDAO(); return ChuyenGiaDAO.instance; }
            private set { ChuyenGiaDAO.instance = value; }
        }

        private ChuyenGiaDAO() { }

        public DataTable loadChuyenGia()
        {
            return DataProvider.Instance.ExecuteQuery("Select c.ten  , c.chuyenmon , c.sodienthoai , n.TenDangNhap , n.Matkhau , n.TenHienThi  from ChuyenGia c , nguoidung n where c.TenDangNhap = n.TenDangNhap");
        }

        public DataTable find(string str)
        {
            string sql = " Select c.ten   , c.chuyenmon , c.sodienthoai , n.TenDangNhap , n.Matkhau , n.TenHienThi  from ChuyenGia c , nguoidung n where c.TenDangNhap = n.TenDangNhap and c.ten like @str  ";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] { "%" + str + "%" });
        }

        public DataTable find2(string str)
        {
            string sql = "Select c.ten  , c.chuyenmon , c.sodienthoai from ChuyenGia c  where c.ten like @str  ";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] { "%" + str + "%" });
        }

        public DataTable loadChuyenGiaForDs(int page)
        {
            string sql = "exec USP_GetListChuyenGia @page ";
            return DataProvider.Instance.ExecuteQuery(sql, new object[] { page });
        }

        public ChuyenGia getIdByPhone(string SDT)
        {
            string sql = "select * from ChuyenGia where tendangnhap = @tendangnhap";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { SDT });
            ChuyenGia chuyenGia = null;
            foreach (DataRow row in data.Rows)
            {
                int chuyenGiaID = Convert.ToInt32(row["ChuyenGiaID"]);
                string tenDangNhap = row["TenDangNhap"].ToString();
                string ten = row["ten"].ToString();
                string chuyenmon = row["ChuyenMon"].ToString();
                string sdt = row["SoDienThoai"].ToString();

                NguoiDung nguoiDung = new NguoiDung();
                nguoiDung.setTenDangNhap(tenDangNhap);


                chuyenGia = new ChuyenGia(chuyenGiaID, ten, chuyenmon, sdt, nguoiDung);
            }
            return chuyenGia;
        }

        public ChuyenGia getIdByUserName(string username)
        {
            string sql = "select * from ChuyenGia where tendangnhap = @username";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { username });
            ChuyenGia chuyenGia = null;
            foreach (DataRow row in data.Rows)
            {
                int chuyenGiaID = Convert.ToInt32(row["ChuyenGiaID"]);
                string tenDangNhap = row["TenDangNhap"].ToString();
                string ten = row["ten"].ToString();
                string chuyenmon = row["ChuyenMon"].ToString();
                string sdt = row["SoDienThoai"].ToString();

                NguoiDung nguoiDung = new NguoiDung();
                nguoiDung.setTenDangNhap(tenDangNhap);


                chuyenGia = new ChuyenGia(chuyenGiaID, ten, chuyenmon, sdt, nguoiDung);
            }
            return chuyenGia;
        }



        public int insert(ChuyenGia chuyenGia, NguoiDung nguoiDung)
        {
            string tenDangNhap = nguoiDung.getTenDangNhap();
            string matKhau = nguoiDung.getMatKhau();
            int vaitro = 2;
            string tenHienThi = nguoiDung.getTenHienThi();

            string ten  = chuyenGia.getTenChuyenGia();
            string chuyenMon = chuyenGia.getChuyenMon();
            string sdt = chuyenGia.getSDT();


            string sqlNguoiDung = "INSERT INTO NguoiDung(TenDangNhap, MatKhau, VaiTro, TenHienThi) " +
                                  "VALUES (@TenDangNhap, @MatKhau, @VaiTro, @TenHienThi);";

            string sqlChuyenGia = "INSERT INTO ChuyenGia(TenDangNhap, Ten, ChuyenMon, SoDienThoai) " +
                                "VALUES (@TenDangNhap, @Ten, @chuyenMon, @sdt);";

            try
            {
                int result1 = DataProvider.Instance.ExecuteNonQuery(sqlNguoiDung, new object[] { tenDangNhap, matKhau, vaitro, tenHienThi });

                int result2 = DataProvider.Instance.ExecuteNonQuery(sqlChuyenGia, new object[] { tenDangNhap, ten, chuyenMon, sdt });

                return result1 + result2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public int Update(ChuyenGia chuyenGia)
        {


            int ChuyenGiaID = chuyenGia.getMaChuyenGia();
            string ten = chuyenGia.getTenChuyenGia();
            string chuyenMon = chuyenGia.getChuyenMon();
            string sdt = chuyenGia.getSDT();
            string sql = " Update CHuyenGia set ten = @ten, ChuyenMon = @chuyenMon  , Sodienthoai  = @sdt  where ChuyenGiaID = @ChuyenGiaID";

            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] {  ten,chuyenMon,sdt , ChuyenGiaID });
                return data;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public int remove(ChuyenGia chuyenGia)
        {


            int ChuyenGiaID = chuyenGia.getMaChuyenGia();
            string ten = chuyenGia.getTenChuyenGia();
            string chuyenMon = chuyenGia.getChuyenMon();
            string sdt = chuyenGia.getSDT();
            string sql = " Delete ChuyenGia  where ChuyenGiaID = @ChuyenGiaID";
            string sql1 = " Delete nguoidung  where tendangnhap = @tendangnhap";

            try
            {
                int data1 = DataProvider.Instance.ExecuteNonQuery(sql1, new object[] { chuyenGia.getNguoiDung().getTenDangNhap() });
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { ChuyenGiaID });
                return data + data1;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public int getCount()
        {
            string sql = "SELECT COUNT(*) AS chuyenmon FROM ChuyenGia;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);

            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["chuyenMon"]);
                return count;


            }
            return -1;
        }

        public List<string> getMax()
        {
            string sql = "WITH chuyenMonCount AS ( SELECT chuyenmon, COUNT(*) AS SoLuong FROM ChuyenGia GROUP BY ChuyenMon )" +
                            " SELECT chuyenmon, SoLuong FROM chuyenMonCount WHERE SoLuong = (SELECT Max(SoLuong) FROM chuyenMonCount);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listChuyenMon = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string chuyenmon = (row["chuyenmon"]).ToString();
                    listChuyenMon.Add(chuyenmon);




                }
                return listChuyenMon;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }

        public List<string> getMin()
        {
            string sql = "WITH chuyenMonCount AS ( SELECT chuyenmon, COUNT(*) AS SoLuong FROM ChuyenGia GROUP BY ChuyenMon )" +
                            " SELECT chuyenmon, SoLuong FROM chuyenMonCount WHERE SoLuong = (SELECT Min(SoLuong) FROM chuyenMonCount);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listChuyenMon = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string chuyenmon = (row["chuyenmon"]).ToString();
                    listChuyenMon.Add(chuyenmon);




                }
                return listChuyenMon;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }

        public Dictionary<string, int> getChuyenByChuyenMon()
        {
            string sql = " SELECT ChuyenMon, COUNT(ChuyenGiaID) AS SoLuongSoLuongChuyenGia FROM ChuyenGia GROUP BY ChuyenMon;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            Dictionary<string, int> list = new Dictionary<string, int>();
            foreach (DataRow row in data.Rows)
            {
                string chuyenmon = row["ChuyenMon"].ToString();
                int cout = Convert.ToInt32(row["SoLuongSoLuongChuyenGia"]);
                list.Add(chuyenmon, cout);
            }

            return list;


        }



    }
}
