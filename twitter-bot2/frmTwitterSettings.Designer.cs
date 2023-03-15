namespace twitter_bot2
{
    partial class frmTwitterSettings
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
            this.txtTwitterConsumerKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTwitterConsumerSecret = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTwitterAccessToken = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTwitterTokenSecret = new System.Windows.Forms.TextBox();
            this.btnTwitterAPITest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTwitterConsumerKey
            // 
            this.txtTwitterConsumerKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTwitterConsumerKey.Location = new System.Drawing.Point(24, 51);
            this.txtTwitterConsumerKey.Multiline = true;
            this.txtTwitterConsumerKey.Name = "txtTwitterConsumerKey";
            this.txtTwitterConsumerKey.Size = new System.Drawing.Size(326, 29);
            this.txtTwitterConsumerKey.TabIndex = 23;
            this.txtTwitterConsumerKey.TextChanged += new System.EventHandler(this.txtAdditionalMessage_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Twitter Aps API Consumerkey";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Twitter Aps API ConsumerSecret";
            // 
            // txtTwitterConsumerSecret
            // 
            this.txtTwitterConsumerSecret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTwitterConsumerSecret.Location = new System.Drawing.Point(24, 119);
            this.txtTwitterConsumerSecret.Multiline = true;
            this.txtTwitterConsumerSecret.Name = "txtTwitterConsumerSecret";
            this.txtTwitterConsumerSecret.Size = new System.Drawing.Size(326, 29);
            this.txtTwitterConsumerSecret.TabIndex = 25;
            this.txtTwitterConsumerSecret.TextChanged += new System.EventHandler(this.txtTwitterConsumerSecret_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Twitter Aps API AccessToken";
            // 
            // txtTwitterAccessToken
            // 
            this.txtTwitterAccessToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTwitterAccessToken.Location = new System.Drawing.Point(24, 189);
            this.txtTwitterAccessToken.Multiline = true;
            this.txtTwitterAccessToken.Name = "txtTwitterAccessToken";
            this.txtTwitterAccessToken.Size = new System.Drawing.Size(326, 29);
            this.txtTwitterAccessToken.TabIndex = 27;
            this.txtTwitterAccessToken.TextChanged += new System.EventHandler(this.txtTwitterAccessToken_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Twitter Aps API AccessTokenSecret";
            // 
            // txtTwitterTokenSecret
            // 
            this.txtTwitterTokenSecret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTwitterTokenSecret.Location = new System.Drawing.Point(24, 260);
            this.txtTwitterTokenSecret.Multiline = true;
            this.txtTwitterTokenSecret.Name = "txtTwitterTokenSecret";
            this.txtTwitterTokenSecret.Size = new System.Drawing.Size(326, 29);
            this.txtTwitterTokenSecret.TabIndex = 29;
            this.txtTwitterTokenSecret.TextChanged += new System.EventHandler(this.txtTwitterTokenSecret_TextChanged);
            // 
            // btnTwitterAPITest
            // 
            this.btnTwitterAPITest.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnTwitterAPITest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTwitterAPITest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTwitterAPITest.Location = new System.Drawing.Point(26, 305);
            this.btnTwitterAPITest.Name = "btnTwitterAPITest";
            this.btnTwitterAPITest.Size = new System.Drawing.Size(324, 51);
            this.btnTwitterAPITest.TabIndex = 36;
            this.btnTwitterAPITest.Text = "Twitter Verbindung testen";
            this.btnTwitterAPITest.UseVisualStyleBackColor = false;
            this.btnTwitterAPITest.Click += new System.EventHandler(this.btnTwitterAPITest_ClickAsync);
            // 
            // frmTwitterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 380);
            this.Controls.Add(this.btnTwitterAPITest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTwitterTokenSecret);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTwitterAccessToken);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTwitterConsumerSecret);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTwitterConsumerKey);
            this.Name = "frmTwitterSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JTL Wawi Twitter Einstellungen";
            this.Load += new System.EventHandler(this.frmTwitterSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTwitterConsumerKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTwitterConsumerSecret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTwitterAccessToken;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTwitterTokenSecret;
        private System.Windows.Forms.Button btnTwitterAPITest;
    }
}