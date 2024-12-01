using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DTO
{
    public class MuaVu
    {
        public  int MaMuaVu {  get; set; }   
        public string tenMuaVu { get; set; }
        public DateTime ngayBatDau { get; set; }
        public DateTime ngayKetThuc {  get; set; }

        public MuaVu() { }
        public MuaVu(int mmaMuaVu, string tenMuaVu, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            MaMuaVu = mmaMuaVu;
            this.tenMuaVu = tenMuaVu;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }

        public MuaVu(string tenMuaVu, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            this.tenMuaVu = tenMuaVu;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }

    }

    }

