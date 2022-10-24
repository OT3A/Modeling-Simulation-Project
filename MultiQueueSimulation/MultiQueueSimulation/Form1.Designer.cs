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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomDigitForArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClockTimeOfArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RandomDigitForService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeServiceBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeServiceEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeInQueue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Select
            // 
            this.Select.Location = new System.Drawing.Point(1224, 720);
            this.Select.Name = "Select";
            this.Select.Size = new System.Drawing.Size(130, 49);
            this.Select.TabIndex = 0;
            this.Select.Text = "Select Test Case";
            this.Select.UseVisualStyleBackColor = true;
            this.Select.Click += new System.EventHandler(this.Select_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customer,
            this.randomDigitForArrival,
            this.InterArrivalTime,
            this.ClockTimeOfArrival,
            this.RandomDigitForService,
            this.TimeServiceBegin,
            this.ServiceTime,
            this.TimeServiceEnd,
            this.ServerID,
            this.TimeInQueue});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1304, 702);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // customer
            // 
            this.customer.HeaderText = "Custome No.";
            this.customer.MinimumWidth = 6;
            this.customer.Name = "customer";
            this.customer.ReadOnly = true;
            this.customer.Width = 125;
            // 
            // randomDigitForArrival
            // 
            this.randomDigitForArrival.HeaderText = "Random Digit For Arrival";
            this.randomDigitForArrival.MinimumWidth = 6;
            this.randomDigitForArrival.Name = "randomDigitForArrival";
            this.randomDigitForArrival.ReadOnly = true;
            this.randomDigitForArrival.Width = 125;
            // 
            // InterArrivalTime
            // 
            this.InterArrivalTime.HeaderText = "Time Between Arrival";
            this.InterArrivalTime.MinimumWidth = 6;
            this.InterArrivalTime.Name = "InterArrivalTime";
            this.InterArrivalTime.Width = 125;
            // 
            // ClockTimeOfArrival
            // 
            this.ClockTimeOfArrival.HeaderText = "ClockTimeOfArrival";
            this.ClockTimeOfArrival.MinimumWidth = 6;
            this.ClockTimeOfArrival.Name = "ClockTimeOfArrival";
            this.ClockTimeOfArrival.Width = 125;
            // 
            // RandomDigitForService
            // 
            this.RandomDigitForService.HeaderText = "Random Digit For Service";
            this.RandomDigitForService.MinimumWidth = 6;
            this.RandomDigitForService.Name = "RandomDigitForService";
            this.RandomDigitForService.Width = 125;
            // 
            // TimeServiceBegin
            // 
            this.TimeServiceBegin.HeaderText = "TimeServiceBegin";
            this.TimeServiceBegin.MinimumWidth = 6;
            this.TimeServiceBegin.Name = "TimeServiceBegin";
            this.TimeServiceBegin.Width = 125;
            // 
            // ServiceTime
            // 
            this.ServiceTime.HeaderText = "ServiceTime";
            this.ServiceTime.MinimumWidth = 6;
            this.ServiceTime.Name = "ServiceTime";
            this.ServiceTime.Width = 125;
            // 
            // TimeServiceEnd
            // 
            this.TimeServiceEnd.HeaderText = "TimeServiceEnd";
            this.TimeServiceEnd.MinimumWidth = 6;
            this.TimeServiceEnd.Name = "TimeServiceEnd";
            this.TimeServiceEnd.Width = 125;
            // 
            // ServerID
            // 
            this.ServerID.HeaderText = "Server ID";
            this.ServerID.MinimumWidth = 6;
            this.ServerID.Name = "ServerID";
            this.ServerID.Width = 125;
            // 
            // TimeInQueue
            // 
            this.TimeInQueue.HeaderText = "TimeInQueue";
            this.TimeInQueue.MinimumWidth = 6;
            this.TimeInQueue.Name = "TimeInQueue";
            this.TimeInQueue.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 781);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Select);
            this.Name = "Form1";
            this.Text = "Siko";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Select;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomDigitForArrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClockTimeOfArrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn RandomDigitForService;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeServiceBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeServiceEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeInQueue;
    }
}

