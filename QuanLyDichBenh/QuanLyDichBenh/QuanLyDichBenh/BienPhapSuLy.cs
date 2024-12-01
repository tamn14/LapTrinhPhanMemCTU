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
    
    public partial class BienPhapSuLy : Form
    {
        string even = "";
        public BienPhapSuLy()
        {
            InitializeComponent();
            dtp_ngayBaoCao.DropDown += dtp_ngayBaoCao_DropDown;
            dtp_ngayBaoCao.CloseUp += dtp_ngayBaoCao_CloseUp;
            loadBienPhap(); 
            loadDichBenh();
            addBienPhap();
            
        }



        public void loadBienPhap()
        {
            dataGridView1.DataSource = BienPhapXuLyDAO.Instance.loadBienPhapSuLy();

            dataGridView1.Columns[0].HeaderText = "Tên Dịch Bệnh ";
            dataGridView1.Columns[1].HeaderText = "Biện Pháp Xử Lý";
            dataGridView1.Columns[2].HeaderText = "Ngay Đề Xuất";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }


        public void addBienPhap()
        {
            //richTextBox_BienPhapSuLy.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "mota"));
        }

        public void loadDichBenh()
        {
            List<DichBenh> list = DichBenhDAO.Instance.GetDichBenhs();
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "ten";
            comboBox1.ValueMember = "dichBenhID";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string tenDichBenh = dataGridView1.CurrentRow.Cells["ten"].Value?.ToString() ?? string.Empty;
                string mota = dataGridView1.CurrentRow.Cells["mota"].Value?.ToString() ?? string.Empty;
                string ngaybaocao = dataGridView1.CurrentRow.Cells["ngaydexuat"].Value?.ToString() ?? string.Empty;
                

                DichBenh dichBenh = DichBenhDAO.Instance.getIdByName(tenDichBenh);
                richTextBox_BienPhapSuLy.Text = mota;  
                comboBox1.SelectedValue = dichBenh?.dichBenhID ?? -1;

                if (DateTime.TryParse(ngaybaocao, out DateTime parsedDate))
                {
                    dtp_ngayBaoCao.CustomFormat = "dd/MM/yyyy";
                    dtp_ngayBaoCao.Value = parsedDate;
                }
                else
                {
                    dtp_ngayBaoCao.CustomFormat = "'Chưa có ngày'";
                    dtp_ngayBaoCao.Value = DateTime.Now;
                }

                if (string.IsNullOrEmpty(mota))
                {
                    richTextBox_BienPhapSuLy.Text = "Chưa có biện pháp xử lý";
                }
                else
                {
                    richTextBox_BienPhapSuLy.Text = mota;
                }
            }
        }

        private void dtp_ngayBaoCao_DropDown(object sender, EventArgs e)
        {
            
            dtp_ngayBaoCao.CustomFormat = "dd/MM/yyyy";
        }

        private void dtp_ngayBaoCao_CloseUp(object sender, EventArgs e)
        {
            
            dtp_ngayBaoCao.CustomFormat = "dd/MM/yyyy";
        }

        private void clear()
        {
            comboBox1.SelectedIndex = 0;
            richTextBox_BienPhapSuLy.Text = "";  
            dtp_ngayBaoCao.Value =  System.DateTime.Now;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            even = "them";  



        }

        private void button2_Click(object sender, EventArgs e)
        {
            even = "sua";
            comboBox1.Enabled = false;

        }

            
        

        private void button3_Click(object sender, EventArgs e)
        {
            string DichBenhName = dataGridView1.CurrentRow.Cells["ten"].Value.ToString();
            string Des = dataGridView1.CurrentRow.Cells["mota"].Value.ToString();
            string ngay = dataGridView1.CurrentRow.Cells["ngaydexuat"].Value.ToString();

            string tenDichBenh = comboBox1.Text;

            string mota = richTextBox_BienPhapSuLy.Text;
            DateTime ngayDeXuat = dtp_ngayBaoCao.Value;



            DichBenh dichBenh = DichBenhDAO.Instance.getIdByName(tenDichBenh);

            BienPhapXL bienPhapXL = new BienPhapXL(mota, ngayDeXuat, dichBenh);


            int id = BienPhapXuLyDAO.Instance.getID(bienPhapXL);


            int check = BienPhapXuLyDAO.Instance.remove(id);
            if (check > 0)
            {
                MessageBox.Show(" Xoa bien phap thanh cong ");
                loadBienPhap();
            }

            else
            {
                MessageBox.Show(" Xoa bien phap khong thanh cong ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (even.Equals("them"))
            {
                string DichBenhName = dataGridView1.CurrentRow.Cells["ten"].Value.ToString();
                string Des = dataGridView1.CurrentRow.Cells["mota"].Value.ToString();
                string ngay = dataGridView1.CurrentRow.Cells["ngaydexuat"].Value.ToString();

                string tenDichBenh = comboBox1.Text;

                string mota = richTextBox_BienPhapSuLy.Text;
                DateTime ngayDeXuat = dtp_ngayBaoCao.Value;
                DichBenh dichBenh = DichBenhDAO.Instance.getIdByName(tenDichBenh);

                if (Des != null)
                {

                    BienPhapXL bienPhap = new BienPhapXL(mota, ngayDeXuat, dichBenh);
                    int check = BienPhapXuLyDAO.Instance.insert(bienPhap);
                    if (check > 0)
                    {
                        MessageBox.Show(" Them bien phap thanh cong ");
                        loadBienPhap();
                    }

                    else
                    {
                        MessageBox.Show(" Them bien phap khong thanh cong ");
                    }

                }

                else
                {
                    BienPhapXL bienPhap = new BienPhapXL(mota, ngayDeXuat, dichBenh);
                    int check = BienPhapXuLyDAO.Instance.insert(bienPhap);
                    if (check > 0)
                    {
                        MessageBox.Show(" Them bien phap thanh cong ");
                        loadBienPhap();
                    }

                    else
                    {
                        MessageBox.Show(" Them bien phap khong thanh cong ");
                    }

                }
            }

            else
            {
                string DichBenhName = dataGridView1.CurrentRow.Cells["ten"].Value.ToString();
                string Des = dataGridView1.CurrentRow.Cells["mota"].Value.ToString();
                string ngay = dataGridView1.CurrentRow.Cells["ngaydexuat"].Value.ToString();

                string tenDichBenh = comboBox1.Text;
                string mota  = richTextBox_BienPhapSuLy.Text;

                DateTime D = DateTime.Parse(ngay);


                DateTime ngayDeXuat = dtp_ngayBaoCao.Value;

                if (mota == null)
                {
                    MessageBox.Show("Vui long them Bien phap su ly va ngay de xuat ");
                    return;
                }


                DichBenh dichBenh = DichBenhDAO.Instance.getIdByName(tenDichBenh);

                BienPhapXL bienPhapXL = new BienPhapXL(Des, D, dichBenh);

                int id = BienPhapXuLyDAO.Instance.getID(bienPhapXL);

              

                BienPhapXL bienPhap = new BienPhapXL(id, mota, ngayDeXuat, dichBenh);
                int check = BienPhapXuLyDAO.Instance.update(bienPhap);
                if (check > 0)
                {
                    MessageBox.Show(" cap nhat bien phap thanh cong ");
                    loadBienPhap();
                }

                else
                {
                    MessageBox.Show(" cap nhat bien phap khong thanh cong ");
                }

            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtp_ngayBaoCao.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void dtp_ngayBaoCao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            dataGridView1.DataSource = BienPhapXuLyDAO.Instance.find(str);

            dataGridView1.Columns[0].HeaderText = "Tên Dịch Bệnh ";
            dataGridView1.Columns[1].HeaderText = "Biện Pháp Xử Lý";
            dataGridView1.Columns[2].HeaderText = "Ngay Đề Xuất";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }
    }

   
}
