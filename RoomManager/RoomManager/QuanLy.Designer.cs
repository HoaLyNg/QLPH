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
            this.btnPH = new System.Windows.Forms.Button();
            this.btnPT = new System.Windows.Forms.Button();
            this.btnTK = new System.Windows.Forms.Button();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.cbbLoai = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTKB
            // 
            this.dgvTKB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKB.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTKB.Location = new System.Drawing.Point(0, 0);
            this.dgvTKB.Name = "dgvTKB";
            this.dgvTKB.Size = new System.Drawing.Size(718, 301);
            this.dgvTKB.TabIndex = 0;
            // 
            // btnAll
            // 
            this.btnAll.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAll.Location = new System.Drawing.Point(12, 307);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(99, 43);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "Tất cả";
            this.btnAll.UseVisualStyleBackColor = true;
            // 
            // btnQ
            // 
            this.btnQ.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQ.Location = new System.Drawing.Point(607, 307);
            this.btnQ.Name = "btnQ";
            this.btnQ.Size = new System.Drawing.Size(99, 43);
            this.btnQ.TabIndex = 3;
            this.btnQ.Text = "Quay lại";
            this.btnQ.UseVisualStyleBackColor = true;
            // 
            // btnPH
            // 
            this.btnPH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPH.Location = new System.Drawing.Point(117, 307);
            this.btnPH.Name = "btnPH";
            this.btnPH.Size = new System.Drawing.Size(99, 43);
            this.btnPH.TabIndex = 4;
            this.btnPH.Text = "Phòng hư";
            this.btnPH.UseVisualStyleBackColor = true;
            // 
            // btnPT
            // 
            this.btnPT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPT.Location = new System.Drawing.Point(222, 307);
            this.btnPT.Name = "btnPT";
            this.btnPT.Size = new System.Drawing.Size(99, 43);
            this.btnPT.TabIndex = 5;
            this.btnPT.Text = "Phòng trống";
            this.btnPT.UseVisualStyleBackColor = true;
            // 
            // btnTK
            // 
            this.btnTK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTK.Location = new System.Drawing.Point(552, 307);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(49, 43);
            this.btnTK.TabIndex = 2;
            this.btnTK.Text = "Tìm";
            this.btnTK.UseVisualStyleBackColor = true;
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(378, 330);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(168, 20);
            this.txtTK.TabIndex = 6;
            // 
            // cbbLoai
            // 
            this.cbbLoai.FormattingEnabled = true;
            this.cbbLoai.Location = new System.Drawing.Point(378, 307);
            this.cbbLoai.Name = "cbbLoai";
            this.cbbLoai.Size = new System.Drawing.Size(168, 21);
            this.cbbLoai.TabIndex = 7;
            // 
            // QuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 359);
            this.Controls.Add(this.cbbLoai);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.btnPT);
            this.Controls.Add(this.btnPH);
            this.Controls.Add(this.btnQ);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.dgvTKB);
            this.Name = "QuanLy";
            this.Text = "QuanLy";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTKB;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Button btnQ;
        private System.Windows.Forms.Button btnPH;
        private System.Windows.Forms.Button btnPT;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.ComboBox cbbLoai;
    }
}