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

namespace QuanLyDichBenh
{
    public partial class QuanLyNhaNong : Form
    {
        string even = "";  
        public QuanLyNhaNong()
        {
            InitializeComponent();
            loadNongDan();
            addNhaNong();
            textBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false; 
            textBox5.Enabled = false;  
          

        }

        public void loadNongDan()

        {
            

            dataGridView1.DataSource = NhaNongDAO.Instance.loadAllNhaNong();
            dataGridView1.Columns[0].HeaderText = "Tên";
            dataGridView1.Columns[2].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[1].HeaderText = "Số điện thoại";
            dataGridView1.Columns[3].HeaderText = "Tên Đang Nhập";
            dataGridView1.Columns[4].HeaderText = "Mật Khẩu";
            dataGridView1.Columns[5].HeaderText = "Tên Hiển Thị";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 400;
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

        public void addNhaNong()
        {
            //txb_tenNhaNong.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ten"));
            //txb_SDT.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "sodienthoai"));
            //txb_diaChi.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "diachi"));
            //textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "tendangnhap"));
            //textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource,"matkhau"));
            //textBox4.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "TenHienThi"));

        }



        

        private void clear()
        {
            txb_tenNhaNong.Text = "";
            txb_diaChi.Text = "";
            txb_SDT.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            clear();
            even = "them";
            txb_tenNhaNong.Enabled = true;
            textBox3.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            even = "sua";
            textBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ten = txb_tenNhaNong.Text;
            string sodienthoai = txb_SDT.Text;
            string diachi = txb_diaChi.Text;

            string tenDangNhap = textBox3.Text;
            string MatKhau = textBox2.Text;
            string MatKhauNhapLai = textBox5.Text;
            string tenHienThi = textBox4.Text;
            int vaiTro = 1;


            if (tenDangNhap != null)
            {
                NguoiDung nguoiDung = new NguoiDung(tenDangNhap, MatKhau, vaiTro, tenDangNhap);
                NongDan nongDan = NhaNongDAO.Instance.getIdByPhone(sodienthoai);
                NongDan n = new NongDan(nongDan.getNongDanID(), ten, sodienthoai, diachi, nguoiDung);
                int check = NhaNongDAO.Instance.remove(n);
                if (check > 0)
                {
                    MessageBox.Show("Xoa nong dan thanh cong");
                    loadNongDan();


                }

                else
                {
                    MessageBox.Show("XOa nong dan khong thanh cong");

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(even.Equals("them") ) {

                string ten = txb_tenNhaNong.Text;
                string sodienthoai = txb_SDT.Text;
                string diachi = txb_diaChi.Text;

                string tenDangNhap = textBox3.Text;
                string MatKhau = textBox2.Text;
                string MatKhauNhapLai = textBox5.Text;
                string tenHienThi = textBox4.Text;
                int vaiTro = 1;

                if(MatKhau != MatKhauNhapLai)
                {
                    MessageBox.Show("Mat khau khong khop!");
                    textBox2.Text = "";
                    textBox5.Text = "";
                    return;

                }

                if (tenDangNhap != null)
                {
                    NguoiDung nguoiDung = new NguoiDung(tenDangNhap, MatKhau, vaiTro, tenDangNhap);
                    NongDan nongDan = new NongDan(ten, sodienthoai, diachi, nguoiDung);
                    int check = NhaNongDAO.Instance.insert(nongDan, nguoiDung);
                    if (check > 0)
                    {
                        MessageBox.Show("Them nong dan thanh cong");
                        loadNongDan();

                        textBox3.Enabled = false;
                        textBox2.Enabled = false;
                        textBox4.Enabled = false;
                        textBox5.Enabled = false;
                    }

                    else
                    {
                        MessageBox.Show("Them nong dan khong thanh cong");

                    }
                }

            }
            else
            {
               
                string ten = txb_tenNhaNong.Text;
                string sodienthoai = txb_SDT.Text;
                string diachi = txb_diaChi.Text;

                string tenDangNhap = textBox3.Text;
                string MatKhau = textBox2.Text;
                string tenHienThi = textBox4.Text;
                int vaiTro = 1;
                if (tenDangNhap != null)
                {
                   
                    NguoiDung nguoiDung = new NguoiDung(tenDangNhap, MatKhau, vaiTro, tenDangNhap);
                    NongDan nongDan = NhaNongDAO.Instance.getIdByPhone(sodienthoai);
                    NongDan n = new NongDan(nongDan.getNongDanID(), ten, sodienthoai, diachi, nguoiDung);
                    int check = NhaNongDAO.Instance.Update(n);
                    if (check > 0)
                    {
                        MessageBox.Show("Cap nhat nong dan thanh cong");
                        loadNongDan();
                        textBox3.Enabled = false;
                        textBox2.Enabled = false;
                        textBox4.Enabled = false;
                        textBox5.Enabled = false;
                    }

                    else
                    {
                        MessageBox.Show("Cap nhat  nong dan khong thanh cong");

                    }
                }

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string tenNhaNong = dataGridView1.CurrentRow.Cells["Ten"].Value.ToString();
            string Diachi = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
            string SoDT = dataGridView1.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            string tenDangNhap = dataGridView1.CurrentRow.Cells["TenDangNhap"].Value.ToString();
            string MatKhau = dataGridView1.CurrentRow.Cells["MatKhau"].Value.ToString();
            string tenHienThi = dataGridView1.CurrentRow.Cells["TenHienThi"].Value.ToString();

            txb_tenNhaNong.Text = tenNhaNong;
            txb_diaChi.Text = Diachi; 
            txb_SDT.Text = SoDT;
            textBox3 .Text = tenDangNhap;
            textBox2.Text = MatKhau;
            textBox4.Text = tenHienThi; 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            dataGridView1.DataSource = NhaNongDAO.Instance.find(str);
            dataGridView1.Columns[0].HeaderText = "Tên";
            dataGridView1.Columns[2].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[1].HeaderText = "Số điện thoại";
            dataGridView1.Columns[3].HeaderText = "Tên Đang Nhập";
            dataGridView1.Columns[4].HeaderText = "Mật Khẩu";
            dataGridView1.Columns[5].HeaderText = "Tên Hiển Thị";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 400;
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

        private void button6_Click(object sender, EventArgs e)
        {
            report r = new report();
            r.ShowDialog();


        }
    }

    
}
