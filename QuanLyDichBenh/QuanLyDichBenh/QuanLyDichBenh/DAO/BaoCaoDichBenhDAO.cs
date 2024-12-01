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
    public class BaoCaoDichBenhDAO
    {
        private static BaoCaoDichBenhDAO instance;

        public static BaoCaoDichBenhDAO Instance
        {
            get { if (instance == null) instance = new BaoCaoDichBenhDAO(); return BaoCaoDichBenhDAO.instance; }
            private set { BaoCaoDichBenhDAO.instance = value; }
        }

        private BaoCaoDichBenhDAO() { }


        public int getID(BCDB baoCaoDichBenh)
        {
            int baocao;
            string sql = "select BaoCaoID from BaoCaoDichBenh where RuongLuaID = @RuongLuaID and DichBenhID = @DichBenhID and NgayBaoCao = @NgayBaoCao and MucDo = @MucDo ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql, new object[] {
                                                                        baoCaoDichBenh.RuongLua.ruongLuaID,
                                                                        baoCaoDichBenh.DichBenh.dichBenhID,
                                                                        baoCaoDichBenh.NgayBaoCao,
                                                                        baoCaoDichBenh.MucDo

            });

            foreach (DataRow row in data.Rows)
            {

                int baoCaoId = Convert.ToInt32(row["BaoCaoID"]);
                baocao = baoCaoId;
                return baocao;



            }

            return -1;








        }

        public int update(BCDB bCDB)
        {
            int DichBenhID = bCDB.DichBenh.dichBenhID;
            DateTime NgayBaoCao = bCDB.NgayBaoCao;
            int MucDo = bCDB.MucDo;
            int BaoCaoID = bCDB.BaoCao_id;


            string sql = " Update BaoCaoDichBenh set DichBenhID = @DichBenhID , NgayBaoCao = @NgayBaoCao , MucDo = @MucDo where BaoCaoID = @BaoCaoId   ";
            try
            {
                int data = DataProvider.Instance.ExecuteNonQuery(sql, new object[] {

                                      DichBenhID,
                                      NgayBaoCao,
                                      MucDo,
                                      BaoCaoID

                    });
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return 0;

            }

        }

        public int insert(BCDB bDB)
        {
            int RuongLuaID = bDB.RuongLua.ruongLuaID;
            int DichBenhID = bDB.DichBenh.dichBenhID;
            DateTime NgayBaoCao = bDB.NgayBaoCao;
            int MucDo = bDB.MucDo;
            string sql = "insert into BaoCaoDichBenh( RuongLuaID, DichBenhID , NgayBaoCao , MucDo) Values (@RuongLuaID , @DichBenhID , @NgayBaoCao, @MucDo )";
            return DataProvider.Instance.ExecuteNonQuery(sql, new object[] {
                RuongLuaID,
                DichBenhID,
                NgayBaoCao,
                MucDo


            });



        }

        public int remove(int BaoCaoId)
        {
            string sql = "DELETE FROM BaoCaoDichBenh WHERE BaoCaoID = @BaoCaoId";
            return DataProvider.Instance.ExecuteNonQuery(sql, new object[] { BaoCaoId });
        }


        public DataTable getCount()
        {
            string sql = "Select count(distinct DichBenhID) from BaoCaoDichBenh";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);


            return data;
        }

        public int getcount()
        {
             string sql = "select count(*) as soluong from DichBenh d, BaoCaoDichBenh b, RuongLua r  Where d.DichBenhID = b.DichBenhID and r.RuongLuaID = b.RuongLuaID ";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach (DataRow row in data.Rows)
            {
                int soluong = Convert.ToInt32(row["soluong"]);
                return soluong;


            }
            return -1;
        }
    }
}
