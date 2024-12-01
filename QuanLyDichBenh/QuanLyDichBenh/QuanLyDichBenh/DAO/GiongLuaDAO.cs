using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyDichBenh.DAO
{
    public class GiongLuaDAO
    {
        private static GiongLuaDAO instance;

        public static GiongLuaDAO Instance
        {
            get { if (instance == null) instance = new GiongLuaDAO(); return GiongLuaDAO.instance; }
            private set { GiongLuaDAO.instance = value; }
        }

        private GiongLuaDAO() { }

        public DataTable getAllGiongLua()
        {
            string sql = " select TenGiong , TenMuaVu , NgayBatDau , NgayKetthuc from MuaVu m  , GiongLua g where m.MuaVuID = g.MuaVuID";
            return DataProvider.Instance.ExecuteQuery(sql);
        }

        public List<GiongLua> getGiongLua()
        {
            List<GiongLua> list = new List<GiongLua>();
            string sql = " select GiongLuaID , TenGiong from GiongLua ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow row in data.Rows)
            {
                int GiongLuaId = Convert.ToInt32(row["GiongLuaID"]);
                string TenGiongLua = row["TenGiong"].ToString();

                GiongLua gionglua = new GiongLua(GiongLuaId, TenGiongLua);
                list.Add(gionglua);
            }

            return list;
        }


        public GiongLua getIdByName(string name)
        {
            string sql = "select * from GiongLua where TenGiong = @name";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { name });
            GiongLua giongLua = null;  
            foreach(DataRow row in data.Rows)
            {
                 int id = Convert.ToInt32(row["GiongLuaID"]);
                string tenGiong = row["TenGiong"].ToString();  
                giongLua = new GiongLua(id, tenGiong);

            }
            return giongLua; 
        }

        public int insert(GiongLua giongLua)
        {
            string ten = giongLua.TenGiong;
            int muaVu = giongLua.muaVu.MaMuaVu;  
            
            try
            {
                string sql = " Insert into GiongLua(tenGiong , MuaVuID) values( @ten , @MuaVuID )";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { ten, muaVu });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);

            }
            return -1;



        }

        public int remove(int GiongLuaID)
        {


            try
            {
                string sql = " Delete from gionglua where GiongLuaID = @GiongLuaID";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { GiongLuaID });
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Loi :  " + e);

            }
            return -1;



        }

        public int update(GiongLua giongLua)
        {
            int giongLuaID = giongLua.GiongLuaID;
            string TenGiong = giongLua.TenGiong;
            int MuaVu = giongLua.muaVu.MaMuaVu;

            try
            {
                string sql = " Update  giongLua set TenGiong = @TenGiong , MuaVuID  = @MuaVu  where giongLuaID = @giongLuaID";
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { TenGiong, MuaVu, giongLuaID });
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
            string sql = "EXEC GetThongTinGiongLuaQuaMuaVu;";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);


            return data;
        }

        public DataTable find(string str)
        {
            string sql = " select TenGiong , TenMuaVu , NgayBatDau , NgayKetthuc from MuaVu m  , GiongLua g where m.MuaVuID = g.MuaVuID and tenGiong like @str";

            return DataProvider.Instance.ExecuteQuery(sql, new object[] { "%" + str + "%" });
        }

    }


}
