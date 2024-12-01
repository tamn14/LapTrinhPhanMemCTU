using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DTO
{
    public class ChuyenGia
    {
        private int maChuyenGia;
        private string tenChuyenGia;
        private string ChuyenMon;
        private string SDT;
        private NguoiDung nguoiDung;

        public ChuyenGia() { }

        public ChuyenGia(int maChuyenGia, string tenChuyenGia, string chuyenMon, string sDT, NguoiDung nguoiDung)
        {
           this.maChuyenGia  = maChuyenGia; 
            this.tenChuyenGia = tenChuyenGia;
            this.ChuyenMon = chuyenMon;
            this.SDT = sDT;
            this.nguoiDung = nguoiDung;
        }

        public ChuyenGia( string tenChuyenGia, string chuyenMon, string sDT, NguoiDung nguoiDung)
        {

            this.tenChuyenGia = tenChuyenGia;
            this.ChuyenMon = chuyenMon;
            this.SDT = sDT;
            this.nguoiDung = nguoiDung;
        }



        public ChuyenGia( string tenChuyenGia, string chuyenMon, string sDT)
        {

            this.ChuyenMon = chuyenMon;
            this.SDT = sDT;
            this.nguoiDung = nguoiDung;
        }

        public void setMaChuyenGia(int maChuyenGia) { this.maChuyenGia = maChuyenGia; }
        public int getMaChuyenGia()
        {
            return this.maChuyenGia;  
        }

        public void setTenChuyenGia(string tenChuyenGia) { this.tenChuyenGia = tenChuyenGia;  } 
        public string getTenChuyenGia() { return this.tenChuyenGia; }
         
        public void setChuyenMon( string chuyenMon )
        {
            this.ChuyenMon = chuyenMon;  

        }

        public string getChuyenMon() { return this.ChuyenMon; }

        public void setSDT( string SDT)
        {
            this.SDT = SDT;  
        }

        public string getSDT() { return this.SDT; }
        public NguoiDung getNguoiDung() { return this.nguoiDung; }
        public void setNguoiDung(NguoiDung nguoiDung) { this.nguoiDung = nguoiDung; }






    }
}
