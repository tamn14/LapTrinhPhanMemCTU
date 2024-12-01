using QuanLyDichBenh.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLyDichBenh.DAO
{
    public class PhuongPhapDieuTriDAO
    {
        private static PhuongPhapDieuTriDAO instance;

        public static PhuongPhapDieuTriDAO Instance
        {
            get { if (instance == null) instance = new PhuongPhapDieuTriDAO(); return PhuongPhapDieuTriDAO.instance; }
            private set { PhuongPhapDieuTriDAO.instance = value; }
        }



        private PhuongPhapDieuTriDAO() { }


        public DataTable loadPhuongPhap( NguoiDung nguoiDung)
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
          
            string sql = " SELECT  rl.Ten AS TenRuong,   db.Ten AS TenDichBenh, gl.TenGiong AS TenGiong,   bpxl.MoTa AS CachXuLy,   bcd.NgayBaoCao FROM   BaoCaoDichBenh bcd JOIN RuongLua rl ON bcd.RuongLuaID = rl.RuongLuaID JOIN DichBenh db ON bcd.DichBenhID = db.DichBenhID JOIN GiongLua gl ON rl.GiongLuaID = gl.GiongLuaID LEFT JOIN BienPhapXuLy bpxl ON bpxl.DichBenhID = db.DichBenhID JOIN NongDan nd ON rl.NongDanID = nd.NongDanID WHERE  nd.TenDangNhap = @TenDangNhap";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { tenDangNhap });
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khi thuc hien truy van : " + ex.Message);
                return null;
            }

        }

        public DataTable find(string TenDangNhap, string str) {

            string sql = " SELECT  rl.Ten AS TenRuong,   db.Ten AS TenDichBenh, gl.TenGiong AS TenGiong,   bpxl.MoTa AS CachXuLy,   bcd.NgayBaoCao FROM   BaoCaoDichBenh bcd JOIN RuongLua rl ON bcd.RuongLuaID = rl.RuongLuaID JOIN DichBenh db ON bcd.DichBenhID = db.DichBenhID JOIN GiongLua gl ON rl.GiongLuaID = gl.GiongLuaID LEFT JOIN BienPhapXuLy bpxl ON bpxl.DichBenhID = db.DichBenhID JOIN NongDan nd ON rl.NongDanID = nd.NongDanID WHERE  nd.TenDangNhap = @TenDangNhap and ( rl.ten like @str or db.ten like @str )";
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { TenDangNhap , "%" + str +"%"});
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi khi thuc hien truy van : " + ex.Message);
                return null;
            }
        }
    }
}
