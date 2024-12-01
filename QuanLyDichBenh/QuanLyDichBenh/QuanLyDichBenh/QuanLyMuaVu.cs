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
    public partial class QuanLyMuaVu : Form
    {
        string even = ""; 
        public QuanLyMuaVu()
        {
            InitializeComponent();
            loadMuaVu();  
        }

        public void loadMuaVu()
        {
            dataGridView1.DataSource = MuaVuDAO.Instance.loadMuaVu();

           
            dataGridView1.Columns[0].HeaderText = "Mùa Vụ ";
            dataGridView1.Columns[1].HeaderText = "Ngày Bắt Đầu";
            dataGridView1.Columns[2].HeaderText = "Ngày Kết Thúc";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string tenMuaVu = dataGridView1.CurrentRow.Cells["TenMuaVu"].Value?.ToString() ?? string.Empty;
           

            string ngaybatDau = dataGridView1.CurrentRow.Cells["NgayBatDau"].Value?.ToString() ?? string.Empty;
            string ngayKetThuc = dataGridView1.CurrentRow.Cells["NgayKetThuc"].Value?.ToString() ?? string.Empty;

            txb_tenMuaVu.Text = tenMuaVu;


            if (DateTime.TryParse(ngaybatDau, out DateTime parsedDate))
            {
                dateTimePicker1.Value = parsedDate;
            }

            if (DateTime.TryParse(ngayKetThuc, out DateTime parsedDateKetThuc))
            {
                dateTimePicker2.Value = parsedDateKetThuc;
            }
        }

        public void clear()
        {
            txb_tenMuaVu.Text = "";
            dateTimePicker1.Value = DateTime.Now; 
            dateTimePicker2.Value= DateTime.Now;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            even = "them"; 
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            even = "sua"; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tenMuaVu = dataGridView1.CurrentRow.Cells["TenMuaVu"].Value.ToString();
            string tenMV = txb_tenMuaVu.Text;
            DateTime nbd = dateTimePicker1.Value;
            DateTime nkt = dateTimePicker2.Value;

            MuaVu mv = MuaVuDAO.Instance.getIdByName(tenMuaVu);

            MuaVu muaVu = new MuaVu(mv.MaMuaVu, tenMV, nbd, nkt);
            int check = MuaVuDAO.Instance.remove(mv.MaMuaVu);
            if (check > 0)
            {
                MessageBox.Show("Xoa Mua Vu Thanh Cong");
                loadMuaVu();
            }
            else
            {
                MessageBox.Show("Xoa Mua Vu Khong Thanh Cong");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tenMuaVu = dataGridView1.CurrentRow.Cells["TenMuaVu"].Value.ToString();  
            string tenMV = txb_tenMuaVu.Text;
            DateTime nbd = dateTimePicker1.Value;  
            DateTime nkt = dateTimePicker2.Value; 

            if(even.Equals("them"))
            {
                MuaVu muaVu = new MuaVu(tenMV , nbd , nkt) ;
                int check  = MuaVuDAO.Instance.insert(muaVu) ;
                if(check  > 0)
                {
                    MessageBox.Show("Them Mua Vu Thanh Cong");  
                    loadMuaVu() ;    
                }
                else
                {
                    MessageBox.Show("Them Mua Vu Khong Thanh Cong");
                }
            }
            else
            {
                MuaVu mv = MuaVuDAO.Instance.getIdByName(tenMuaVu); 

                MuaVu muaVu = new MuaVu( mv.MaMuaVu,  tenMV, nbd, nkt);
                int check = MuaVuDAO.Instance.update(muaVu);
                if (check > 0)
                {
                    MessageBox.Show("Cap Nhat Mua Vu Thanh Cong");
                    loadMuaVu();
                }
                else
                {
                    MessageBox.Show("Cap Nhat Mua Vu Khong Thanh Cong");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            dataGridView1.DataSource = MuaVuDAO.Instance.find(str);


            dataGridView1.Columns[0].HeaderText = "Mùa Vụ ";
            dataGridView1.Columns[1].HeaderText = "Ngày Bắt Đầu";
            dataGridView1.Columns[2].HeaderText = "Ngày Kết Thúc";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }
    }
}
