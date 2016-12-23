namespace RoomManager
{
    partial class QuanLy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTKB = new System.Windows.Forms.DataGridView();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnQ = new System.Windows.Forms.Button();
            this.btnPT = new System.Windows.Forms.Button();
            this.btnTK = new System.Windows.Forms.Button();
            this.cbbLoai = new System.Windows.Forms.ComboBox();
            this.dtpPT = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbChiTiet = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTKB
            // 
            this.dgvTKB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKB.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTKB.Location = new System.Drawing.Point(0, 0);
            this.dgvTKB.Name = "dgvTKB";
            this.dgvTKB.Size = new System.Drawing.Size(831, 301);
            this.dgvTKB.TabIndex = 0;
            // 
            // btnAll
            // 
            this.btnAll.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAll.Location = new System.Drawing.Point(12, 307);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(81, 43);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "Tất cả";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnQ
            // 
            this.btnQ.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQ.Location = new System.Drawing.Point(720, 307);
            this.btnQ.Name = "btnQ";
            this.btnQ.Size = new System.Drawing.Size(99, 43);
            this.btnQ.TabIndex = 3;
            this.btnQ.Text = "Quay lại";
            this.btnQ.UseVisualStyleBackColor = true;
            this.btnQ.Click += new System.EventHandler(this.btnQ_Click);
            // 
            // btnPT
            // 
            this.btnPT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPT.Location = new System.Drawing.Point(170, 307);
            this.btnPT.Name = "btnPT";
            this.btnPT.Size = new System.Drawing.Size(99, 43);
            this.btnPT.TabIndex = 5;
            this.btnPT.Text = "Phòng trống";
            this.btnPT.UseVisualStyleBackColor = true;
            this.btnPT.Click += new System.EventHandler(this.btnPT_Click);
            // 
            // btnTK
            // 
            this.btnTK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTK.Location = new System.Drawing.Point(613, 307);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(49, 43);
            this.btnTK.TabIndex = 2;
            this.btnTK.Text = "Tìm";
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // cbbLoai
            // 
            this.cbbLoai.FormattingEnabled = true;
            this.cbbLoai.Location = new System.Drawing.Point(394, 307);
            this.cbbLoai.Name = "cbbLoai";
            this.cbbLoai.Size = new System.Drawing.Size(213, 21);
            this.cbbLoai.TabIndex = 7;
            this.cbbLoai.SelectedIndexChanged += new System.EventHandler(this.cbbLoai_SelectedIndexChanged);
            // 
            // dtpPT
            // 
            this.dtpPT.CustomFormat = "dd/MM/yyyy";
            this.dtpPT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPT.Location = new System.Drawing.Point(279, 328);
            this.dtpPT.Name = "dtpPT";
            this.dtpPT.Size = new System.Drawing.Size(89, 20);
            this.dtpPT.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(275, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Trong";
            // 
            // cbbChiTiet
            // 
            this.cbbChiTiet.FormattingEnabled = true;
            this.cbbChiTiet.Location = new System.Drawing.Point(394, 331);
            this.cbbChiTiet.Name = "cbbChiTiet";
            this.cbbChiTiet.Size = new System.Drawing.Size(213, 21);
            this.cbbChiTiet.TabIndex = 11;
            // 
            // QuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 359);
            this.Controls.Add(this.cbbChiTiet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpPT);
            this.Controls.Add(this.cbbLoai);
            this.Controls.Add(this.btnPT);
            this.Controls.Add(this.btnQ);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.dgvTKB);
            this.Name = "QuanLy";
            this.Text = "Quản lý phòng";
            this.Load += new System.EventHandler(this.QuanLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTKB;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Button btnQ;
        private System.Windows.Forms.Button btnPT;
        private System.Windows.Forms.ComboBox cbbLoai;
        private System.Windows.Forms.DateTimePicker dtpPT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbChiTiet;
    }
}