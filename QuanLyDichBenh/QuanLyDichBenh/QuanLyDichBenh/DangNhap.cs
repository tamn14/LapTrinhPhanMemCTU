using QuanLyDichBenh;
using QuanLyDichBenh.DAO;
using QuanLyDichBenh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDB.view
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            
        }

        private void txb_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {   
            string username  = txb_username.Text;    
            string  password = txb_password.Text;
            if(login(username , password))
            {
                NguoiDung nguoiDungLogin = AccountDAO.Instance.layNguoiDungTheoTenDangNhap(username);   

                PhanMemQuanLy app = new PhanMemQuanLy(nguoiDungLogin);
                this.Hide();
                app.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công, vui lòng kiểm tra lại tên đăng nhập hoặc mật khẩu!!");
            }
        
           
            
        }

        bool login(string username, string password)
        {
            return AccountDAO.Instance.login(username, password);

        }

        

       

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát khỏi chương trình không ?","Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }

        }

        private void txb_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txb_password.Focus();
                e.SuppressKeyPress = true;
            }

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txb_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_login_Click(sender, e); 
                e.SuppressKeyPress = true; 
            }
        }
    }
}
