namespace RepeatSystemForms.Gui
{
    partial class FormFactCard
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
            this.gBQuestion = new System.Windows.Forms.GroupBox();
            this.txtBQuestion = new System.Windows.Forms.TextBox();
            this.gBInformation = new System.Windows.Forms.GroupBox();
            this.gBCreationDate = new System.Windows.Forms.GroupBox();
            this.txtBCreationDate = new System.Windows.Forms.TextBox();
            this.gBNumber = new System.Windows.Forms.GroupBox();
            this.txtBNumber = new System.Windows.Forms.TextBox();
            this.gBName = new System.Windows.Forms.GroupBox();
            this.txtBName = new System.Windows.Forms.TextBox();
            this.gBFactType = new System.Windows.Forms.GroupBox();
            this.cmBFactType = new System.Windows.Forms.ComboBox();
            this.tabPageHint = new System.Windows.Forms.TabPage();
            this.txtBHint = new System.Windows.Forms.TextBox();
            this.tabPageAnswer = new System.Windows.Forms.TabPage();
            this.txtBAnswer = new System.Windows.Forms.TextBox();
            this.tabPageNote = new System.Windows.Forms.TabPage();
            this.txtBNote = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageInformation.SuspendLayout();
            this.gBQuestion.SuspendLayout();
            this.gBInformation.SuspendLayout();
            this.gBCreationDate.SuspendLayout();
            this.gBNumber.SuspendLayout();
            this.gBName.SuspendLayout();
            this.gBFactType.SuspendLayout();
            this.tabPageHint.SuspendLayout();
            this.tabPageAnswer.SuspendLayout();
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
            this.tabControl.Controls.Add(this.tabPageHint);
            this.tabControl.Controls.Add(this.tabPageAnswer);
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
            this.tabPageInformation.Controls.Add(this.gBQuestion);
            this.tabPageInformation.Controls.Add(this.gBInformation);
            this.tabPageInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageInformation.Name = "tabPageInformation";
            this.tabPageInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInformation.Size = new System.Drawing.Size(816, 501);
            this.tabPageInformation.TabIndex = 0;
            this.tabPageInformation.Text = "Информация";
            this.tabPageInformation.UseVisualStyleBackColor = true;
            // 
            // gBQuestion
            // 
            this.gBQuestion.Controls.Add(this.txtBQuestion);
            this.gBQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBQuestion.Location = new System.Drawing.Point(3, 113);
            this.gBQuestion.Name = "gBQuestion";
            this.gBQuestion.Size = new System.Drawing.Size(810, 385);
            this.gBQuestion.TabIndex = 1;
            this.gBQuestion.TabStop = false;
            this.gBQuestion.Text = "Вопрос";
            // 
            // txtBQuestion
            // 
            this.txtBQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBQuestion.Location = new System.Drawing.Point(3, 16);
            this.txtBQuestion.Multiline = true;
            this.txtBQuestion.Name = "txtBQuestion";
            this.txtBQuestion.ReadOnly = true;
            this.txtBQuestion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBQuestion.Size = new System.Drawing.Size(804, 366);
            this.txtBQuestion.TabIndex = 2;
            // 
            // gBInformation
            // 
            this.gBInformation.Controls.Add(this.gBCreationDate);
            this.gBInformation.Controls.Add(this.gBNumber);
            this.gBInformation.Controls.Add(this.gBName);
            this.gBInformation.Controls.Add(this.gBFactType);
            this.gBInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBInformation.Location = new System.Drawing.Point(3, 3);
            this.gBInformation.Name = "gBInformation";
            this.gBInformation.Size = new System.Drawing.Size(810, 110);
            this.gBInformation.TabIndex = 0;
            this.gBInformation.TabStop = false;
            this.gBInformation.Text = "Информация";
            // 
            // gBCreationDate
            // 
            this.gBCreationDate.Controls.Add(this.txtBCreationDate);
            this.gBCreationDate.Location = new System.Drawing.Point(6, 19);
            this.gBCreationDate.Name = "gBCreationDate";
            this.gBCreationDate.Size = new System.Drawing.Size(153, 40);
            this.gBCreationDate.TabIndex = 0;
            this.gBCreationDate.TabStop = false;
            this.gBCreationDate.Text = "Дата создания";
            // 
            // txtBCreationDate
            // 
            this.txtBCreationDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBCreationDate.Location = new System.Drawing.Point(3, 16);
            this.txtBCreationDate.MaxLength = 80;
            this.txtBCreationDate.Name = "txtBCreationDate";
            this.txtBCreationDate.ReadOnly = true;
            this.txtBCreationDate.Size = new System.Drawing.Size(147, 20);
            this.txtBCreationDate.TabIndex = 0;
            this.txtBCreationDate.TabStop = false;
            // 
            // gBNumber
            // 
            this.gBNumber.Controls.Add(this.txtBNumber);
            this.gBNumber.Location = new System.Drawing.Point(165, 19);
            this.gBNumber.Name = "gBNumber";
            this.gBNumber.Size = new System.Drawing.Size(75, 40);
            this.gBNumber.TabIndex = 1;
            this.gBNumber.TabStop = false;
            this.gBNumber.Text = "№";
            // 
            // txtBNumber
            // 
            this.txtBNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBNumber.Location = new System.Drawing.Point(3, 16);
            this.txtBNumber.MaxLength = 80;
            this.txtBNumber.Name = "txtBNumber";
            this.txtBNumber.ReadOnly = true;
            this.txtBNumber.Size = new System.Drawing.Size(69, 20);
            this.txtBNumber.TabIndex = 0;
            // 
            // gBName
            // 
            this.gBName.Controls.Add(this.txtBName);
            this.gBName.Location = new System.Drawing.Point(6, 65);
            this.gBName.Name = "gBName";
            this.gBName.Size = new System.Drawing.Size(569, 40);
            this.gBName.TabIndex = 3;
            this.gBName.TabStop = false;
            this.gBName.Text = "Название";
            // 
            // txtBName
            // 
            this.txtBName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBName.Location = new System.Drawing.Point(3, 16);
            this.txtBName.MaxLength = 80;
            this.txtBName.Name = "txtBName";
            this.txtBName.ReadOnly = true;
            this.txtBName.Size = new System.Drawing.Size(563, 20);
            this.txtBName.TabIndex = 0;
            // 
            // gBFactType
            // 
            this.gBFactType.Controls.Add(this.cmBFactType);
            this.gBFactType.Location = new System.Drawing.Point(246, 19);
            this.gBFactType.Name = "gBFactType";
            this.gBFactType.Size = new System.Drawing.Size(329, 40);
            this.gBFactType.TabIndex = 2;
            this.gBFactType.TabStop = false;
            this.gBFactType.Text = "Тип файта";
            // 
            // cmBFactType
            // 
            this.cmBFactType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmBFactType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBFactType.Enabled = false;
            this.cmBFactType.FormattingEnabled = true;
            this.cmBFactType.Location = new System.Drawing.Point(3, 16);
            this.cmBFactType.MaxDropDownItems = 16;
            this.cmBFactType.Name = "cmBFactType";
            this.cmBFactType.Size = new System.Drawing.Size(323, 21);
            this.cmBFactType.TabIndex = 0;
            // 
            // tabPageHint
            // 
            this.tabPageHint.Controls.Add(this.txtBHint);
            this.tabPageHint.Location = new System.Drawing.Point(4, 22);
            this.tabPageHint.Name = "tabPageHint";
            this.tabPageHint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHint.Size = new System.Drawing.Size(816, 501);
            this.tabPageHint.TabIndex = 1;
            this.tabPageHint.Text = "Подсказка";
            this.tabPageHint.UseVisualStyleBackColor = true;
            // 
            // txtBHint
            // 
            this.txtBHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBHint.Location = new System.Drawing.Point(3, 3);
            this.txtBHint.Multiline = true;
            this.txtBHint.Name = "txtBHint";
            this.txtBHint.ReadOnly = true;
            this.txtBHint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBHint.Size = new System.Drawing.Size(810, 495);
            this.txtBHint.TabIndex = 0;
            // 
            // tabPageAnswer
            // 
            this.tabPageAnswer.Controls.Add(this.txtBAnswer);
            this.tabPageAnswer.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnswer.Name = "tabPageAnswer";
            this.tabPageAnswer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnswer.Size = new System.Drawing.Size(816, 501);
            this.tabPageAnswer.TabIndex = 4;
            this.tabPageAnswer.Text = "Ответ";
            this.tabPageAnswer.UseVisualStyleBackColor = true;
            // 
            // txtBAnswer
            // 
            this.txtBAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBAnswer.Location = new System.Drawing.Point(3, 3);
            this.txtBAnswer.Multiline = true;
            this.txtBAnswer.Name = "txtBAnswer";
            this.txtBAnswer.ReadOnly = true;
            this.txtBAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBAnswer.Size = new System.Drawing.Size(810, 495);
            this.txtBAnswer.TabIndex = 2;
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
            // FormFactCard
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
            this.Name = "FormFactCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Информация о факте";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageInformation.ResumeLayout(false);
            this.gBQuestion.ResumeLayout(false);
            this.gBQuestion.PerformLayout();
            this.gBInformation.ResumeLayout(false);
            this.gBCreationDate.ResumeLayout(false);
            this.gBCreationDate.PerformLayout();
            this.gBNumber.ResumeLayout(false);
            this.gBNumber.PerformLayout();
            this.gBName.ResumeLayout(false);
            this.gBName.PerformLayout();
            this.gBFactType.ResumeLayout(false);
            this.tabPageHint.ResumeLayout(false);
            this.tabPageHint.PerformLayout();
            this.tabPageAnswer.ResumeLayout(false);
            this.tabPageAnswer.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPageHint;
        private System.Windows.Forms.TabPage tabPageNote;
        private System.Windows.Forms.TextBox txtBHint;
        private System.Windows.Forms.TextBox txtBNote;
        private System.Windows.Forms.TabPage tabPageAnswer;
        private System.Windows.Forms.TextBox txtBAnswer;
        private System.Windows.Forms.GroupBox gBCreationDate;
        private System.Windows.Forms.TextBox txtBCreationDate;
        private System.Windows.Forms.GroupBox gBName;
        private System.Windows.Forms.TextBox txtBName;
        private System.Windows.Forms.GroupBox gBFactType;
        private System.Windows.Forms.ComboBox cmBFactType;
        private System.Windows.Forms.GroupBox gBNumber;
        private System.Windows.Forms.TextBox txtBNumber;
        private System.Windows.Forms.GroupBox gBInformation;
        private System.Windows.Forms.GroupBox gBQuestion;
        private System.Windows.Forms.TextBox txtBQuestion;
    }
}