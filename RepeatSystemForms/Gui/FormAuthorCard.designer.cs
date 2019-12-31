namespace RepeatSystemForms.Gui
{
    partial class FormAuthorCard
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
            this.gBSurname = new System.Windows.Forms.GroupBox();
            this.txtBSurname = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.gBFirstName = new System.Windows.Forms.GroupBox();
            this.txtBFirstName = new System.Windows.Forms.TextBox();
            this.gBSecondName = new System.Windows.Forms.GroupBox();
            this.txtBSecondName = new System.Windows.Forms.TextBox();
            this.gBSecondNameEnglish = new System.Windows.Forms.GroupBox();
            this.txtBSecondNameEnglish = new System.Windows.Forms.TextBox();
            this.gBFirstNameEnglish = new System.Windows.Forms.GroupBox();
            this.txtBFirstNameEnglish = new System.Windows.Forms.TextBox();
            this.gBSurnameEnglish = new System.Windows.Forms.GroupBox();
            this.txtBSurnameEnglish = new System.Windows.Forms.TextBox();
            this.gBSurname.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.gBFirstName.SuspendLayout();
            this.gBSecondName.SuspendLayout();
            this.gBSecondNameEnglish.SuspendLayout();
            this.gBFirstNameEnglish.SuspendLayout();
            this.gBSurnameEnglish.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBSurname
            // 
            this.gBSurname.Controls.Add(this.txtBSurname);
            this.gBSurname.Location = new System.Drawing.Point(12, 27);
            this.gBSurname.Name = "gBSurname";
            this.gBSurname.Size = new System.Drawing.Size(415, 40);
            this.gBSurname.TabIndex = 0;
            this.gBSurname.TabStop = false;
            this.gBSurname.Text = "Фамилия";
            // 
            // txtBSurname
            // 
            this.txtBSurname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBSurname.Location = new System.Drawing.Point(3, 16);
            this.txtBSurname.MaxLength = 80;
            this.txtBSurname.Name = "txtBSurname";
            this.txtBSurname.ReadOnly = true;
            this.txtBSurname.Size = new System.Drawing.Size(409, 20);
            this.txtBSurname.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(271, 303);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(352, 303);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIEdit});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(439, 24);
            this.menuStrip.TabIndex = 8;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tSMIEdit
            // 
            this.tSMIEdit.Enabled = false;
            this.tSMIEdit.Image = global::RepeatSystemForms.Properties.Resources.Edit;
            this.tSMIEdit.Name = "tSMIEdit";
            this.tSMIEdit.Size = new System.Drawing.Size(114, 20);
            this.tSMIEdit.Text = "Редактировать";
            this.tSMIEdit.Visible = false;
            this.tSMIEdit.Click += new System.EventHandler(this.tSMIEdit_Click);
            // 
            // gBFirstName
            // 
            this.gBFirstName.Controls.Add(this.txtBFirstName);
            this.gBFirstName.Location = new System.Drawing.Point(12, 73);
            this.gBFirstName.Name = "gBFirstName";
            this.gBFirstName.Size = new System.Drawing.Size(415, 40);
            this.gBFirstName.TabIndex = 1;
            this.gBFirstName.TabStop = false;
            this.gBFirstName.Text = "Имя";
            // 
            // txtBFirstName
            // 
            this.txtBFirstName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBFirstName.Location = new System.Drawing.Point(3, 16);
            this.txtBFirstName.MaxLength = 80;
            this.txtBFirstName.Name = "txtBFirstName";
            this.txtBFirstName.ReadOnly = true;
            this.txtBFirstName.Size = new System.Drawing.Size(409, 20);
            this.txtBFirstName.TabIndex = 0;
            // 
            // gBSecondName
            // 
            this.gBSecondName.Controls.Add(this.txtBSecondName);
            this.gBSecondName.Location = new System.Drawing.Point(12, 119);
            this.gBSecondName.Name = "gBSecondName";
            this.gBSecondName.Size = new System.Drawing.Size(415, 40);
            this.gBSecondName.TabIndex = 2;
            this.gBSecondName.TabStop = false;
            this.gBSecondName.Text = "Отчество";
            // 
            // txtBSecondName
            // 
            this.txtBSecondName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBSecondName.Location = new System.Drawing.Point(3, 16);
            this.txtBSecondName.MaxLength = 80;
            this.txtBSecondName.Name = "txtBSecondName";
            this.txtBSecondName.ReadOnly = true;
            this.txtBSecondName.Size = new System.Drawing.Size(409, 20);
            this.txtBSecondName.TabIndex = 0;
            // 
            // gBSecondNameEnglish
            // 
            this.gBSecondNameEnglish.Controls.Add(this.txtBSecondNameEnglish);
            this.gBSecondNameEnglish.Location = new System.Drawing.Point(12, 257);
            this.gBSecondNameEnglish.Name = "gBSecondNameEnglish";
            this.gBSecondNameEnglish.Size = new System.Drawing.Size(415, 40);
            this.gBSecondNameEnglish.TabIndex = 5;
            this.gBSecondNameEnglish.TabStop = false;
            this.gBSecondNameEnglish.Text = "Отчество English";
            // 
            // txtBSecondNameEnglish
            // 
            this.txtBSecondNameEnglish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBSecondNameEnglish.Location = new System.Drawing.Point(3, 16);
            this.txtBSecondNameEnglish.MaxLength = 80;
            this.txtBSecondNameEnglish.Name = "txtBSecondNameEnglish";
            this.txtBSecondNameEnglish.ReadOnly = true;
            this.txtBSecondNameEnglish.Size = new System.Drawing.Size(409, 20);
            this.txtBSecondNameEnglish.TabIndex = 0;
            // 
            // gBFirstNameEnglish
            // 
            this.gBFirstNameEnglish.Controls.Add(this.txtBFirstNameEnglish);
            this.gBFirstNameEnglish.Location = new System.Drawing.Point(12, 211);
            this.gBFirstNameEnglish.Name = "gBFirstNameEnglish";
            this.gBFirstNameEnglish.Size = new System.Drawing.Size(415, 40);
            this.gBFirstNameEnglish.TabIndex = 4;
            this.gBFirstNameEnglish.TabStop = false;
            this.gBFirstNameEnglish.Text = "Имя English";
            // 
            // txtBFirstNameEnglish
            // 
            this.txtBFirstNameEnglish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBFirstNameEnglish.Location = new System.Drawing.Point(3, 16);
            this.txtBFirstNameEnglish.MaxLength = 80;
            this.txtBFirstNameEnglish.Name = "txtBFirstNameEnglish";
            this.txtBFirstNameEnglish.ReadOnly = true;
            this.txtBFirstNameEnglish.Size = new System.Drawing.Size(409, 20);
            this.txtBFirstNameEnglish.TabIndex = 0;
            // 
            // gBSurnameEnglish
            // 
            this.gBSurnameEnglish.Controls.Add(this.txtBSurnameEnglish);
            this.gBSurnameEnglish.Location = new System.Drawing.Point(12, 165);
            this.gBSurnameEnglish.Name = "gBSurnameEnglish";
            this.gBSurnameEnglish.Size = new System.Drawing.Size(415, 40);
            this.gBSurnameEnglish.TabIndex = 3;
            this.gBSurnameEnglish.TabStop = false;
            this.gBSurnameEnglish.Text = "Фамилия English";
            // 
            // txtBSurnameEnglish
            // 
            this.txtBSurnameEnglish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBSurnameEnglish.Location = new System.Drawing.Point(3, 16);
            this.txtBSurnameEnglish.MaxLength = 80;
            this.txtBSurnameEnglish.Name = "txtBSurnameEnglish";
            this.txtBSurnameEnglish.ReadOnly = true;
            this.txtBSurnameEnglish.Size = new System.Drawing.Size(409, 20);
            this.txtBSurnameEnglish.TabIndex = 0;
            // 
            // FormAuthorCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(439, 338);
            this.Controls.Add(this.gBSecondNameEnglish);
            this.Controls.Add(this.gBFirstNameEnglish);
            this.Controls.Add(this.gBSurnameEnglish);
            this.Controls.Add(this.gBSecondName);
            this.Controls.Add(this.gBFirstName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gBSurname);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAuthorCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Информация об авторе";
            this.gBSurname.ResumeLayout(false);
            this.gBSurname.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.gBFirstName.ResumeLayout(false);
            this.gBFirstName.PerformLayout();
            this.gBSecondName.ResumeLayout(false);
            this.gBSecondName.PerformLayout();
            this.gBSecondNameEnglish.ResumeLayout(false);
            this.gBSecondNameEnglish.PerformLayout();
            this.gBFirstNameEnglish.ResumeLayout(false);
            this.gBFirstNameEnglish.PerformLayout();
            this.gBSurnameEnglish.ResumeLayout(false);
            this.gBSurnameEnglish.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBSurname;
        private System.Windows.Forms.TextBox txtBSurname;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tSMIEdit;
        private System.Windows.Forms.GroupBox gBFirstName;
        private System.Windows.Forms.TextBox txtBFirstName;
        private System.Windows.Forms.GroupBox gBSecondName;
        private System.Windows.Forms.TextBox txtBSecondName;
        private System.Windows.Forms.GroupBox gBSecondNameEnglish;
        private System.Windows.Forms.TextBox txtBSecondNameEnglish;
        private System.Windows.Forms.GroupBox gBFirstNameEnglish;
        private System.Windows.Forms.TextBox txtBFirstNameEnglish;
        private System.Windows.Forms.GroupBox gBSurnameEnglish;
        private System.Windows.Forms.TextBox txtBSurnameEnglish;
    }
}