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
    public partial class PhuongPhapDieuTri : Form
    {
        private NguoiDung nguoiDung;
        public PhuongPhapDieuTri(NguoiDung NguoiDung)
        {
            this.nguoiDung = NguoiDung;
            InitializeComponent();
            loadDichBenh();
            loadGiongLua();
            loadPPDT(nguoiDung);
            addDichBenh();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public void loadPPDT(NguoiDung nguoiDung)
        {

            dataGridView1.DataSource = PhuongPhapDieuTriDAO.Instance.loadPhuongPhap(nguoiDung);
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.Columns[0].HeaderText = "Tên Đồng Ruộng";
                dataGridView1.Columns[1].HeaderText = "Tên Dịch Bệnh";
                dataGridView1.Columns[2].HeaderText = "Tên Giống";
                dataGridView1.Columns[3].HeaderText = "Cách Sử Lý ";
                dataGridView1.Columns[4].HeaderText = "Ngày Báo Cáo ";



                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 230;
                dataGridView1.Columns[4].Width = 100;


                dataGridView1.Font = new Font("Arial", 9);
                dataGridView1.ScrollBars = ScrollBars.Both;

                DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
                rowStyle.BackColor = Color.LightBlue;
                dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

                dataGridView1.RowTemplate.Height = 25;
            }
            else
            {

                Console.WriteLine("Không có dữ liệu để hiển thị trong DataGridView.");
            }

        }

        public void addDichBenh()
        {
            textBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "TenRuong"));
            richTextBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "CachXuLy"));



        }


        public void loadGiongLua()
        {
            List<GiongLua> list = GiongLuaDAO.Instance.getGiongLua();
            cbb2.DataSource = list;
            cbb2.DisplayMember = "tenGiong";
            cbb2.ValueMember = "giongLuaID";

        }

        public void loadDichBenh()
        {
            List<DichBenh> list = DichBenhDAO.Instance.GetDichBenhs();
            cbb1.DataSource = list;
            cbb1.DisplayMember = "ten";
            cbb1.ValueMember = "dichBenhID";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string tenGiong = dataGridView1.CurrentRow.Cells["TenGiong"].Value?.ToString() ?? string.Empty;
                string tenDichBenh = dataGridView1.CurrentRow.Cells["TenDichBenh"].Value?.ToString() ?? string.Empty;
               
                
                string ngaybaocao = dataGridView1.CurrentRow.Cells["NgayBaoCao"].Value?.ToString() ?? string.Empty;

                GiongLua gionglua = GiongLuaDAO.Instance.getIdByName(tenGiong);
                DichBenh dichBenh = DichBenhDAO.Instance.getIdByName(tenDichBenh);
               

               
                cbb2.SelectedValue = gionglua.GiongLuaID;
                cbb1.SelectedValue = dichBenh.dichBenhID;
                if (DateTime.TryParse(ngaybaocao, out DateTime parsedDate))
                {
                    dtp1.Value = parsedDate;
                }
              


            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbb1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cbb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbb2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cbb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                richTextBox1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void dtp1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtp1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox2.Text;
            dataGridView1.DataSource = PhuongPhapDieuTriDAO.Instance.find(nguoiDung.getTenDangNhap() , str);
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.Columns[0].HeaderText = "Tên Đồng Ruộng";
                dataGridView1.Columns[1].HeaderText = "Tên Dịch Bệnh";
                dataGridView1.Columns[2].HeaderText = "Tên Giống";
                dataGridView1.Columns[3].HeaderText = "Cách Sử Lý ";
                dataGridView1.Columns[4].HeaderText = "Ngày Báo Cáo ";



                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 230;
                dataGridView1.Columns[4].Width = 100;


                dataGridView1.Font = new Font("Arial", 9);
                dataGridView1.ScrollBars = ScrollBars.Both;

                DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
                rowStyle.BackColor = Color.LightBlue;
                dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

                dataGridView1.RowTemplate.Height = 25;
            }
            else
            {

                Console.WriteLine("Không có dữ liệu để hiển thị trong DataGridView.");
            }


        }
    }
}
