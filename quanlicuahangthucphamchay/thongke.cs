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
    public partial class thongke : Form
    {
        db conn = new db();
        public thongke()
        {
            InitializeComponent();
        }

        private void thongke_Load(object sender, EventArgs e)
        {

        }

        void tinhtien()
        {

            int tong = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView2.Rows[i];
                int tt = Convert.ToInt32(row.Cells[5].Value);
                tong += tt;
            }

            // Hiển thị tổng số lượng
            label18.Text = dataGridView2.Rows.Count.ToString();
            label17.Text = tong.ToString();
        }
        void sanpham(string maso)
        {
            string cmnd = "select * from v_sanpham_chitiet where HD =" + maso;
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView3.DataSource = dt;
                dataGridView3.Columns[0].Width = 220;
                dataGridView3.Columns[1].Width = 50;
                dataGridView3.Columns[2].Width = 120;
                dataGridView3.Columns[3].Width = 20;
            }
            else MessageBox.Show("err");
            dataGridView3.ClearSelection();

        }
       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string a = dataGridView1.Rows[row].Cells[0].Value.ToString();
            label12.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            label13.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            label7.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
            label8.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
            label9.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();
            sanpham(a);

        }


        // chọn doanh thu 
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                string cmnd = "select * from v_doanhthu  where  Ngày >= CAST(GETDATE() AS DATE) ";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView2.DataSource = dt;

                }
                else MessageBox.Show("err");
                dataGridView2.ClearSelection();
                tinhtien();

            }
            if (r2.Checked)
            {

                string cmnd = "select * from v_doanhthu where Ngày >= DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), 0) AND Ngày < DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()) + 1, 0) ";
                    DataTable dt = conn.readdata(cmnd);

                    if (dt != null)
                    {
                        dataGridView2.DataSource = dt;

                    }
                    else MessageBox.Show("err");
                    dataGridView2.ClearSelection();
                    tinhtien();

                }
                if (r3.Checked)
                {

                    string cmnd = "select * from v_doanhthu where YEAR(Ngày) = YEAR(GETDATE()) AND MONTH(Ngày) = MONTH(GETDATE())  ";
                    DataTable dt = conn.readdata(cmnd);

                    if (dt != null)
                    {
                        dataGridView2.DataSource = dt;

                    }
                    else MessageBox.Show("err");
                    dataGridView2.ClearSelection();
                    tinhtien();

                }
                if (r4.Checked)
                {

                    string dt1 = dateTimePicker1.Value.ToString("yyyy'/'MM'/'dd");
                    string cmnd = "select * from v_doanhthu where Ngày =  '" + dt1 + "'";
                    DataTable dt = conn.readdata(cmnd);

                    if (dt != null)
                    {
                        dataGridView2.DataSource = dt;

                    }
                    else MessageBox.Show("err");
                    dataGridView2.ClearSelection();
                    tinhtien();
                }


            }

        // chọn hóa đơn 
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (rd1.Checked) {
                string cmnd = "select * from v_hoadon";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;


                }
                dataGridView1.ClearSelection();
            }
            if (rd2.Checked)
            {
                string cmnd = "select * from v_hoadon where Ngày >= CAST(GETDATE() AS DATE)";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;


                }
                dataGridView1.ClearSelection();
            }
            if (rd3.Checked)
            {
                string cmnd = "select * from v_hoadon where [Ngày] >= DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), 0) AND [Ngày] < DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()) + 1, 0) ";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                }
                dataGridView1.ClearSelection();
            }
            if (rd4.Checked)
            {
                string cmnd = "select * from v_hoadon where YEAR([Ngày]) = YEAR(GETDATE()) AND MONTH([Ngày]) = MONTH(GETDATE()) ";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;


                }
                dataGridView1.ClearSelection();
            }
            if (rd5.Checked)
            {
                string dt1 = dateTimePicker2.Value.ToString("yyyy'/'MM'/'dd");
                string cmnd = "select * from v_hoadon where [Ngày] =  '"+dt1+"'";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;

                }
                dataGridView1.ClearSelection();
            }
        }



        }
    }


