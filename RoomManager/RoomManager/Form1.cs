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
    public partial class btnQL : Form
    {
        public btnQL()
        {
            InitializeComponent();
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            Muon m= new Muon();
            m.ShowDialog();
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            Tra t = new Tra();
            t.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuanLy q = new QuanLy();
            q.ShowDialog();
        }

        private void btnPH_Click(object sender, EventArgs e)
        {
            PhongHu p = new PhongHu();
            p.ShowDialog();
        }

        private void btnQL_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đóng chương trình ?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }
     
    }
}
