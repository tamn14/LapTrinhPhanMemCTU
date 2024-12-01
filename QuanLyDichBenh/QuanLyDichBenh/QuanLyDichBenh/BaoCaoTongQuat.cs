using QuanLyDichBenh.DAO;
using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;





namespace QuanLyDichBenh

{
    public partial class BaoCaoTongQuat : Form
    {
        string even = "";
        public BaoCaoTongQuat()
        {
            InitializeComponent();
           
            loadData();
        }

        public void loadRuongLua()
        {
            dataGridView1.DataSource = DongRuongDAO.Instance.loadDongRuong();
            dataGridView1.Columns[0].HeaderText = "Tên ruộng lúa";
            dataGridView1.Columns[1].HeaderText = "Tên nông dân";
            dataGridView1.Columns[2].HeaderText = "Diện tích";
            dataGridView1.Columns[3].HeaderText = "Vị trí";
            dataGridView1.Columns[4].HeaderText = "Tên giống";
            dataGridView1.Columns[5].HeaderText = "Ngày gieo";


            dataGridView1.Columns[3].Width = 300;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
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

        public void loadChuyenGia()
        {
            dataGridView1.DataSource = ChuyenGiaDAO.Instance.loadChuyenGia();

            dataGridView1.Columns[0].HeaderText = "Tên";
            dataGridView1.Columns[1].HeaderText = "Chuyên môn";
            dataGridView1.Columns[2].HeaderText = "Số điện thoại";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 300;


            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }



        public void loadNongDan()
        {
            dataGridView1.DataSource = NhaNongDAO.Instance.loadNhaNong();
            dataGridView1.Columns[0].HeaderText = "Tên";
            dataGridView1.Columns[2].HeaderText = "Địa Chỉ";
            dataGridView1.Columns[1].HeaderText = "Số điện thoại";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 250;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
        }

        public void loadNguoiDung()
        {
            dataGridView1.DataSource = NguoiDungDAO.Instance.loadNguoiDung();
            dataGridView1.Columns[0].HeaderText = "Tên Đăng Nhập ";
            dataGridView1.Columns[1].HeaderText = "Mật Khẩu";
            dataGridView1.Columns[2].HeaderText = "Vai Trò";
            dataGridView1.Columns[3].HeaderText = "Tên Hiển Thị";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[0].Width = 230;
            dataGridView1.Columns[1].Width = 230;
            dataGridView1.Columns[2].Width = 230;
            dataGridView1.Columns[3].Width = 230;

            dataGridView1.Font = new Font("Arial", 9);
            dataGridView1.ScrollBars = ScrollBars.Both;

            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.LightBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle = rowStyle;

            dataGridView1.RowTemplate.Height = 25;
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



        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            even = "nhanong";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Địa Chỉ");
            NhaNong.BackColor = Color.Green;
            
          
        }

        private void ChuyenGia_Click(object sender, EventArgs e)
        {
            ResetButtonColors(); 
            even = "chuyengia";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Chuyên Môn");
            ChuyenGia.BackColor = Color.Green; 
        }

        private void NguoiDung_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            comboBox1.Items.Clear();
            even = "nguoidung";
            
            comboBox1.Items.Add("Vai Trò");
            NguoiDung.BackColor = Color.Green;
        }

        private void RuongLua_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            even = "ruonglua";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Vị Trí");
            comboBox1.Items.Add("Nông Dân");
            comboBox1.Items.Add("Giống Lúa"); 
            RuongLua.BackColor = Color.Green;
        }

