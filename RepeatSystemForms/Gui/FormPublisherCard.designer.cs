namespace RepeatSystemForms.Gui
{
    partial class FormPublisherCard
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
            this.components = new System.ComponentModel.Container();
            this.gBName = new System.Windows.Forms.GroupBox();
            this.txtBName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gBShortName = new System.Windows.Forms.GroupBox();
            this.txtBShortName = new System.Windows.Forms.TextBox();
            this.gBCity = new System.Windows.Forms.GroupBox();
            this.cmBCity = new System.Windows.Forms.ComboBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.gBName.SuspendLayout();
            this.gBShortName.SuspendLayout();
            this.gBCity.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBName
            // 
            this.gBName.Controls.Add(this.txtBName);
            this.gBName.Location = new System.Drawing.Point(12, 27);
            this.gBName.Name = "gBName";
            this.gBName.Size = new System.Drawing.Size(415, 40);
            this.gBName.TabIndex = 0;
            this.gBName.TabStop = false;
            this.gBName.Text = "Наименование";
            // 
            // txtBName
            // 
            this.txtBName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBName.Location = new System.Drawing.Point(3, 16);
            this.txtBName.MaxLength = 80;
            this.txtBName.Name = "txtBName";
            this.txtBName.ReadOnly = true;
            this.txtBName.Size = new System.Drawing.Size(409, 20);
            this.txtBName.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(271, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(352, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gBShortName
            // 
            this.gBShortName.Controls.Add(this.txtBShortName);
            this.gBShortName.Location = new System.Drawing.Point(12, 119);
            this.gBShortName.Name = "gBShortName";
            this.gBShortName.Size = new System.Drawing.Size(415, 40);
            this.gBShortName.TabIndex = 2;
            this.gBShortName.TabStop = false;
            this.gBShortName.Text = "Краткое наименование";
            // 
            // txtBShortName
            // 
            this.txtBShortName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBShortName.Location = new System.Drawing.Point(3, 16);
            this.txtBShortName.MaxLength = 80;
            this.txtBShortName.Name = "txtBShortName";
            this.txtBShortName.ReadOnly = true;
            this.txtBShortName.Size = new System.Drawing.Size(409, 20);
            this.txtBShortName.TabIndex = 0;
            // 
            // gBCity
            // 
            this.gBCity.Controls.Add(this.cmBCity);
            this.gBCity.Location = new System.Drawing.Point(12, 73);
            this.gBCity.Name = "gBCity";
            this.gBCity.Size = new System.Drawing.Size(415, 40);
            this.gBCity.TabIndex = 1;
            this.gBCity.TabStop = false;
            this.gBCity.Text = "Город";
            // 
            // cmBCity
            // 
            this.cmBCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmBCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBCity.Enabled = false;
            this.cmBCity.FormattingEnabled = true;
            this.cmBCity.Location = new System.Drawing.Point(3, 16);
            this.cmBCity.MaxDropDownItems = 16;
            this.cmBCity.Name = "cmBCity";
            this.cmBCity.Size = new System.Drawing.Size(409, 21);
            this.cmBCity.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIEdit});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(439, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tSMIEdit
            // 
            this.tSMIEdit.Enabled = false;
            this.tSMIEdit.Name = "tSMIEdit";
            this.tSMIEdit.Size = new System.Drawing.Size(98, 20);
            this.tSMIEdit.Text = "Редактировать";
            this.tSMIEdit.Visible = false;
            this.tSMIEdit.Click += new System.EventHandler(this.tSMIEdit_Click);
            // 
            // FormPublisherCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(439, 200);
            this.Controls.Add(this.gBCity);
            this.Controls.Add(this.gBShortName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gBName);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPublisherCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Информация об издательстве";
            this.gBName.ResumeLayout(false);
            this.gBName.PerformLayout();
            this.gBShortName.ResumeLayout(false);
            this.gBShortName.PerformLayout();
            this.gBCity.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBName;
        private System.Windows.Forms.TextBox txtBName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox gBShortName;
        private System.Windows.Forms.TextBox txtBShortName;
        private System.Windows.Forms.GroupBox gBCity;
        private System.Windows.Forms.ComboBox cmBCity;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tSMIEdit;
    }
}