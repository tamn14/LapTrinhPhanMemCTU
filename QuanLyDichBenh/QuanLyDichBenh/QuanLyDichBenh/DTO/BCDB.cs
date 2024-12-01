using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDichBenh.DTO
{
    public class BCDB
    {
        public int BaoCao_id { get; set; }
        public DateTime NgayBaoCao { get; set; }
        public int MucDo { get; set; }
        public DichBenh DichBenh { get; set; }
        public RuongLua RuongLua { get; set; }

        public BCDB() { }

        public BCDB(DateTime ngayBaoCao, int mucDo, DichBenh dichBenh, RuongLua ruongLua)
        {
            this.NgayBaoCao = ngayBaoCao;
            this.MucDo = mucDo;
            this.DichBenh = dichBenh;
            this.RuongLua = ruongLua;
        }

        public BCDB(int id ,DateTime ngayBaoCao, int mucDo, DichBenh dichBenh, RuongLua ruongLua)
        {
            this.BaoCao_id = id;    
            this.NgayBaoCao = ngayBaoCao;
            this.MucDo = mucDo;
            this.DichBenh = dichBenh;
            this.RuongLua = ruongLua;
        }
    }

}
