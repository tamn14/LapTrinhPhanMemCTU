using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DTO
{
    public class NongDan
    {
        private int nongDanID;
        private string Ten;
        private string SDT;
        private string diaChi;
        private NguoiDung nguoiDung ;  

        public NongDan()
        {

        }

        public NongDan(  string Ten , string SDT  ,  string diaChi , NguoiDung nguoiDung)
        {
           
            this.Ten = Ten;  
            this.SDT = SDT; 
            this.diaChi = diaChi ; 
            this.nguoiDung = nguoiDung ;
          
        }

        public NongDan(int nongDanID, string Ten, string SDT, string diaChi, NguoiDung nguoiDung)
        {
            this.nongDanID = nongDanID; 
            this.Ten = Ten;
            this.SDT = SDT;
            this.diaChi = diaChi;
            this.nguoiDung = nguoiDung;
        }

        public void setNongDanID(int nongDanID) { 
             this.nongDanID = nongDanID; 
        }

        public int getNongDanID() {
            return this.nongDanID; 
        }

        public void setTen( string ten)
        {
            this.Ten = ten;
        }

        public string getTen() { return this.Ten; }

        public void setSDT( string SDT)
        {
            this.SDT = SDT;

        }

        public string getSDT() { return this.SDT; }

        public void setDiaChi(string DiaChi) { this.diaChi = DiaChi; }

        public string getDiaChi() { return this.diaChi; }

        public NguoiDung getNguoiDung() { return this.nguoiDung; }
        public void setNguoiDung(NguoiDung nguoiDung) { this.nguoiDung = nguoiDung;  }


        




        
    }
}
