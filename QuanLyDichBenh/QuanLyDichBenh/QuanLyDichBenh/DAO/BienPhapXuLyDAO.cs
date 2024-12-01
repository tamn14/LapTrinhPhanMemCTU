using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLyDichBenh.DAO
{
    public class BienPhapXuLyDAO
    {
        private static BienPhapXuLyDAO instance;

        public static BienPhapXuLyDAO Instance
        {
            get { if (instance == null) instance = new BienPhapXuLyDAO(); return BienPhapXuLyDAO.instance; }
            private set { BienPhapXuLyDAO.instance = value; }
        }

        private BienPhapXuLyDAO() { }

        public DataTable loadBienPhapSuLy()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT d.ten , b.mota , b.ngaydexuat  from DichBenh d left join BienPhapXuLy b on b.DichBenhID = d.DichBenhID");
        }

        public DataTable find(string str)
        {
            string sql = "SELECT d.ten , b.mota , b.ngaydexuat  from DichBenh d left join BienPhapXuLy b on b.DichBenhID = d.DichBenhID where  d.ten like @str "; 
            return DataProvider.Instance.ExecuteQuery(sql, new object[] { "%" + str +"%" });
        }

        public int getID(BienPhapXL b)
        {
            string ngaydexuat = b.getNgayDeXuat().ToString();
            string sql = "SELECT  BienPhapID FROM BienPhapXuLy WHERE DichBenhID = @DichBenhID AND NgayDeXuat = @NgayDeXuat AND MoTa = @mota";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] { b.getDichBenh().dichBenhID ,  b.getNgayDeXuat(), b.getMoTa() });
            int bienPhapId = -1;

            if (data.Rows.Count > 0)
            {
                bienPhapId = Convert.ToInt32(data.Rows[0]["BienPhapID"]);
            }

            return bienPhapId;
        }




        public int insert ( BienPhapXL b)
        {
            int DichBenhID = b.getDichBenh().dichBenhID;
            string mota = b.getMoTa();  
            DateTime ngayDeXuat = b.getNgayDeXuat();

            string sql = " insert into BienPhapXuLy( DichBenhID , MoTa , NgayDeXuat ) values ( @DichBenhID , @mota , @ngayDeXuat ) ";
            try
            {
                int data  = DataProvider.Instance.ExecuteNonQuery(sql , new object[] { DichBenhID, mota, ngayDeXuat });
                return data; 

            }
            catch (Exception ex) 
            {
                Console.WriteLine("Loi : " +ex.Message);
            }
            return -1; 
        }

        public int remove(int id)
        {
            

            string sql = " Delete from BienPhapXuLy where BienPhapID = @id ";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] { id });
                return data;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi : " + ex.Message);
            }
            return -1;
        }




        public int update(BienPhapXL b)
        {
            int BienPhapID = b.getBienPhapSuLyID();  
            int DichBenhID = b.getDichBenh().dichBenhID;
            string mota = b.getMoTa();
            DateTime ngayDeXuat = b.getNgayDeXuat();

            string sql = " Update  BienPhapXuLy set DichBenhID = @DichBenhID , MoTa = @MoTa , ngayDeXuat = @ngayDeXuat where BienPhapID = @BienPhapID";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] {DichBenhID, mota, ngayDeXuat  ,BienPhapID });
                return data;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi : " + ex.Message);
            }
            return -1;
        }
    }
}
