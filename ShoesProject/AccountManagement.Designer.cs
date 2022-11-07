namespace ShoesProject
{
    partial class AccountManagement
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnNameAccount = new System.Windows.Forms.Button();
            this.btnNameDisplay = new System.Windows.Forms.Button();
            this.btnTypeAccount = new System.Windows.Forms.Button();
            this.tbNameAccount = new System.Windows.Forms.TextBox();
            this.tbNameDisplay = new System.Windows.Forms.TextBox();
            this.cbTypeAccount = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 378);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDeleteAccount);
            this.panel2.Controls.Add(this.btnAddAccount);
            this.panel2.Controls.Add(this.btnEditAccount);
            this.panel2.Location = new System.Drawing.Point(15, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 49);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(435, 368);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(14, 3);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(98, 43);
            this.btnAddAccount.TabIndex = 0;
            this.btnAddAccount.Text = "Thêm";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(166, 3);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(98, 43);
            this.btnEditAccount.TabIndex = 1;
            this.btnEditAccount.Text = "Sửa";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(318, 3);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(98, 43);
            this.btnDeleteAccount.TabIndex = 2;
            this.btnDeleteAccount.Text = "Xoá";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(456, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 161);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbNameAccount);
            this.panel4.Controls.Add(this.btnNameAccount);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(279, 46);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbNameDisplay);
            this.panel5.Controls.Add(this.btnNameDisplay);
            this.panel5.Location = new System.Drawing.Point(3, 55);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(279, 46);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbTypeAccount);
            this.panel6.Controls.Add(this.btnTypeAccount);
            this.panel6.Location = new System.Drawing.Point(3, 107);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(279, 46);
            this.panel6.TabIndex = 2;
            // 
            // btnNameAccount
            // 
            this.btnNameAccount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNameAccount.Location = new System.Drawing.Point(0, 3);
            this.btnNameAccount.Name = "btnNameAccount";
            this.btnNameAccount.Size = new System.Drawing.Size(118, 40);
            this.btnNameAccount.TabIndex = 0;
            this.btnNameAccount.Text = "Tên Tài Khoản :";
            this.btnNameAccount.UseVisualStyleBackColor = true;
            // 
            // btnNameDisplay
            // 
            this.btnNameDisplay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNameDisplay.Location = new System.Drawing.Point(3, 3);
            this.btnNameDisplay.Name = "btnNameDisplay";
            this.btnNameDisplay.Size = new System.Drawing.Size(115, 40);
            this.btnNameDisplay.TabIndex = 0;
            this.btnNameDisplay.Text = "Tên hiển thị :";
            this.btnNameDisplay.UseVisualStyleBackColor = true;
            // 
            // btnTypeAccount
            // 
            this.btnTypeAccount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeAccount.Location = new System.Drawing.Point(3, 3);
            this.btnTypeAccount.Name = "btnTypeAccount";
            this.btnTypeAccount.Size = new System.Drawing.Size(115, 38);
            this.btnTypeAccount.TabIndex = 0;
            this.btnTypeAccount.Text = "Loại tài khoản :";
            this.btnTypeAccount.UseVisualStyleBackColor = true;
            // 
            // tbNameAccount
            // 
            this.tbNameAccount.Location = new System.Drawing.Point(131, 15);
            this.tbNameAccount.Name = "tbNameAccount";
            this.tbNameAccount.Size = new System.Drawing.Size(145, 20);
            this.tbNameAccount.TabIndex = 1;
            // 
            // tbNameDisplay
            // 
            this.tbNameDisplay.Location = new System.Drawing.Point(131, 20);
            this.tbNameDisplay.Name = "tbNameDisplay";
            this.tbNameDisplay.Size = new System.Drawing.Size(145, 20);
            this.tbNameDisplay.TabIndex = 2;
            // 
            // cbTypeAccount
            // 
            this.cbTypeAccount.FormattingEnabled = true;
            this.cbTypeAccount.Location = new System.Drawing.Point(131, 20);
            this.cbTypeAccount.Name = "cbTypeAccount";
            this.cbTypeAccount.Size = new System.Drawing.Size(143, 21);
            this.cbTypeAccount.TabIndex = 1;
            // 
            // AccountManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AccountManagement";
            this.Text = "AccountManagement";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cbTypeAccount;
        private System.Windows.Forms.Button btnTypeAccount;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbNameDisplay;
        private System.Windows.Forms.Button btnNameDisplay;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbNameAccount;
        private System.Windows.Forms.Button btnNameAccount;
    }
}