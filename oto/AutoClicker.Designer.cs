namespace oto
{
    partial class AutoClicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_stop = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.numericUpDown_Delay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_stop = new System.Windows.Forms.Label();
            this.label_run = new System.Windows.Forms.Label();
            this.label_startguide = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.NumericUpDown_Kliks = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Delay)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Kliks)).BeginInit();
            this.SuspendLayout();
            // 
            // button_stop
            // 
            this.button_stop.Enabled = false;
            this.button_stop.Location = new System.Drawing.Point(372, 108);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(215, 78);
            this.button_stop.TabIndex = 2;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(372, 7);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(215, 78);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // numericUpDown_Delay
            // 
            this.numericUpDown_Delay.Location = new System.Drawing.Point(136, 147);
            this.numericUpDown_Delay.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_Delay.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.numericUpDown_Delay.Name = "numericUpDown_Delay";
            this.numericUpDown_Delay.Size = new System.Drawing.Size(203, 39);
            this.numericUpDown_Delay.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Delay (ms)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tilføj et delay mellem clicks";
            // 
            // label_stop
            // 
            this.label_stop.AutoSize = true;
            this.label_stop.Location = new System.Drawing.Point(171, 34);
            this.label_stop.Name = "label_stop";
            this.label_stop.Size = new System.Drawing.Size(90, 32);
            this.label_stop.TabIndex = 0;
            this.label_stop.Text = "Stoped";
            // 
            // label_run
            // 
            this.label_run.AutoSize = true;
            this.label_run.Location = new System.Drawing.Point(3, 34);
            this.label_run.Name = "label_run";
            this.label_run.Size = new System.Drawing.Size(120, 32);
            this.label_run.TabIndex = 0;
            this.label_run.Text = "Running...";
            this.label_run.Visible = false;
            // 
            // label_startguide
            // 
            this.label_startguide.AutoSize = true;
            this.label_startguide.Location = new System.Drawing.Point(3, 2);
            this.label_startguide.Name = "label_startguide";
            this.label_startguide.Size = new System.Drawing.Size(258, 32);
            this.label_startguide.TabIndex = 0;
            this.label_startguide.Text = "Press Shift + X to start ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(4, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Note:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(319, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Delay = -1 means 100 CPS**";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(461, 32);
            this.label6.TabIndex = 7;
            this.label6.Text = "Delay = 0 means full throtle (1000+ CPS)*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(319, 32);
            this.label7.TabIndex = 7;
            this.label7.Text = "Delay = -2 means 200 CPS**";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(9, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 263);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(432, 32);
            this.label9.TabIndex = 8;
            this.label9.Text = "*/** See README notated with * and **";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 32);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kliks";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 32);
            this.label8.TabIndex = 12;
            this.label8.Text = "Max antal kliks";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(34, 235);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // NumericUpDown_Kliks
            // 
            this.NumericUpDown_Kliks.Enabled = false;
            this.NumericUpDown_Kliks.Location = new System.Drawing.Point(136, 242);
            this.NumericUpDown_Kliks.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Kliks.Name = "NumericUpDown_Kliks";
            this.NumericUpDown_Kliks.Size = new System.Drawing.Size(203, 39);
            this.NumericUpDown_Kliks.TabIndex = 14;
            this.NumericUpDown_Kliks.ValueChanged += new System.EventHandler(this.NumericUpDown_Kliks_ValueChanged);
            // 
            // AutoClicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NumericUpDown_Kliks);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_startguide);
            this.Controls.Add(this.label_run);
            this.Controls.Add(this.label_stop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_Delay);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_stop);
            this.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "AutoClicker";
            this.Size = new System.Drawing.Size(594, 548);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AutoClicker_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Delay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Kliks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.NumericUpDown numericUpDown_Delay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_stop;
        private System.Windows.Forms.Label label_run;
        private System.Windows.Forms.Label label_startguide;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Kliks;
        private System.Windows.Forms.Label label9;
    }
}
