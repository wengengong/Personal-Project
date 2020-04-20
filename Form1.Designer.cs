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
            this.connect_btn = new System.Windows.Forms.Button();
            this.disconnect_btn = new System.Windows.Forms.Button();
            this.remove_btn = new System.Windows.Forms.Button();
            this.component_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.simulate_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.load_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connect_btn
            // 
            this.connect_btn.BackColor = System.Drawing.Color.Gainsboro;
            this.connect_btn.Location = new System.Drawing.Point(9, 9);
            this.connect_btn.Margin = new System.Windows.Forms.Padding(2);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(62, 19);
            this.connect_btn.TabIndex = 1;
            this.connect_btn.Text = "connect";
            this.connect_btn.UseVisualStyleBackColor = false;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // disconnect_btn
            // 
            this.disconnect_btn.Location = new System.Drawing.Point(8, 32);
            this.disconnect_btn.Margin = new System.Windows.Forms.Padding(2);
            this.disconnect_btn.Name = "disconnect_btn";
            this.disconnect_btn.Size = new System.Drawing.Size(63, 19);
            this.disconnect_btn.TabIndex = 2;
            this.disconnect_btn.Text = "disconnect";
            this.disconnect_btn.UseVisualStyleBackColor = true;
            this.disconnect_btn.Click += new System.EventHandler(this.disconnect_btn_Click);
            // 
            // remove_btn
            // 
            this.remove_btn.Location = new System.Drawing.Point(8, 55);
            this.remove_btn.Margin = new System.Windows.Forms.Padding(2);
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.Size = new System.Drawing.Size(63, 19);
            this.remove_btn.TabIndex = 5;
            this.remove_btn.Text = "remove";
            this.remove_btn.UseVisualStyleBackColor = true;
            this.remove_btn.Click += new System.EventHandler(this.remove_btn_Click);
            // 
            // component_flowLayoutPanel
            // 
            this.component_flowLayoutPanel.AutoScroll = true;
            this.component_flowLayoutPanel.Location = new System.Drawing.Point(5, 78);
            this.component_flowLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.component_flowLayoutPanel.Name = "component_flowLayoutPanel";
            this.component_flowLayoutPanel.Size = new System.Drawing.Size(89, 278);
            this.component_flowLayoutPanel.TabIndex = 9;
            // 
            // simulate_btn
            // 
            this.simulate_btn.Location = new System.Drawing.Point(513, 333);
            this.simulate_btn.Name = "simulate_btn";
            this.simulate_btn.Size = new System.Drawing.Size(75, 23);
            this.simulate_btn.TabIndex = 11;
            this.simulate_btn.Text = "simulate";
            this.simulate_btn.UseVisualStyleBackColor = true;
            this.simulate_btn.Click += new System.EventHandler(this.simulate_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(513, 7);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 12;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // load_btn
            // 
            this.load_btn.Location = new System.Drawing.Point(432, 7);
            this.load_btn.Name = "load_btn";
            this.load_btn.Size = new System.Drawing.Size(75, 23);
            this.load_btn.TabIndex = 13;
            this.load_btn.Text = "Load";
            this.load_btn.UseVisualStyleBackColor = true;
            this.load_btn.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.load_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.simulate_btn);
            this.Controls.Add(this.component_flowLayoutPanel);
            this.Controls.Add(this.remove_btn);
            this.Controls.Add(this.disconnect_btn);
            this.Controls.Add(this.connect_btn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.Button disconnect_btn;
        private System.Windows.Forms.Button remove_btn;
        private System.Windows.Forms.FlowLayoutPanel component_flowLayoutPanel;
        private System.Windows.Forms.Button simulate_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button load_btn;
    }
}

