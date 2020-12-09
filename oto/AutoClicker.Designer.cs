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
            this.numericUpDown_Delay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label_startguide = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.NumericUpDown_Kliks = new System.Windows.Forms.NumericUpDown();
            this.button_help = new System.Windows.Forms.Button();
            this.label_start = new System.Windows.Forms.Label();
            this.button_change = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Kliks)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_Delay
            // 
            this.numericUpDown_Delay.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.numericUpDown_Delay.Location = new System.Drawing.Point(102, 13);
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
            this.numericUpDown_Delay.Size = new System.Drawing.Size(170, 32);
            this.numericUpDown_Delay.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.Location = new System.Drawing.Point(-4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Delay (ms)";
            // 
            // label_startguide
            // 
            this.label_startguide.AutoSize = true;
            this.label_startguide.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label_startguide.Location = new System.Drawing.Point(3, 136);
            this.label_startguide.Name = "label_startguide";
            this.label_startguide.Size = new System.Drawing.Size(165, 25);
            this.label_startguide.TabIndex = 0;
            this.label_startguide.Text = "To start/stop press";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label5.Location = new System.Drawing.Point(3, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Clicks";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.checkBox1.Location = new System.Drawing.Point(3, 60);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(178, 29);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Enable max clicks";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // NumericUpDown_Kliks
            // 
            this.NumericUpDown_Kliks.Enabled = false;
            this.NumericUpDown_Kliks.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.NumericUpDown_Kliks.Location = new System.Drawing.Point(69, 90);
            this.NumericUpDown_Kliks.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NumericUpDown_Kliks.Name = "NumericUpDown_Kliks";
            this.NumericUpDown_Kliks.Size = new System.Drawing.Size(203, 32);
            this.NumericUpDown_Kliks.TabIndex = 14;
            this.NumericUpDown_Kliks.ValueChanged += new System.EventHandler(this.NumericUpDown_Kliks_ValueChanged);
            // 
            // button_help
            // 
            this.button_help.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.button_help.Location = new System.Drawing.Point(0, 0);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(43, 21);
            this.button_help.TabIndex = 15;
            this.button_help.Text = "Help";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // label_start
            // 
            this.label_start.AutoSize = true;
            this.label_start.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label_start.Location = new System.Drawing.Point(65, 172);
            this.label_start.Name = "label_start";
            this.label_start.Size = new System.Drawing.Size(31, 25);
            this.label_start.TabIndex = 16;
            this.label_start.Text = "F5";
            // 
            // button_change
            // 
            this.button_change.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button_change.Location = new System.Drawing.Point(178, 136);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(94, 30);
            this.button_change.TabIndex = 17;
            this.button_change.Text = "Change";
            this.button_change.UseVisualStyleBackColor = true;
            this.button_change.Click += new System.EventHandler(this.button_change_Click);
            // 
            // AutoClicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_change);
            this.Controls.Add(this.label_start);
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.NumericUpDown_Kliks);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label_startguide);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_Delay);
            this.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AutoClicker";
            this.Size = new System.Drawing.Size(281, 203);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Kliks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown_Delay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_startguide;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Kliks;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button button_change;
        public System.Windows.Forms.Label label_start;
    }
}
