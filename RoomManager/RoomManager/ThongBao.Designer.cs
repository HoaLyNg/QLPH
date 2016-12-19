namespace RoomManager
{
    partial class ThongBao
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
            this.lblTB = new System.Windows.Forms.Label();
            this.dgvTKB = new System.Windows.Forms.DataGridView();
            this.btnTT = new System.Windows.Forms.Button();
            this.btnQL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTB
            // 
            this.lblTB.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTB.Location = new System.Drawing.Point(126, 9);
            this.lblTB.Name = "lblTB";
            this.lblTB.Size = new System.Drawing.Size(340, 27);
            this.lblTB.TabIndex = 0;
            this.lblTB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTKB
            // 
            this.dgvTKB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKB.Location = new System.Drawing.Point(0, 51);
            this.dgvTKB.Name = "dgvTKB";
            this.dgvTKB.Size = new System.Drawing.Size(588, 34);
            this.dgvTKB.TabIndex = 1;
            // 
            // btnTT
            // 
            this.btnTT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTT.Location = new System.Drawing.Point(104, 100);
            this.btnTT.Name = "btnTT";
            this.btnTT.Size = new System.Drawing.Size(130, 37);
            this.btnTT.TabIndex = 2;
            this.btnTT.Text = "Tiếp tục nhập";
            this.btnTT.UseVisualStyleBackColor = true;
            // 
            // btnQL
            // 
            this.btnQL.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQL.Location = new System.Drawing.Point(334, 100);
            this.btnQL.Name = "btnQL";
            this.btnQL.Size = new System.Drawing.Size(130, 37);
            this.btnQL.TabIndex = 3;
            this.btnQL.Text = "Quay lại trang chủ";
            this.btnQL.UseVisualStyleBackColor = true;
            // 
            // ThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 154);
            this.Controls.Add(this.btnQL);
            this.Controls.Add(this.btnTT);
            this.Controls.Add(this.dgvTKB);
            this.Controls.Add(this.lblTB);
            this.Name = "ThongBao";
            this.Text = "Thông báo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTB;
        private System.Windows.Forms.DataGridView dgvTKB;
        private System.Windows.Forms.Button btnTT;
        private System.Windows.Forms.Button btnQL;
    }
}