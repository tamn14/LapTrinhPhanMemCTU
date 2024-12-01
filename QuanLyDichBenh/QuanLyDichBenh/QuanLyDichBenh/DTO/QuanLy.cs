using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DTO
{
    public class QuanLy
    {
        private int quanLyID;
        private string SDT;
        private string ten;
        private NguoiDung nguoiDung; 

        public QuanLy( string sDT, string ten, NguoiDung nguoiDung)
        {
            
            this.SDT = sDT;
            this.ten = ten;
            this.nguoiDung = nguoiDung;
        }

        public QuanLy() { }

        public void setQuanLyID(int quanLyID) { this.quanLyID = quanLyID; } 
        public int getQuanLyID() { return this.quanLyID; } 
        public void setSDT(string sdt) { this.SDT = sdt; }
        public string getSDT() { return this.SDT; } 
        public void setTen( string ten)
        {
            this.ten = ten; 
        }
        public NguoiDung getNguoiDung() { return this.nguoiDung; }
        public void setNguoiDung(NguoiDung nguoiDung) { this.nguoiDung = nguoiDung; }

    }
}
