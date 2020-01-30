namespace personal_project
{
    partial class Form1
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
            this.resistor_btn = new System.Windows.Forms.Button();
            this.connect_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resistor_btn
            // 
            this.resistor_btn.Location = new System.Drawing.Point(13, 42);
            this.resistor_btn.Name = "resistor_btn";
            this.resistor_btn.Size = new System.Drawing.Size(75, 23);
            this.resistor_btn.TabIndex = 0;
            this.resistor_btn.Text = "resistor";
            this.resistor_btn.UseVisualStyleBackColor = true;
            this.resistor_btn.Click += new System.EventHandler(this.resistor_btn_Click);
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(13, 13);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(75, 23);
            this.connect_btn.TabIndex = 1;
            this.connect_btn.Text = "connect";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.resistor_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button resistor_btn;
        private System.Windows.Forms.Button connect_btn;
    }
}

