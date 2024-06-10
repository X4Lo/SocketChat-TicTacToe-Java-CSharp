namespace ProjectSR_Client.Services
{
    partial class GameInviteRequest
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
            this.btn_accept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_refuse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_accept
            // 
            this.btn_accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_accept.Location = new System.Drawing.Point(97, 147);
            this.btn_accept.Name = "btn_accept";
            this.btn_accept.Size = new System.Drawing.Size(137, 37);
            this.btn_accept.TabIndex = 3;
            this.btn_accept.Text = "Accept";
            this.btn_accept.UseVisualStyleBackColor = true;
            this.btn_accept.Click += new System.EventHandler(this.btn_accept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "player has invited you to a game of gameName";
            // 
            // btn_refuse
            // 
            this.btn_refuse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refuse.Location = new System.Drawing.Point(240, 147);
            this.btn_refuse.Name = "btn_refuse";
            this.btn_refuse.Size = new System.Drawing.Size(137, 37);
            this.btn_refuse.TabIndex = 4;
            this.btn_refuse.Text = "Refuse";
            this.btn_refuse.UseVisualStyleBackColor = true;
            this.btn_refuse.Click += new System.EventHandler(this.btn_refuse_Click);
            // 
            // GameInviteRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 209);
            this.Controls.Add(this.btn_refuse);
            this.Controls.Add(this.btn_accept);
            this.Controls.Add(this.label1);
            this.Name = "GameInviteRequest";
            this.Text = "GameInviteRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_accept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_refuse;
    }
}