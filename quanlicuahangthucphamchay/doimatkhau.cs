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
    public partial class doimatkhau : Form
    {
        db conn = new db();
        public doimatkhau()
        {
            InitializeComponent();
        }

        private void ckpass_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckpass.Checked)
                textBox1.PasswordChar = textBox2.PasswordChar  = '*';
            if (ckpass.Checked)
                textBox1.PasswordChar = textBox2.PasswordChar  = '\0';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp!");
            }
            else
            {
                doimk(uid, textBox2.Text);
            }  
        }
        public string uid = "";
        private void doimatkhau_Load(object sender, EventArgs e)
        {
            label8.Text = dangnhap.Name_USER;
            uid = dangnhap.ID_USER;
        }

        private void doimk(string id, string pass) {
            String cmd = ("update nhanvien set matkhau= '" + pass + "' WHERE maso ='" + id + "'");
            if (conn.exedata(cmd))
            {
                MessageBox.Show("Đổi mật khẩu thành công !");
                this.Close();
            }
            else MessageBox.Show("Đổi mật khẩu không thành công !");
        
        
        }


    }
}
