namespace PayMonitorUI
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnOrdering = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnSalesreport = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblRoleLabel = new System.Windows.Forms.Label();
            this.lblEmpLabel = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblRoleType = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccount
            // 
            this.btnAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(193)))), ((int)(((byte)(66)))));
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAccount.ForeColor = System.Drawing.Color.White;
            this.btnAccount.Location = new System.Drawing.Point(281, 193);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(257, 97);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.Text = "Manage Accounts";
            this.btnAccount.UseVisualStyleBackColor = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnOrdering
            // 
            this.btnOrdering.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(193)))), ((int)(((byte)(66)))));
            this.btnOrdering.FlatAppearance.BorderSize = 0;
            this.btnOrdering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrdering.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnOrdering.ForeColor = System.Drawing.Color.White;
            this.btnOrdering.Location = new System.Drawing.Point(27, 89);
            this.btnOrdering.Name = "btnOrdering";
            this.btnOrdering.Size = new System.Drawing.Size(249, 97);
            this.btnOrdering.TabIndex = 2;
            this.btnOrdering.Text = "Ordering";
            this.btnOrdering.UseVisualStyleBackColor = false;
            this.btnOrdering.Click += new System.EventHandler(this.btnOrdering_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(193)))), ((int)(((byte)(66)))));
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnInventory.ForeColor = System.Drawing.Color.White;
            this.btnInventory.Location = new System.Drawing.Point(281, 89);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(257, 97);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnSalesreport
            // 
            this.btnSalesreport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(193)))), ((int)(((byte)(66)))));
            this.btnSalesreport.FlatAppearance.BorderSize = 0;
            this.btnSalesreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnSalesreport.ForeColor = System.Drawing.Color.White;
            this.btnSalesreport.Location = new System.Drawing.Point(27, 193);
            this.btnSalesreport.Name = "btnSalesreport";
            this.btnSalesreport.Size = new System.Drawing.Size(249, 97);
            this.btnSalesreport.TabIndex = 4;
            this.btnSalesreport.Text = "Sales Report";
            this.btnSalesreport.UseVisualStyleBackColor = false;
            this.btnSalesreport.Click += new System.EventHandler(this.btnSalesreport_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(450, 33);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(88, 35);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblRoleLabel
            // 
            this.lblRoleLabel.AutoSize = true;
            this.lblRoleLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblRoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRoleLabel.ForeColor = System.Drawing.Color.White;
            this.lblRoleLabel.Location = new System.Drawing.Point(50, 48);
            this.lblRoleLabel.Name = "lblRoleLabel";
            this.lblRoleLabel.Size = new System.Drawing.Size(41, 17);
            this.lblRoleLabel.TabIndex = 6;
            this.lblRoleLabel.Text = "Role:";
            this.lblRoleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmpLabel
            // 
            this.lblEmpLabel.AutoSize = true;
            this.lblEmpLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblEmpLabel.ForeColor = System.Drawing.Color.White;
            this.lblEmpLabel.Location = new System.Drawing.Point(26, 30);
            this.lblEmpLabel.Name = "lblEmpLabel";
            this.lblEmpLabel.Size = new System.Drawing.Size(65, 17);
            this.lblEmpLabel.TabIndex = 7;
            this.lblEmpLabel.Text = "L. Name:";
            this.lblEmpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastName
            // 
            this.lblLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblLastName.ForeColor = System.Drawing.Color.White;
            this.lblLastName.Location = new System.Drawing.Point(90, 31);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(131, 17);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "LastName";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLastName.Click += new System.EventHandler(this.lblLastName_Click);
            // 
            // lblRoleType
            // 
            this.lblRoleType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRoleType.BackColor = System.Drawing.Color.Transparent;
            this.lblRoleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRoleType.ForeColor = System.Drawing.Color.White;
            this.lblRoleType.Location = new System.Drawing.Point(90, 48);
            this.lblRoleType.Name = "lblRoleType";
            this.lblRoleType.Size = new System.Drawing.Size(131, 17);
            this.lblRoleType.TabIndex = 9;
            this.lblRoleType.Text = "Role Type";
            this.lblRoleType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRoleType.Click += new System.EventHandler(this.lblRoleType_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(227, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(64)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(568, 326);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRoleType);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblEmpLabel);
            this.Controls.Add(this.lblRoleLabel);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSalesreport);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnOrdering);
            this.Controls.Add(this.btnAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnOrdering;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnSalesreport;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblRoleLabel;
        private System.Windows.Forms.Label lblEmpLabel;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblRoleType;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}