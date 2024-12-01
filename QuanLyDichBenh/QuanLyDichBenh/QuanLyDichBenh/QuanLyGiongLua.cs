using QuanLyDichBenh.DAO;
using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDichBenh
{
    public partial class QuanLyGiongLua : Form
    {
        string even = ""; 
        public QuanLyGiongLua()
        {
            InitializeComponent();
            loadGiongLua();
            addGiongLua();
            loadMuaVu(); 
        }


        public void loadGiongLua()
        {
            dataGridView1.DataSource = GiongLuaDAO.Instance.getAllGiongLua();

            dataGridView1.Columns[0].HeaderText = "Tên Giống";
            dataGridView1.Columns[1].HeaderText = "Mùa Vụ ";
            dataGridView1.Columns[2].HeaderText = "Ngày Bắt Đầu";
            dataGridView1.Columns[3].HeaderText = "Ngày Kết Thúc";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }

        public void addGiongLua()
        {
           
            
            
        }

        public void loadMuaVu()
        {
            List<MuaVu> list = MuaVuDAO.Instance.getMuaVu();
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "tenMuaVu";
            comboBox1.ValueMember = "MaMuaVu";

        }

        public void clear()
        {
            txb_tenGiongLua.Text = "";
            comboBox1.SelectedIndex = 0;  
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

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
            string tenGiongLua = dataGridView1.CurrentRow.Cells["TenGiong"].Value.ToString();
            string ten = txb_tenGiongLua.Text;
            string MuaVu = comboBox1.Text;
            DateTime nbd = dateTimePicker1.Value;
            DateTime nkt = dateTimePicker2.Value;

            MuaVu muaVu = MuaVuDAO.Instance.getIdByName(MuaVu);
            GiongLua giongLua = GiongLuaDAO.Instance.getIdByName(tenGiongLua);
            GiongLua n = new GiongLua(giongLua.GiongLuaID, ten, muaVu);

            int check = GiongLuaDAO.Instance.remove(giongLua.GiongLuaID);
            if(check > 0)
            {
                MessageBox.Show("Xoa Giong Lua Thanh Cong");
                loadGiongLua(); 
            }
            else
            {
                MessageBox.Show("Xoa Giong Lua Thanh Cong");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tenGiongLua = dataGridView1.CurrentRow.Cells["TenGiong"].Value.ToString();
            string ten = txb_tenGiongLua.Text;

            string MuaVu  = comboBox1.Text; 
            DateTime nbd = dateTimePicker1.Value;   
            DateTime nkt = dateTimePicker2.Value;
            if(even.Equals("them"))
            {
                MuaVu muaVu = MuaVuDAO.Instance.getIdByName(MuaVu);
                GiongLua giongLua = new GiongLua(ten, muaVu); 
                int check = GiongLuaDAO.Instance.insert(giongLua);
                if(check > 0)
                {
                    MessageBox.Show("Them Giong Lua Thanh Cong");  
                    loadGiongLua();
                }

                else
                {
                    MessageBox.Show("Them Giong Lua Khong Thanh Cong");
                }
            }

            else
            {
                MuaVu muaVu = MuaVuDAO.Instance.getIdByName(MuaVu);
                GiongLua giongLua = GiongLuaDAO.Instance.getIdByName(tenGiongLua);
               
            
                GiongLua n = new GiongLua(giongLua.GiongLuaID, ten, muaVu);
                int check = GiongLuaDAO.Instance.update(n);
                if (check > 0)
                {
                    MessageBox.Show("Cap Nhat Giong Lua Thanh Cong");
                    loadGiongLua();
                }

                else
                {
                    MessageBox.Show("Cap Nhat Giong Lua Khong Thanh Cong");
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string tenMuaVu = dataGridView1.CurrentRow.Cells["TenMuaVu"].Value?.ToString() ?? string.Empty;
            string tenGiong = dataGridView1.CurrentRow.Cells["TenGiong"].Value?.ToString() ?? string.Empty;

            string ngaybatDau = dataGridView1.CurrentRow.Cells["NgayBatDau"].Value?.ToString() ?? string.Empty;
            string ngayKetThuc = dataGridView1.CurrentRow.Cells["NgayKetThuc"].Value?.ToString() ?? string.Empty;

            MuaVu muaVu = MuaVuDAO.Instance.getIdByName(tenMuaVu);
            comboBox1.SelectedValue = muaVu.MaMuaVu;
            txb_tenGiongLua.Text = tenGiong;

            if (DateTime.TryParse(ngaybatDau, out DateTime parsedDate))
            {
                dateTimePicker1.Value = parsedDate;
            }

            if (DateTime.TryParse(ngayKetThuc, out DateTime parsedDateKetThuc))
            {
                dateTimePicker2.Value = parsedDateKetThuc;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            dataGridView1.DataSource = GiongLuaDAO.Instance.find(str);

            dataGridView1.Columns[0].HeaderText = "Tên Giống";
            dataGridView1.Columns[1].HeaderText = "Mùa Vụ ";
            dataGridView1.Columns[2].HeaderText = "Ngày Bắt Đầu";
            dataGridView1.Columns[3].HeaderText = "Ngày Kết Thúc";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;

        }
    }
}
