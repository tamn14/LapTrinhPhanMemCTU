using QuanLyDichBenh;
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

namespace QuanLyDB.view
{
   
    public partial class ThongTinTaiKhoan : Form
    {
        private NguoiDung nguoiDung;
        public ThongTinTaiKhoan(NguoiDung nguoiDung)
        {   
            this.nguoiDung  = nguoiDung ;
            InitializeComponent();
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void loadData()
        {
            txb_username.Text = this.nguoiDung.getTenDangNhap();
            textBox1.Text = this.nguoiDung.getTenHienThi();
            

        }

        public NguoiDung Update()
        {
            string OldMatKhau = textBox2.Text.Trim();
            string tenHienThi = textBox1.Text.Trim();
            string matKhauMoi = textBox3.Text.Trim();
            string nhapLaiMatKhau = textBox4.Text.Trim();
            NguoiDung newNguoiDung = null;

            try
            {
                if (!string.IsNullOrEmpty(matKhauMoi) || !string.IsNullOrEmpty(nhapLaiMatKhau))
                {
                    if (matKhauMoi != nhapLaiMatKhau)
                    {
                        MessageBox.Show("Mật khẩu mới và mật khẩu nhập lại không khớp.");
                        return null;
                    }

                    
                    if (OldMatKhau != this.nguoiDung.getMatKhau())
                    {
                        MessageBox.Show("Vui lòng nhập đúng mật cũ để thay đổi thông tin.");
                        return null;
                    }

                    newNguoiDung = new NguoiDung(this.nguoiDung.getTenDangNhap(), matKhauMoi, this.nguoiDung.getVaitro(), tenHienThi);
                }
                else
                {
                    newNguoiDung = new NguoiDung(this.nguoiDung.getTenDangNhap(), this.nguoiDung.getMatKhau(), this.nguoiDung.getVaitro(), tenHienThi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình cập nhật: " + ex.Message);
                return null;
            }

            return newNguoiDung;
        }


        private void button_capnhat_Click(object sender, EventArgs e)
        {
            NguoiDung nguoiDung = Update();

            // Kiểm tra nếu nguoiDung là null trước khi gọi update
            if (nguoiDung == null)
            {
                MessageBox.Show("Thông tin cập nhật không hợp lệ. Vui lòng kiểm tra lại.");
                return;
            }

            int result = AccountDAO.Instance.updateNguoidung(nguoiDung);
            if (result == 0)
            {
                MessageBox.Show("Cập nhật không thành công.");
            }
            else
            {
                MessageBox.Show("Cập nhật thành công.");
                
            }



        }
        }
 }

