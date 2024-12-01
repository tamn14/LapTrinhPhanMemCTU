using QuanLyDichBenh.DAO;
using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDichBenh
{
    public partial class QuanLyChuyenGIa : Form
    {
        string even = ""; 
        public QuanLyChuyenGIa()
        {
            InitializeComponent();
            loadChuyenGia();
            addChuyenGia();
            txb_TenDangNhap.Enabled = false;
            txb_MatKhau.Enabled = false;    
            txb_TenHienThi.Enabled = false;
            textBox2.Enabled = false;   
        }

        public void loadChuyenGia()
        {
            dataGridView1.DataSource = ChuyenGiaDAO.Instance.loadChuyenGia();

            dataGridView1.Columns[0].HeaderText = "Tên";
            dataGridView1.Columns[1].HeaderText = "Chuyên môn";
            dataGridView1.Columns[2].HeaderText = "Số điện thoại";
            dataGridView1.Columns[3].HeaderText = "Tên Đăng Nhập";
            dataGridView1.Columns[4].HeaderText = "Mật Khẩu";
            dataGridView1.Columns[5].HeaderText = "Tên Hiển Thị";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;


            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Mật Khẩu" && e.Value != null)
            {

                e.Value = new string('*', e.Value.ToString().Length);
            }
        }

        public void addChuyenGia()
        {
            //txb_tenNhaNong.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ten"));
            //txb_ChuyenMon.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ChuyenMon"));
            //txb_SDT.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "SodienThoai"));
            //txb_TenDangNhap.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "tendangnhap"));
            //txb_MatKhau.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "matkhau"));
            //txb_TenHienThi.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "TenHienThi"));
        }

        public void clear()
        {
            txb_tenNhaNong.Text = "";
            txb_ChuyenMon.Text = "";
            txb_SDT.Text = "";
            txb_TenDangNhap.Text = "";
            txb_TenHienThi.Text = "";
            textBox2.Text = "";
            txb_MatKhau.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            even = "them";
            txb_tenNhaNong.Enabled = true;
            txb_TenDangNhap.Enabled = true;
            txb_MatKhau.Enabled = true;
            txb_TenHienThi.Enabled = true;
            textBox2.Enabled = true;
            txb_SDT.Enabled = true; 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            even = "sua";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ten = txb_tenNhaNong.Text;
            string chuyenMon = txb_ChuyenMon.Text;
            string sodienthoai = txb_SDT.Text;

            string tenDangNhap = txb_TenDangNhap.Text;
            string MatKhau = txb_MatKhau.Text;
            string MatKhauNhapLai = textBox2.Text;
            string tenHienThi = txb_TenHienThi.Text;
            int vaiTro = 2;

          

            if (tenDangNhap != null)
            {
                NguoiDung nguoiDung = new NguoiDung(tenDangNhap, MatKhau, vaiTro, tenHienThi);
                ChuyenGia chuyenGia = ChuyenGiaDAO.Instance.getIdByPhone(tenDangNhap);
                ChuyenGia n = new ChuyenGia(chuyenGia.getMaChuyenGia(), ten, sodienthoai, chuyenMon, nguoiDung);
               
               
                int check = ChuyenGiaDAO.Instance.remove(n);
                if (check > 0)
                {
                    MessageBox.Show("Xoa chuyen gia thanh cong");
                    loadChuyenGia();

                    txb_tenNhaNong.Enabled = false;
                    txb_TenDangNhap.Enabled = false;
                    txb_MatKhau.Enabled = false;
                    txb_TenHienThi.Enabled = false;
                    textBox2.Enabled = false;
                   
                }

                else
                {
                    MessageBox.Show("Xoa chuyen gia khong thanh cong");
                    loadChuyenGia();

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(even.Equals("them"))
            {
                string ten = txb_tenNhaNong.Text;
                string chuyenMon = txb_ChuyenMon.Text;
                string sodienthoai = txb_SDT.Text;

                string tenDangNhap = txb_TenDangNhap.Text;
                string MatKhau = txb_MatKhau.Text;
                string MatKhauNhapLai = textBox2.Text;
                string tenHienThi = txb_TenHienThi.Text;
                int vaiTro = 2;

                if (MatKhau != MatKhauNhapLai)
                {
                    MessageBox.Show("Mat khau khong khop!");
                    txb_MatKhau.Text = "";
                    textBox2.Text = "";
                    return;

                }

                if (tenDangNhap != null)
                {
                    NguoiDung nguoiDung = new NguoiDung(tenDangNhap, MatKhau, vaiTro, tenDangNhap);
                    ChuyenGia chuyenGia = new ChuyenGia(ten ,chuyenMon , sodienthoai , nguoiDung );
                    int check = ChuyenGiaDAO.Instance.insert(chuyenGia, nguoiDung);
                    if (check > 0)
                    {
                        MessageBox.Show("Them chuyen gia thanh cong");
                        loadChuyenGia();

                       
                        txb_TenDangNhap.Enabled = false;
                        txb_MatKhau.Enabled = false;
                        txb_TenHienThi.Enabled = false;
                        textBox2.Enabled = false;
                       
                    }

                    else
                    {
                        MessageBox.Show("Them chuyen gia khong thanh cong");

                    }
                }
            }

            else
            {
                string ten = txb_tenNhaNong.Text;
                string chuyenMon = txb_ChuyenMon.Text;
              

                string SDT = dataGridView1.CurrentRow.Cells["SodienThoai"].Value.ToString();

                string tenDangNhap = txb_TenDangNhap.Text;
                string MatKhau = txb_MatKhau.Text;
                string MatKhauNhapLai = textBox2.Text;
                string tenHienThi = txb_TenHienThi.Text;
                int vaiTro = 2;

               

                if (tenDangNhap != null)
                {
                    NguoiDung nguoiDung = new NguoiDung(tenDangNhap, MatKhau, vaiTro, tenDangNhap);


                    
                    ChuyenGia chuyenGia = ChuyenGiaDAO.Instance.getIdByPhone(tenDangNhap);

                    
                    ChuyenGia n = new ChuyenGia(chuyenGia.getMaChuyenGia(), ten, chuyenMon,SDT, nguoiDung);
                  


                    int check = ChuyenGiaDAO.Instance.Update(n);
                    if (check > 0)
                    {
                        MessageBox.Show("Cap nhat chuyen gia thanh cong");
                        txb_TenDangNhap.Enabled = false;
                        txb_MatKhau.Enabled = false;
                        txb_TenHienThi.Enabled = false;
                        textBox2.Enabled = false;
                        loadChuyenGia();

                        
                    }

                    else
                    {
                        MessageBox.Show("Cap nhat chuyen gia khong thanh cong");

                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string tenNhaNong = dataGridView1.CurrentRow.Cells["Ten"].Value.ToString();
            string ChuyenMon = dataGridView1.CurrentRow.Cells["ChuyenMon"].Value.ToString();
            string SoDT = dataGridView1.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            string tenDangNhap = dataGridView1.CurrentRow.Cells["TenDangNhap"].Value.ToString();
            string MatKhau = dataGridView1.CurrentRow.Cells["MatKhau"].Value.ToString();
            string tenHienThi = dataGridView1.CurrentRow.Cells["TenHienThi"].Value.ToString();

            txb_tenNhaNong.Text = tenNhaNong;
            txb_ChuyenMon.Text = ChuyenMon; 
            txb_SDT.Text = SoDT;    
            txb_TenDangNhap.Text = tenDangNhap;
            txb_MatKhau.Text = MatKhau;
            txb_TenHienThi.Text = tenHienThi;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            dataGridView1.DataSource = ChuyenGiaDAO.Instance.find(str);

            dataGridView1.Columns[0].HeaderText = "Tên";
            dataGridView1.Columns[1].HeaderText = "Chuyên môn";
            dataGridView1.Columns[2].HeaderText = "Số điện thoại";
            dataGridView1.Columns[3].HeaderText = "Tên Đăng Nhập";
            dataGridView1.Columns[4].HeaderText = "Mật Khẩu";
            dataGridView1.Columns[5].HeaderText = "Tên Hiển Thị";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;


            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

        }
    }
}
