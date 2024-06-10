namespace ProjectSR_Client
{
    partial class LoginForm
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
            this.tbox_username = new System.Windows.Forms.TextBox();
            this.button_confirm = new System.Windows.Forms.Button();
            this.tbox_ip = new System.Windows.Forms.TextBox();
            this.tbox_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome, choose a username to start playing!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbox_username
            // 
            this.tbox_username.AcceptsReturn = true;
            this.tbox_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_username.Location = new System.Drawing.Point(90, 112);
            this.tbox_username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbox_username.Name = "tbox_username";
            this.tbox_username.Size = new System.Drawing.Size(252, 35);
            this.tbox_username.TabIndex = 1;
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(392, 112);
            this.button_confirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(112, 35);
            this.button_confirm.TabIndex = 2;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbox_ip
            // 
            this.tbox_ip.AcceptsReturn = true;
            this.tbox_ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_ip.Location = new System.Drawing.Point(147, 272);
            this.tbox_ip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbox_ip.Name = "tbox_ip";
            this.tbox_ip.Size = new System.Drawing.Size(228, 35);
            this.tbox_ip.TabIndex = 3;
            this.tbox_ip.Text = "127.0.10.1";
            // 
            // tbox_port
            // 
            this.tbox_port.AcceptsReturn = true;
            this.tbox_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbox_port.Location = new System.Drawing.Point(147, 317);
            this.tbox_port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbox_port.Name = "tbox_port";
            this.tbox_port.Size = new System.Drawing.Size(87, 35);
            this.tbox_port.TabIndex = 4;
            this.tbox_port.Text = "12345";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 229);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 275);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 320);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.button_confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 192);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbox_port);
            this.Controls.Add(this.tbox_ip);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.tbox_username);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_username;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.TextBox tbox_ip;
        private System.Windows.Forms.TextBox tbox_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}