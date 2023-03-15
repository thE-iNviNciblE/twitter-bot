namespace twitter_bot2
{
    partial class frmDatenbank
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
            this.txtMSSQLSernameInstanz = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMSSQLDatebankname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMSSQLDatenbankBenutzername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMSSQLDatenbankPasswort = new System.Windows.Forms.TextBox();
            this.btnJTLWawiReadIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "MSSQL-Server \\ Instanz (Meist \\JTLWAWI)";
            // 
            // txtMSSQLSernameInstanz
            // 
            this.txtMSSQLSernameInstanz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSSQLSernameInstanz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMSSQLSernameInstanz.Location = new System.Drawing.Point(26, 53);
            this.txtMSSQLSernameInstanz.Multiline = true;
            this.txtMSSQLSernameInstanz.Name = "txtMSSQLSernameInstanz";
            this.txtMSSQLSernameInstanz.Size = new System.Drawing.Size(326, 29);
            this.txtMSSQLSernameInstanz.TabIndex = 27;
            this.txtMSSQLSernameInstanz.TextChanged += new System.EventHandler(this.txtMSSQLSernameInstanz_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Datenbankname (Standard: eazybusiness)";
            // 
            // txtMSSQLDatebankname
            // 
            this.txtMSSQLDatebankname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSSQLDatebankname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMSSQLDatebankname.Location = new System.Drawing.Point(25, 122);
            this.txtMSSQLDatebankname.Multiline = true;
            this.txtMSSQLDatebankname.Name = "txtMSSQLDatebankname";
            this.txtMSSQLDatebankname.Size = new System.Drawing.Size(326, 29);
            this.txtMSSQLDatebankname.TabIndex = 29;
            this.txtMSSQLDatebankname.TextChanged += new System.EventHandler(this.txtMSSQLDatebankname_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Datenbank-Benutzername (Standard: sa)";
            // 
            // txtMSSQLDatenbankBenutzername
            // 
            this.txtMSSQLDatenbankBenutzername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSSQLDatenbankBenutzername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMSSQLDatenbankBenutzername.Location = new System.Drawing.Point(26, 193);
            this.txtMSSQLDatenbankBenutzername.Multiline = true;
            this.txtMSSQLDatenbankBenutzername.Name = "txtMSSQLDatenbankBenutzername";
            this.txtMSSQLDatenbankBenutzername.Size = new System.Drawing.Size(326, 29);
            this.txtMSSQLDatenbankBenutzername.TabIndex = 31;
            this.txtMSSQLDatenbankBenutzername.TextChanged += new System.EventHandler(this.txtMSSQLDatenbankBenutzername_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Datenbank-Passwort (Standard: sa04jT14)";
            // 
            // txtMSSQLDatenbankPasswort
            // 
            this.txtMSSQLDatenbankPasswort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSSQLDatenbankPasswort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMSSQLDatenbankPasswort.Location = new System.Drawing.Point(26, 265);
            this.txtMSSQLDatenbankPasswort.Multiline = true;
            this.txtMSSQLDatenbankPasswort.Name = "txtMSSQLDatenbankPasswort";
            this.txtMSSQLDatenbankPasswort.PasswordChar = '*';
            this.txtMSSQLDatenbankPasswort.Size = new System.Drawing.Size(326, 29);
            this.txtMSSQLDatenbankPasswort.TabIndex = 33;
            this.txtMSSQLDatenbankPasswort.TextChanged += new System.EventHandler(this.txtMSSQLDatenbankPasswort_TextChanged);
            // 
            // btnJTLWawiReadIn
            // 
            this.btnJTLWawiReadIn.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnJTLWawiReadIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJTLWawiReadIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJTLWawiReadIn.Location = new System.Drawing.Point(26, 315);
            this.btnJTLWawiReadIn.Name = "btnJTLWawiReadIn";
            this.btnJTLWawiReadIn.Size = new System.Drawing.Size(324, 51);
            this.btnJTLWawiReadIn.TabIndex = 35;
            this.btnJTLWawiReadIn.Text = "Datenbankverbindung testen";
            this.btnJTLWawiReadIn.UseVisualStyleBackColor = false;
            this.btnJTLWawiReadIn.Click += new System.EventHandler(this.btnJTLWawiReadIn_Click);
            // 
            // frmDatenbank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 378);
            this.Controls.Add(this.btnJTLWawiReadIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMSSQLDatenbankPasswort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMSSQLDatenbankBenutzername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMSSQLDatebankname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMSSQLSernameInstanz);
            this.Name = "frmDatenbank";
            this.Text = "JTL Wawi Datenbankverbindung";
            this.Load += new System.EventHandler(this.frmDatenbank_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMSSQLSernameInstanz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMSSQLDatebankname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMSSQLDatenbankBenutzername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMSSQLDatenbankPasswort;
        private System.Windows.Forms.Button btnJTLWawiReadIn;
    }
}