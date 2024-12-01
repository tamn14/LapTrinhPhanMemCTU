using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DTO
{
    public class DichBenh
    {
        public int dichBenhID {  get; set; }
        public string ten {  get; set; }
        public string moTa {  get; set; }

        public DichBenh() { } 
        public DichBenh(int dichBenhID, string ten, string moTa)
        {
            this.dichBenhID = dichBenhID;
            this.ten = ten;
            this.moTa = moTa;
        }

        public DichBenh( string ten, string moTa)
        {
           
            this.ten = ten;
            this.moTa = moTa;
        }



    }
}
