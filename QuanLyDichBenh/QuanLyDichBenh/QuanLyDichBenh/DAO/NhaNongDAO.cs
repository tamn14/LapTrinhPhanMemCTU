using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DAO
{
    internal class NhaNongDAO
    {
        private static NhaNongDAO instance;

        public static NhaNongDAO Instance
        {
            get { if (instance == null) instance = new NhaNongDAO(); return NhaNongDAO.instance; }
            private set { NhaNongDAO.instance = value; }
        }

        private NhaNongDAO() { }

        public DataTable loadNhaNong()
        {
            return DataProvider.Instance.ExecuteQuery("select ten , sodienthoai , diachi from NongDan ");
        }

        public DataTable loadNhaNong1()
        {
            return DataProvider.Instance.ExecuteQuery("select  * from NongDan ");
        }

        public DataTable loadNhaNongForDs(int page)
        {
            string sql =  "exec USP_GetListNhaNong @page ";
            return DataProvider.Instance.ExecuteQuery(sql, new object[] { page });
        }

        public DataTable loadAllNhaNong()
        {
            return DataProvider.Instance.ExecuteQuery("select n.ten , n.sodienthoai , n.diachi, m.tendangnhap , m.matkhau, m.TenHienThi from NongDan n , nguoidung m where n.tendangnhap = m.tendangnhap ");
        }


        public NongDan getIdByPhone(string SDT)
        {
            string sql = "select * from NongDan where SoDienThoai = @SDT";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { SDT });
            NongDan nongDan = null;
            foreach (DataRow row in data.Rows)
            {
                int nongDanID = Convert.ToInt32(row["NongDanID"]); 
                string tenDangNhap = row["TenDangNhap"].ToString();
                string ten = row["ten"].ToString();
                string sdt = row["SoDienThoai"].ToString();
                string diaChi = row["DiaChi"].ToString();

                NguoiDung nguoiDung = new NguoiDung();
                nguoiDung.setTenDangNhap(tenDangNhap);

                
                nongDan = new NongDan(nongDanID, ten, sdt, diaChi, nguoiDung);
            }
            return nongDan;
        }

        public NongDan getIdByUserName(string username)
        {
            string sql = "select * from NongDan where TenDangNhap = @username";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { username });
            NongDan nongDan = null;
            foreach (DataRow row in data.Rows)
            {
                int nongDanID = Convert.ToInt32(row["NongDanID"]);
                string tenDangNhap = row["TenDangNhap"].ToString();
                string ten = row["ten"].ToString();
                string sdt = row["SoDienThoai"].ToString();
                string diaChi = row["DiaChi"].ToString();

                NguoiDung nguoiDung = new NguoiDung();
                nguoiDung.setTenDangNhap(tenDangNhap);


                nongDan = new NongDan(nongDanID, ten, sdt, diaChi, nguoiDung);
            }
            return nongDan;
        }



        public int insert(NongDan nhanong, NguoiDung nguoiDung)
        {
            string tenDangNhap = nguoiDung.getTenDangNhap();
            string matKhau = nguoiDung.getMatKhau();
            int vaitro = 1;
            string tenHienThi = nguoiDung.getTenHienThi();

            string ten = nhanong.getTen();
            string SoDienThoai = nhanong.getSDT();
            string diachi = nhanong.getDiaChi();

          
            string sqlNguoiDung = "INSERT INTO NguoiDung(TenDangNhap, MatKhau, VaiTro, TenHienThi) " +
                                  "VALUES (@TenDangNhap, @MatKhau, @VaiTro, @TenHienThi);";

            string sqlNongDan = "INSERT INTO NongDan(TenDangNhap, Ten, SoDienThoai, DiaChi) " +
                                "VALUES (@TenDangNhap, @Ten, @SoDienThoai, @DiaChi);";

            try
            {
                int result1 = DataProvider.Instance.ExecuteNonQuery(sqlNguoiDung, new object[] { tenDangNhap, matKhau, vaitro, tenHienThi });

                int result2 = DataProvider.Instance.ExecuteNonQuery(sqlNongDan, new object[] { tenDangNhap, ten, SoDienThoai, diachi });

                return result1 + result2; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public int Update(NongDan nhanong)
        {
           

            int NongDanID = nhanong.getNongDanID();

            string ten = nhanong.getTen();
            string SoDienThoai = nhanong.getSDT();
            string diachi = nhanong.getDiaChi();
            string sql = " Update NongDan set Ten = @Ten , SoDienThoai = @SoDienThoai , DiaChi = @DiaChi where NongDanID = @NongDanID";

            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { ten , SoDienThoai , diachi , NongDanID });
                return data;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public int remove(NongDan nhanong)
        {


            int NongDanID = nhanong.getNongDanID();

            string ten = nhanong.getTen();
            string SoDienThoai = nhanong.getSDT();
            string diachi = nhanong.getDiaChi();
            string sql = " Delete NongDan  where NongDanID = @NongDanID";
            string sql1 = " Delete nguoidung  where tendangnhap  = @tendangnhap";

            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] {  NongDanID });
                int data1 = DataProvider.Instance.ExecuteNonQuery(sql1, new object[] { nhanong.getNguoiDung().getTenDangNhap() });
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
            string sql = "SELECT COUNT(*) AS TongSoDiaChi FROM NongDan;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            
            foreach (DataRow row in data.Rows)
            {
                int count = Convert.ToInt32(row["TongSoDiaChi"]);
                return count;   
             
                
            }
            return -1;
        }

        public List<string> getMax()
        {
            string sql = "WITH DiaChi_Count AS ( SELECT DiaChi, COUNT(*) AS SoLuong FROM NongDan  GROUP BY DiaChi )" +
                            " SELECT DiaChi, SoLuong FROM DiaChi_Count WHERE SoLuong = (SELECT MAX(SoLuong) FROM DiaChi_Count);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listDiaChi = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string diachi = (row["DiaChi"]).ToString();
                    listDiaChi.Add(diachi);
                    



                }
                return listDiaChi;

            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            
            }
            
            return null; 
            
        }

        public List<string> getMin()
        {
            string sql = "WITH DiaChi_Count AS ( SELECT DiaChi, COUNT(*) AS SoLuong FROM NongDan  GROUP BY DiaChi )" +
                            " SELECT DiaChi, SoLuong FROM DiaChi_Count WHERE SoLuong = (SELECT MIN(SoLuong) FROM DiaChi_Count);";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql);
                List<string> listDiaChi = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    string diachi = (row["DiaChi"]).ToString();
                    listDiaChi.Add(diachi);




                }
                return listDiaChi;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return null;

        }


        public Dictionary<string, int> getNongDanByDiaChi()
        {
            string sql = " SELECT DiaChi, COUNT(NongDanID) AS SoLuongNongDan FROM NongDan GROUP BY DiaChi;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            Dictionary<string, int> list = new Dictionary<string, int>();
            foreach (DataRow row in data.Rows)
            {
                string diaChi = row["DiaChi"].ToString();
                int cout = Convert.ToInt32(row["SoLuongNongDan"]);
                list.Add(diaChi, cout);
            }

            return list;


        }

        public DataTable find( string str)
        {
            string sql = "select n.ten , n.sodienthoai , n.diachi, m.tendangnhap , m.matkhau, m.TenHienThi from NongDan n, nguoidung m where n.tendangnhap = m.tendangnhap and ten like @str  ";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] {  "%" + str + "%" });
        }

        public DataTable find2(string str)
        {
            string sql = "select n.ten ,  n.diachi , n.sodienthoai from NongDan n where ten like @str  ";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] { "%" + str + "%" });
        }
    }

}

