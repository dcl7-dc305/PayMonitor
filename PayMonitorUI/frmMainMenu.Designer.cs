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
            this.button5 = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(281, 167);
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
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome";
            // 
            // btnOrdering
            // 
            this.btnOrdering.Location = new System.Drawing.Point(26, 63);
            this.btnOrdering.Name = "btnOrdering";
            this.btnOrdering.Size = new System.Drawing.Size(249, 97);
            this.btnOrdering.TabIndex = 2;
            this.btnOrdering.Text = "Ordering";
            this.btnOrdering.UseVisualStyleBackColor = true;
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(281, 63);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(257, 97);
            this.btnInventory.TabIndex = 3;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            // 
            // btnSalesreport
            // 
            this.btnSalesreport.Location = new System.Drawing.Point(26, 167);
            this.btnSalesreport.Name = "btnSalesreport";
            this.btnSalesreport.Size = new System.Drawing.Size(249, 97);
            this.btnSalesreport.TabIndex = 4;
            this.btnSalesreport.Text = "Sales Report";
            this.btnSalesreport.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(450, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 22);
            this.button5.TabIndex = 5;
            this.button5.Text = "Logout";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(81, 26);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(0, 13);
            this.lblRole.TabIndex = 6;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 312);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnSalesreport);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnOrdering);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccount);
            this.MaximumSize = new System.Drawing.Size(584, 351);
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
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblRole;
    }
}