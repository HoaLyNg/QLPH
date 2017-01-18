using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RoomManager
{
    public partial class Muon : Form
    {
        SqlConnection cn;
        SqlCommand cm;
        SqlDataAdapter ap;
        DataSet ds;
        public Muon()
        {
            InitializeComponent();
        }
        private void radSV_CheckedChanged(object sender, EventArgs e)
        {
            if (radSV.Checked == true)
                lblH.Text = "MSSV";
           
            else if (radSV.Checked == false)
                lblH.Text = "MaGV";
        }
        public void connect()
        {
            string cntr = "Server = .; Database = QLPH; Integrated Security = true;";
            cn = new SqlConnection(cntr);
            try
            {
                if (cn != null && cn.State == ConnectionState.Closed)
                    cn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void disconnect()
        {
            if (cn != null && cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        private void Muon_Load_1(object sender, EventArgs e)
        {
            TimeSt();
            Timekt();
        }
        public void TimeSt()
        {
            connect();
            cm = new SqlCommand("select MaTiet, TenTiet From Tiet Order by MaTiet ASC", cn);
            ap = new SqlDataAdapter(cm);
            ds = new DataSet();
            ap.Fill(ds, "Tiet");
            cbbTietBD.DataSource = ds.Tables[0];
            cbbTietBD.DisplayMember = "TenTiet";
            cbbTietBD.ValueMember = "MaTiet";
            disconnect();
        }
        public void Timekt()
        {
            connect();
            cm = new SqlCommand("select MaTiet, TenTiet From Tiet where MaTiet >" + cbbTietBD.SelectedValue.ToString().Trim() + " ", cn);
            SqlDataAdapter ap = new SqlDataAdapter(cm);
            DataSet dss = new DataSet();

            ap.Fill(dss, "Tiet");
            cbbTietKT.DataSource = dss.Tables[0];
            cbbTietKT.DisplayMember = "TenTiet";
            cbbTietKT.ValueMember = "MaTiet";
            disconnect();
        }
        private void cbbTietKT_MouseEnter(object sender, EventArgs e)
        {
            Timekt();
        }
        public void PhongTrong()
        {
            string bd = cbbTietBD.SelectedValue.ToString().Trim();
            string kt = cbbTietKT.SelectedValue.ToString().Trim();
            string day = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            connect();
            cm = new SqlCommand("select MaPhong, TenPhong From Phong where MaPhong not in ( select MaPhong From TKBieu where Ngay like '" + day + "' and MaPhong in (select Maphong From TKBieu where(" + bd + " >= TietBD and " + bd + " <= TietKT) or(" + kt + " >= TietBD and " + kt + " <= TietKT)))", cn);
            ap = new SqlDataAdapter(cm);
            ds = new DataSet();

            ap.Fill(ds, "Phong");
            cbbPhong.DataSource = ds.Tables[0];
            cbbPhong.DisplayMember = "TenPhong";
            cbbPhong.ValueMember = "MaPhong";
            disconnect();
        }
        private void cbbPhong_MouseEnter(object sender, EventArgs e)
        {
            PhongTrong();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            connect();
           
                SqlCommand cmd = new SqlCommand("INS_MUON", cn);
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (txtTen.Text.Length == 0)
                {  throw new Exception("Tên không được rỗng !"); }
                else
                cmd.Parameters.Add(new SqlParameter("@ten", txtTen.Text));
                if (txtMa.Text.Length == 0)
                { throw new Exception("Mã số không được rỗng !"); }
                else
                    cmd.Parameters.Add(new SqlParameter("@ms", txtMa.Text));
                if (txtLyDo.Text.Length == 0)
                { throw new Exception("Lý do không được rỗng !"); }
                else
                    cmd.Parameters.Add(new SqlParameter("@not", txtLyDo.Text));
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("INS_TKB", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@maphong", cbbPhong.SelectedValue.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("@bd", cbbTietBD.SelectedValue.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("@kt", cbbTietKT.SelectedValue.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("@date", dateTimePicker1.Value.ToString("yyyy-MM-dd")));
                cmd.Parameters.Add(new SqlParameter("@lap", cbbLaplai.Text));
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Đăng kí thành công !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                

               
            }
            finally
            {
                disconnect();
            }
            
        } 
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
