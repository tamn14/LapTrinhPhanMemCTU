using QuanLyDichBenh.DAO;
using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDichBenh
{
    public partial class BaoCaoDichBenh : Form
    {
        string even = "";
        string tab = "";
        private NguoiDung nguoiDung;
        public BaoCaoDichBenh(NguoiDung nguoiDung)
        {
            
            this.nguoiDung = nguoiDung;
            InitializeComponent();
            loadDanhSachRuongBenh(nguoiDung);
            loadDanhSachRuongChuaBenh(nguoiDung);
            loadDichBenh();
            loadGiongLua();
            loadRuongByUserName(nguoiDung);
            dtp_ngayBaoCao.ValueChanged += dtp_ngayBaoCao_ValueChanged;

            
            addDichBenh();
            txb_tenNhaNong.Enabled = false;
            cbb_tenGiongLua.Enabled = false;
            comboBox1.Enabled = false;

        }



        public void loadDanhSachRuongBenh(NguoiDung nguoiDung)
        {
            dataGridView1.DataSource = DichBenhDAO.Instance.loadDichBenhTheoNguoiDung(nguoiDung);


            if (dataGridView1.DataSource != null)
            {
                dataGridView1.Columns[0].HeaderText = "Tên Nông Dân";
                dataGridView1.Columns[1].HeaderText = "Tên Đồng Ruộng";
                dataGridView1.Columns[2].HeaderText = "Tên Dịch Bệnh";
                dataGridView1.Columns[3].HeaderText = "Tên Giống";
                dataGridView1.Columns[4].HeaderText = "Mức Độ";
                dataGridView1.Columns[5].HeaderText = "Ngày Báo Cáo";

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridView1.Columns[i].Width = 120;
                }

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



        public void loadDanhSachRuongChuaBenh(NguoiDung nguoiDung)
        {
            dataGridView2.DataSource = DichBenhDAO.Instance.loadRuongChuaDichBenhTheoNguoiDung(nguoiDung);


            if (dataGridView2.DataSource != null)
            {
                dataGridView2.Columns[0].HeaderText = "Tên Nông Dân";
                dataGridView2.Columns[1].HeaderText = "Tên Đồng Ruộng";
                dataGridView2.Columns[2].HeaderText = "Tên Dịch Bệnh";
                dataGridView2.Columns[3].HeaderText = "Tên Giống";
                dataGridView2.Columns[4].HeaderText = "Mức Độ";
                dataGridView2.Columns[5].HeaderText = "Ngày Báo Cáo";

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    dataGridView2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridView2.Columns[i].Width = 120;
                }

                dataGridView2.Font = new Font("Arial", 9);
                dataGridView2.ScrollBars = ScrollBars.Both;

                DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
                rowStyle.BackColor = Color.LightBlue;
                dataGridView2.AlternatingRowsDefaultCellStyle = rowStyle;

                dataGridView2.RowTemplate.Height = 25;
            }
            else
            {
                Console.WriteLine("Không có dữ liệu để hiển thị trong DataGridView.");
            }
        }

        public void addDichBenh ()
        {
            txb_tenNhaNong.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "TenNhaNong"));
            


        }


        public void loadGiongLua()
        {
            List<GiongLua> list = GiongLuaDAO.Instance.getGiongLua();
            cbb_tenGiongLua.DataSource = list;
            cbb_tenGiongLua.DisplayMember = "tenGiong";
            cbb_tenGiongLua.ValueMember = "giongLuaID";

        }

        public void loadDichBenh()
        {
            List<DichBenh> list = DichBenhDAO.Instance.GetDichBenhs();
            cbb_tenDichBenh.DataSource = list;
            cbb_tenDichBenh.DisplayMember = "ten";
            cbb_tenDichBenh.ValueMember = "dichBenhID";
        }

        public void loadRuongByUserName(NguoiDung nguoiDung)
        {
            List<RuongLua> list = DongRuongDAO.Instance.getDongRuongByUserName(nguoiDung);
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "ten";
            comboBox1.ValueMember = "RuongLuaID";

        }

        private void clear()
        {
            comboBox1.SelectedIndex = 0;
            cbb_tenDichBenh.SelectedIndex = 0; 
            cbb_tenGiongLua.SelectedIndex = 0 ; 
            cbb_mucDo.SelectedIndex = 0;
            dtp_ngayBaoCao.Value = System.DateTime.Now;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            even = "sua";
            comboBox1.Enabled = false;
            

        }

        private void dtp_ngayBaoCao_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_ngayBaoCao.CustomFormat == "'Chua co ngay'")
            {
                dtp_ngayBaoCao.CustomFormat = "dd/MM/yyyy";
                dtp_ngayBaoCao.Format = DateTimePickerFormat.Custom;
                
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string tenGiong = dataGridView1.CurrentRow.Cells["TenGiong"].Value?.ToString() ?? string.Empty;
                string tenDichBenh = dataGridView1.CurrentRow.Cells["TenDichBenh"].Value?.ToString() ?? string.Empty;
                string mucdo = dataGridView1.CurrentRow.Cells["MucDo"].Value?.ToString() ?? string.Empty;
                string tenruong = dataGridView1.CurrentRow.Cells["TenRuong"].Value?.ToString() ?? string.Empty;
                string ngaybaocao = dataGridView1.CurrentRow.Cells["NgayBaoCao"].Value?.ToString() ?? string.Empty;

                GiongLua gionglua = GiongLuaDAO.Instance.getIdByName(tenGiong);
                DichBenh dichBenh = DichBenhDAO.Instance.getIdByName(tenDichBenh);
                RuongLua ruongLua = DongRuongDAO.Instance.getRuongLuaByName(tenruong);

                comboBox1.SelectedValue = ruongLua.ruongLuaID;
                cbb_tenGiongLua.SelectedValue = gionglua.GiongLuaID;
                cbb_tenDichBenh.SelectedValue = dichBenh.dichBenhID;
                if (DateTime.TryParse(ngaybaocao, out DateTime parsedDate))
                {
                    dtp_ngayBaoCao.Value = parsedDate;
                }
                cbb_mucDo.Text = mucdo;
               

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
            even = "them";
            comboBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tenNguoiDung = txb_tenNhaNong.Text;
            string tenRuong = comboBox1.Text;
            string dicbenhname = dataGridView1.CurrentRow.Cells["TenDichBenh"].Value.ToString();
            string giongluaname = dataGridView1.CurrentRow.Cells["TenGiong"].Value.ToString();

            DateTime ngayBaoCao = dtp_ngayBaoCao.Value;

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng trong bảng!");
                return;
            }
            string name = dataGridView1.CurrentRow.Cells["TenRuong"].Value.ToString();
            string rank = dataGridView1.CurrentRow.Cells["MucDo"].Value.ToString();
            string tenDichBenh = cbb_tenDichBenh.Text;
            string tenGiong = cbb_tenGiongLua.Text;
            string mucdo = cbb_mucDo.Text;


          



            RuongLua ruongLua = DongRuongDAO.Instance.getRuongLuaByName(name);
            RuongLua ruongLua1 = DongRuongDAO.Instance.getRuongLuaByName(tenRuong);


            DichBenh dichBenh = DichBenhDAO.Instance.getIdByName(dicbenhname);
            DichBenh dichBenh1 = DichBenhDAO.Instance.getIdByName(tenDichBenh);







            if (dicbenhname != null || !String.IsNullOrEmpty(dicbenhname))
            {

                DateTime ngay = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["NgayBaoCao"].Value);
                BCDB baoCaoDichBenh = new BCDB(ngay, Convert.ToInt32(rank), dichBenh, ruongLua);
                int baoCaoDichBenhId = BaoCaoDichBenhDAO.Instance.getID(baoCaoDichBenh);

               
                int check = BaoCaoDichBenhDAO.Instance.remove(baoCaoDichBenhId);
                if (check == 0)
                {
                    MessageBox.Show("Xóa không thành công.");
                }
                else
                {
                    MessageBox.Show("Xóa thành công.");
                    loadDanhSachRuongBenh(nguoiDung);
                    loadDanhSachRuongChuaBenh(nguoiDung);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == tabPage2)
            {
                button2.Visible = false;
                button3.Visible = false;
                button1.Visible = false;
                button5.Visible = false;
                comboBox1.Enabled = false;
                tab = "tab2";


            }

            else
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button5.Visible = true;
                comboBox1.Enabled = true;

            }
        }


        

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                string tenGiong = dataGridView2.CurrentRow.Cells["TenGiong"].Value?.ToString() ?? string.Empty;
                string tenDichBenh = dataGridView2.CurrentRow.Cells["TenDichBenh"].Value?.ToString() ?? string.Empty;
                string mucdo = dataGridView2.CurrentRow.Cells["MucDo"].Value?.ToString() ?? string.Empty;
                string tenruong = dataGridView2.CurrentRow.Cells["TenRuong"].Value?.ToString() ?? string.Empty;
                string ngaybaocao = dataGridView2.CurrentRow.Cells["NgayBaoCao"].Value?.ToString() ?? string.Empty;

                GiongLua gionglua = GiongLuaDAO.Instance.getIdByName(tenGiong);
                DichBenh dichBenh = DichBenhDAO.Instance.getIdByName(tenDichBenh);
                RuongLua ruongLua = DongRuongDAO.Instance.getRuongLuaByName(tenruong);

                comboBox1.SelectedValue = ruongLua.ruongLuaID;
                cbb_tenGiongLua.SelectedValue = gionglua.GiongLuaID;
                
                if (DateTime.TryParse(ngaybaocao, out DateTime parsedDate))
                {
                    dtp_ngayBaoCao.Value = parsedDate;
                }

                cbb_tenDichBenh.Text = "Chua co benh";
                cbb_mucDo.Text = "Chua co muc do";
                if (String.IsNullOrEmpty(ngaybaocao)) {
                    dtp_ngayBaoCao.CustomFormat = "'Chua co ngay'";
                    dtp_ngayBaoCao.Format = DateTimePickerFormat.Custom;


                }


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (even.Equals("them")) {
                string tenNguoiDung = txb_tenNhaNong.Text;
                string tenRuong = comboBox1.Text;
                string dicbenhname = dataGridView1.CurrentRow.Cells["TenDichBenh"].Value.ToString();
                string giongluaname = dataGridView1.CurrentRow.Cells["TenGiong"].Value.ToString();

                DateTime ngayBaoCao = dtp_ngayBaoCao.Value;

                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một dòng trong bảng!");
                    return;
                }
                string name = dataGridView1.CurrentRow.Cells["TenRuong"].Value.ToString();
                string rank = dataGridView1.CurrentRow.Cells["MucDo"].Value.ToString();
                string tenDichBenh = cbb_tenDichBenh.Text;
                string tenGiong = cbb_tenGiongLua.Text;
                string mucdo = cbb_mucDo.Text;




                RuongLua ruongLua = DongRuongDAO.Instance.getRuongLuaByName(name);
                RuongLua ruongLua1 = DongRuongDAO.Instance.getRuongLuaByName(tenRuong);


                DichBenh dichBenh = DichBenhDAO.Instance.getIdByName(dicbenhname);
                DichBenh dichBenh1 = DichBenhDAO.Instance.getIdByName(tenDichBenh);







                if (dicbenhname != null || !String.IsNullOrEmpty(dicbenhname))
                {

                    DateTime ngay = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["NgayBaoCao"].Value);
                    BCDB baoCaoDichBenh = new BCDB(ngay, Convert.ToInt32(rank), dichBenh, ruongLua);
                    int baoCaoDichBenhId = BaoCaoDichBenhDAO.Instance.getID(baoCaoDichBenh);

                    BCDB baoCao = new BCDB(ngayBaoCao, Convert.ToInt32(mucdo), dichBenh1, ruongLua1);
                    int check = BaoCaoDichBenhDAO.Instance.insert(baoCao);
                    if (check == 0)
                    {
                        MessageBox.Show("Thêm không thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thành công.");
                        comboBox1.Enabled = false;
                        loadDanhSachRuongBenh(nguoiDung);
                        loadDanhSachRuongChuaBenh(nguoiDung);
                    }
                }
            }

            else  {

                string tenNguoiDung = txb_tenNhaNong.Text;
                string tenRuong = comboBox1.Text;
                string dicbenhname = dataGridView1.CurrentRow.Cells["TenDichBenh"].Value.ToString();
                string giongluaname = dataGridView1.CurrentRow.Cells["TenGiong"].Value.ToString();

                DateTime ngayBaoCao = dtp_ngayBaoCao.Value;

                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một dòng trong bảng!");
                    return;
                }
                string name = dataGridView1.CurrentRow.Cells["TenRuong"].Value.ToString();
                string rank = dataGridView1.CurrentRow.Cells["MucDo"].Value.ToString();
                string tenDichBenh = cbb_tenDichBenh.Text;
                string tenGiong = cbb_tenGiongLua.Text;
                string mucdo = cbb_mucDo.Text;


                if (name != tenRuong || tenGiong != giongluaname)
                {
                    MessageBox.Show("Vui long chi cap nhat ten dich benh , muc do va ngay bao cao");
                    return;
                }

                RuongLua ruongLua = DongRuongDAO.Instance.getRuongLuaByName(name);
                RuongLua ruongLua1 = DongRuongDAO.Instance.getRuongLuaByName(tenRuong);

                DichBenh dichBenh = DichBenhDAO.Instance.getIdByName(dicbenhname);
                DichBenh dichBenh1 = DichBenhDAO.Instance.getIdByName(tenDichBenh);

                if (dicbenhname != null || !String.IsNullOrEmpty(dicbenhname))
                {

                    DateTime ngay = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["NgayBaoCao"].Value);
                    BCDB baoCaoDichBenh = new BCDB(ngay, Convert.ToInt32(rank), dichBenh, ruongLua);
                    int baoCaoDichBenhId = BaoCaoDichBenhDAO.Instance.getID(baoCaoDichBenh);

                    BCDB baoCao = new BCDB(baoCaoDichBenhId, ngayBaoCao, Convert.ToInt32(mucdo), dichBenh1, ruongLua);
                    int check = BaoCaoDichBenhDAO.Instance.update(baoCao);
                    if (check == 0)
                    {
                        MessageBox.Show("Cập nhật không thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thành công.");
                        loadDanhSachRuongBenh(nguoiDung);
                        loadDanhSachRuongChuaBenh(nguoiDung);
                        comboBox1.Enabled = true; 
                    }
                }

            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbb_tenDichBenh.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cbb_tenDichBenh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbb_tenGiongLua.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cbb_tenGiongLua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbb_mucDo.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void cbb_mucDo_KeyDown(object sender, KeyEventArgs e)
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
                button2_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tab.Equals("tab2"))
            {
                string str = textBox1.Text;
                dataGridView2.DataSource = DichBenhDAO.Instance.find2(nguoiDung.getTenDangNhap(), str);


                if (dataGridView2.DataSource != null)
                {
                    dataGridView2.Columns[0].HeaderText = "Tên Nông Dân";
                    dataGridView2.Columns[1].HeaderText = "Tên Đồng Ruộng";
                    dataGridView2.Columns[2].HeaderText = "Tên Dịch Bệnh";
                    dataGridView2.Columns[3].HeaderText = "Tên Giống";
                    dataGridView2.Columns[4].HeaderText = "Mức Độ";
                    dataGridView2.Columns[5].HeaderText = "Ngày Báo Cáo";

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    for (int i = 0; i < dataGridView2.Columns.Count; i++)
                    {
                        dataGridView2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridView2.Columns[i].Width = 120;
                    }

                    dataGridView2.Font = new Font("Arial", 9);
                    dataGridView2.ScrollBars = ScrollBars.Both;

                    DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
                    rowStyle.BackColor = Color.LightBlue;
                    dataGridView2.AlternatingRowsDefaultCellStyle = rowStyle;

                    dataGridView2.RowTemplate.Height = 25;
                }
                else
                {
                    Console.WriteLine("Không có dữ liệu để hiển thị trong DataGridView.");
                }
            }
            else
            {
                string str = textBox1.Text;
                dataGridView1.DataSource = DichBenhDAO.Instance.find(nguoiDung.getTenDangNhap() , str);


                if (dataGridView1.DataSource != null)
                {
                    dataGridView1.Columns[0].HeaderText = "Tên Nông Dân";
                    dataGridView1.Columns[1].HeaderText = "Tên Đồng Ruộng";
                    dataGridView1.Columns[2].HeaderText = "Tên Dịch Bệnh";
                    dataGridView1.Columns[3].HeaderText = "Tên Giống";
                    dataGridView1.Columns[4].HeaderText = "Mức Độ";
                    dataGridView1.Columns[5].HeaderText = "Ngày Báo Cáo";

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridView1.Columns[i].Width = 120;
                    }

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


}
