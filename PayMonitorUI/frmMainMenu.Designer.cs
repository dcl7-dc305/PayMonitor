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
            this.btnAccount = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOrdering = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnSalesreport = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblRoleLabel = new System.Windows.Forms.Label();
            this.lblEmpLabel = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblRoleType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccount
            // 
            this.btnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnAccount.Location = new System.Drawing.Point(281, 223);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(257, 97);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.Text = "Manage Accounts";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnOrdering
            // 
            this.btnOrdering.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnOrdering.Location = new System.Drawing.Point(27, 120);
            this.btnOrdering.Name = "btnOrdering";
            this.btnOrdering.Size = new System.Drawing.Size(249, 97);
            this.btnOrdering.TabIndex = 2;
            this.btnOrdering.Text = "Ordering";
            this.btnOrdering.UseVisualStyleBackColor = true;
            this.btnOrdering.Click += new System.EventHandler(this.btnOrdering_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnInventory.Location = new System.Drawing.Point(281, 119);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(257, 97);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnSalesreport
            // 
            this.btnSalesreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnSalesreport.Location = new System.Drawing.Point(27, 224);
            this.btnSalesreport.Name = "btnSalesreport";
            this.btnSalesreport.Size = new System.Drawing.Size(249, 97);
            this.btnSalesreport.TabIndex = 4;
            this.btnSalesreport.Text = "Sales Report";
            this.btnSalesreport.UseVisualStyleBackColor = true;
            this.btnSalesreport.Click += new System.EventHandler(this.btnSalesreport_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(450, 60);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(88, 35);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblRoleLabel
            // 
            this.lblRoleLabel.AutoSize = true;
            this.lblRoleLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblRoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRoleLabel.Location = new System.Drawing.Point(50, 78);
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
            this.lblEmpLabel.Location = new System.Drawing.Point(26, 60);
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
            this.lblLastName.Location = new System.Drawing.Point(90, 61);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(131, 17);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "LastName";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRoleType
            // 
            this.lblRoleType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRoleType.BackColor = System.Drawing.Color.Transparent;
            this.lblRoleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRoleType.Location = new System.Drawing.Point(90, 78);
            this.lblRoleType.Name = "lblRoleType";
            this.lblRoleType.Size = new System.Drawing.Size(131, 17);
            this.lblRoleType.TabIndex = 9;
            this.lblRoleType.Text = "Role Type";
            this.lblRoleType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 343);
            this.Controls.Add(this.lblRoleType);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblEmpLabel);
            this.Controls.Add(this.lblRoleLabel);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSalesreport);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnOrdering);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOrdering;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnSalesreport;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblRoleLabel;
        private System.Windows.Forms.Label lblEmpLabel;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblRoleType;
    }
}