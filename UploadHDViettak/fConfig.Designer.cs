namespace UploadHDViettak
{
    partial class fConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tUrl = new System.Windows.Forms.TextBox();
            this.tUser = new System.Windows.Forms.TextBox();
            this.tPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bGhi = new System.Windows.Forms.Button();
            this.tPasssql = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tUsersql = new System.Windows.Forms.TextBox();
            this.tServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tDatabase = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Url";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User";
            // 
            // tUrl
            // 
            this.tUrl.Location = new System.Drawing.Point(106, 122);
            this.tUrl.Name = "tUrl";
            this.tUrl.Size = new System.Drawing.Size(329, 20);
            this.tUrl.TabIndex = 2;
            this.tUrl.Text = "https://hddt.v-invoiced.vn:8443/eInvoicing/API/";
            // 
            // tUser
            // 
            this.tUser.Location = new System.Drawing.Point(106, 155);
            this.tUser.Name = "tUser";
            this.tUser.Size = new System.Drawing.Size(203, 20);
            this.tUser.TabIndex = 3;
            this.tUser.Text = "0312588549";
            // 
            // tPass
            // 
            this.tPass.Location = new System.Drawing.Point(106, 187);
            this.tPass.Name = "tPass";
            this.tPass.PasswordChar = '*';
            this.tPass.Size = new System.Drawing.Size(203, 20);
            this.tPass.TabIndex = 5;
            this.tPass.Text = "Admin@123";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pass";
            // 
            // bGhi
            // 
            this.bGhi.Location = new System.Drawing.Point(200, 234);
            this.bGhi.Name = "bGhi";
            this.bGhi.Size = new System.Drawing.Size(75, 23);
            this.bGhi.TabIndex = 6;
            this.bGhi.Text = "Ghi";
            this.bGhi.UseVisualStyleBackColor = true;
            this.bGhi.Click += new System.EventHandler(this.bGhi_Click);
            // 
            // tPasssql
            // 
            this.tPasssql.Location = new System.Drawing.Point(281, 55);
            this.tPasssql.Name = "tPasssql";
            this.tPasssql.PasswordChar = '*';
            this.tPasssql.Size = new System.Drawing.Size(122, 20);
            this.tPasssql.TabIndex = 12;
            this.tPasssql.Text = "sa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Pass sql";
            // 
            // tUsersql
            // 
            this.tUsersql.Location = new System.Drawing.Point(106, 55);
            this.tUsersql.Name = "tUsersql";
            this.tUsersql.Size = new System.Drawing.Size(90, 20);
            this.tUsersql.TabIndex = 10;
            this.tUsersql.Text = "sa";
            // 
            // tServer
            // 
            this.tServer.Location = new System.Drawing.Point(106, 22);
            this.tServer.Name = "tServer";
            this.tServer.Size = new System.Drawing.Size(90, 20);
            this.tServer.TabIndex = 9;
            this.tServer.Text = ".\\SQL2012";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "User sql";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Dataserver";
            // 
            // tDatabase
            // 
            this.tDatabase.Location = new System.Drawing.Point(281, 18);
            this.tDatabase.Name = "tDatabase";
            this.tDatabase.Size = new System.Drawing.Size(122, 20);
            this.tDatabase.TabIndex = 14;
            this.tDatabase.Text = "CBABPMHD";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Dataserver";
            // 
            // fConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 269);
            this.Controls.Add(this.tDatabase);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tPasssql);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tUsersql);
            this.Controls.Add(this.tServer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bGhi);
            this.Controls.Add(this.tPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tUser);
            this.Controls.Add(this.tUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fConfig";
            this.Text = "Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tUrl;
        private System.Windows.Forms.TextBox tUser;
        private System.Windows.Forms.TextBox tPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bGhi;
        private System.Windows.Forms.TextBox tPasssql;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tUsersql;
        private System.Windows.Forms.TextBox tServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tDatabase;
        private System.Windows.Forms.Label label7;
    }
}

