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
            public int IDPhong { get; set; }
            public int IDLop { get; set; }
            public int TietBD { get; set; }
            public int TietKT { get; set; }
            public DateTime NgayMuon { get; set; }
            public string NguoiMuon { get; set; }
            public string NguoiTra { get; set; }
            public string LyDo { get; set; }

            //
            public TKB(int IDPhong, int IDLop, int TietBD, int TietKT, DateTime NgayMuon, string NguoiMuon, string NguoiTra, string LyDo)
            {
                this.IDPhong = IDPhong;
                this.IDLop = IDLop;
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
            public int IDPhong { get; set; }
            public string TietTrong { get; set; }
            public DateTime Ngay { get; set; }

            //
            public PhongTrong(int IDPhong, string TietTrong, DateTime NgayMuon)
            {
                this.IDPhong = IDPhong;
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

        private void btnAll_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "select TKB.MaPhong, TKB.MaLH, TKB.TietBD, TKB.TietKT, TKB.Ngay, MP.TenNgMuon, TP.TenNgTra , MP.Note from TKBieu TKB, MuonPhong MP, TraPhong TP where  TKB.MaMP like MP.MaMuonPhong and TKB.MaTP like TP.MaTraPhong";
            List<TKB> list = new List<TKB>();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            int IDPhong, IDLop, TietBD, TietKT; 
            DateTime NgayMuon;
            string NguoiMuon, NguoiTra, LyDo;
            while (dr.Read())
            {
                IDPhong = dr.GetInt32(0);
                IDLop = dr.GetInt32(1);
                TietBD = dr.GetInt32(2);
                TietKT = dr.GetInt32(3);
                NgayMuon = dr.GetDateTime(4);
                NguoiMuon = dr.GetString(5);
                NguoiTra = dr.GetString(6);
                LyDo = dr.GetString(7);
                TKB tkbieu = new TKB(IDPhong, IDLop, TietBD, TietKT, NgayMuon, NguoiMuon,NguoiTra, LyDo);
                list.Add(tkbieu);
            }
            dr.Close();
            dgvTKB.DataSource = list;
            cn.Close();
        }

        private void btnPT_Click(object sender, EventArgs e)
        {
            cn.Open();
            string sql = "select * from TKBieu";
            List<PhongTrong> list = new List<PhongTrong>();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            int IDPhong, TietBD, TietKT;
            DateTime Ngay;
            int[,] tiet = new int[3, 10] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
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
            for (int i = 0; i < 3; i++)
            {
               string tt = ""; 
               for (int j = 1; j <= 9; j++)
               {
                   if( tiet[i, j] != 1)
                   {
                       tt += j + ", ";
                   }
               }
               tt = tt.TrimEnd(' ');
               tt = tt.TrimEnd(',');
               PhongTrong room = new PhongTrong(i+1, tt, Convert.ToDateTime(dtpPT.Text));
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
                        sql = "select MaPhong from Phong";
                        newDisp = "MaPhong";
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
                sql = "select TKB.MaPhong, TKB.MaLH, TKB.TietBD, TKB.TietKT, TKB.Ngay, MP.TenNgMuon, TP.TenNgTra , MP.Note from TKBieu TKB, MuonPhong MP, TraPhong TP where  TKB.MaMP like MP.MaMuonPhong and TKB.MaTP like TP.MaTraPhong and TKB.MaLH in (select LH.MaLH from LopHoc LH where LH.MaMon like " + Ma + ")";
            }
            if (Loai == "MaPhong")
            {
                sql = "select TKB.MaPhong, TKB.MaLH, TKB.TietBD, TKB.TietKT, TKB.Ngay, MP.TenNgMuon, TP.TenNgTra , MP.Note from TKBieu TKB, MuonPhong MP, TraPhong TP where  TKB.MaMP like MP.MaMuonPhong and TKB.MaTP like TP.MaTraPhong and TKB.MaPhong like " + Ma;
            }
            if (Loai == "MaGV")
            {
                sql = "select TKB.MaPhong, TKB.MaLH, TKB.TietBD, TKB.TietKT, TKB.Ngay, MP.TenNgMuon, TP.TenNgTra , MP.Note from TKBieu TKB, MuonPhong MP, TraPhong TP where  TKB.MaMP like MP.MaMuonPhong and TKB.MaTP like TP.MaTraPhong and TKB.MaLH in (select LH.MaLH from LopHoc LH where LH.MaGV like " + Ma + ")";
            }
            List<TKB> list = new List<TKB>();
            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            int IDPhong, IDLop, TietBD, TietKT; 
            DateTime NgayMuon;
            string NguoiMuon, NguoiTra, LyDo;
            while (dr.Read())
            {
                IDPhong = dr.GetInt32(0);
                IDLop = dr.GetInt32(1);
                TietBD = dr.GetInt32(2);
                TietKT = dr.GetInt32(3);
                NgayMuon = dr.GetDateTime(4);
                NguoiMuon = dr.GetString(5);
                NguoiTra = dr.GetString(6);
                LyDo = dr.GetString(7);
                TKB tkbieu = new TKB(IDPhong, IDLop, TietBD, TietKT, NgayMuon, NguoiMuon,NguoiTra, LyDo);
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
