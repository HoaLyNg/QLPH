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
    public partial class Tra : Form
    {
        SqlConnection cn = new SqlConnection();
        DSTraPhong DSTP;
        public Tra(DSTraPhong temp)
        {
            InitializeComponent();
            DSTP = temp;
            try
            {
                string cnstr = "Server = .; Database = QLPH; Integrated Security = true;";
                cn.ConnectionString = cnstr;
                if (cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Loi ket noi !!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                cn.Close();
            }
        }
        private void Tra_Load(object sender, EventArgs e)
        {
            lblNgay.Text = DSTraPhong.GNgay.ToString();
            lblP.Text = DSTraPhong.GIDPhong.ToString();
            lblTBD.Text = DSTraPhong.GTietBD.ToString();
            lblTKT.Text = DSTraPhong.GTietKT.ToString();
            cn.Open();
            string sql1 = "select * from Phong where MaPhong like " + lblP.Text;
            bool mc, at, asang, ml, rdc;
            SqlCommand cmd = new SqlCommand(sql1, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                mc = dr.GetBoolean(2);
                at = dr.GetBoolean(3);
                asang = dr.GetBoolean(4);
                ml = dr.GetBoolean(5);
                rdc = dr.GetBoolean(6);
                if (mc == true) { radMCTot.Checked = true; radMCHong.Checked = false; } else { radMCTot.Checked = false; radMCHong.Checked = true; }
                if (at == true) { radATTot.Checked = true; radATHong.Checked = false; } else { radATTot.Checked = false; radATHong.Checked = true; }
                if (asang == true) { radASTot.Checked = true; radASHong.Checked = false; } else { radASTot.Checked = false; radASHong.Checked = true; }
                if (ml == true) { radMLTot.Checked = true; radMLHong.Checked = false; } else { radMLTot.Checked = false; radMLHong.Checked = true; }
                if (rdc == true) { radRDCTot.Checked = true; radRDCHong.Checked = false; } else { radRDCTot.Checked = false; radRDCHong.Checked = true; }
            }
            cn.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("QLPHRoomUpdate", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IDPhong", lblP.Text));
            cmd.Parameters.Add(new SqlParameter("@MC", (radMCTot.Checked == true) ? true : false));
            cmd.Parameters.Add(new SqlParameter("@AT", (radATTot.Checked == true) ? true : false));
            cmd.Parameters.Add(new SqlParameter("@AS", (radASTot.Checked == true) ? true : false));
            cmd.Parameters.Add(new SqlParameter("@ML", (radMLTot.Checked == true) ? true : false));
            cmd.Parameters.Add(new SqlParameter("@RO", (radRDCTot.Checked == true) ? true : false));
            cmd.ExecuteNonQuery();

            ///////////////////////////////////

            SqlCommand cmd1 = new SqlCommand("QLPHTKBUpdate", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add(new SqlParameter("@IDPhong", lblP.Text));
            cmd1.Parameters.Add(new SqlParameter("@TietBD", lblTBD.Text));
            cmd1.Parameters.Add(new SqlParameter("@TietKT", lblTKT.Text));
            cmd1.Parameters.Add(new SqlParameter("@Ngay", Convert.ToDateTime(lblNgay.Text)));
            cmd1.Parameters.Add(new SqlParameter("@TenTra", txtTen.Text));
            cmd1.Parameters.Add(new SqlParameter("@MaSo", txtMSSV.Text));
            cmd1.ExecuteNonQuery();

            cn.Close();
            if (MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                this.Close();
        }

        private void Tra_FormClosing(object sender, FormClosingEventArgs e)
        {
            DSTP.Getdata();
        }
    }
}
