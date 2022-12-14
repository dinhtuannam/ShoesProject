namespace ShoesProject.UserControls
{
    partial class UC_BanHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnAddBH = new System.Windows.Forms.Button();
            this.btnEditBH = new System.Windows.Forms.Button();
            this.btnMuaHang = new System.Windows.Forms.Button();
            this.txtSearchBH = new System.Windows.Forms.TextBox();
            this.btnSearchBH = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.Label();
            this.txtItemSelected = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(15, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 342);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(408, 336);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Location = new System.Drawing.Point(449, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 342);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.Size = new System.Drawing.Size(433, 336);
            this.dataGridView2.TabIndex = 0;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // btnAddBH
            // 
            this.btnAddBH.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAddBH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddBH.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBH.ForeColor = System.Drawing.Color.White;
            this.btnAddBH.Location = new System.Drawing.Point(17, 370);
            this.btnAddBH.Name = "btnAddBH";
            this.btnAddBH.Size = new System.Drawing.Size(98, 43);
            this.btnAddBH.TabIndex = 5;
            this.btnAddBH.Text = "Thêm";
            this.btnAddBH.UseVisualStyleBackColor = false;
            this.btnAddBH.Click += new System.EventHandler(this.btnAddBH_Click);
            // 
            // btnEditBH
            // 
            this.btnEditBH.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnEditBH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditBH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditBH.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditBH.ForeColor = System.Drawing.Color.White;
            this.btnEditBH.Location = new System.Drawing.Point(684, 370);
            this.btnEditBH.Name = "btnEditBH";
            this.btnEditBH.Size = new System.Drawing.Size(98, 43);
            this.btnEditBH.TabIndex = 6;
            this.btnEditBH.Text = "Xoá";
            this.btnEditBH.UseVisualStyleBackColor = false;
            this.btnEditBH.Click += new System.EventHandler(this.btnEditBH_Click);
            // 
            // btnMuaHang
            // 
            this.btnMuaHang.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnMuaHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMuaHang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMuaHang.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuaHang.ForeColor = System.Drawing.Color.White;
            this.btnMuaHang.Location = new System.Drawing.Point(787, 370);
            this.btnMuaHang.Name = "btnMuaHang";
            this.btnMuaHang.Size = new System.Drawing.Size(98, 43);
            this.btnMuaHang.TabIndex = 7;
            this.btnMuaHang.Text = "Mua Hàng";
            this.btnMuaHang.UseVisualStyleBackColor = false;
            this.btnMuaHang.Click += new System.EventHandler(this.btnMuaHang_Click);
            // 
            // txtSearchBH
            // 
            this.txtSearchBH.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBH.Location = new System.Drawing.Point(224, 381);
            this.txtSearchBH.Name = "txtSearchBH";
            this.txtSearchBH.Size = new System.Drawing.Size(203, 26);
            this.txtSearchBH.TabIndex = 8;
            // 
            // btnSearchBH
            // 
            this.btnSearchBH.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSearchBH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchBH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchBH.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchBH.ForeColor = System.Drawing.Color.White;
            this.btnSearchBH.Location = new System.Drawing.Point(121, 370);
            this.btnSearchBH.Name = "btnSearchBH";
            this.btnSearchBH.Size = new System.Drawing.Size(98, 43);
            this.btnSearchBH.TabIndex = 9;
            this.btnSearchBH.Text = "Tim kiem";
            this.btnSearchBH.UseVisualStyleBackColor = false;
            this.btnSearchBH.Click += new System.EventHandler(this.btnSearchBH_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.White;
            this.txtTotal.Location = new System.Drawing.Point(554, 381);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(56, 20);
            this.txtTotal.TabIndex = 11;
            this.txtTotal.Text = "Total : ";
            // 
            // txtItemSelected
            // 
            this.txtItemSelected.AutoSize = true;
            this.txtItemSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemSelected.ForeColor = System.Drawing.Color.White;
            this.txtItemSelected.Location = new System.Drawing.Point(446, 383);
            this.txtItemSelected.Name = "txtItemSelected";
            this.txtItemSelected.Size = new System.Drawing.Size(49, 20);
            this.txtItemSelected.TabIndex = 12;
            this.txtItemSelected.Text = "Item: ";
            // 
            // UC_BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(43)))));
            this.Controls.Add(this.txtItemSelected);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtSearchBH);
            this.Controls.Add(this.btnSearchBH);
            this.Controls.Add(this.btnMuaHang);
            this.Controls.Add(this.btnEditBH);
            this.Controls.Add(this.btnAddBH);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_BanHang";
            this.Size = new System.Drawing.Size(902, 430);
            this.Load += new System.EventHandler(this.UC_BanHang_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddBH;
        private System.Windows.Forms.Button btnEditBH;
        private System.Windows.Forms.Button btnMuaHang;
        private System.Windows.Forms.TextBox txtSearchBH;
        private System.Windows.Forms.Button btnSearchBH;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label txtItemSelected;
    }
}
