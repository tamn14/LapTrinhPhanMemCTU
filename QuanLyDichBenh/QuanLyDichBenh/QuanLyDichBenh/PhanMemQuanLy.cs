using QuanLyDB.view;
using QuanLyDichBenh.DAO;
using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDichBenh
{
    public partial class PhanMemQuanLy : Form
    {
        private NguoiDung nguoiDung;  
        public PhanMemQuanLy(NguoiDung nguoiDung)
        {
            this.nguoiDung = nguoiDung;
            InitializeComponent();
    
            
            //LoadDichBenh();
            //LoadBienPhapPhongTru();
            KiemTraQuyen();
        }

        // bat dau logic su ly su kien
        private void chuyênGiaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ThongTinTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan T = new ThongTinTaiKhoan(this.nguoiDung);
            T.ShowDialog();

           
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void QuanLyDongRuongToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QLDongRuong q = new QLDongRuong(this.nguoiDung);  
            q.ShowDialog(); 
        }

        private void BaoCaoDichBenhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoDichBenh b = new BaoCaoDichBenh(this.nguoiDung);
            b.ShowDialog();
        }

        private void PhuongPhapDieuTriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PhuongPhapDieuTri p = new PhuongPhapDieuTri(this.nguoiDung); 
            p.ShowDialog();
        }

        private void QuanLyDichBenhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyDichBenh q = new QuanLyDichBenh(); 
            q.ShowDialog();

        }

        private void PhuongPhapDieuTriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BienPhapSuLy p = new BienPhapSuLy(); 
            p.ShowDialog(); 

        }

        private void QuanLyNhaNongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhaNong q  = new QuanLyNhaNong(); 
            q.ShowDialog();
        }

        private void QuanLyKySuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyChuyenGIa q = new QuanLyChuyenGIa();
            q.ShowDialog(); 
        }

        private void QuanLyDongRuongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSach d = new DanhSach(); 
            d.ShowDialog();
        }

        private void danhSáchĐồngRuộngVàNôngDânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachDongRuongVaDichBenh d = new DanhSachDongRuongVaDichBenh();    
            d.ShowDialog();
        }


        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
            
        //}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{

        //}
        //ket thuc logic su ly su kien  

        //bat dau logic su ly method

        public void KiemTraQuyen()
        {
            if(this.nguoiDung.getVaitro() == 1)
            {
                ShowToolStripForRole1();
            }

            else if(this.nguoiDung.getVaitro()==2)
            {
                ShowToolStripForRole2(); 
            }

            else
            {
                ShowToolStripForRole3();
            }
        }


        public void ShowToolStripForRole1()
        {
            NhaNongToolStripMenuItem.Visible = true;
            KySuToolStripMenuItem.Visible = false;
            QuanLyToolStripMenuItem.Visible = false;
        }

        public void ShowToolStripForRole2()
        {
            NhaNongToolStripMenuItem.Visible = false;
            KySuToolStripMenuItem.Visible = true;
            QuanLyToolStripMenuItem.Visible = false;
        }

        public void ShowToolStripForRole3()
        {
            NhaNongToolStripMenuItem.Visible = false;
            KySuToolStripMenuItem.Visible = false;
            QuanLyToolStripMenuItem.Visible = true;
        }

        //public void LoadDichBenh()
        //{
        //    dataGridView1.DataSource = DichBenhDAO.Instance.loadDichBenh();

        //    dataGridView1.Columns[0].HeaderText = "Tên bệnh";
        //    dataGridView1.Columns[1].HeaderText = "Mô tả";

        //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        //    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

        //    dataGridView1.Columns[0].Width = 120;
        //    dataGridView1.Columns[1].Width = 600;








        //    dataGridView1.Font = new Font("Arial", 9);
        //    dataGridView1.ScrollBars = ScrollBars.Both;

        //    DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
        //    rowStyle.BackColor = Color.LightBlue;
        //    dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

        //    dataGridView1.RowTemplate.Height = 25;



        //}


        //public void LoadBienPhapPhongTru()
        //{
           
        //    dataGridView2.DataSource = BienPhapXuLyDAO.Instance.loadBienPhapSuLy();

        //    dataGridView2.Columns[0].HeaderText = "Tên bệnh";
        //    dataGridView2.Columns[1].HeaderText = "Cách Điều Trị";
        //    dataGridView2.Columns[2].HeaderText = "Ngày Đề Xuất";
        //    //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    //dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

        //    dataGridView2.Columns[0].Width = 100;
        //    dataGridView2.Columns[1].Width = 300;
        //    dataGridView2.Columns[2].Width = 100; 





        //    dataGridView2.Font = new Font("Arial", 9);
        //    dataGridView2.ScrollBars = ScrollBars.Both;

        //    DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
        //    rowStyle.BackColor = Color.LightBlue;
        //    dataGridView2.AlternatingRowsDefaultCellStyle = rowStyle;

        //    dataGridView2.RowTemplate.Height = 25;

        //}

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoTongQuat bao = new BaoCaoTongQuat();
            bao.ShowDialog();
        }

        //private void thốngKêToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    ThongKe thongKe = new ThongKe();
        //    thongKe.ShowDialog();
        //}

        private void quảnLýGiốngLúaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyGiongLua g = new QuanLyGiongLua();
            g.ShowDialog();
        }

        private void quanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyMuaVu quanLyMuaVu = new QuanLyMuaVu(); 
            quanLyMuaVu.ShowDialog();   
        }







        // ket thuc logic su ly method


    }
}
