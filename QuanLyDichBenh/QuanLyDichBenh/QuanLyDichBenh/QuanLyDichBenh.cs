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
    public partial class QuanLyDichBenh : Form
    {
        string even = "";
        public QuanLyDichBenh()
        {
            InitializeComponent();
            loadDichBenh();
            addDichBenh();
        }

        public void loadDichBenh()
        {
            dataGridView1.DataSource = DichBenhDAO.Instance.loadDichBenh();

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

        public void addDichBenh()
        {
            //txb_tenDichBenh.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ten"));
            //richTextBox_mota.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "mota"));
        }

        private void clear()
        {
            txb_tenDichBenh.Text = "";
            richTextBox_mota.Text = "";
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
            string dicbenhname = dataGridView1.CurrentRow.Cells["ten"].Value.ToString();
            string dicbenhdesr = dataGridView1.CurrentRow.Cells["mota"].Value.ToString();

            string tenDichBenh = txb_tenDichBenh.Text;
            string mota = richTextBox_mota.Text;

            DichBenh db = DichBenhDAO.Instance.getIdByName(dicbenhname);


            if (db == null)
            {
                MessageBox.Show("Dich benh khong ton tai");
                return;
            }

            int check = DichBenhDAO.Instance.remove(db.dichBenhID);
            if (check < 0)
            {
                MessageBox.Show("Xoa dich benh khong thanh cong");
                loadDichBenh();

            }

            else
            {
                MessageBox.Show("Xoa nhat dich benh thanh cong ");
                loadDichBenh();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (even.Equals("them"))
            {
                string dicbenhname = dataGridView1.CurrentRow.Cells["ten"].Value.ToString();
                string dicbenhdesr = dataGridView1.CurrentRow.Cells["mota"].Value.ToString();

                string tenDichBenh = txb_tenDichBenh.Text;
                string mota = richTextBox_mota.Text;

                DichBenh dichBenh = new DichBenh(tenDichBenh, mota);

                DichBenh db = DichBenhDAO.Instance.getIdByName(tenDichBenh);



                if (db != null)
                {
                    MessageBox.Show("Dich benh da ton tai");
                    return;
                }

                int check = DichBenhDAO.Instance.insert(dichBenh);
                if (check < 0)
                {
                    MessageBox.Show("Them dich benh khong thanh cong");
                    loadDichBenh();

                }

                else
                {
                    MessageBox.Show("Them dich benh thanh cong ");
                    loadDichBenh();

                }
            }
            else
            {
               
                string dicbenhname = dataGridView1.CurrentRow.Cells["ten"].Value.ToString();
                string dicbenhdesr = dataGridView1.CurrentRow.Cells["mota"].Value.ToString();

                string tenDichBenh = txb_tenDichBenh.Text;
                string mota = richTextBox_mota.Text;

                DichBenh db = DichBenhDAO.Instance.getIdByName(dicbenhname);


                if (db == null)
                {
                    MessageBox.Show("Dich benh khong ton tai");
                    return;
                }

                DichBenh dichBenh = new DichBenh(db.dichBenhID, tenDichBenh, mota);
                int check = DichBenhDAO.Instance.update(dichBenh);
                if (check < 0)
                {
                    MessageBox.Show("Cap nhat dich benh khong thanh cong");
                    loadDichBenh();

                }

                else
                {
                    MessageBox.Show("Cap nhat dich benh thanh cong ");
                    loadDichBenh();

                }
            }
        }

        private void txb_tenDichBenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox_mota.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void richTextBox_mota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string dicbenhname = dataGridView1.CurrentRow.Cells["ten"].Value.ToString();
            string dicbenhdesr = dataGridView1.CurrentRow.Cells["mota"].Value.ToString();

           txb_tenDichBenh.Text = dicbenhname;
           richTextBox_mota.Text = dicbenhdesr;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text; 
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
    }
}
