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
    public partial class Sua : Form
    {
        public class cbbItem
        {
            //
            public string Text { get; set; }
            public object Value { get; set; }

            public cbbItem(string t, object v)
            {
                this.Text = t;
                this.Value = v;
            }
        }
        SqlConnection cn = new SqlConnection();
        public Sua()
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

            ////////////////////////////////////////////////////////////

            List<cbbItem> list = new List<cbbItem>();
            cn.Open();
            string id;
            string sql = "select MaPhong from Phong";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = Convert.ToString(dr.GetInt32(0));
                cbbItem item = new cbbItem(id, id);
                list.Add(item);
            }
            cbbPhong.DataSource = list;
            cbbPhong.DisplayMember = "Text";
            cbbPhong.ValueMember = "Value";
            dr.Close();

            ////////////////////////////////////////////////////////

            cbbItem cbb = (cbbItem)cbbPhong.SelectedItem;
            string value = cbb.Value.ToString();
            if (value != "")
            {
                string sql1 = "select * from Phong where MaPhong like " + value;
                bool mc, at, asang, ml, rdc;
                SqlCommand cmd1 = new SqlCommand(sql1, cn);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    mc = dr1.GetBoolean(1);
                    at = dr1.GetBoolean(2);
                    asang = dr1.GetBoolean(3);
                    ml = dr1.GetBoolean(4);
                    rdc = dr1.GetBoolean(5);
                    if (mc == true) { radMCTot.Checked = true; radMCHong.Checked = false; } else { radMCTot.Checked = false; radMCHong.Checked = true; }
                    if (at == true) { radATTot.Checked = true; radATHong.Checked = false; } else { radATTot.Checked = false; radATHong.Checked = true; }
                    if (asang == true) { radASTot.Checked = true; radASHong.Checked = false; } else { radASTot.Checked = false; radASHong.Checked = true; }
                    if (ml == true) { radMLTot.Checked = true; radMLHong.Checked = false; } else { radMLTot.Checked = false; radMLHong.Checked = true; }
                    if (rdc == true) { radRDCTot.Checked = true; radRDCHong.Checked = false; } else { radRDCTot.Checked = false; radRDCHong.Checked = true; }
                }
                dr1.Close();
            }
            cn.Close();
        }

        private void cbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cn != null && cn.State == ConnectionState.Closed)
                cn.Open();
            cbbItem cbb = (cbbItem)cbbPhong.SelectedItem;
            string value = cbb.Value.ToString();
            if (value != "")
            {
                string sql1 = "select * from Phong where MaPhong like " + value;
                bool mc, at, asang, ml, rdc;
                SqlCommand cmd1 = new SqlCommand(sql1, cn);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    mc = dr1.GetBoolean(1);
                    at = dr1.GetBoolean(2);
                    asang = dr1.GetBoolean(3);
                    ml = dr1.GetBoolean(4);
                    rdc = dr1.GetBoolean(5);
                    if (mc == true) { radMCTot.Checked = true; radMCHong.Checked = false; } else { radMCTot.Checked = false; radMCHong.Checked = true; }
                    if (at == true) { radATTot.Checked = true; radATHong.Checked = false; } else { radATTot.Checked = false; radATHong.Checked = true; }
                    if (asang == true) { radASTot.Checked = true; radASHong.Checked = false; } else { radASTot.Checked = false; radASHong.Checked = true; }
                    if (ml == true) { radMLTot.Checked = true; radMLHong.Checked = false; } else { radMLTot.Checked = false; radMLHong.Checked = true; }
                    if (rdc == true) { radRDCTot.Checked = true; radRDCHong.Checked = false; } else { radRDCTot.Checked = false; radRDCHong.Checked = true; }
                }
                dr1.Close();
            }
            cn.Close();
        }
    }
}
