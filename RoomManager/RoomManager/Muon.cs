﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoomManager
{
    public partial class Muon : Form
    {
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


    }
}
