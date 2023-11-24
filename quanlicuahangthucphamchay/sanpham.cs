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
    public partial class sanpham : Form
    {
        db conn = new db();
        public string id;

        public sanpham(string id)
        {
            InitializeComponent();
            this.id = id;
        }


        private void sanpham_Load(object sender, EventArgs e)
        {
            loaddanhmuc();
            if (id != "") { dodulieu(id); }
        }

        private void dodulieu(string id) {

            string cmnd = "select * from sanpham where maso = " +id;
            DataTable dt = conn.readdata(cmnd);
            if (dt != null)
            {
                t1.Text = dt.Rows[0]["maso"].ToString();
                t2.Text = dt.Rows[0]["ten"].ToString();
                cb1.SelectedValue = dt.Rows[0]["danhmuc"];
                t3.Text = dt.Rows[0]["donvitinh"].ToString();
                t4.Text = dt.Rows[0]["gia"].ToString();
                dt1.Value = DateTime.Parse(dt.Rows[0]["ngaynhap"].ToString());
                t6.Text = dt.Rows[0]["soluongton"].ToString();
            }
        }

        private void loaddanhmuc()
        {
            string cmnd = "select * from danhmucsanpham";
            DataTable dt = conn.readdata(cmnd);
            if (dt != null)
            {
                cb1.DataSource = dt;
                cb1.DisplayMember = "ten";
                cb1.ValueMember = "maso";
            }
            cb1.SelectedValue = -1;

        }
        // thêm sản phẩm 
        private void add()
        {
            DateTime t1 = dt1.Value;
            string cmd = "SP_them_sanpham N'" + t2.Text + "','" + cb1.SelectedValue + "',N'" + t3.Text + "','" + t4.Text + "','" + t1.ToString("yyyy'/'MM'/'dd") + "','" + t6.Text + "'";

            if (conn.exedata(cmd) == true)
            {
                MessageBox.Show("Đã thêm sản phẩm ");
            }
            else
            {
                MessageBox.Show("Không thể thêm sản phẩm");
            }
            this.Close();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                add();
            }
            else {
                sua();
            }
        }
        // sửa sản phẩm 
        private void sua()
        {
            DateTime dt = dt1.Value;
            string cmd = "SP_sua_sanpham '" + t1.Text + "',N'" + t2.Text + "','" + cb1.SelectedValue.ToString() + "',N'" + t3.Text + "','" + t4.Text + "','" + dt.ToString("yyyy'/'MM'/'dd") + "','" + t6.Text + "'";

            if (conn.exedata(cmd) == true)
            {
                MessageBox.Show("Đã sửa thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể sửa dữ liệu");
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
