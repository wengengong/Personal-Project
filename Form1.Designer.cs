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
            this.disconnect_btn = new System.Windows.Forms.Button();
            this.battery_btn = new System.Windows.Forms.Button();
            this.LED_btn = new System.Windows.Forms.Button();
            this.remove_btn = new System.Windows.Forms.Button();
            this.switch_btn = new System.Windows.Forms.Button();
            this.component_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.joint_btn = new System.Windows.Forms.Button();
            this.simulate_btn = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resistor_btn
            // 
            this.resistor_btn.Location = new System.Drawing.Point(112, 106);
            this.resistor_btn.Margin = new System.Windows.Forms.Padding(2);
            this.resistor_btn.Name = "resistor_btn";
            this.resistor_btn.Size = new System.Drawing.Size(63, 19);
            this.resistor_btn.TabIndex = 0;
            this.resistor_btn.Text = "resistor";
            this.resistor_btn.UseVisualStyleBackColor = true;
            this.resistor_btn.Click += new System.EventHandler(this.resistor_btn_Click);
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
            // battery_btn
            // 
            this.battery_btn.Location = new System.Drawing.Point(112, 81);
            this.battery_btn.Margin = new System.Windows.Forms.Padding(2);
            this.battery_btn.Name = "battery_btn";
            this.battery_btn.Size = new System.Drawing.Size(63, 22);
            this.battery_btn.TabIndex = 3;
            this.battery_btn.Text = "battery";
            this.battery_btn.UseVisualStyleBackColor = true;
            this.battery_btn.Click += new System.EventHandler(this.battery_btn_Click);
            // 
            // LED_btn
            // 
            this.LED_btn.Location = new System.Drawing.Point(112, 128);
            this.LED_btn.Margin = new System.Windows.Forms.Padding(2);
            this.LED_btn.Name = "LED_btn";
            this.LED_btn.Size = new System.Drawing.Size(63, 19);
            this.LED_btn.TabIndex = 4;
            this.LED_btn.Text = "LED";
            this.LED_btn.UseVisualStyleBackColor = true;
            this.LED_btn.Click += new System.EventHandler(this.LED_btn_Click);
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
            // switch_btn
            // 
            this.switch_btn.Location = new System.Drawing.Point(112, 151);
            this.switch_btn.Margin = new System.Windows.Forms.Padding(2);
            this.switch_btn.Name = "switch_btn";
            this.switch_btn.Size = new System.Drawing.Size(63, 19);
            this.switch_btn.TabIndex = 7;
            this.switch_btn.Text = "switch";
            this.switch_btn.UseVisualStyleBackColor = true;
            this.switch_btn.Click += new System.EventHandler(this.switch_btn_Click);
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
            // joint_btn
            // 
            this.joint_btn.Location = new System.Drawing.Point(112, 174);
            this.joint_btn.Margin = new System.Windows.Forms.Padding(2);
            this.joint_btn.Name = "joint_btn";
            this.joint_btn.Size = new System.Drawing.Size(63, 19);
            this.joint_btn.TabIndex = 10;
            this.joint_btn.Text = "joint";
            this.joint_btn.UseVisualStyleBackColor = true;
            this.joint_btn.Click += new System.EventHandler(this.joint_btn_Click);
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
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(513, 7);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(432, 7);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 13;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.simulate_btn);
            this.Controls.Add(this.joint_btn);
            this.Controls.Add(this.component_flowLayoutPanel);
            this.Controls.Add(this.switch_btn);
            this.Controls.Add(this.remove_btn);
            this.Controls.Add(this.LED_btn);
            this.Controls.Add(this.battery_btn);
            this.Controls.Add(this.disconnect_btn);
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.resistor_btn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button resistor_btn;
        private System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.Button disconnect_btn;
        private System.Windows.Forms.Button battery_btn;
        private System.Windows.Forms.Button LED_btn;
        private System.Windows.Forms.Button remove_btn;
        private System.Windows.Forms.Button switch_btn;
        private System.Windows.Forms.FlowLayoutPanel component_flowLayoutPanel;
        private System.Windows.Forms.Button joint_btn;
        private System.Windows.Forms.Button simulate_btn;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_load;
    }
}

