namespace ShoesProject.UserControls.Bills
{
    partial class AddBill
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtid = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtidcustomer = new Guna.UI2.WinForms.Guna2TextBox();
            this.date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbtrangthai = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtidsanpham = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtamount = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnaddsanpham = new Guna.UI2.WinForms.Guna2Button();
            this.btnremovesp = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.txttotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbboxtrangthai = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 154);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "ID Hoa Don";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "ID Khach Hang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Ngay Mua";
            // 
            // txtid
            // 
            this.txtid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtid.DefaultText = "";
            this.txtid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtid.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtid.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtid.Location = new System.Drawing.Point(52, 29);
            this.txtid.Name = "txtid";
            this.txtid.PasswordChar = '\0';
            this.txtid.PlaceholderText = "";
            this.txtid.SelectedText = "";
            this.txtid.Size = new System.Drawing.Size(160, 26);
            this.txtid.TabIndex = 44;
            // 
            // txtidcustomer
            // 
            this.txtidcustomer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtidcustomer.DefaultText = "";
            this.txtidcustomer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtidcustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtidcustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtidcustomer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtidcustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtidcustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtidcustomer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtidcustomer.Location = new System.Drawing.Point(52, 119);
            this.txtidcustomer.Name = "txtidcustomer";
            this.txtidcustomer.PasswordChar = '\0';
            this.txtidcustomer.PlaceholderText = "";
            this.txtidcustomer.SelectedText = "";
            this.txtidcustomer.Size = new System.Drawing.Size(160, 26);
            this.txtidcustomer.TabIndex = 46;
            // 
            // date
            // 
            this.date.Checked = true;
            this.date.FillColor = System.Drawing.Color.White;
            this.date.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.date.Location = new System.Drawing.Point(280, 74);
            this.date.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.date.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(223, 36);
            this.date.TabIndex = 47;
            this.date.Value = new System.DateTime(2022, 11, 18, 20, 20, 58, 393);
            // 
            // lbtrangthai
            // 
            this.lbtrangthai.AutoSize = true;
            this.lbtrangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtrangthai.ForeColor = System.Drawing.Color.Red;
            this.lbtrangthai.Location = new System.Drawing.Point(218, 127);
            this.lbtrangthai.Name = "lbtrangthai";
            this.lbtrangthai.Size = new System.Drawing.Size(78, 18);
            this.lbtrangthai.TabIndex = 48;
            this.lbtrangthai.Text = "trang thai";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(536, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Id san pham";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(536, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "So luong";
            // 
            // txtidsanpham
            // 
            this.txtidsanpham.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtidsanpham.DefaultText = "";
            this.txtidsanpham.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtidsanpham.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtidsanpham.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtidsanpham.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtidsanpham.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtidsanpham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtidsanpham.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtidsanpham.Location = new System.Drawing.Point(539, 159);
            this.txtidsanpham.Name = "txtidsanpham";
            this.txtidsanpham.PasswordChar = '\0';
            this.txtidsanpham.PlaceholderText = "";
            this.txtidsanpham.SelectedText = "";
            this.txtidsanpham.Size = new System.Drawing.Size(95, 26);
            this.txtidsanpham.TabIndex = 51;
            this.txtidsanpham.TextChanged += new System.EventHandler(this.txtidsanpham_TextChanged);
            // 
            // txtamount
            // 
            this.txtamount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtamount.DefaultText = "";
            this.txtamount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtamount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtamount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtamount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtamount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtamount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtamount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtamount.Location = new System.Drawing.Point(539, 204);
            this.txtamount.Name = "txtamount";
            this.txtamount.PasswordChar = '\0';
            this.txtamount.PlaceholderText = "";
            this.txtamount.SelectedText = "";
            this.txtamount.Size = new System.Drawing.Size(95, 26);
            this.txtamount.TabIndex = 52;
            // 
            // btnaddsanpham
            // 
            this.btnaddsanpham.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnaddsanpham.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnaddsanpham.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnaddsanpham.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnaddsanpham.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnaddsanpham.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnaddsanpham.ForeColor = System.Drawing.Color.White;
            this.btnaddsanpham.Location = new System.Drawing.Point(461, 159);
            this.btnaddsanpham.Name = "btnaddsanpham";
            this.btnaddsanpham.Size = new System.Drawing.Size(59, 42);
            this.btnaddsanpham.TabIndex = 54;
            this.btnaddsanpham.Text = "<=";
            this.btnaddsanpham.Click += new System.EventHandler(this.btnaddsanpham_Click);
            // 
            // btnremovesp
            // 
            this.btnremovesp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnremovesp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnremovesp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnremovesp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnremovesp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnremovesp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnremovesp.ForeColor = System.Drawing.Color.White;
            this.btnremovesp.Location = new System.Drawing.Point(461, 237);
            this.btnremovesp.Name = "btnremovesp";
            this.btnremovesp.Size = new System.Drawing.Size(59, 42);
            this.btnremovesp.TabIndex = 55;
            this.btnremovesp.Text = "=>";
            this.btnremovesp.Click += new System.EventHandler(this.btnremovesp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(221, 349);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 45);
            this.btnAdd.TabIndex = 57;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txttotal
            // 
            this.txttotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txttotal.DefaultText = "";
            this.txttotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txttotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txttotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txttotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txttotal.HideSelection = false;
            this.txttotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txttotal.Location = new System.Drawing.Point(357, 317);
            this.txttotal.Name = "txttotal";
            this.txttotal.PasswordChar = '\0';
            this.txttotal.PlaceholderText = "";
            this.txttotal.SelectedText = "";
            this.txttotal.Size = new System.Drawing.Size(95, 26);
            this.txttotal.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Tong so tien";
            // 
            // cbboxtrangthai
            // 
            this.cbboxtrangthai.BackColor = System.Drawing.Color.Transparent;
            this.cbboxtrangthai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbboxtrangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxtrangthai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbboxtrangthai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbboxtrangthai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbboxtrangthai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbboxtrangthai.ItemHeight = 30;
            this.cbboxtrangthai.Items.AddRange(new object[] {
            "confirmed",
            "unconfirmed"});
            this.cbboxtrangthai.Location = new System.Drawing.Point(472, 35);
            this.cbboxtrangthai.Name = "cbboxtrangthai";
            this.cbboxtrangthai.Size = new System.Drawing.Size(140, 36);
            this.cbboxtrangthai.TabIndex = 58;
            this.cbboxtrangthai.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // AddBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(648, 396);
            this.Controls.Add(this.cbboxtrangthai);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnremovesp);
            this.Controls.Add(this.btnaddsanpham);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.txtamount);
            this.Controls.Add(this.txtidsanpham);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbtrangthai);
            this.Controls.Add(this.date);
            this.Controls.Add(this.txtidcustomer);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddBill";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddBill";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddBill_FormClosing);
            this.Load += new System.EventHandler(this.AddBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtid;
        private Guna.UI2.WinForms.Guna2TextBox txtidcustomer;
        private Guna.UI2.WinForms.Guna2DateTimePicker date;
        private System.Windows.Forms.Label lbtrangthai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtidsanpham;
        private Guna.UI2.WinForms.Guna2TextBox txtamount;
        private Guna.UI2.WinForms.Guna2Button btnaddsanpham;
        private Guna.UI2.WinForms.Guna2Button btnremovesp;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2TextBox txttotal;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2ComboBox cbboxtrangthai;
    }
}