        private void DichBenh_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            even = "dichbenh";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Ruộng Lúa");
            DichBenh.BackColor = Color.Green;
        }

        private void GiongLua_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            even = "muavu";
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Giống Lúa");
            GiongLua.BackColor = Color.Green;
        }

        
        private void ResetButtonColors()
        {
            NhaNong.BackColor = SystemColors.Control; 
            ChuyenGia.BackColor = SystemColors.Control;
            NguoiDung.BackColor = SystemColors.Control;
            RuongLua.BackColor = SystemColors.Control;
            DichBenh.BackColor = SystemColors.Control;
            GiongLua.BackColor = SystemColors.Control;
        }


        public void ControlEven()
        {

            if (even.Equals("nhanong"))
            {
                string value = comboBox1.Text;
                loadNongDan();
                if (value.Equals("Địa Chỉ"))
                {
                    int Count = NhaNongDAO.Instance.getCount();
                    List<string> max = NhaNongDAO.Instance.getMax();
                    List<string> min = NhaNongDAO.Instance.getMin();

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

                    Dictionary<string, int> data = NhaNongDAO.Instance.getNongDanByDiaChi(); 
                    chart1.Series[0].Points.Clear();

                    
                    foreach (var item in data)
                    {
                        chart1.Series[0].Points.AddXY(item.Key, item.Value);

                    }

                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chart1.ChartAreas[0].AxisX.Title = "Địa Chỉ";
                    chart1.ChartAreas[0].AxisY.Title = "Số Lượng Nông Dân";
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -40;
                    chart1.Series[0].IsValueShownAsLabel = true;
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false; 
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                    chart2.Series.Clear();
                    Series series = new Series
                    {
                        Color = System.Drawing.Color.FromArgb(255, 128, 0), 
                        IsValueShownAsLabel = true,
                        ChartType = SeriesChartType.Doughnut 
                    };

                  
                    foreach (var item in data)
                    {
                        series.Points.AddXY(item.Key, item.Value);
                    }

                    chart2.Series.Add(series);
                }

            }

            else if (even.Equals("chuyengia"))
            {

                string value = comboBox1.Text;
                loadChuyenGia();
                if (value.Equals("Chuyên Môn"))
                {
                    int Count = ChuyenGiaDAO.Instance.getCount();
                    List<string> max = ChuyenGiaDAO.Instance.getMax();
                    List<string> min = ChuyenGiaDAO.Instance.getMin();

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

                    Dictionary<string, int> data = ChuyenGiaDAO.Instance.getChuyenByChuyenMon();
                    chart1.Series[0].Points.Clear();


                    foreach (var item in data)
                    {
                        chart1.Series[0].Points.AddXY(item.Key, item.Value);

                    }

                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chart1.ChartAreas[0].AxisX.Title = "Chuyên Môn";
                    chart1.ChartAreas[0].AxisY.Title = "Số Lượng Chuyên Gia";
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -40;
                    chart1.Series[0].IsValueShownAsLabel = true;
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                    chart2.Series.Clear();
                    Series series = new Series
                    {
                        
                        Color = System.Drawing.Color.FromArgb(255, 128, 0),
                        IsValueShownAsLabel = true,
                        ChartType = SeriesChartType.Doughnut
                    };


                    foreach (var item in data)
                    {
                        series.Points.AddXY(item.Key, item.Value);
                    }

                    chart2.Series.Add(series);

                }

                
            }

            else if (even.Equals("nguoidung"))
            {
                string value = comboBox1.Text;
                loadNguoiDung();
                if (value.Equals("Vai Trò"))
                {
                    int Count = NguoiDungDAO.Instance.getCount();
                    List<string> max = NguoiDungDAO.Instance.getMax();
                    List<string> min = NguoiDungDAO.Instance.getMin();

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

                    Dictionary<string, int> data = NguoiDungDAO.Instance.getNguoiDungByVaiTro();
                    chart1.Series[0].Points.Clear();


                    foreach (var item in data)
                    {
                        chart1.Series[0].Points.AddXY(item.Key, item.Value);

                    }

                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chart1.ChartAreas[0].AxisX.Title = "Vai Trò";
                    chart1.ChartAreas[0].AxisY.Title = "Số Lượng Người Dùng";
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -40;
                    chart1.Series[0].IsValueShownAsLabel = true;
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                    chart2.Series.Clear();
                    Series series = new Series
                    {

                        Color = System.Drawing.Color.FromArgb(255, 128, 0),
                        IsValueShownAsLabel = true,
                        ChartType = SeriesChartType.Doughnut
                    };


                    foreach (var item in data)
                    {
                        series.Points.AddXY(item.Key, item.Value);
                    }

                    chart2.Series.Add(series);

                }

            }


            else if (even.Equals("ruonglua"))
            {
                string value = comboBox1.Text;
                loadRuongLua();
                if (value.Equals("Vị Trí"))
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

                    Dictionary<string, int> data1 = DongRuongDAO.Instance.getRuongLuaByVitri();
                    chart1.Series[0].Points.Clear();


                    foreach (var item in data1)
                    {
                        chart1.Series[0].Points.AddXY(item.Key, item.Value);

                    }

                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chart1.ChartAreas[0].AxisX.Title = "Vị Trí";
                    chart1.ChartAreas[0].AxisY.Title = "Số Lượng Ruộng";
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -40;
                    chart1.Series[0].IsValueShownAsLabel = true;
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                    chart2.Series.Clear();
                    Series series = new Series
                    {

                        Color = System.Drawing.Color.FromArgb(255, 128, 0),
                        IsValueShownAsLabel = true,
                        ChartType = SeriesChartType.Doughnut
                    };


                    foreach (var item in data1)
                    {
                        series.Points.AddXY(item.Key, item.Value);
                    }

                    chart2.Series.Add(series);






                }

                if (value.Equals("Nông Dân"))
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


                    Dictionary<string, int> data1 = DongRuongDAO.Instance.getRuongLuaByNongDan();
                    chart1.Series[0].Points.Clear();


                    foreach (var item in data1)
                    {
                        chart1.Series[0].Points.AddXY(item.Key, item.Value);

                    }

                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chart1.ChartAreas[0].AxisX.Title = "Nông Dân ";
                    chart1.ChartAreas[0].AxisY.Title = "Số Lượng Ruộng";
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -40;
                    chart1.Series[0].IsValueShownAsLabel = true;
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                    chart2.Series.Clear();
                    Series series = new Series
                    {

                        Color = System.Drawing.Color.FromArgb(255, 128, 0),
                        IsValueShownAsLabel = true,
                        ChartType = SeriesChartType.Doughnut
                    };


                    foreach (var item in data1)
                    {
                        series.Points.AddXY(item.Key, item.Value);
                    }

                    chart2.Series.Add(series);


                }
              

                if (value.Equals("Giống Lúa"))
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


                    Dictionary<string, int> data1 = DongRuongDAO.Instance.getRuongLuaByGiongLua();
                    chart1.Series[0].Points.Clear();


                    foreach (var item in data1)
                    {
                        chart1.Series[0].Points.AddXY(item.Key, item.Value);

                    }

                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chart1.ChartAreas[0].AxisX.Title = "Giống Lúa ";
                    chart1.ChartAreas[0].AxisY.Title = "Số Lượng Ruộng";
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -40;
                    chart1.Series[0].IsValueShownAsLabel = true;
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                    chart2.Series.Clear();
                    Series series = new Series
                    {

                        Color = System.Drawing.Color.FromArgb(255, 128, 0),
                        IsValueShownAsLabel = true,
                        ChartType = SeriesChartType.Doughnut
                    };


                    foreach (var item in data1)
                    {
                        series.Points.AddXY(item.Key, item.Value);
                    }

                    chart2.Series.Add(series);


                }




            }



            else if (even.Equals("dichbenh"))
            {
                string value = comboBox1.Text;
                loadDichBenh();
                if (value.Equals("Ruộng Lúa"))
                {
                    int Count = DichBenhDAO.Instance.getCount();
                    List<string> max = DichBenhDAO.Instance.getMaxByRuongLua();
                    List<string> min = DichBenhDAO.Instance.getMinByRuongLua();

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

                    Dictionary<string, int> data1 = DichBenhDAO.Instance.getDichBenhByRuongLua();
                    chart1.Series[0].Points.Clear();


                    foreach (var item in data1)
                    {
                        chart1.Series[0].Points.AddXY(item.Key, item.Value);

                    }

                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chart1.ChartAreas[0].AxisX.Title = " Dịch Bệnh ";
                    chart1.ChartAreas[0].AxisY.Title = "Số Lượng Bệnh";
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -40;
                    chart1.Series[0].IsValueShownAsLabel = true;
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                    chart2.Series.Clear();
                    Series series = new Series
                    {

                        Color = System.Drawing.Color.FromArgb(255, 128, 0),
                        IsValueShownAsLabel = true,
                        ChartType = SeriesChartType.Doughnut
                    };


                    foreach (var item in data1)
                    {
                        series.Points.AddXY(item.Key, item.Value);
                    }

                    chart2.Series.Add(series);



                }

            }

            else
            {

                string value = comboBox1.Text;
                loadGiongLua();
                if (value.Equals("Giống Lúa"))
                {
                    int Count = MuaVuDAO.Instance.getCount();
                    List<string> max = MuaVuDAO.Instance.getMaxByGiongLua();
                    List<string> min = MuaVuDAO.Instance.getMinByGiongLua();

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

                    Dictionary<string, int> data1 = MuaVuDAO.Instance.getMuaVuByGiongLua();
                    chart1.Series[0].Points.Clear();


                    foreach (var item in data1)
                    {
                        chart1.Series[0].Points.AddXY(item.Key, item.Value);

                    }

                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chart1.ChartAreas[0].AxisX.Title = " Giống Lúa ";
                    chart1.ChartAreas[0].AxisY.Title = "Số Lượng Mùa Vụ";
                    chart1.ChartAreas[0].AxisX.Interval = 1;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -40;
                    chart1.Series[0].IsValueShownAsLabel = true;
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                    chart2.Series.Clear();
                    Series series = new Series
                    {

                        Color = System.Drawing.Color.FromArgb(255, 128, 0),
                        IsValueShownAsLabel = true,
                        ChartType = SeriesChartType.Doughnut
                    };


                    foreach (var item in data1)
                    {
                        series.Points.AddXY(item.Key, item.Value);
                    }

                    chart2.Series.Add(series);

                }
            }

            
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            ControlEven();  
            
        }

        public void loadData()
        {
            DataTable SoDichBenh = BaoCaoDichBenhDAO.Instance.getCount();  
            int SoRuong = DongRuongDAO.Instance.getCount();

            int db = Convert.ToInt32(SoDichBenh.Rows[0][0]);
            int sr = SoRuong; 
            double tyle = (double)db / sr;
            double roundedTyle = Math.Round(tyle, 2);

            label3.Text = db.ToString();
            label10.Text = sr.ToString();
            label12.Text = roundedTyle.ToString();
            
            
        }
    }


    
}
