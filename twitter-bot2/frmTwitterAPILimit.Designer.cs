namespace twitter_bot2
{
    partial class frmTwitterAPILimit
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
            this.txtMSG = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMSG
            // 
            this.txtMSG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMSG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSG.Location = new System.Drawing.Point(12, 12);
            this.txtMSG.Multiline = true;
            this.txtMSG.Name = "txtMSG";
            this.txtMSG.Size = new System.Drawing.Size(998, 330);
            this.txtMSG.TabIndex = 0;
            // 
            // frmTwitterAPILimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 354);
            this.Controls.Add(this.txtMSG);
            this.Name = "frmTwitterAPILimit";
            this.Text = "Twitter API Limit";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.frmTwitterAPILimit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMSG;
    }
}