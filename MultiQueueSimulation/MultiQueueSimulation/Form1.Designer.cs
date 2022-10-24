namespace MultiQueueSimulation
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
            this.Select = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Select
            // 
            this.Select.Location = new System.Drawing.Point(974, 92);
            this.Select.Name = "Select";
            this.Select.Size = new System.Drawing.Size(212, 146);
            this.Select.TabIndex = 0;
            this.Select.Text = "Select Test Case";
            this.Select.UseVisualStyleBackColor = true;
            this.Select.Click += new System.EventHandler(this.Select_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 781);
            this.Controls.Add(this.Select);
            this.Name = "Form1";
            this.Text = "Siko";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Select;
    }
}

