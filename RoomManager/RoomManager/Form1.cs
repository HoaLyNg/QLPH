using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    }
}
