namespace PayMonitorUI
{
    partial class frmSalesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesReport));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProductID = new System.Windows.Forms.Label();
            this.lblStaff = new System.Windows.Forms.Label();
            this.lblTransactionCode = new System.Windows.Forms.Label();
            this.lblSalesID = new System.Windows.Forms.Label();
            this.txtProdName = new System.Windows.Forms.TextBox();
            this.txtProdId = new System.Windows.Forms.TextBox();
            this.txtStaffLastName = new System.Windows.Forms.TextBox();
            this.txtTransactionCode = new System.Windows.Forms.TextBox();
            this.txtSalesId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgSales = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.btnBackMainMenu = new System.Windows.Forms.Button();
            this.lblRoleType = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sales Report";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dtEnd);
            this.groupBox1.Controls.Add(this.dtStart);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblProductID);
            this.groupBox1.Controls.Add(this.lblStaff);
            this.groupBox1.Controls.Add(this.lblTransactionCode);
            this.groupBox1.Controls.Add(this.lblSalesID);
            this.groupBox1.Controls.Add(this.txtProdName);
            this.groupBox1.Controls.Add(this.txtProdId);
            this.groupBox1.Controls.Add(this.txtStaffLastName);
            this.groupBox1.Controls.Add(this.txtTransactionCode);
            this.groupBox1.Controls.Add(this.txtSalesId);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(29, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 394);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(14, 358);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(196, 20);
            this.dtEnd.TabIndex = 6;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(14, 311);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(196, 20);
            this.dtStart.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(12, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "End Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(11, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(11, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Product Name";
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.BackColor = System.Drawing.Color.Transparent;
            this.lblProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblProductID.Location = new System.Drawing.Point(11, 187);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(74, 17);
            this.lblProductID.TabIndex = 7;
            this.lblProductID.Text = "Product ID";
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.BackColor = System.Drawing.Color.Transparent;
            this.lblStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblStaff.Location = new System.Drawing.Point(11, 133);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(109, 17);
            this.lblStaff.TabIndex = 6;
            this.lblStaff.Text = "Staff Last Name";
            // 
            // lblTransactionCode
            // 
            this.lblTransactionCode.AutoSize = true;
            this.lblTransactionCode.BackColor = System.Drawing.Color.Transparent;
            this.lblTransactionCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTransactionCode.Location = new System.Drawing.Point(11, 80);
            this.lblTransactionCode.Name = "lblTransactionCode";
            this.lblTransactionCode.Size = new System.Drawing.Size(120, 17);
            this.lblTransactionCode.TabIndex = 5;
            this.lblTransactionCode.Text = "Transaction Code";
            // 
            // lblSalesID
            // 
            this.lblSalesID.AutoSize = true;
            this.lblSalesID.BackColor = System.Drawing.Color.Transparent;
            this.lblSalesID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSalesID.Location = new System.Drawing.Point(11, 28);
            this.lblSalesID.Name = "lblSalesID";
            this.lblSalesID.Size = new System.Drawing.Size(60, 17);
            this.lblSalesID.TabIndex = 3;
            this.lblSalesID.Text = "Sales ID";
            // 
            // txtProdName
            // 
            this.txtProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtProdName.Location = new System.Drawing.Point(11, 255);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Size = new System.Drawing.Size(199, 26);
            this.txtProdName.TabIndex = 4;
            // 
            // txtProdId
            // 
            this.txtProdId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtProdId.Location = new System.Drawing.Point(11, 207);
            this.txtProdId.Name = "txtProdId";
            this.txtProdId.Size = new System.Drawing.Size(199, 26);
            this.txtProdId.TabIndex = 3;
            this.txtProdId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProdId_KeyPress);
            // 
            // txtStaffLastName
            // 
            this.txtStaffLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtStaffLastName.Location = new System.Drawing.Point(11, 154);
            this.txtStaffLastName.Name = "txtStaffLastName";
            this.txtStaffLastName.Size = new System.Drawing.Size(199, 26);
            this.txtStaffLastName.TabIndex = 2;
            // 
            // txtTransactionCode
            // 
            this.txtTransactionCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTransactionCode.Location = new System.Drawing.Point(11, 100);
            this.txtTransactionCode.Name = "txtTransactionCode";
            this.txtTransactionCode.Size = new System.Drawing.Size(199, 26);
            this.txtTransactionCode.TabIndex = 1;
            this.txtTransactionCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransactionCode_KeyPress);
            // 
            // txtSalesId
            // 
            this.txtSalesId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSalesId.Location = new System.Drawing.Point(11, 49);
            this.txtSalesId.Name = "txtSalesId";
            this.txtSalesId.Size = new System.Drawing.Size(199, 26);
            this.txtSalesId.TabIndex = 0;
            this.txtSalesId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesId_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(193)))), ((int)(((byte)(66)))));
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(193)))), ((int)(((byte)(66)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(29, 480);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(226, 35);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgSales
            // 
            this.dgSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSales.Location = new System.Drawing.Point(276, 66);
            this.dgSales.Name = "dgSales";
            this.dgSales.Size = new System.Drawing.Size(435, 394);
            this.dgSales.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(351, 484);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 31);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total Sales: $ ";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSales.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.ForeColor = System.Drawing.Color.White;
            this.lblTotalSales.Location = new System.Drawing.Point(546, 484);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(165, 31);
            this.lblTotalSales.TabIndex = 0;
            this.lblTotalSales.Text = "0";
            this.lblTotalSales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBackMainMenu
            // 
            this.btnBackMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(193)))), ((int)(((byte)(66)))));
            this.btnBackMainMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(193)))), ((int)(((byte)(66)))));
            this.btnBackMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackMainMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBackMainMenu.Location = new System.Drawing.Point(512, 18);
            this.btnBackMainMenu.Name = "btnBackMainMenu";
            this.btnBackMainMenu.Size = new System.Drawing.Size(199, 31);
            this.btnBackMainMenu.TabIndex = 18;
            this.btnBackMainMenu.Text = "<< Back to Main Menu";
            this.btnBackMainMenu.UseVisualStyleBackColor = false;
            this.btnBackMainMenu.Click += new System.EventHandler(this.btnBackMainMenu_Click);
            // 
            // lblRoleType
            // 
            this.lblRoleType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRoleType.BackColor = System.Drawing.Color.Transparent;
            this.lblRoleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRoleType.Location = new System.Drawing.Point(200, 35);
            this.lblRoleType.Name = "lblRoleType";
            this.lblRoleType.Size = new System.Drawing.Size(131, 17);
            this.lblRoleType.TabIndex = 20;
            this.lblRoleType.Text = "Role Type";
            this.lblRoleType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblLastName.Location = new System.Drawing.Point(200, 18);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(131, 17);
            this.lblLastName.TabIndex = 19;
            this.lblLastName.Text = "LastName";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(276, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // frmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(64)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(745, 536);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRoleType);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.btnBackMainMenu);
            this.Controls.Add(this.lblTotalSales);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgSales);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.Label lblTransactionCode;
        private System.Windows.Forms.Label lblSalesID;
        private System.Windows.Forms.TextBox txtProdName;
        private System.Windows.Forms.TextBox txtProdId;
        private System.Windows.Forms.TextBox txtStaffLastName;
        private System.Windows.Forms.TextBox txtTransactionCode;
        private System.Windows.Forms.TextBox txtSalesId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgSales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Button btnBackMainMenu;
        private System.Windows.Forms.Label lblRoleType;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}