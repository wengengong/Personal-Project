﻿namespace personal_project
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
            this.SuspendLayout();
            // 
            // resistor_btn
            // 
            this.resistor_btn.Location = new System.Drawing.Point(12, 99);
            this.resistor_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resistor_btn.Name = "resistor_btn";
            this.resistor_btn.Size = new System.Drawing.Size(84, 23);
            this.resistor_btn.TabIndex = 0;
            this.resistor_btn.Text = "resistor";
            this.resistor_btn.UseVisualStyleBackColor = true;
            this.resistor_btn.Click += new System.EventHandler(this.resistor_btn_Click);
            // 
            // connect_btn
            // 
            this.connect_btn.BackColor = System.Drawing.Color.Gainsboro;
            this.connect_btn.Location = new System.Drawing.Point(13, 14);
            this.connect_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(83, 23);
            this.connect_btn.TabIndex = 1;
            this.connect_btn.Text = "connect";
            this.connect_btn.UseVisualStyleBackColor = false;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // disconnect_btn
            // 
            this.disconnect_btn.Location = new System.Drawing.Point(12, 42);
            this.disconnect_btn.Name = "disconnect_btn";
            this.disconnect_btn.Size = new System.Drawing.Size(84, 23);
            this.disconnect_btn.TabIndex = 2;
            this.disconnect_btn.Text = "disconnect";
            this.disconnect_btn.UseVisualStyleBackColor = true;
            this.disconnect_btn.Click += new System.EventHandler(this.disconnect_btn_Click);
            // 
            // battery_btn
            // 
            this.battery_btn.Location = new System.Drawing.Point(12, 127);
            this.battery_btn.Name = "battery_btn";
            this.battery_btn.Size = new System.Drawing.Size(84, 27);
            this.battery_btn.TabIndex = 3;
            this.battery_btn.Text = "battery";
            this.battery_btn.UseVisualStyleBackColor = true;
            // 
            // LED_btn
            // 
            this.LED_btn.Location = new System.Drawing.Point(12, 160);
            this.LED_btn.Name = "LED_btn";
            this.LED_btn.Size = new System.Drawing.Size(84, 23);
            this.LED_btn.TabIndex = 4;
            this.LED_btn.Text = "LED";
            this.LED_btn.UseVisualStyleBackColor = true;
            // 
            // remove_btn
            // 
            this.remove_btn.Location = new System.Drawing.Point(12, 71);
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.Size = new System.Drawing.Size(84, 23);
            this.remove_btn.TabIndex = 5;
            this.remove_btn.Text = "remove";
            this.remove_btn.UseVisualStyleBackColor = true;
            this.remove_btn.Click += new System.EventHandler(this.remove_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.remove_btn);
            this.Controls.Add(this.LED_btn);
            this.Controls.Add(this.battery_btn);
            this.Controls.Add(this.disconnect_btn);
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.resistor_btn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
    }
}

