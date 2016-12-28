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
    public partial class DSTraPhong : Form
    {
        public class TKB 
        {
            //
            public int IDPhong { get; set; }
            public string Phong { get; set; }
            public string Lop { get; set; }
            public string Mon { get; set; }
            public int TietBD { get; set; }
            public int TietKT { get; set; }
            public DateTime NgayMuon { get; set; }
            public string NguoiMuon { get; set; }
            public string NguoiTra { get; set; }
            public string LyDo { get; set; }

            //
            public TKB(int Id, string Phong, string Lop, string Mon, int TietBD, int TietKT, DateTime NgayMuon, string NguoiMuon, string NguoiTra, string LyDo)
            {
                this.IDPhong = Id;
                this.Phong = Phong;
                this.Lop = Lop;
                this.Mon = Mon;
                this.TietBD = TietBD;
                this.TietKT = TietKT;
                this.NgayMuon = NgayMuon;
                this.NguoiMuon = NguoiMuon;
                this.NguoiTra = NguoiTra;
                this.LyDo = LyDo;
            }
        }
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
        public DSTraPhong()
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

            //////////////////////////////////

            List<cbbItem> list = new List<cbbItem>();
            cn.Open();
            string name;
            object v;
            string sql = "select MaPhong, TenPhong from Phong";
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            cbbItem t = new cbbItem("Tất cả","0");
            list.Add(t);
            while (dr.Read())
            {
                v = Convert.ToString(dr.GetInt32(0));
                name = dr.GetString(1);
                cbbItem item = new cbbItem(name, v);
                list.Add(item);
            }
            cbbPhong.DataSource = list;
            cbbPhong.DisplayMember = "Text";
            cbbPhong.ValueMember = "Value";
            dr.Close();
            cn.Close();
        }
        public void Getdata()
        {
            cn.Open();
            string sql;
            cbbItem cbb = (cbbItem)cbbPhong.SelectedItem;
            string value = cbb.Value.ToString();
            if (Convert.ToInt32(value) == 0)
                sql = "select TKB.MaPhong, P.TenPhong, LH.TenLop, M.TenMon, TKB.TietBD, TKB.TietKT, TKB.Ngay, MP.TenNgMuon, TP.TenNgTra , MP.Note from TKBieu TKB, MuonPhong MP, TraPhong TP, Phong P, LopHoc LH,Mon M where  TKB.MaMP like MP.MaMP and TKB.MaTP like TP.MaTP and TKB.MaPhong like P.MaPhong and TKB.MaLH like LH.MaLH and LH.MaMon like M.MaMon";
            else
                sql = "select TKB.MaPhong, P.TenPhong, LH.TenLop, M.TenMon, TKB.TietBD, TKB.TietKT, TKB.Ngay, MP.TenNgMuon, TP.TenNgTra , MP.Note from TKBieu TKB, MuonPhong MP, TraPhong TP, Phong P, LopHoc LH,Mon M where  TKB.MaMP like MP.MaMP and TKB.MaTP like TP.MaTP and TKB.MaPhong like P.MaPhong and TKB.MaLH like LH.MaLH and LH.MaMon like M.MaMon and TKB.MaPhong like " + value;
            List<TKB> list = new List<TKB>();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            int TietBD, TietKT, IDPhong;
            DateTime NgayMuon;
            string NguoiMuon, NguoiTra, LyDo, Mon, Phong, Lop;
            while (dr.Read())
            {
                IDPhong = dr.GetInt32(0); 
                Phong = dr.GetString(1);
                Lop = dr.GetString(2);
                Mon = dr.GetString(3);
                TietBD = dr.GetInt32(4);
                TietKT = dr.GetInt32(5);
                NgayMuon = dr.GetDateTime(6);
                NguoiMuon = dr.GetString(7);
                NguoiTra = dr.GetString(8);
                LyDo = dr.GetString(9);
                if (NgayMuon.Date == Convert.ToDateTime(dtpPT.Text))
                {
                    TKB tkbieu = new TKB(IDPhong, Phong, Lop, Mon, TietBD, TietKT, NgayMuon, NguoiMuon, NguoiTra, LyDo);
                    list.Add(tkbieu);
                }
            }
            dr.Close();
            dgvTKB.DataSource = list;
            cn.Close();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            Getdata();
        }
        int rNum = -1;
        private void dgvTKB_SelectionChanged(object sender, EventArgs e)
        {
            rNum = dgvTKB.CurrentRow.Index;
        }
        public static int GIDPhong, GTietBD, GTietKT;
        public static DateTime GNgay;
        private void btnTra_Click(object sender, EventArgs e)
        {
            GIDPhong = Convert.ToInt32(dgvTKB.Rows[rNum].Cells[0].Value.ToString());
            GTietBD = Convert.ToInt32(dgvTKB.Rows[rNum].Cells[4].Value.ToString());
            GTietKT = Convert.ToInt32(dgvTKB.Rows[rNum].Cells[5].Value.ToString());
            GNgay = Convert.ToDateTime(dgvTKB.Rows[rNum].Cells[6].Value);
            Tra Tra = new Tra(this);
            Tra.ShowDialog();
        }  
    }
}
