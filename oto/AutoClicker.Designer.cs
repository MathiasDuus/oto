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
            numericUpDown_delay = new System.Windows.Forms.NumericUpDown();
            label_delay = new System.Windows.Forms.Label();
            label_startguide = new System.Windows.Forms.Label();
            label_clicks = new System.Windows.Forms.Label();
            checkbox_enable_max_clicks = new System.Windows.Forms.CheckBox();
            NumericUpDown_clicks = new System.Windows.Forms.NumericUpDown();
            button_help = new System.Windows.Forms.Button();
            label_start = new System.Windows.Forms.Label();
            button_change = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_delay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown_clicks).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown_delay
            // 
            numericUpDown_delay.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericUpDown_delay.Location = new System.Drawing.Point(102, 13);
            numericUpDown_delay.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            numericUpDown_delay.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            numericUpDown_delay.Name = "numericUpDown_delay";
            numericUpDown_delay.Size = new System.Drawing.Size(170, 32);
            numericUpDown_delay.TabIndex = 0;
            numericUpDown_delay.ValueChanged += NumericUpDown_delay_ValueChanged;
            // 
            // label_delay
            // 
            label_delay.AutoSize = true;
            label_delay.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_delay.Location = new System.Drawing.Point(-4, 15);
            label_delay.Name = "label_delay";
            label_delay.Size = new System.Drawing.Size(100, 25);
            label_delay.TabIndex = 4;
            label_delay.Text = "Delay (ms)";
            // 
            // label_startguide
            // 
            label_startguide.AutoSize = true;
            label_startguide.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_startguide.Location = new System.Drawing.Point(3, 136);
            label_startguide.Name = "label_startguide";
            label_startguide.Size = new System.Drawing.Size(165, 25);
            label_startguide.TabIndex = 0;
            label_startguide.Text = "To start/stop press";
            // 
            // label_clicks
            // 
            label_clicks.AutoSize = true;
            label_clicks.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_clicks.Location = new System.Drawing.Point(3, 92);
            label_clicks.Name = "label_clicks";
            label_clicks.Size = new System.Drawing.Size(60, 25);
            label_clicks.TabIndex = 10;
            label_clicks.Text = "Clicks";
            // 
            // checkbox_enable_max_clicks
            // 
            checkbox_enable_max_clicks.AutoSize = true;
            checkbox_enable_max_clicks.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkbox_enable_max_clicks.Location = new System.Drawing.Point(3, 60);
            checkbox_enable_max_clicks.Name = "checkbox_enable_max_clicks";
            checkbox_enable_max_clicks.Size = new System.Drawing.Size(178, 29);
            checkbox_enable_max_clicks.TabIndex = 13;
            checkbox_enable_max_clicks.Text = "Enable max clicks";
            checkbox_enable_max_clicks.UseVisualStyleBackColor = true;
            checkbox_enable_max_clicks.CheckedChanged += Checkbox_enable_max_clicks_CheckedChanged;
            // 
            // NumericUpDown_clicks
            // 
            NumericUpDown_clicks.Enabled = false;
            NumericUpDown_clicks.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            NumericUpDown_clicks.Location = new System.Drawing.Point(69, 90);
            NumericUpDown_clicks.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            NumericUpDown_clicks.Name = "NumericUpDown_clicks";
            NumericUpDown_clicks.Size = new System.Drawing.Size(203, 32);
            NumericUpDown_clicks.TabIndex = 14;
            NumericUpDown_clicks.ValueChanged += NumericUpDown_clicks_ValueChanged;
            // 
            // button_help
            // 
            button_help.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button_help.Location = new System.Drawing.Point(0, 0);
            button_help.Name = "button_help";
            button_help.Size = new System.Drawing.Size(43, 21);
            button_help.TabIndex = 15;
            button_help.Text = "Help";
            button_help.UseVisualStyleBackColor = true;
            button_help.Click += Button_help_Click;
            // 
            // label_start
            // 
            label_start.AutoSize = true;
            label_start.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_start.Location = new System.Drawing.Point(65, 172);
            label_start.Name = "label_start";
            label_start.Size = new System.Drawing.Size(31, 25);
            label_start.TabIndex = 16;
            label_start.Text = "F5";
            // 
            // button_change
            // 
            button_change.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button_change.Location = new System.Drawing.Point(178, 136);
            button_change.Name = "button_change";
            button_change.Size = new System.Drawing.Size(94, 30);
            button_change.TabIndex = 17;
            button_change.Text = "Change";
            button_change.UseVisualStyleBackColor = true;
            button_change.Click += Button_change_Click;
            // 
            // AutoClicker
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(button_change);
            Controls.Add(label_start);
            Controls.Add(button_help);
            Controls.Add(NumericUpDown_clicks);
            Controls.Add(checkbox_enable_max_clicks);
            Controls.Add(label_startguide);
            Controls.Add(label_clicks);
            Controls.Add(label_delay);
            Controls.Add(numericUpDown_delay);
            Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Margin = new System.Windows.Forms.Padding(0);
            Name = "AutoClicker";
            Size = new System.Drawing.Size(281, 203);
            ((System.ComponentModel.ISupportInitialize)numericUpDown_delay).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown_clicks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown_delay;
        private System.Windows.Forms.Label label_delay;
        private System.Windows.Forms.Label label_startguide;
        private System.Windows.Forms.Label label_clicks;
        private System.Windows.Forms.CheckBox checkbox_enable_max_clicks;
        private System.Windows.Forms.NumericUpDown NumericUpDown_clicks;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button button_change;
        public System.Windows.Forms.Label label_start;
    }
}
