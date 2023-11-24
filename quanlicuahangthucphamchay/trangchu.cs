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
    public partial class trangchu : Form
    {
        db conn = new db();
        public bool isExit = true;
        public event EventHandler logout;
        public trangchu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logout(this, new EventArgs());
        }

        private void trangchu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình ?", "Thông báo ", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    e.Cancel = true;
                }

            }
        }

        private void trangchu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
                Application.Exit();
        }


        // đổi mật khẩu
        private void button2_Click(object sender, EventArgs e)
        {
            doimatkhau dmk = new doimatkhau();
            dmk.ShowDialog();
        }

        private void trangchu_Load(object sender, EventArgs e)
        {
            label1.Text = " Log-in with : " + dangnhap.Name_USER;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            quanlikho qlik = new quanlikho();
            qlik.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            banhang bh = new banhang();
            bh.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            thongke tk = new thongke();
            tk.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (r1.Checked) {
                string cmnd = "select * from v_trangchu where [Ngày bán] = GETDATE() ";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = 100;
                    dataGridView1.Columns[1].Width = 220;
                    dataGridView1.Columns[2].Width = 100;
                    dataGridView1.Columns[3].Width = 100;
                    dataGridView1.ClearSelection();
                }
                else MessageBox.Show("err");
            }
            if (r2.Checked) {
                string cmnd = "select * from v_trangchu where [Ngày bán] >= DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), 0) AND [Ngày bán] < DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()) + 1, 0) ";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = 100;
                    dataGridView1.Columns[1].Width = 220;
                    dataGridView1.Columns[2].Width = 100;
                    dataGridView1.Columns[3].Width = 100;
                    dataGridView1.ClearSelection();


                }
                else MessageBox.Show("err");
            }
            if (r3.Checked) {
                string cmnd = "select * from v_trangchu where YEAR([Ngày bán]) = YEAR(GETDATE()) AND MONTH([Ngày bán]) = MONTH(GETDATE())  ";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = 100;
                    dataGridView1.Columns[1].Width = 220;
                    dataGridView1.Columns[2].Width = 100;
                    dataGridView1.Columns[3].Width = 100;   

                    dataGridView1.ClearSelection();

                }
                else MessageBox.Show("err");
            }
        }

        



    }
}
