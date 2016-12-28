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
            public string Phong { get; set; }
            public string MayChieu { get; set; }
            public string AmThanh { get; set; }
            public string AnhSang { get; set; }
            public string MayLanh { get; set; }
            public string RoDungCu { get; set; }
            public int SucChua { get; set; }

            public Room(string p, string mc, string at, string asang, string ml, string rdc,int sc)
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
            int sc;
            bool mc, at, asang, ml, rdc;
            string Smc = ""; string Sat = ""; string Sasang = ""; string Sml = ""; string Srdc = ""; string p;
            List<Room> list = new List<Room>();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                p = dr.GetString(1);
                mc = dr.GetBoolean(2);
                at = dr.GetBoolean(3);
                asang = dr.GetBoolean(4);
                ml = dr.GetBoolean(5);
                rdc = dr.GetBoolean(6);
                sc = dr.GetInt32(7);
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
