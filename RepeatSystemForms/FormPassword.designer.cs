namespace RepeatSystemForms
{
    partial class FormPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPassword));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.gBDataBase = new System.Windows.Forms.GroupBox();
            this.btnChooseDataBaseFilePath = new System.Windows.Forms.Button();
            this.txtBDataBaseFilePath = new System.Windows.Forms.TextBox();
            this.gBSourceFiles = new System.Windows.Forms.GroupBox();
            this.btnChooseSourceFiles = new System.Windows.Forms.Button();
            this.txtBSourceFiles = new System.Windows.Forms.TextBox();
            this.gBSourceBooks = new System.Windows.Forms.GroupBox();
            this.btnChooseSourceBooks = new System.Windows.Forms.Button();
            this.txtBSourceBooks = new System.Windows.Forms.TextBox();
            this.gBDataBase.SuspendLayout();
            this.gBSourceFiles.SuspendLayout();
            this.gBSourceBooks.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(512, 150);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonEnter
            // 
            this.buttonEnter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonEnter.Location = new System.Drawing.Point(403, 150);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(90, 23);
            this.buttonEnter.TabIndex = 0;
            this.buttonEnter.Text = "Подключиться";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // gBDataBase
            // 
            this.gBDataBase.Controls.Add(this.btnChooseDataBaseFilePath);
            this.gBDataBase.Controls.Add(this.txtBDataBaseFilePath);
            this.gBDataBase.Location = new System.Drawing.Point(12, 12);
            this.gBDataBase.Name = "gBDataBase";
            this.gBDataBase.Size = new System.Drawing.Size(590, 40);
            this.gBDataBase.TabIndex = 2;
            this.gBDataBase.TabStop = false;
            this.gBDataBase.Text = "База данных";
            // 
            // btnChooseDataBaseFilePath
            // 
            this.btnChooseDataBaseFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseDataBaseFilePath.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseDataBaseFilePath.Image")));
            this.btnChooseDataBaseFilePath.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnChooseDataBaseFilePath.Location = new System.Drawing.Point(511, 12);
            this.btnChooseDataBaseFilePath.Name = "btnChooseDataBaseFilePath";
            this.btnChooseDataBaseFilePath.Size = new System.Drawing.Size(71, 24);
            this.btnChooseDataBaseFilePath.TabIndex = 1;
            this.btnChooseDataBaseFilePath.Text = "Выбрать";
            this.btnChooseDataBaseFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChooseDataBaseFilePath.UseVisualStyleBackColor = true;
            this.btnChooseDataBaseFilePath.Click += new System.EventHandler(this.btnChoseDataBaseFilePath_Click);
            // 
            // txtBDataBaseFilePath
            // 
            this.txtBDataBaseFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBDataBaseFilePath.Location = new System.Drawing.Point(6, 15);
            this.txtBDataBaseFilePath.Name = "txtBDataBaseFilePath";
            this.txtBDataBaseFilePath.ReadOnly = true;
            this.txtBDataBaseFilePath.Size = new System.Drawing.Size(499, 20);
            this.txtBDataBaseFilePath.TabIndex = 0;
            this.txtBDataBaseFilePath.TabStop = false;
            // 
            // gBSourceFiles
            // 
            this.gBSourceFiles.Controls.Add(this.btnChooseSourceFiles);
            this.gBSourceFiles.Controls.Add(this.txtBSourceFiles);
            this.gBSourceFiles.Location = new System.Drawing.Point(12, 104);
            this.gBSourceFiles.Name = "gBSourceFiles";
            this.gBSourceFiles.Size = new System.Drawing.Size(590, 40);
            this.gBSourceFiles.TabIndex = 4;
            this.gBSourceFiles.TabStop = false;
            this.gBSourceFiles.Text = "Библиотека файлов";
            // 
            // btnChooseSourceFiles
            // 
            this.btnChooseSourceFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseSourceFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseSourceFiles.Image")));
            this.btnChooseSourceFiles.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnChooseSourceFiles.Location = new System.Drawing.Point(511, 12);
            this.btnChooseSourceFiles.Name = "btnChooseSourceFiles";
            this.btnChooseSourceFiles.Size = new System.Drawing.Size(71, 24);
            this.btnChooseSourceFiles.TabIndex = 1;
            this.btnChooseSourceFiles.Text = "Выбрать";
            this.btnChooseSourceFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChooseSourceFiles.UseVisualStyleBackColor = true;
            // 
            // txtBSourceFiles
            // 
            this.txtBSourceFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBSourceFiles.Location = new System.Drawing.Point(6, 15);
            this.txtBSourceFiles.Name = "txtBSourceFiles";
            this.txtBSourceFiles.ReadOnly = true;
            this.txtBSourceFiles.Size = new System.Drawing.Size(499, 20);
            this.txtBSourceFiles.TabIndex = 0;
            this.txtBSourceFiles.TabStop = false;
            // 
            // gBSourceBooks
            // 
            this.gBSourceBooks.Controls.Add(this.btnChooseSourceBooks);
            this.gBSourceBooks.Controls.Add(this.txtBSourceBooks);
            this.gBSourceBooks.Location = new System.Drawing.Point(12, 58);
            this.gBSourceBooks.Name = "gBSourceBooks";
            this.gBSourceBooks.Size = new System.Drawing.Size(590, 40);
            this.gBSourceBooks.TabIndex = 3;
            this.gBSourceBooks.TabStop = false;
            this.gBSourceBooks.Text = "Библиотека книг";
            // 
            // btnChooseSourceBooks
            // 
            this.btnChooseSourceBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseSourceBooks.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseSourceBooks.Image")));
            this.btnChooseSourceBooks.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnChooseSourceBooks.Location = new System.Drawing.Point(511, 12);
            this.btnChooseSourceBooks.Name = "btnChooseSourceBooks";
            this.btnChooseSourceBooks.Size = new System.Drawing.Size(71, 24);
            this.btnChooseSourceBooks.TabIndex = 1;
            this.btnChooseSourceBooks.Text = "Выбрать";
            this.btnChooseSourceBooks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChooseSourceBooks.UseVisualStyleBackColor = true;
            // 
            // txtBSourceBooks
            // 
            this.txtBSourceBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBSourceBooks.Location = new System.Drawing.Point(6, 15);
            this.txtBSourceBooks.Name = "txtBSourceBooks";
            this.txtBSourceBooks.ReadOnly = true;
            this.txtBSourceBooks.Size = new System.Drawing.Size(499, 20);
            this.txtBSourceBooks.TabIndex = 0;
            this.txtBSourceBooks.TabStop = false;
            // 
            // FormPassword
            // 
            this.AcceptButton = this.buttonEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(614, 185);
            this.Controls.Add(this.gBSourceBooks);
            this.Controls.Add(this.gBSourceFiles);
            this.Controls.Add(this.gBDataBase);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonEnter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подключение";
            this.gBDataBase.ResumeLayout(false);
            this.gBDataBase.PerformLayout();
            this.gBSourceFiles.ResumeLayout(false);
            this.gBSourceFiles.PerformLayout();
            this.gBSourceBooks.ResumeLayout(false);
            this.gBSourceBooks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.GroupBox gBDataBase;
        private System.Windows.Forms.Button btnChooseDataBaseFilePath;
        private System.Windows.Forms.TextBox txtBDataBaseFilePath;
        private System.Windows.Forms.GroupBox gBSourceFiles;
        private System.Windows.Forms.Button btnChooseSourceFiles;
        private System.Windows.Forms.TextBox txtBSourceFiles;
        private System.Windows.Forms.GroupBox gBSourceBooks;
        private System.Windows.Forms.Button btnChooseSourceBooks;
        private System.Windows.Forms.TextBox txtBSourceBooks;
    }
}