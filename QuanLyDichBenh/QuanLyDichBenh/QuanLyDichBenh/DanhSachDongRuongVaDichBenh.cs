using QuanLyDichBenh.DAO;
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
    public partial class DanhSachDongRuongVaDichBenh : Form
    {
        int page1 = 1;
        int page2 = 1;
       string even = "";
        int tab = 1; 
        public DanhSachDongRuongVaDichBenh()
        {
            InitializeComponent();
            loadAllDR(page1);
            loadAllDB(page2);
            loadtextbox();
            loadtextboxpage2();
        }

       

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void loadAllDR(int page)
        {
            dataGridView2.DataSource = DongRuongDAO.Instance.loadAllDongRuong(page);

            dataGridView2.Columns[0].HeaderText = "Tên Nhà Nông ";
            dataGridView2.Columns[1].HeaderText = "Địa Chỉ";
            dataGridView2.Columns[2].HeaderText = "SDT";
            dataGridView2.Columns[3].HeaderText = "Tên Ruộng";
            dataGridView2.Columns[4].HeaderText = "Tên Giống";
            dataGridView2.Columns[5].HeaderText = "Mùa Vụ";

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView2.Columns[0].Width = 120;
            dataGridView2.Columns[1].Width = 240;
            dataGridView2.Columns[2].Width = 120;
            dataGridView2.Columns[3].Width = 120;
            dataGridView2.Columns[4].Width = 120;
            dataGridView2.Columns[5].Width = 120;
            dataGridView2.Font = new Font("Arial", 9);
            dataGridView2.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView2.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView2.RowTemplate.Height = 25;
        }



        public void loadAllDB(int page)
        {
            dataGridView1.DataSource = DichBenhDAO.Instance.loadAllDB(page);

            dataGridView1.Columns[0].HeaderText = "ID ";
            dataGridView1.Columns[1].HeaderText = "Tên Ruộng";
            dataGridView1.Columns[2].HeaderText = "Vị Trí";
            dataGridView1.Columns[3].HeaderText = "Diện Tích";
            dataGridView1.Columns[4].HeaderText = "Tên Giống";
            dataGridView1.Columns[5].HeaderText = "Tên Dịch Bệnh";
            dataGridView1.Columns[6].HeaderText = "Ngày Báo Cáo";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

           
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 320;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 170;
            dataGridView1.Columns[6].Width = 150;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            page1 = 1;  
            loadAllDR(page1);
            loadtextbox();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int soluong = DongRuongDAO.Instance.getcount();
            
             page1 = (soluong / 10) + 1;
          
            loadAllDR( page1 );
            loadtextbox(); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            if(page1 > 1 )
            {
                page1--;
                loadAllDR(page1);
                loadtextbox();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
           int soluong = DongRuongDAO.Instance.getcount();
           int ketthuc = (soluong / 10);
            
            if (page1 < (ketthuc + 1) )
            {
                
                page1++;
                loadAllDR(page1);
                loadtextbox();  
            }
        }

        public void loadtextbox()
        {
            textBox6.Text = page1.ToString();
        }

        public void loadtextboxpage2()
        {
            textBox3.Text = page2.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            page2 = 1;
            loadAllDB(page2);
            loadtextboxpage2();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int soluong =BaoCaoDichBenhDAO.Instance.getcount();
            MessageBox.Show(soluong + "");

            page2 = (soluong / 10) + 1;

            loadAllDB(page2);
            loadtextboxpage2();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (page2 > 1)
            {
                page2--;
                loadAllDB(page2);
                loadtextboxpage2();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int soluong = BaoCaoDichBenhDAO.Instance.getcount();
            int ketthuc = (soluong / 10);

            if (page2 < (ketthuc + 1))
            {

                page2++;
                loadAllDB(page2);
                loadtextboxpage2();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;

            if (selectedTab == tabPage1)
            {

                tab = 1; 

              


            }
            else if (selectedTab == tabPage2)
            {
                tab = 2; 
                
               
            }
        }

        

        private void ThongKeBtn_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            
            if (selectedTab == tabPage1)
            {
                string chosse = comboBox1.Text;
                if (chosse.Equals("Vị Trí"))
                {


                    int Count = DongRuongDAO.Instance.getCount();
                    List<string> max = DongRuongDAO.Instance.getMaxByViTri();
                    List<string> min = DongRuongDAO.Instance.getMinByViTri();

                    label_Sum.Text = Count.ToString();
                    string text1 = "";
                    string text2 = "";
                    foreach (string item in max)
                    {

                        text1 += item + "\n";

                    }

                    foreach (string item in min)
                    {

                        text2 += item + "\n";

                    }

                    label_Max.Text = text1;
                    label_min.Text = text2;
                }
                else if (chosse.Equals("Nông Dân"))
                {
                    int Count = DongRuongDAO.Instance.getCount();
                    List<string> max = DongRuongDAO.Instance.getMaxByNhaNong();
                    List<string> min = DongRuongDAO.Instance.getMinByNhaNong();

                    label_Sum.Text = Count.ToString();
                    string text1 = "";
                    string text2 = "";
                    foreach (string item in max)
                    {

                        text1 += item + "\n";

                    }

                    foreach (string item in min)
                    {

                        text2 += item + "\n";

                    }

                    label_Max.Text = text1;
                    label_min.Text = text2;
                }
                else if (chosse.Equals("Giống Lúa"))
                {
                    int Count = DongRuongDAO.Instance.getCount();
                    List<string> max = DongRuongDAO.Instance.getMaxByGiongLua();
                    List<string> min = DongRuongDAO.Instance.getMinByGiongLua();

                    label_Sum.Text = Count.ToString();
                    string text1 = "";
                    string text2 = "";
                    foreach (string item in max)
                    {

                        text1 += item + "\n";

                    }

                    foreach (string item in min)
                    {

                        text2 += item + "\n";

                    }

                    label_Max.Text = text1;
                    label_min.Text = text2;
                }
            }


           
               
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string choose1 = comboBox2.Text;
                if (choose1.Equals("Ruộng Lúa"))
            {
                int Count = DichBenhDAO.Instance.getCount();
                List<string> max = DichBenhDAO.Instance.getMaxByRuongLua();
                List<string> min = DichBenhDAO.Instance.getMinByRuongLua();

                label7.Text = Count.ToString();
                string text1 = "";
                string text2 = "";
                foreach (string item in max)
                {

                    text1 += item + "\n";

                }

                foreach (string item in min)
                {

                    text2 += item + "\n";

                }

                label4.Text = text1;
                label1.Text = text2;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string str = textBox2.Text;
            dataGridView2.DataSource = DongRuongDAO.Instance.find2(str);

            dataGridView2.Columns[0].HeaderText = "Tên Nhà Nông ";
            dataGridView2.Columns[1].HeaderText = "Địa Chỉ";
            dataGridView2.Columns[2].HeaderText = "SDT";
            dataGridView2.Columns[3].HeaderText = "Tên Ruộng";
            dataGridView2.Columns[4].HeaderText = "Tên Giống";
            dataGridView2.Columns[5].HeaderText = "Mùa Vụ";

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView2.Columns[0].Width = 120;
            dataGridView2.Columns[1].Width = 240;
            dataGridView2.Columns[2].Width = 120;
            dataGridView2.Columns[3].Width = 120;
            dataGridView2.Columns[4].Width = 120;
            dataGridView2.Columns[5].Width = 120;
            dataGridView2.Font = new Font("Arial", 9);
            dataGridView2.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView2.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView2.RowTemplate.Height = 25;
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            dataGridView1.DataSource = DichBenhDAO.Instance.find4(str);


            dataGridView1.Columns[0].HeaderText = "ID ";
            dataGridView1.Columns[1].HeaderText = "Tên Ruộng";
            dataGridView1.Columns[2].HeaderText = "Vị Trí";
            dataGridView1.Columns[3].HeaderText = "Diện Tích";
            dataGridView1.Columns[4].HeaderText = "Tên Giống";
            dataGridView1.Columns[5].HeaderText = "Tên Dịch Bệnh";
            dataGridView1.Columns[6].HeaderText = "Ngày Báo Cáo";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 320;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 170;
            dataGridView1.Columns[6].Width = 150;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }
    }
}
