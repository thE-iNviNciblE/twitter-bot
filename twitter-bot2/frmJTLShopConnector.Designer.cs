namespace twitter_bot2
{
    partial class frmJTLShopConnector
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
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.btnJTLShopConnectorPluginTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Domainname z.B. meinedomain.de";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDomain
            // 
            this.txtDomain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDomain.Location = new System.Drawing.Point(37, 55);
            this.txtDomain.Multiline = true;
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(326, 29);
            this.txtDomain.TabIndex = 25;
            this.txtDomain.TextChanged += new System.EventHandler(this.txtDomain_TextChanged);
            // 
            // btnJTLShopConnectorPluginTest
            // 
            this.btnJTLShopConnectorPluginTest.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnJTLShopConnectorPluginTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJTLShopConnectorPluginTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJTLShopConnectorPluginTest.Location = new System.Drawing.Point(368, 55);
            this.btnJTLShopConnectorPluginTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnJTLShopConnectorPluginTest.Name = "btnJTLShopConnectorPluginTest";
            this.btnJTLShopConnectorPluginTest.Size = new System.Drawing.Size(104, 29);
            this.btnJTLShopConnectorPluginTest.TabIndex = 27;
            this.btnJTLShopConnectorPluginTest.Text = "Testen";
            this.btnJTLShopConnectorPluginTest.UseVisualStyleBackColor = false;
            this.btnJTLShopConnectorPluginTest.Click += new System.EventHandler(this.btnJTLShopConnectorPluginTest_Click);
            // 
            // frmJTLShopConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 131);
            this.Controls.Add(this.btnJTLShopConnectorPluginTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDomain);
            this.Name = "frmJTLShopConnector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JTL Shop Connector";
            this.Load += new System.EventHandler(this.frmJTLShopConnector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Button btnJTLShopConnectorPluginTest;
    }
}