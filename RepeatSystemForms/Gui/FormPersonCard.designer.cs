namespace RepeatSystemForms.Gui
{
    partial class FormPersonCard
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageInformation = new System.Windows.Forms.TabPage();
            this.gBReading = new System.Windows.Forms.GroupBox();
            this.gBPhotoFileName = new System.Windows.Forms.GroupBox();
            this.txtBPhotoFileName = new System.Windows.Forms.TextBox();
            this.gBPhoneNumber = new System.Windows.Forms.GroupBox();
            this.txtBPhoneNumber = new System.Windows.Forms.TextBox();
            this.gBAddress = new System.Windows.Forms.GroupBox();
            this.txtBAddress = new System.Windows.Forms.TextBox();
            this.gBMeetingPlace = new System.Windows.Forms.GroupBox();
            this.txtBMeetingPlace = new System.Windows.Forms.TextBox();
            this.gBMeetingDate = new System.Windows.Forms.GroupBox();
            this.nDTPMeetingDate = new ru.sevmash.pkb.Controls.NullableDateTimePicker();
            this.gBBirthDay = new System.Windows.Forms.GroupBox();
            this.nDTPBirthDay = new ru.sevmash.pkb.Controls.NullableDateTimePicker();
            this.gBSecondName = new System.Windows.Forms.GroupBox();
            this.txtBSecondName = new System.Windows.Forms.TextBox();
            this.gBFirstName = new System.Windows.Forms.GroupBox();
            this.txtBFirstName = new System.Windows.Forms.TextBox();
            this.gBSurname = new System.Windows.Forms.GroupBox();
            this.txtBSurname = new System.Windows.Forms.TextBox();
            this.gBCreationDate = new System.Windows.Forms.GroupBox();
            this.txtBCreationDate = new System.Windows.Forms.TextBox();
            this.tabPageDescription = new System.Windows.Forms.TabPage();
            this.txtBDescription = new System.Windows.Forms.TextBox();
            this.tabPageNote = new System.Windows.Forms.TabPage();
            this.txtBNote = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageInformation.SuspendLayout();
            this.gBReading.SuspendLayout();
            this.gBPhotoFileName.SuspendLayout();
            this.gBPhoneNumber.SuspendLayout();
            this.gBAddress.SuspendLayout();
            this.gBMeetingPlace.SuspendLayout();
            this.gBMeetingDate.SuspendLayout();
            this.gBBirthDay.SuspendLayout();
            this.gBSecondName.SuspendLayout();
            this.gBFirstName.SuspendLayout();
            this.gBSurname.SuspendLayout();
            this.gBCreationDate.SuspendLayout();
            this.tabPageDescription.SuspendLayout();
            this.tabPageNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(656, 15);
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
            this.btnCancel.Location = new System.Drawing.Point(737, 15);
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
            this.menuStrip.Size = new System.Drawing.Size(824, 24);
            this.menuStrip.TabIndex = 2;
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
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 551);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(824, 50);
            this.panelButtons.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageInformation);
            this.tabControl.Controls.Add(this.tabPageDescription);
            this.tabControl.Controls.Add(this.tabPageNote);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(824, 527);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageInformation
            // 
            this.tabPageInformation.Controls.Add(this.gBReading);
            this.tabPageInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageInformation.Name = "tabPageInformation";
            this.tabPageInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInformation.Size = new System.Drawing.Size(816, 501);
            this.tabPageInformation.TabIndex = 0;
            this.tabPageInformation.Text = "Информация";
            this.tabPageInformation.UseVisualStyleBackColor = true;
            // 
            // gBReading
            // 
            this.gBReading.Controls.Add(this.gBPhotoFileName);
            this.gBReading.Controls.Add(this.gBPhoneNumber);
            this.gBReading.Controls.Add(this.gBAddress);
            this.gBReading.Controls.Add(this.gBMeetingPlace);
            this.gBReading.Controls.Add(this.gBMeetingDate);
            this.gBReading.Controls.Add(this.gBBirthDay);
            this.gBReading.Controls.Add(this.gBSecondName);
            this.gBReading.Controls.Add(this.gBFirstName);
            this.gBReading.Controls.Add(this.gBSurname);
            this.gBReading.Controls.Add(this.gBCreationDate);
            this.gBReading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBReading.Location = new System.Drawing.Point(3, 3);
            this.gBReading.Name = "gBReading";
            this.gBReading.Size = new System.Drawing.Size(810, 495);
            this.gBReading.TabIndex = 4;
            this.gBReading.TabStop = false;
            this.gBReading.Text = "Чтение и пересказ";
            // 
            // gBPhotoFileName
            // 
            this.gBPhotoFileName.Controls.Add(this.txtBPhotoFileName);
            this.gBPhotoFileName.Location = new System.Drawing.Point(6, 341);
            this.gBPhotoFileName.Name = "gBPhotoFileName";
            this.gBPhotoFileName.Size = new System.Drawing.Size(759, 40);
            this.gBPhotoFileName.TabIndex = 9;
            this.gBPhotoFileName.TabStop = false;
            this.gBPhotoFileName.Text = "Файл фотографии";
            // 
            // txtBPhotoFileName
            // 
            this.txtBPhotoFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBPhotoFileName.Location = new System.Drawing.Point(3, 16);
            this.txtBPhotoFileName.MaxLength = 60000;
            this.txtBPhotoFileName.Name = "txtBPhotoFileName";
            this.txtBPhotoFileName.ReadOnly = true;
            this.txtBPhotoFileName.Size = new System.Drawing.Size(753, 20);
            this.txtBPhotoFileName.TabIndex = 0;
            // 
            // gBPhoneNumber
            // 
            this.gBPhoneNumber.Controls.Add(this.txtBPhoneNumber);
            this.gBPhoneNumber.Location = new System.Drawing.Point(6, 295);
            this.gBPhoneNumber.Name = "gBPhoneNumber";
            this.gBPhoneNumber.Size = new System.Drawing.Size(388, 40);
            this.gBPhoneNumber.TabIndex = 8;
            this.gBPhoneNumber.TabStop = false;
            this.gBPhoneNumber.Text = "Телефон";
            // 
            // txtBPhoneNumber
            // 
            this.txtBPhoneNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBPhoneNumber.Location = new System.Drawing.Point(3, 16);
            this.txtBPhoneNumber.MaxLength = 60000;
            this.txtBPhoneNumber.Name = "txtBPhoneNumber";
            this.txtBPhoneNumber.ReadOnly = true;
            this.txtBPhoneNumber.Size = new System.Drawing.Size(382, 20);
            this.txtBPhoneNumber.TabIndex = 0;
            // 
            // gBAddress
            // 
            this.gBAddress.Controls.Add(this.txtBAddress);
            this.gBAddress.Location = new System.Drawing.Point(6, 249);
            this.gBAddress.Name = "gBAddress";
            this.gBAddress.Size = new System.Drawing.Size(759, 40);
            this.gBAddress.TabIndex = 7;
            this.gBAddress.TabStop = false;
            this.gBAddress.Text = "Адрес";
            // 
            // txtBAddress
            // 
            this.txtBAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBAddress.Location = new System.Drawing.Point(3, 16);
            this.txtBAddress.MaxLength = 60000;
            this.txtBAddress.Name = "txtBAddress";
            this.txtBAddress.ReadOnly = true;
            this.txtBAddress.Size = new System.Drawing.Size(753, 20);
            this.txtBAddress.TabIndex = 0;
            // 
            // gBMeetingPlace
            // 
            this.gBMeetingPlace.Controls.Add(this.txtBMeetingPlace);
            this.gBMeetingPlace.Location = new System.Drawing.Point(6, 157);
            this.gBMeetingPlace.Name = "gBMeetingPlace";
            this.gBMeetingPlace.Size = new System.Drawing.Size(759, 86);
            this.gBMeetingPlace.TabIndex = 6;
            this.gBMeetingPlace.TabStop = false;
            this.gBMeetingPlace.Text = "Место встречи";
            // 
            // txtBMeetingPlace
            // 
            this.txtBMeetingPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBMeetingPlace.Location = new System.Drawing.Point(3, 16);
            this.txtBMeetingPlace.MaxLength = 32600;
            this.txtBMeetingPlace.Multiline = true;
            this.txtBMeetingPlace.Name = "txtBMeetingPlace";
            this.txtBMeetingPlace.ReadOnly = true;
            this.txtBMeetingPlace.Size = new System.Drawing.Size(753, 67);
            this.txtBMeetingPlace.TabIndex = 1;
            // 
            // gBMeetingDate
            // 
            this.gBMeetingDate.Controls.Add(this.nDTPMeetingDate);
            this.gBMeetingDate.Location = new System.Drawing.Point(141, 111);
            this.gBMeetingDate.Name = "gBMeetingDate";
            this.gBMeetingDate.Size = new System.Drawing.Size(129, 40);
            this.gBMeetingDate.TabIndex = 5;
            this.gBMeetingDate.TabStop = false;
            this.gBMeetingDate.Text = "Дата встречи";
            // 
            // nDTPMeetingDate
            // 
            this.nDTPMeetingDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nDTPMeetingDate.Enabled = false;
            this.nDTPMeetingDate.Location = new System.Drawing.Point(3, 16);
            this.nDTPMeetingDate.Name = "nDTPMeetingDate";
            this.nDTPMeetingDate.Size = new System.Drawing.Size(123, 20);
            this.nDTPMeetingDate.TabIndex = 8;
            this.nDTPMeetingDate.Value = null;
            // 
            // gBBirthDay
            // 
            this.gBBirthDay.Controls.Add(this.nDTPBirthDay);
            this.gBBirthDay.Location = new System.Drawing.Point(6, 111);
            this.gBBirthDay.Name = "gBBirthDay";
            this.gBBirthDay.Size = new System.Drawing.Size(129, 40);
            this.gBBirthDay.TabIndex = 4;
            this.gBBirthDay.TabStop = false;
            this.gBBirthDay.Text = "Дата рождения";
            // 
            // nDTPBirthDay
            // 
            this.nDTPBirthDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nDTPBirthDay.Enabled = false;
            this.nDTPBirthDay.Location = new System.Drawing.Point(3, 16);
            this.nDTPBirthDay.Name = "nDTPBirthDay";
            this.nDTPBirthDay.Size = new System.Drawing.Size(123, 20);
            this.nDTPBirthDay.TabIndex = 8;
            this.nDTPBirthDay.Value = null;
            // 
            // gBSecondName
            // 
            this.gBSecondName.Controls.Add(this.txtBSecondName);
            this.gBSecondName.Location = new System.Drawing.Point(516, 65);
            this.gBSecondName.Name = "gBSecondName";
            this.gBSecondName.Size = new System.Drawing.Size(249, 40);
            this.gBSecondName.TabIndex = 3;
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
            this.txtBSecondName.Size = new System.Drawing.Size(243, 20);
            this.txtBSecondName.TabIndex = 0;
            // 
            // gBFirstName
            // 
            this.gBFirstName.Controls.Add(this.txtBFirstName);
            this.gBFirstName.Location = new System.Drawing.Point(261, 65);
            this.gBFirstName.Name = "gBFirstName";
            this.gBFirstName.Size = new System.Drawing.Size(249, 40);
            this.gBFirstName.TabIndex = 2;
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
            this.txtBFirstName.Size = new System.Drawing.Size(243, 20);
            this.txtBFirstName.TabIndex = 0;
            // 
            // gBSurname
            // 
            this.gBSurname.Controls.Add(this.txtBSurname);
            this.gBSurname.Location = new System.Drawing.Point(6, 65);
            this.gBSurname.Name = "gBSurname";
            this.gBSurname.Size = new System.Drawing.Size(249, 40);
            this.gBSurname.TabIndex = 1;
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
            this.txtBSurname.Size = new System.Drawing.Size(243, 20);
            this.txtBSurname.TabIndex = 0;
            // 
            // gBCreationDate
            // 
            this.gBCreationDate.Controls.Add(this.txtBCreationDate);
            this.gBCreationDate.Location = new System.Drawing.Point(6, 19);
            this.gBCreationDate.Name = "gBCreationDate";
            this.gBCreationDate.Size = new System.Drawing.Size(141, 40);
            this.gBCreationDate.TabIndex = 0;
            this.gBCreationDate.TabStop = false;
            this.gBCreationDate.Text = "Дата записи";
            // 
            // txtBCreationDate
            // 
            this.txtBCreationDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBCreationDate.Location = new System.Drawing.Point(3, 16);
            this.txtBCreationDate.MaxLength = 80;
            this.txtBCreationDate.Name = "txtBCreationDate";
            this.txtBCreationDate.ReadOnly = true;
            this.txtBCreationDate.Size = new System.Drawing.Size(135, 20);
            this.txtBCreationDate.TabIndex = 0;
            this.txtBCreationDate.TabStop = false;
            // 
            // tabPageDescription
            // 
            this.tabPageDescription.Controls.Add(this.txtBDescription);
            this.tabPageDescription.Location = new System.Drawing.Point(4, 22);
            this.tabPageDescription.Name = "tabPageDescription";
            this.tabPageDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDescription.Size = new System.Drawing.Size(816, 501);
            this.tabPageDescription.TabIndex = 4;
            this.tabPageDescription.Text = "Описание";
            this.tabPageDescription.UseVisualStyleBackColor = true;
            // 
            // txtBDescription
            // 
            this.txtBDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBDescription.Location = new System.Drawing.Point(3, 3);
            this.txtBDescription.Multiline = true;
            this.txtBDescription.Name = "txtBDescription";
            this.txtBDescription.ReadOnly = true;
            this.txtBDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBDescription.Size = new System.Drawing.Size(810, 495);
            this.txtBDescription.TabIndex = 2;
            // 
            // tabPageNote
            // 
            this.tabPageNote.Controls.Add(this.txtBNote);
            this.tabPageNote.Location = new System.Drawing.Point(4, 22);
            this.tabPageNote.Name = "tabPageNote";
            this.tabPageNote.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNote.Size = new System.Drawing.Size(816, 501);
            this.tabPageNote.TabIndex = 2;
            this.tabPageNote.Text = "Примечание";
            this.tabPageNote.UseVisualStyleBackColor = true;
            // 
            // txtBNote
            // 
            this.txtBNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBNote.Location = new System.Drawing.Point(3, 3);
            this.txtBNote.Multiline = true;
            this.txtBNote.Name = "txtBNote";
            this.txtBNote.ReadOnly = true;
            this.txtBNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBNote.Size = new System.Drawing.Size(810, 495);
            this.txtBNote.TabIndex = 1;
            // 
            // FormPersonCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(824, 601);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPersonCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Информация о человеке";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageInformation.ResumeLayout(false);
            this.gBReading.ResumeLayout(false);
            this.gBPhotoFileName.ResumeLayout(false);
            this.gBPhotoFileName.PerformLayout();
            this.gBPhoneNumber.ResumeLayout(false);
            this.gBPhoneNumber.PerformLayout();
            this.gBAddress.ResumeLayout(false);
            this.gBAddress.PerformLayout();
            this.gBMeetingPlace.ResumeLayout(false);
            this.gBMeetingPlace.PerformLayout();
            this.gBMeetingDate.ResumeLayout(false);
            this.gBBirthDay.ResumeLayout(false);
            this.gBSecondName.ResumeLayout(false);
            this.gBSecondName.PerformLayout();
            this.gBFirstName.ResumeLayout(false);
            this.gBFirstName.PerformLayout();
            this.gBSurname.ResumeLayout(false);
            this.gBSurname.PerformLayout();
            this.gBCreationDate.ResumeLayout(false);
            this.gBCreationDate.PerformLayout();
            this.tabPageDescription.ResumeLayout(false);
            this.tabPageDescription.PerformLayout();
            this.tabPageNote.ResumeLayout(false);
            this.tabPageNote.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tSMIEdit;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageInformation;
        private System.Windows.Forms.TabPage tabPageNote;
        private System.Windows.Forms.TextBox txtBNote;
        private System.Windows.Forms.GroupBox gBReading;
        private System.Windows.Forms.TabPage tabPageDescription;
        private System.Windows.Forms.TextBox txtBDescription;
        private System.Windows.Forms.GroupBox gBCreationDate;
        private System.Windows.Forms.TextBox txtBCreationDate;
        private System.Windows.Forms.GroupBox gBSecondName;
        private System.Windows.Forms.TextBox txtBSecondName;
        private System.Windows.Forms.GroupBox gBFirstName;
        private System.Windows.Forms.TextBox txtBFirstName;
        private System.Windows.Forms.GroupBox gBSurname;
        private System.Windows.Forms.TextBox txtBSurname;
        private ru.sevmash.pkb.Controls.NullableDateTimePicker nDTPBirthDay;
        private System.Windows.Forms.GroupBox gBBirthDay;
        private System.Windows.Forms.GroupBox gBMeetingDate;
        private ru.sevmash.pkb.Controls.NullableDateTimePicker nDTPMeetingDate;
        private System.Windows.Forms.GroupBox gBMeetingPlace;
        private System.Windows.Forms.TextBox txtBMeetingPlace;
        private System.Windows.Forms.GroupBox gBAddress;
        private System.Windows.Forms.TextBox txtBAddress;
        private System.Windows.Forms.GroupBox gBPhoneNumber;
        private System.Windows.Forms.TextBox txtBPhoneNumber;
        private System.Windows.Forms.GroupBox gBPhotoFileName;
        private System.Windows.Forms.TextBox txtBPhotoFileName;
    }
}