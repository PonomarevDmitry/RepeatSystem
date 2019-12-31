namespace TestProject
{
    partial class Form6
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
            this.btnNextDate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCreateMemoryDates = new System.Windows.Forms.Button();
            this.dTPicker = new System.Windows.Forms.DateTimePicker();
            this.btnCheckAllDates = new System.Windows.Forms.Button();
            this.btnPreviousDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNextDate
            // 
            this.btnNextDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextDate.Location = new System.Drawing.Point(646, 505);
            this.btnNextDate.Name = "btnNextDate";
            this.btnNextDate.Size = new System.Drawing.Size(90, 23);
            this.btnNextDate.TabIndex = 5;
            this.btnNextDate.Text = "Следующая";
            this.btnNextDate.UseVisualStyleBackColor = true;
            this.btnNextDate.Click += new System.EventHandler(this.btnNextDate_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(757, 403);
            this.textBox1.TabIndex = 3;
            // 
            // btnCreateMemoryDates
            // 
            this.btnCreateMemoryDates.Location = new System.Drawing.Point(265, 505);
            this.btnCreateMemoryDates.Name = "btnCreateMemoryDates";
            this.btnCreateMemoryDates.Size = new System.Drawing.Size(151, 23);
            this.btnCreateMemoryDates.TabIndex = 0;
            this.btnCreateMemoryDates.Text = "Даты для повтора";
            this.btnCreateMemoryDates.UseVisualStyleBackColor = true;
            this.btnCreateMemoryDates.Click += new System.EventHandler(this.btnCreateMemoryDates_Click);
            // 
            // dTPicker
            // 
            this.dTPicker.Location = new System.Drawing.Point(128, 508);
            this.dTPicker.Name = "dTPicker";
            this.dTPicker.Size = new System.Drawing.Size(131, 20);
            this.dTPicker.TabIndex = 1;
            // 
            // btnCheckAllDates
            // 
            this.btnCheckAllDates.Location = new System.Drawing.Point(274, 572);
            this.btnCheckAllDates.Name = "btnCheckAllDates";
            this.btnCheckAllDates.Size = new System.Drawing.Size(175, 23);
            this.btnCheckAllDates.TabIndex = 2;
            this.btnCheckAllDates.Text = "Проверка покрытия всех дат";
            this.btnCheckAllDates.UseVisualStyleBackColor = true;
            this.btnCheckAllDates.Click += new System.EventHandler(this.btnCheckAllDates_Click);
            // 
            // btnPreviousDate
            // 
            this.btnPreviousDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviousDate.Location = new System.Drawing.Point(550, 505);
            this.btnPreviousDate.Name = "btnPreviousDate";
            this.btnPreviousDate.Size = new System.Drawing.Size(90, 23);
            this.btnPreviousDate.TabIndex = 4;
            this.btnPreviousDate.Text = "Предыдущая";
            this.btnPreviousDate.UseVisualStyleBackColor = true;
            this.btnPreviousDate.Click += new System.EventHandler(this.btnPreviousDate_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 639);
            this.Controls.Add(this.btnPreviousDate);
            this.Controls.Add(this.btnCheckAllDates);
            this.Controls.Add(this.dTPicker);
            this.Controls.Add(this.btnCreateMemoryDates);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnNextDate);
            this.Name = "Form6";
            this.Text = "Form6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNextDate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCreateMemoryDates;
        private System.Windows.Forms.DateTimePicker dTPicker;
        private System.Windows.Forms.Button btnCheckAllDates;
        private System.Windows.Forms.Button btnPreviousDate;



    }
}