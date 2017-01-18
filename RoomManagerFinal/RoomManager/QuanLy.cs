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
    public partial class QuanLy : Form
    {
        public class TKB 
        {
            //
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
            public TKB(string Phong, string Lop, string Mon, int TietBD, int TietKT, DateTime NgayMuon, string NguoiMuon, string NguoiTra, string LyDo)
            {
                this.Phong = Phong;
                this.Lop = Lop;
                this.Mon = Mon;
                this.TietBD = TietBD;
                this.TietKT = TietKT;
                this.NgayMuon = NgayMuon;
                this.NguoiMuon = NguoiMuon;
                this.NguoiTra = NguoiTra;
                this.LyDo =LyDo;
            }
        }
        public class PhongTrong
        {
            //
            public string TenPhong { get; set; }
            public string TietTrong { get; set; }
            public DateTime Ngay { get; set; }

            //
            public PhongTrong(string IDPhong, string TietTrong, DateTime NgayMuon)
            {
                this.TenPhong = IDPhong;
                this.TietTrong = TietTrong;
                this.Ngay = NgayMuon;
            }
        }
        public class cbbItem
        {
            //
            public string Text { get; set; }
            public object Value { get; set; }

            //
            //public override string ToString()
            //{
            //    return Text;
            //}
            public cbbItem(string t, object v)
            {
                this.Text = t;
                this.Value = v;
            }
        }

        SqlConnection cn = new SqlConnection();
        public QuanLy()
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

        private void btnAll_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "select P.TenPhong, LH.TenLop, M.TenMon, TKB.TietBD, TKB.TietKT, TKB.Ngay, MP.TenNgMuon, TP.TenNgTra , MP.Note from TKBieu TKB, MuonPhong MP, TraPhong TP, Phong P, LopHoc LH,Mon M where  TKB.MaMP like MP.MaMP and TKB.MaTP like TP.MaTP and TKB.MaPhong like P.MaPhong and TKB.MaLH like LH.MaLH and LH.MaMon like M.MaMon";
            List<TKB> list = new List<TKB>();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            int  TietBD, TietKT; 
            DateTime NgayMuon;
            string NguoiMuon, NguoiTra, LyDo, Phong, Lop, Mon;
            while (dr.Read())
            {
                Phong = dr.GetString(0);
                Lop = dr.GetString(1);
                Mon = dr.GetString(2);
                TietBD = dr.GetInt32(3);
                TietKT = dr.GetInt32(4);
                NgayMuon = dr.GetDateTime(5);
                NguoiMuon = dr.GetString(6);
                NguoiTra = dr.GetString(7);
                LyDo = dr.GetString(8);
                TKB tkbieu = new TKB(Phong, Lop, Mon, TietBD, TietKT, NgayMuon, NguoiMuon, NguoiTra, LyDo);
                list.Add(tkbieu);
            }
            dr.Close();
            dgvTKB.DataSource = list;
            cn.Close();
        }

        private void btnPT_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "select TKB.* from TKBieu TKB";
            List<PhongTrong> list = new List<PhongTrong>();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            int IDPhong, TietBD, TietKT;
            string TenPhong;
            DateTime Ngay;
            int[,] tiet = new int[10, 14];
            string[] TenP = new string[10];
            while (dr.Read())
            {
                IDPhong = dr.GetInt32(0);
                TietBD = dr.GetInt32(2);
                TietKT = dr.GetInt32(3);
                Ngay = dr.GetDateTime(4);

                if (Ngay.Date == Convert.ToDateTime(dtpPT.Text))
                {
                    for (int i = TietBD; i <= TietKT; i++)
                    {
                        tiet[IDPhong-1, i] = 1;
                    }
                }
            }
            dr.Close();
            sql = "select P.MaPhong, P.TenPhong from Phong P";
            cmd = new SqlCommand(sql, cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IDPhong = dr.GetInt32(0);
                TenPhong = dr.GetString(1);
                TenP[IDPhong - 1] = TenPhong;
            }
            dr.Close();
            for (int i = 0; i < 10; i++)
            {
               string tt = ""; 
               for (int j = 1; j <= 13; j++)
               {
                   if( tiet[i, j] != 1)
                   {
                       tt += j + ", ";
                   }
               }
               tt = tt.TrimEnd(' ');
               tt = tt.TrimEnd(',');
               PhongTrong room = new PhongTrong(TenP[i], tt, Convert.ToDateTime(dtpPT.Text));
               list.Add(room);             
            }
            dgvTKB.DataSource = list;
            cn.Close();
        }
        string newValue = "";
        string newDisp = "";
        private void cbbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "";
            if (cn != null && cn.State == ConnectionState.Closed)
                cn.Open();
            cbbItem cbb = (cbbItem)cbbLoai.SelectedItem;
            string value = cbb.Value.ToString();
            switch (value)
            {
                case "MaMon":
                    {
                        sql = "select MaMon, TenMon from Mon";
                        newDisp = "TenMon";
                        newValue = "MaMon";
                        break;
                    }
                case "MaPhong":
                    {
                        sql = "select MaPhong,TenPhong from Phong";
                        newDisp = "TenPhong";
                        newValue = "MaPhong";
                        break;
                    }
                case "MaGV":
                    {
                        sql = "select MaGV, TenGV from GiangVien";
                        newDisp = "TenGV";
                        newValue = "MaGV";
                        break;
                    }
            }
            List<cbbItem> list= new List<cbbItem>();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            cbbChiTiet.DataSource = ds.Tables[0];
            cbbChiTiet.DisplayMember = newDisp;
            cbbChiTiet.ValueMember = newValue;
            cn.Close();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            cbbItem i1,i2,i3;
            i1 = new cbbItem("Môn học","MaMon");
            i2 = new cbbItem("Phòng", "MaPhong");
            i3 = new cbbItem("Giảng viên", "MaGV");
            List<cbbItem> list= new List<cbbItem>();
            list.Add(i1);
            list.Add(i2);
            list.Add(i3);
            cbbLoai.DataSource = list;
            cbbLoai.DisplayMember = "Text";
            cbbLoai.ValueMember = "Value";
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "";
            DataTable dsCT = (DataTable)cbbChiTiet.DataSource;
            string Ma = dsCT.Rows[cbbChiTiet.SelectedIndex][0].ToString();
            cbbItem cbbL = (cbbItem)cbbLoai.SelectedItem;
            string Loai = cbbL.Value.ToString();
            if (Loai == "MaMon")
            {
                sql = "select P.TenPhong, LH.TenLop, M.TenMon, TKB.TietBD, TKB.TietKT, TKB.Ngay, MP.TenNgMuon, TP.TenNgTra, MP.Note from TKBieu TKB, MuonPhong MP, TraPhong TP, Phong P, LopHoc LH, Mon M where  TKB.MaMP like MP.MaMP and TKB.MaTP like TP.MaTP and TKB.MaPhong like P.MaPhong and TKB.MaLH like LH.MaLH and LH.MaMon like M.MaMon and M.MaMon like " + Ma;
            }
            if (Loai == "MaPhong")
            {
                sql = "select P.TenPhong, LH.TenLop, M.TenMon, TKB.TietBD, TKB.TietKT, TKB.Ngay, MP.TenNgMuon, TP.TenNgTra , MP.Note from TKBieu TKB, MuonPhong MP, TraPhong TP, Phong P, LopHoc LH, Mon M where  TKB.MaMP like MP.MaMP and TKB.MaTP like TP.MaTP and TKB.MaPhong like P.MaPhong and TKB.MaLH like LH.MaLH and LH.MaMon like M.MaMon and TKB.MaPhong like " + Ma;
            }
            if (Loai == "MaGV")
            {
                sql = "select P.TenPhong, LH.TenLop, M.TenMon, TKB.TietBD, TKB.TietKT, TKB.Ngay, MP.TenNgMuon, TP.TenNgTra , MP.Note from TKBieu TKB, MuonPhong MP, TraPhong TP, Phong P, LopHoc LH, Mon M where  TKB.MaMP like MP.MaMP and TKB.MaTP like TP.MaTP and TKB.MaPhong like P.MaPhong and TKB.MaLH like LH.MaLH and LH.MaMon like M.MaMon and LH.MaGV like " + Ma;
            }
            List<TKB> list = new List<TKB>();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            int  TietBD, TietKT; 
            DateTime NgayMuon;
            string NguoiMuon, NguoiTra, LyDo, Phong, Lop, Mon;
            while (dr.Read())
            {
                Phong = dr.GetString(0);
                Lop = dr.GetString(1);
                Mon = dr.GetString(2);
                TietBD = dr.GetInt32(3);
                TietKT = dr.GetInt32(4);
                NgayMuon = dr.GetDateTime(5);
                NguoiMuon = dr.GetString(6);
                NguoiTra = dr.GetString(7);
                LyDo = dr.GetString(8);
                TKB tkbieu = new TKB(Phong, Lop, Mon, TietBD, TietKT, NgayMuon, NguoiMuon, NguoiTra, LyDo);
                list.Add(tkbieu);
            }
            dr.Close();
            dgvTKB.DataSource = list;
            cn.Close();
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
  
    }
}
