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
    public partial class quanlikho : Form
    {
        db conn = new db();
        public quanlikho()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void loaddata()
        {
            string cmnd = "select * from v_sanpham " ;
            DataTable dt = conn.readdata(cmnd);
           
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;
            }
            dataGridView1.ClearSelection();
            label3.Text = string.Format("Tổng cộng: {0} sản phầm.", dataGridView1.Rows.Count);
        }

        private void quanlikho_Load(object sender, EventArgs e)
        {
            loaddata();
            if (dangnhap.ID_USER == "0") {
                button10.Enabled = button11.Enabled = button9.Enabled = false;
            
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            sanpham sp = new sanpham("");
            sp.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string a = dataGridView1.Rows[row].Cells[0].Value.ToString();
            sanpham sp = new sanpham(a);
            sp.ShowDialog();
        }

        // nút xóa 
        private void button9_Click(object sender, EventArgs e)
        {
            del();
        }
        // hàm xóa 
        private void del()
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string a = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string cmd = "delete sanpham where maso = " + a;
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xóa không ? ", " Thông Báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                if (conn.exedata(cmd) == true)
                {
                    MessageBox.Show("Đã xóa dữ liệu");
                }
                else
                {
                    MessageBox.Show("Không thể xóa dữ liệu");
                }
                loaddata();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timkiem();
        }

        public void timkiem()
        {
            string cmnd = "select * from v_sanpham  where [Tên sản phẩm] like N'%" + textBox1.Text + "%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;
             
            }
            dataGridView1.ClearSelection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_sanpham  where [Danh mục] like N'%Đông lạnh%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;

            }
            dataGridView1.ClearSelection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_sanpham  where [Danh mục] like N'%Khô hộp%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;

            }
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_sanpham  where [Danh mục] like N'%Ăn liền%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;

            }
            dataGridView1.ClearSelection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_sanpham  where [Danh mục] like N'%Gia vị sốt%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;

            }
            dataGridView1.ClearSelection();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_sanpham  where [Danh mục] like N'%Khác%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;

            }
            dataGridView1.ClearSelection();
        }






    }
}
