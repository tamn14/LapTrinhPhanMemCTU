using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DTO
{
    public class RuongLua
    {
        public int ruongLuaID {  get; set; }
        public string ten {  get; set; }
        private string viTri;
        private double dienTich;
        private DateTime ngayGieo;
        private GiongLua giongLua;
        private NongDan nongDan; 

        public RuongLua(string ten, string viTri, double dienTich, DateTime ngayGieo, GiongLua giongLua, NongDan nongDan)
        {
            this.ten = ten;
            this.viTri = viTri;
            this.dienTich = dienTich;
            this.ngayGieo = ngayGieo;
            this.giongLua = giongLua;
            this.nongDan = nongDan;
        }

        public RuongLua(int ruongLuaID , string ten )
        {
            this.ruongLuaID = ruongLuaID;
            this.ten = ten;
           
        }
        public RuongLua(int ruongLuaID, string ten, string viTri, double dienTich, DateTime ngayGieo, GiongLua giongLua, NongDan nongDan)
        {
            this.ruongLuaID = ruongLuaID; 
            this.ten = ten;
            this.viTri = viTri;
            this.dienTich = dienTich;
            this.ngayGieo = ngayGieo;
            this.giongLua = giongLua;
            this.nongDan = nongDan;
        }

        public RuongLua() { }

        
       
        public void setViTri(string vitri) { this.viTri = vitri;}
        public string getViTri() { return this.viTri; } 
        public void setDienTich( double dienTich) { this.dienTich= dienTich;}
        public double getDienTich() { return this.dienTich;  }
        public void setNgayGieo( DateTime ngayGieo) { this.ngayGieo= ngayGieo; } 
        public DateTime getNgayGieo() { return this.ngayGieo; }
        public void setGiongLua(GiongLua giongLua) { this.giongLua = giongLua; }
        public GiongLua getGiongLua() { return this.giongLua; }
        public void setNongDan(NongDan nongDan) { this.nongDan = nongDan; }
        public NongDan getNongDan() { return this.nongDan; }
    }
}
