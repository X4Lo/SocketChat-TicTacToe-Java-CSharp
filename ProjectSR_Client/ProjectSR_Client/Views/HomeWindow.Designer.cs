namespace ProjectSR_Client
{
    partial class HomeWindow
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
            this.panel_header = new System.Windows.Forms.Panel();
            this.panel_2 = new System.Windows.Forms.Panel();
            this.panel_usersList = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_body = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_title = new System.Windows.Forms.Label();
            this.panel_2.SuspendLayout();
            this.panel_body.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(881, 47);
            this.panel_header.TabIndex = 2;
            // 
            // panel_2
            // 
            this.panel_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_2.Controls.Add(this.panel_usersList);
            this.panel_2.Controls.Add(this.label1);
            this.panel_2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_2.Location = new System.Drawing.Point(624, 0);
            this.panel_2.Name = "panel_2";
            this.panel_2.Size = new System.Drawing.Size(257, 666);
            this.panel_2.TabIndex = 1;
            // 
            // panel_usersList
            // 
            this.panel_usersList.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel_usersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_usersList.Location = new System.Drawing.Point(0, 36);
            this.panel_usersList.Name = "panel_usersList";
            this.panel_usersList.Size = new System.Drawing.Size(255, 628);
            this.panel_usersList.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Online players:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_body
            // 
            this.panel_body.Controls.Add(this.label_title);
            this.panel_body.Controls.Add(this.button1);
            this.panel_body.Controls.Add(this.richTextBox1);
            this.panel_body.Controls.Add(this.textBox1);
            this.panel_body.Controls.Add(this.panel_2);
            this.panel_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_body.Location = new System.Drawing.Point(0, 47);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(881, 666);
            this.panel_body.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(507, 605);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(24, 96);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(576, 503);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(24, 605);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(477, 35);
            this.textBox1.TabIndex = 2;
            // 
            // label_title
            // 
            this.label_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.Location = new System.Drawing.Point(0, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(624, 83);
            this.label_title.TabIndex = 5;
            this.label_title.Text = "Welcome";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HomeWindow
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 713);
            this.Controls.Add(this.panel_body);
            this.Controls.Add(this.panel_header);
            this.Name = "HomeWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomeWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.panel_2.ResumeLayout(false);
            this.panel_body.ResumeLayout(false);
            this.panel_body.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_header;
        public System.Windows.Forms.Panel panel_2;
        public System.Windows.Forms.Panel panel_usersList;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel panel_body;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label_title;
    }
}

