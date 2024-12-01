using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DTO
{
    public class NguoiDung
    {
        
        private string tenDangNhap;
        private string matKhau;
        private int vaiTro;
        private string tenHienThi;  

        public NguoiDung()
        {

        }

        public NguoiDung( string tenDangNhap, string matKhau, int vaitro, string tenHienThi)
        {
            
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.vaiTro = vaitro;
            this.tenHienThi = tenHienThi;
        }

       

        public void setTenDangNhap(string tenDangNhap) {
            this.tenDangNhap = tenDangNhap; 
        }
        public string getTenDangNhap() { 
            return this.tenDangNhap; 
        }

        public void setMatKhau(string matKhau) 
        {
            this.matKhau = matKhau.Trim();
        }
        public string getMatKhau() { 
            return this.matKhau; 
        } 

        public  void setVaiTro(int vaiTro) {
            this.vaiTro = vaiTro;  
        }
        public int getVaitro() { return this.vaiTro; }


        public void setTenHienThi(string tenHienThi)
        {
            this.tenHienThi = tenHienThi;
        
        }
        public string getTenHienThi() { return this.tenHienThi; }




        

    }
}
