using QuanLyDichBenh.DAO;
using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDB.view
{
    public partial class QLDongRuong : Form
    {
        string even = "";

        private NguoiDung nguoiDung;
         
        public QLDongRuong(NguoiDung nguoiDung)
        {
            
            this.nguoiDung=  nguoiDung ;
            InitializeComponent();
            loadDanhSach(nguoiDung);
            loadGiongLua();
            AddDongRuong();
            txb_tenNhaNong.Enabled = false;

        }

        private void QLDongRuong_Load(object sender, EventArgs e)
        {

        }


        public void loadDanhSach(NguoiDung nguoiDung)
        {
            dataGridView1.DataSource = DongRuongDAO.Instance.loadDongRuongTheoNguoiDung(nguoiDung);
            dataGridView1.Columns[0].HeaderText = "Tên Nông Dân";
            dataGridView1.Columns[1].HeaderText = "Tên Đồng Ruộng";
            dataGridView1.Columns[2].HeaderText = "Vị Trí";
            dataGridView1.Columns[3].HeaderText = "Diện Tích ";
            dataGridView1.Columns[4].HeaderText = "Tên Giống";
            dataGridView1.Columns[5].HeaderText = "Ngày Gieo";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 120;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;

        }


        public void AddDongRuong()
        {
            //txb_tenNhaNong.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "TenNhaNong"));
            //textBox1.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "TenRuong"));
            //textBox2.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ViTri"));
            //textBox3.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "DienTich"));
           
            //dateTimePicker1.DataBindings.Add(new Binding("value", dataGridView1.DataSource, "NgayGieo"));
        }


        public void loadGiongLua()
        {
            List<GiongLua> list = GiongLuaDAO.Instance.getGiongLua();
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "tenGiong";
            comboBox1.ValueMember = "giongLuaID"; 

        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string tenGiong = dataGridView1.CurrentRow.Cells["TenGiong"].Value.ToString();
                string tennhanong = dataGridView1.CurrentRow.Cells["TenNhaNong"].Value.ToString();
                string tenRuong = dataGridView1.CurrentRow.Cells["TenRuong"].Value.ToString();
                string  viTri = dataGridView1.CurrentRow.Cells["ViTri"].Value.ToString();
                string DienTich = dataGridView1.CurrentRow.Cells["DienTich"].Value.ToString();
                string ngaybaocao = dataGridView1.CurrentRow.Cells["NgayGieo"].Value.ToString();
                GiongLua gionglua = GiongLuaDAO.Instance.getIdByName(tenGiong);
                txb_tenNhaNong.Text = tennhanong;
                textBox1.Text = tenRuong;  
                textBox2.Text = viTri;

                textBox3.Text = DienTich;  
                if (gionglua != null)
                {
                    comboBox1.SelectedValue = gionglua.GiongLuaID;
                }
                if (DateTime.TryParse(ngaybaocao, out DateTime parsedDate))
                {
                    dateTimePicker1.Value = parsedDate;
                }
            }
        }

        private void clear()
        {
            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = 0; 
            dateTimePicker1.Value = DateTime.Now;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            clear();
            even = "them"; 


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tenRuong = textBox1.Text;
            int id  = DongRuongDAO.Instance.getIDByName(tenRuong); 
            int delete = DongRuongDAO.Instance.Remove(id);
            if (delete > 0) {
                MessageBox.Show("Xóa ruộng lúa thành công!!");
                loadDanhSach(nguoiDung); 
            }

            else
            {
                MessageBox.Show("Xóa không thành công!!!!"); 
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            even = "sua";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (even.Equals("them")) {
                string tenNhaNong = txb_tenNhaNong.Text;
                string tenRuong = textBox1.Text;
                string viTri = textBox2.Text;
                double dientich;


                if (!double.TryParse(textBox3.Text, out dientich))
                {
                    MessageBox.Show("Vui lòng nhập diện tích hợp lệ.");
                    return;
                }

                string giongLuaName = comboBox1.Text;

                GiongLua giongLua = GiongLuaDAO.Instance.getIdByName(giongLuaName);
                MessageBox.Show(nguoiDung.getTenDangNhap());
                NongDan nongDan = NhaNongDAO.Instance.getIdByUserName(nguoiDung.getTenDangNhap());




                if (giongLua == null)
                {
                    MessageBox.Show("Không tìm thấy giống lúa");
                    return;
                }

                if (nongDan == null)
                {
                    MessageBox.Show("Không tìm thấy nông dân ");
                    return;
                }

                DateTime ngayGieo = dateTimePicker1.Value;


                if (string.IsNullOrEmpty(tenRuong) || string.IsNullOrEmpty(viTri) || string.IsNullOrEmpty(giongLua.TenGiong))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                }
                else
                {
                    RuongLua ruongLua = new RuongLua(tenRuong, viTri, dientich, ngayGieo, giongLua, nongDan);

                    int ruongLuaID = DongRuongDAO.Instance.InsertData(nongDan.getNongDanID(), ruongLua.ten, ruongLua.getViTri(), ruongLua.getDienTich(), ruongLua.getGiongLua().GiongLuaID, ruongLua.getNgayGieo());
                    if (ruongLuaID > 0)
                    {
                        ruongLua.ruongLuaID = (ruongLuaID); // Thiết lập ruongLuaID cho đối tượng
                        MessageBox.Show("Thêm thành công với RuongLuaID: " + ruongLua.ruongLuaID);
                        loadDanhSach(nguoiDung);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công");
                    }
                }



            }
            else
            {
                string tenNhaNong = txb_tenNhaNong.Text;
                string tenRuong = textBox1.Text;
                string name = dataGridView1.CurrentRow.Cells["TenRuong"].Value.ToString();
                string viTri = textBox2.Text;
                double dientich;


                if (!double.TryParse(textBox3.Text, out dientich))
                {
                    MessageBox.Show("Vui lòng nhập diện tích hợp lệ.");
                    return;
                }

                string giongLuaName = comboBox1.Text;

                GiongLua giongLua = GiongLuaDAO.Instance.getIdByName(giongLuaName);
                NongDan nongDan = NhaNongDAO.Instance.getIdByUserName(nguoiDung.getTenDangNhap());




                if (giongLua == null)
                {
                    MessageBox.Show("Không tìm thấy giống lúa");
                    return;
                }

                if (nongDan == null)
                {
                    MessageBox.Show("Không tìm thấy nông dân ");
                    return;
                }

                DateTime ngayGieo = dateTimePicker1.Value;


                if (string.IsNullOrEmpty(tenRuong) || string.IsNullOrEmpty(viTri) || string.IsNullOrEmpty(giongLua.TenGiong))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                }
                else
                {
                    int id = DongRuongDAO.Instance.getIDByName(name);

                    RuongLua ruongLua = new RuongLua(id, tenRuong, viTri, dientich, ngayGieo, giongLua, nongDan);

                    int ruongLuaID = DongRuongDAO.Instance.Update(ruongLua);
                    if (ruongLuaID > 0)
                    {

                        MessageBox.Show("Cap nhat thành công!!!!");
                        loadDanhSach(nguoiDung);
                    }
                    else
                    {
                        MessageBox.Show("Cap nhat không thành công");
                    }
                }
            }

        }

        private void txb_tenNhaNong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
                e.SuppressKeyPress = true;
            }

        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox4.Text;
            dataGridView1.DataSource = DongRuongDAO.Instance.find(nguoiDung.getTenDangNhap(), str);
            dataGridView1.Columns[0].HeaderText = "Tên Nông Dân";
            dataGridView1.Columns[1].HeaderText = "Tên Đồng Ruộng";
            dataGridView1.Columns[2].HeaderText = "Vị Trí";
            dataGridView1.Columns[3].HeaderText = "Diện Tích ";
            dataGridView1.Columns[4].HeaderText = "Tên Giống";
            dataGridView1.Columns[5].HeaderText = "Ngày Gieo";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 120;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Width = 120;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
