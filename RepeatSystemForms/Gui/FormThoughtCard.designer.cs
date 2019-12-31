﻿namespace RepeatSystemForms.Gui
{
    partial class FormThoughtCard
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
            this.gBDescription = new System.Windows.Forms.GroupBox();
            this.txtBDescription = new System.Windows.Forms.TextBox();
            this.gBInformation = new System.Windows.Forms.GroupBox();
            this.gBCreationDate = new System.Windows.Forms.GroupBox();
            this.txtBCreationDate = new System.Windows.Forms.TextBox();
            this.gBNumber = new System.Windows.Forms.GroupBox();
            this.txtBNumber = new System.Windows.Forms.TextBox();
            this.gBIdea = new System.Windows.Forms.GroupBox();
            this.txtBIdea = new System.Windows.Forms.TextBox();
            this.gBThoughtType = new System.Windows.Forms.GroupBox();
            this.cmBThoughtType = new System.Windows.Forms.ComboBox();
            this.tabPageNote = new System.Windows.Forms.TabPage();
            this.txtBNote = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageInformation.SuspendLayout();
            this.gBDescription.SuspendLayout();
            this.gBInformation.SuspendLayout();
            this.gBCreationDate.SuspendLayout();
            this.gBNumber.SuspendLayout();
            this.gBIdea.SuspendLayout();
            this.gBThoughtType.SuspendLayout();
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
            this.tabPageInformation.Controls.Add(this.gBDescription);
            this.tabPageInformation.Controls.Add(this.gBInformation);
            this.tabPageInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageInformation.Name = "tabPageInformation";
            this.tabPageInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInformation.Size = new System.Drawing.Size(816, 501);
            this.tabPageInformation.TabIndex = 0;
            this.tabPageInformation.Text = "Информация";
            this.tabPageInformation.UseVisualStyleBackColor = true;
            // 
            // gBDescription
            // 
            this.gBDescription.Controls.Add(this.txtBDescription);
            this.gBDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBDescription.Location = new System.Drawing.Point(3, 113);
            this.gBDescription.Name = "gBDescription";
            this.gBDescription.Size = new System.Drawing.Size(810, 385);
            this.gBDescription.TabIndex = 5;
            this.gBDescription.TabStop = false;
            this.gBDescription.Text = "Описание";
            // 
            // txtBDescription
            // 
            this.txtBDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBDescription.Location = new System.Drawing.Point(3, 16);
            this.txtBDescription.Multiline = true;
            this.txtBDescription.Name = "txtBDescription";
            this.txtBDescription.ReadOnly = true;
            this.txtBDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBDescription.Size = new System.Drawing.Size(804, 366);
            this.txtBDescription.TabIndex = 2;
            // 
            // gBInformation
            // 
            this.gBInformation.Controls.Add(this.gBCreationDate);
            this.gBInformation.Controls.Add(this.gBNumber);
            this.gBInformation.Controls.Add(this.gBIdea);
            this.gBInformation.Controls.Add(this.gBThoughtType);
            this.gBInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBInformation.Location = new System.Drawing.Point(3, 3);
            this.gBInformation.Name = "gBInformation";
            this.gBInformation.Size = new System.Drawing.Size(810, 110);
            this.gBInformation.TabIndex = 4;
            this.gBInformation.TabStop = false;
            this.gBInformation.Text = "Информация";
            // 
            // gBCreationDate
            // 
            this.gBCreationDate.Controls.Add(this.txtBCreationDate);
            this.gBCreationDate.Location = new System.Drawing.Point(6, 19);
            this.gBCreationDate.Name = "gBCreationDate";
            this.gBCreationDate.Size = new System.Drawing.Size(141, 40);
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
            this.txtBCreationDate.Size = new System.Drawing.Size(135, 20);
            this.txtBCreationDate.TabIndex = 0;
            this.txtBCreationDate.TabStop = false;
            // 
            // gBNumber
            // 
            this.gBNumber.Controls.Add(this.txtBNumber);
            this.gBNumber.Location = new System.Drawing.Point(6, 65);
            this.gBNumber.Name = "gBNumber";
            this.gBNumber.Size = new System.Drawing.Size(67, 40);
            this.gBNumber.TabIndex = 2;
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
            this.txtBNumber.Size = new System.Drawing.Size(61, 20);
            this.txtBNumber.TabIndex = 0;
            // 
            // gBIdea
            // 
            this.gBIdea.Controls.Add(this.txtBIdea);
            this.gBIdea.Location = new System.Drawing.Point(79, 65);
            this.gBIdea.Name = "gBIdea";
            this.gBIdea.Size = new System.Drawing.Size(470, 40);
            this.gBIdea.TabIndex = 3;
            this.gBIdea.TabStop = false;
            this.gBIdea.Text = "Размышление";
            // 
            // txtBIdea
            // 
            this.txtBIdea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBIdea.Location = new System.Drawing.Point(3, 16);
            this.txtBIdea.MaxLength = 80;
            this.txtBIdea.Name = "txtBIdea";
            this.txtBIdea.ReadOnly = true;
            this.txtBIdea.Size = new System.Drawing.Size(464, 20);
            this.txtBIdea.TabIndex = 0;
            // 
            // gBThoughtType
            // 
            this.gBThoughtType.Controls.Add(this.cmBThoughtType);
            this.gBThoughtType.Location = new System.Drawing.Point(153, 19);
            this.gBThoughtType.Name = "gBThoughtType";
            this.gBThoughtType.Size = new System.Drawing.Size(396, 40);
            this.gBThoughtType.TabIndex = 1;
            this.gBThoughtType.TabStop = false;
            this.gBThoughtType.Text = "Тип размышления";
            // 
            // cmBThoughtType
            // 
            this.cmBThoughtType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmBThoughtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBThoughtType.Enabled = false;
            this.cmBThoughtType.FormattingEnabled = true;
            this.cmBThoughtType.Location = new System.Drawing.Point(3, 16);
            this.cmBThoughtType.MaxDropDownItems = 16;
            this.cmBThoughtType.Name = "cmBThoughtType";
            this.cmBThoughtType.Size = new System.Drawing.Size(390, 21);
            this.cmBThoughtType.TabIndex = 0;
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
            // FormThoughtCard
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
            this.Name = "FormThoughtCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Информация о размышлении";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageInformation.ResumeLayout(false);
            this.gBDescription.ResumeLayout(false);
            this.gBDescription.PerformLayout();
            this.gBInformation.ResumeLayout(false);
            this.gBCreationDate.ResumeLayout(false);
            this.gBCreationDate.PerformLayout();
            this.gBNumber.ResumeLayout(false);
            this.gBNumber.PerformLayout();
            this.gBIdea.ResumeLayout(false);
            this.gBIdea.PerformLayout();
            this.gBThoughtType.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gBCreationDate;
        private System.Windows.Forms.TextBox txtBCreationDate;
        private System.Windows.Forms.GroupBox gBIdea;
        private System.Windows.Forms.TextBox txtBIdea;
        private System.Windows.Forms.GroupBox gBThoughtType;
        private System.Windows.Forms.ComboBox cmBThoughtType;
        private System.Windows.Forms.GroupBox gBNumber;
        private System.Windows.Forms.TextBox txtBNumber;
        private System.Windows.Forms.GroupBox gBInformation;
        private System.Windows.Forms.GroupBox gBDescription;
        private System.Windows.Forms.TextBox txtBDescription;
    }
}