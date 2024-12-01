using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DTO
{
    public class BienPhapXL
    {
        private int BienPhapSuLyID;
        private string moTa;
        private DateTime ngayDeXuat;
        private DichBenh dichBenh;  

        public BienPhapXL() { } 
        public BienPhapXL( string moTa , DateTime ngayDeXuat ,  DichBenh dichBenh)
        {
            this.moTa = moTa;
            this.ngayDeXuat = ngayDeXuat; 
            this.dichBenh = dichBenh;
        }

        public BienPhapXL(int id,string moTa, DateTime ngayDeXuat, DichBenh dichBenh)
        {
            this.BienPhapSuLyID = id; 
            this.moTa = moTa;
            this.ngayDeXuat = ngayDeXuat;
            this.dichBenh = dichBenh;
        }

        public void setMoTa( string moTa ) { this.moTa = moTa; } 
        public string getMoTa( ) { return this.moTa; }

        public void setBienPhapSuLyID(int id) { this.BienPhapSuLyID = id; }
        public int getBienPhapSuLyID() { return this.BienPhapSuLyID; }

        public void setNgayDeXuat(DateTime ngayDeXuat ) { this.ngayDeXuat=ngayDeXuat; } 
        public DateTime getNgayDeXuat() {  return this.ngayDeXuat;} 

        public void setDichBenh( DichBenh dichBenh ) { this.dichBenh = dichBenh; }
        public DichBenh getDichBenh() { return this.dichBenh; }




    }
}
