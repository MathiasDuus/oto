
namespace oto
{
    partial class ChangeStart
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
            label_change_start_guide = new System.Windows.Forms.Label();
            textBox_change_start = new System.Windows.Forms.TextBox();
            button_set = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label_change_start_guide
            // 
            label_change_start_guide.AutoSize = true;
            label_change_start_guide.Location = new System.Drawing.Point(0, 0);
            label_change_start_guide.Name = "label_change_start_guide";
            label_change_start_guide.Size = new System.Drawing.Size(176, 29);
            label_change_start_guide.TabIndex = 1;
            label_change_start_guide.Text = "Press a button";
            // 
            // textBox_change_start
            // 
            textBox_change_start.AcceptsReturn = true;
            textBox_change_start.AcceptsTab = true;
            textBox_change_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox_change_start.Location = new System.Drawing.Point(5, 32);
            textBox_change_start.Name = "textBox_change_start";
            textBox_change_start.ReadOnly = true;
            textBox_change_start.Size = new System.Drawing.Size(111, 44);
            textBox_change_start.TabIndex = 0;
            textBox_change_start.KeyDown += textBox1_KeyDown;
            // 
            // button_set
            // 
            button_set.DialogResult = System.Windows.Forms.DialogResult.OK;
            button_set.Location = new System.Drawing.Point(117, 32);
            button_set.Name = "button_set";
            button_set.Size = new System.Drawing.Size(75, 44);
            button_set.TabIndex = 2;
            button_set.Text = "Set";
            button_set.UseVisualStyleBackColor = true;
            // 
            // ChangeStart
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(button_set);
            Controls.Add(textBox_change_start);
            Controls.Add(label_change_start_guide);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Margin = new System.Windows.Forms.Padding(7);
            Name = "ChangeStart";
            Size = new System.Drawing.Size(195, 82);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label_change_start_guide;
        public System.Windows.Forms.TextBox textBox_change_start;
        private System.Windows.Forms.Button button_set;
    }
}
