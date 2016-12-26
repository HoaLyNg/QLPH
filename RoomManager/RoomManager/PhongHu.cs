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
    public partial class PhongHu : Form
    {
        public class Room
        {
            public int Phong { get; set; }
            public string MayChieu { get; set; }
            public string AmThanh { get; set; }
            public string AnhSang { get; set; }
            public string MayLanh { get; set; }
            public string RoDungCu { get; set; }
            public int SucChua { get; set; }

            public Room(int p, string mc, string at, string asang, string ml, string rdc,int sc)
            {
                this.Phong = p;
                this.MayChieu = mc;
                this.AmThanh = at;
                this.AnhSang = asang;
                this.MayLanh = ml;
                this.RoDungCu = rdc;
                this.SucChua = sc;
            }
        }
        SqlConnection cn = new SqlConnection();
        public PhongHu()
        {
            InitializeComponent();
            try
            {
                string cnstr = "Server = .; Database = QLPH1; Integrated Security = true;";
                cn.ConnectionString = cnstr;
                if (cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    MessageBox.Show("Ket noi thanh cong !!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        
        private void PhongHu_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            Sua s = new Sua(this);
            s.ShowDialog();
        }
        public void GetData()
        {
            cn.Open();
            string sql = "select * from Phong";
            int p, sc;
            bool mc, at, asang, ml, rdc;
            string Smc = ""; string Sat = ""; string Sasang = ""; string Sml = ""; string Srdc = "";
            List<Room> list = new List<Room>();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                p = dr.GetInt32(0);
                mc = dr.GetBoolean(1);
                at = dr.GetBoolean(2);
                asang = dr.GetBoolean(3);
                ml = dr.GetBoolean(4);
                rdc = dr.GetBoolean(5);
                sc = dr.GetInt32(6);
                if (mc == true) { Smc = "Tốt"; } else { Smc = "Hỏng"; }
                if (at == true) { Sat = "Tốt"; } else { Sat = "Hỏng"; }
                if (asang == true) { Sasang = "Tốt"; } else { Sasang = "Hỏng"; }
                if (ml == true) { Sml = "Tốt"; } else { Sml = "Hỏng"; }
                if (rdc == true) { Srdc = "Tốt"; } else { Srdc = "Hỏng"; }
                Room r = new Room(p, Smc, Sat, Sasang, Sml, Srdc, sc);
                list.Add(r);
            }
            dgvPH.DataSource = list;
            dr.Close();
            cn.Close();
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
