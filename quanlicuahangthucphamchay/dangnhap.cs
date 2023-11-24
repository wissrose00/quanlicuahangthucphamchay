using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace quanlicuahangthucphamchay
{
    public partial class dangnhap : Form
    {
        db connect = new db();
        public dangnhap()
        {
            InitializeComponent();
        }

        void tc_logout(object sender, EventArgs e)
        {
            (sender as trangchu).isExit = false;
            (sender as trangchu).Close();
            this.Show();
        }
        // nút thoát 
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // hiện mật khẩu 
        private void ckpass_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckpass.Checked)
                txtpassword.PasswordChar = '*';
            if (ckpass.Checked)
                txtpassword.PasswordChar = '\0';
        }

        // nút đăng nhập
        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtusername.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!");
                return;
            }
            if (String.IsNullOrEmpty(txtpassword.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }
            login();
        }

        public static string ID_USER = "";
        public static string Name_USER = "";

        // hàm đăng nhập
        private void login()
        {
            ID_USER = getID(txtusername.Text, txtpassword.Text);
            Name_USER = getName(txtusername.Text, txtpassword.Text);
            string a = Name_USER;
            if (a != "")
            {
                trangchu tc = new trangchu();
                tc.Show();
                this.Hide();
                tc.logout +=new EventHandler(tc_logout);
                }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin tài khoản !");
                System.Media.SystemSounds.Exclamation.Play();

            }
        }
        // lấy id 
        private string getID(string username, string password)
        {
            string id = "";
            String cmd = ("SELECT * FROM nhanvien WHERE taikhoan ='" + username + "' and matkhau='" + password + "'");
            DataTable dt = connect.readdata(cmd);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["maso"].ToString();
                }
            }
            return id;
        }

        private string getName(string username, string password)
        {
            string id = "";
            String cmd = ("SELECT * FROM nhanvien WHERE taikhoan ='" + username + "' and matkhau='" + password + "'");
            DataTable dt = connect.readdata(cmd);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["hoten"].ToString();
                }
            }
            return id;
        }



    }
}
