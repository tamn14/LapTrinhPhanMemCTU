using QuanLyDichBenh.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDichBenh
{
    public partial class DanhSach : Form
    {
        int page1 = 1;
        int page2 = 1;
        int page3 = 1;
        int page4 = 1;
        int page5 = 1;
        string even = "";
        public DanhSach()
        {
            InitializeComponent();
            loadRuongLua(page4);
            loadDichBenh(page5);
            loadChuyenGia(page2);

            loadNongDan(page1);
            loadNguoiDung(page3);

            loadtextbox();
            loadtextboxPage2();  
            loadtextboxPage3(); 
            loadtextboxPage4(); 
            loadtextboxPage5();
        }

        public void loadRuongLua(int page4)
        {
            dataGridView2.DataSource = DongRuongDAO.Instance.loadDongRuongForDS(page4);
            dataGridView2.Columns[0].HeaderText = "Tên ruộng lúa";
            dataGridView2.Columns[1].HeaderText = "Tên nông dân";
            dataGridView2.Columns[2].HeaderText = "Diện tích";
            dataGridView2.Columns[3].HeaderText = "Vị trí";
            dataGridView2.Columns[4].HeaderText = "Tên giống";
            dataGridView2.Columns[5].HeaderText = "Mua Vu ";
            dataGridView2.Columns[6].HeaderText = "Ngày gieo";


            dataGridView2.Columns[3].Width = 300;

            dataGridView2.Font = new Font("Arial", 9);
            dataGridView2.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView2.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView2.RowTemplate.Height = 25;
        }

        public void loadDichBenh(int page5)
        {
            dataGridView1.DataSource = DichBenhDAO.Instance.loadAllDBForDS(page5);

            dataGridView1.Columns[0].HeaderText = "Tên bệnh";
            dataGridView1.Columns[1].HeaderText = "Mô tả";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 1000;
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }

        public void loadChuyenGia(int page2)
        {
            dataGridView4.DataSource = ChuyenGiaDAO.Instance.loadChuyenGiaForDs(page2);

            dataGridView4.Columns[0].HeaderText = "Tên";
            dataGridView4.Columns[1].HeaderText = "Chuyên môn";
            dataGridView4.Columns[2].HeaderText = "Số điện thoại";

            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView4.Columns[0].Width = 150;
            dataGridView4.Columns[1].Width = 400;
            dataGridView4.Columns[2].Width = 300;


            dataGridView4.Font = new Font("Arial", 9);
            dataGridView4.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView4.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView4.RowTemplate.Height = 25;
        }



        public void loadNongDan(int page1)
        {
            dataGridView5.DataSource = NhaNongDAO.Instance.loadNhaNongForDs(page1);
            dataGridView5.Columns[0].HeaderText = "Tên";
            dataGridView5.Columns[2].HeaderText = "Địa Chỉ";
            dataGridView5.Columns[1].HeaderText = "Số điện thoại";

            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView5.Columns[0].Width = 150;

            dataGridView5.Font = new Font("Arial", 9);
            dataGridView5.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView5.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView5.RowTemplate.Height = 25;
        }

        public void loadNguoiDung(int page3)
        {
            dataGridView3.DataSource = NguoiDungDAO.Instance.loadNguoiDungForDS(page3);
            dataGridView3.Columns[0].HeaderText = "Tên Đăng Nhập ";
            dataGridView3.Columns[1].HeaderText = "Mật Khẩu";
            dataGridView3.Columns[2].HeaderText = "Vai Trò";
            dataGridView3.Columns[3].HeaderText = "Tên Hiển Thị";


            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView3.Columns[0].Width = 230;
            dataGridView3.Columns[1].Width = 230;
            dataGridView3.Columns[2].Width = 230;
            dataGridView3.Columns[3].Width = 230;

            dataGridView3.Font = new Font("Arial", 9);
            dataGridView3.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView3.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView3.RowTemplate.Height = 25;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            page3 = 1;
            loadNongDan(page3);
            loadtextboxPage3();
        }

        public void loadtextbox()
        {
            
            textBox10.Text = page1.ToString();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (page5 > 1)
            {
                page5--;
                loadDichBenh(page1);
                loadtextboxPage5();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            page1 = 1;
            loadNongDan(page1);
            loadtextbox();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int soluong = NhaNongDAO.Instance.getCount();

            page1 = (soluong / 10) + 1;

            loadNongDan(page1);
            loadtextbox();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int soluong = NhaNongDAO.Instance.getCount();
            int ketthuc = (soluong / 10);

            if (page1 < (ketthuc + 1))
            {

                page1++;
                loadNongDan(page1);
                loadtextbox();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (page1 > 1)
            {
                page1--;
                loadNongDan(page1);
                loadtextbox();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            page2 = 1;
            loadChuyenGia(page2);
            loadtextboxPage2();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int soluong = ChuyenGiaDAO.Instance.getCount();

            page2 = (soluong / 10) + 1;

            loadNongDan(page2);
            loadtextboxPage2();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (page2 > 1)
            {
                page2--;
                loadNongDan(page2);
                loadtextboxPage2();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int soluong = ChuyenGiaDAO.Instance.getCount();
            int ketthuc = (soluong / 10);

            if (page2 < (ketthuc + 1))
            {

                page2++;
                loadNongDan(page2);
                loadtextboxPage2();
            }

        }
        public void loadtextboxPage2()
        {
            textBox11.Text = page2.ToString();
        }
        public void loadtextboxPage3()
        {
            textBox12.Text = page3.ToString();
        }
        public void loadtextboxPage4()
        {
            textBox13.Text = page4.ToString();
        }
        public void loadtextboxPage5()
        {
            textBox14.Text = page5.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int soluong = NguoiDungDAO.Instance.getCount();

            page3 = (soluong / 10) + 1;

            loadNongDan(page3);
            loadtextboxPage3();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (page3 > 1)
            {
                page3--;
                loadNongDan(page3);
                loadtextboxPage3();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int soluong = NguoiDungDAO.Instance.getCount();
            int ketthuc = (soluong / 10);

            if (page3 < (ketthuc + 1))
            {

                page3++;
                loadNongDan(page3);
                loadtextboxPage3();
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            page4 = 1;
            loadRuongLua(page4);
            loadtextboxPage4();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int soluong = DongRuongDAO.Instance.getCount();

            page4 = (soluong / 10) + 1;

            loadRuongLua(page4);
            loadtextboxPage4();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (page4 > 1)
            {
                page4--;
                loadRuongLua(page4);
                loadtextboxPage4();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int soluong = DongRuongDAO.Instance.getCount();
            int ketthuc = (soluong / 10);

            if (page4 < (ketthuc + 1))
            {

                page4++;
                loadRuongLua(page4);
                loadtextboxPage4();
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            page5 = 1;
            loadDichBenh(page5);
            loadtextboxPage5();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            int soluong =DichBenhDAO.Instance.getCount();

            page5 = (soluong / 10) + 1;

            loadDichBenh(page5);
            loadtextboxPage5();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int soluong = DichBenhDAO.Instance.getCount();
            int ketthuc = (soluong / 10);

            if (page5 < (ketthuc + 1))
            {

                page5++;
                loadDichBenh(page5);
                loadtextboxPage5();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox4.Text;
            dataGridView5.DataSource = NhaNongDAO.Instance.find2(str);
            dataGridView5.Columns[0].HeaderText = "Tên";
            dataGridView5.Columns[2].HeaderText = "Địa Chỉ";
            dataGridView5.Columns[1].HeaderText = "Số điện thoại";

            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView5.Columns[0].Width = 150;

            dataGridView5.Font = new Font("Arial", 9);
            dataGridView5.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView5.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView5.RowTemplate.Height = 25;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            dataGridView4.DataSource = ChuyenGiaDAO.Instance.find2(str);

            dataGridView4.Columns[0].HeaderText = "Tên";
            dataGridView4.Columns[1].HeaderText = "Chuyên môn";
            dataGridView4.Columns[2].HeaderText = "Số điện thoại";

            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView4.Columns[0].Width = 150;
            dataGridView4.Columns[1].Width = 400;
            dataGridView4.Columns[2].Width = 300;


            dataGridView4.Font = new Font("Arial", 9);
            dataGridView4.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView4.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView4.RowTemplate.Height = 25;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox2.Text;
            dataGridView3.DataSource = NguoiDungDAO.Instance.find(str);
            dataGridView3.Columns[0].HeaderText = "Tên Đăng Nhập ";
            dataGridView3.Columns[1].HeaderText = "Mật Khẩu";
            dataGridView3.Columns[2].HeaderText = "Vai Trò";
            dataGridView3.Columns[3].HeaderText = "Tên Hiển Thị";


            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView3.Columns[0].Width = 230;
            dataGridView3.Columns[1].Width = 230;
            dataGridView3.Columns[2].Width = 230;
            dataGridView3.Columns[3].Width = 230;

            dataGridView3.Font = new Font("Arial", 9);
            dataGridView3.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView3.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView3.RowTemplate.Height = 25;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            dataGridView2.DataSource = DongRuongDAO.Instance.find3(str);
            dataGridView2.Columns[0].HeaderText = "Tên ruộng lúa";
            dataGridView2.Columns[1].HeaderText = "Tên nông dân";
            dataGridView2.Columns[3].HeaderText = "Diện tích";
            dataGridView2.Columns[2].HeaderText = "Vị trí";
            dataGridView2.Columns[4].HeaderText = "Tên giống";
            dataGridView2.Columns[5].HeaderText = "Mua Vu";
            dataGridView2.Columns[6].HeaderText = "Ngày gieo";


            dataGridView2.Columns[2].Width = 300;

            dataGridView2.Font = new Font("Arial", 9);
            dataGridView2.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView2.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView2.RowTemplate.Height = 25;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = txb_TimNhaNong.Text;
            dataGridView1.DataSource = DichBenhDAO.Instance.finđB(str);

            dataGridView1.Columns[0].HeaderText = "Tên bệnh";
            dataGridView1.Columns[1].HeaderText = "Mô tả";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 1000;
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
