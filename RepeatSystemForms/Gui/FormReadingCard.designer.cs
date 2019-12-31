namespace RepeatSystemForms.Gui
{
    partial class FormReadingCard
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
            this.gBBookName = new System.Windows.Forms.GroupBox();
            this.txtBBookName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIBookCard = new System.Windows.Forms.ToolStripMenuItem();
            this.gBBookEdition = new System.Windows.Forms.GroupBox();
            this.txtBBookEdition = new System.Windows.Forms.TextBox();
            this.gBBookYear = new System.Windows.Forms.GroupBox();
            this.txtBBookYear = new System.Windows.Forms.TextBox();
            this.gBBookPageCount = new System.Windows.Forms.GroupBox();
            this.txtBBookPageCount = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageInformation = new System.Windows.Forms.TabPage();
            this.gBReading = new System.Windows.Forms.GroupBox();
            this.gBCreationDate = new System.Windows.Forms.GroupBox();
            this.txtBCreationDate = new System.Windows.Forms.TextBox();
            this.gBName = new System.Windows.Forms.GroupBox();
            this.txtBName = new System.Windows.Forms.TextBox();
            this.gBLastPage = new System.Windows.Forms.GroupBox();
            this.txtBLastPage = new System.Windows.Forms.TextBox();
            this.gBNumber = new System.Windows.Forms.GroupBox();
            this.txtBNumber = new System.Windows.Forms.TextBox();
            this.gBFirstPage = new System.Windows.Forms.GroupBox();
            this.txtBFirstPage = new System.Windows.Forms.TextBox();
            this.gBBook = new System.Windows.Forms.GroupBox();
            this.btnSearchBook = new System.Windows.Forms.Button();
            this.tabPageHint = new System.Windows.Forms.TabPage();
            this.txtBHint = new System.Windows.Forms.TextBox();
            this.tabPageRetelling = new System.Windows.Forms.TabPage();
            this.txtBRetelling = new System.Windows.Forms.TextBox();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.txtBSummary = new System.Windows.Forms.TextBox();
            this.tabPageNote = new System.Windows.Forms.TabPage();
            this.txtBNote = new System.Windows.Forms.TextBox();
            this.tabPageBookReview = new System.Windows.Forms.TabPage();
            this.txtBBookReview = new System.Windows.Forms.TextBox();
            this.tabPageBookEstimation = new System.Windows.Forms.TabPage();
            this.txtBBookEstimation = new System.Windows.Forms.TextBox();
            this.tabPageBookNote = new System.Windows.Forms.TabPage();
            this.txtBBookNote = new System.Windows.Forms.TextBox();
            this.gBBookName.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.gBBookEdition.SuspendLayout();
            this.gBBookYear.SuspendLayout();
            this.gBBookPageCount.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageInformation.SuspendLayout();
            this.gBReading.SuspendLayout();
            this.gBCreationDate.SuspendLayout();
            this.gBName.SuspendLayout();
            this.gBLastPage.SuspendLayout();
            this.gBNumber.SuspendLayout();
            this.gBFirstPage.SuspendLayout();
            this.gBBook.SuspendLayout();
            this.tabPageHint.SuspendLayout();
            this.tabPageRetelling.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            this.tabPageNote.SuspendLayout();
            this.tabPageBookReview.SuspendLayout();
            this.tabPageBookEstimation.SuspendLayout();
            this.tabPageBookNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBBookName
            // 
            this.gBBookName.Controls.Add(this.txtBBookName);
            this.gBBookName.Location = new System.Drawing.Point(6, 19);
            this.gBBookName.Name = "gBBookName";
            this.gBBookName.Size = new System.Drawing.Size(621, 40);
            this.gBBookName.TabIndex = 0;
            this.gBBookName.TabStop = false;
            this.gBBookName.Text = "Наименование";
            // 
            // txtBBookName
            // 
            this.txtBBookName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBBookName.Location = new System.Drawing.Point(3, 16);
            this.txtBBookName.MaxLength = 80;
            this.txtBBookName.Name = "txtBBookName";
            this.txtBBookName.ReadOnly = true;
            this.txtBBookName.Size = new System.Drawing.Size(615, 20);
            this.txtBBookName.TabIndex = 0;
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
            this.tSMIEdit,
            this.tSMIBookCard});
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
            // tSMIBookCard
            // 
            this.tSMIBookCard.Enabled = false;
            this.tSMIBookCard.Name = "tSMIBookCard";
            this.tSMIBookCard.Size = new System.Drawing.Size(49, 20);
            this.tSMIBookCard.Text = "Книга";
            this.tSMIBookCard.Visible = false;
            this.tSMIBookCard.Click += new System.EventHandler(this.tSMIBookCard_Click);
            // 
            // gBBookEdition
            // 
            this.gBBookEdition.Controls.Add(this.txtBBookEdition);
            this.gBBookEdition.Location = new System.Drawing.Point(79, 65);
            this.gBBookEdition.Name = "gBBookEdition";
            this.gBBookEdition.Size = new System.Drawing.Size(53, 40);
            this.gBBookEdition.TabIndex = 2;
            this.gBBookEdition.TabStop = false;
            this.gBBookEdition.Text = "Изд";
            // 
            // txtBBookEdition
            // 
            this.txtBBookEdition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBBookEdition.Location = new System.Drawing.Point(3, 16);
            this.txtBBookEdition.MaxLength = 80;
            this.txtBBookEdition.Name = "txtBBookEdition";
            this.txtBBookEdition.ReadOnly = true;
            this.txtBBookEdition.Size = new System.Drawing.Size(47, 20);
            this.txtBBookEdition.TabIndex = 0;
            // 
            // gBBookYear
            // 
            this.gBBookYear.Controls.Add(this.txtBBookYear);
            this.gBBookYear.Location = new System.Drawing.Point(6, 65);
            this.gBBookYear.Name = "gBBookYear";
            this.gBBookYear.Size = new System.Drawing.Size(67, 40);
            this.gBBookYear.TabIndex = 1;
            this.gBBookYear.TabStop = false;
            this.gBBookYear.Text = "Год";
            // 
            // txtBBookYear
            // 
            this.txtBBookYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBBookYear.Location = new System.Drawing.Point(3, 16);
            this.txtBBookYear.MaxLength = 80;
            this.txtBBookYear.Name = "txtBBookYear";
            this.txtBBookYear.ReadOnly = true;
            this.txtBBookYear.Size = new System.Drawing.Size(61, 20);
            this.txtBBookYear.TabIndex = 0;
            // 
            // gBBookPageCount
            // 
            this.gBBookPageCount.Controls.Add(this.txtBBookPageCount);
            this.gBBookPageCount.Location = new System.Drawing.Point(138, 65);
            this.gBBookPageCount.Name = "gBBookPageCount";
            this.gBBookPageCount.Size = new System.Drawing.Size(70, 40);
            this.gBBookPageCount.TabIndex = 3;
            this.gBBookPageCount.TabStop = false;
            this.gBBookPageCount.Text = "Страниц";
            // 
            // txtBBookPageCount
            // 
            this.txtBBookPageCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBBookPageCount.Location = new System.Drawing.Point(3, 16);
            this.txtBBookPageCount.MaxLength = 80;
            this.txtBBookPageCount.Name = "txtBBookPageCount";
            this.txtBBookPageCount.ReadOnly = true;
            this.txtBBookPageCount.Size = new System.Drawing.Size(64, 20);
            this.txtBBookPageCount.TabIndex = 0;
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
            this.tabControl.Controls.Add(this.tabPageRetelling);
            this.tabControl.Controls.Add(this.tabPageSummary);
            this.tabControl.Controls.Add(this.tabPageNote);
            this.tabControl.Controls.Add(this.tabPageBookReview);
            this.tabControl.Controls.Add(this.tabPageBookEstimation);
            this.tabControl.Controls.Add(this.tabPageBookNote);
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
            this.tabPageInformation.Controls.Add(this.gBBook);
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
            this.gBReading.Controls.Add(this.gBCreationDate);
            this.gBReading.Controls.Add(this.gBName);
            this.gBReading.Controls.Add(this.gBLastPage);
            this.gBReading.Controls.Add(this.gBNumber);
            this.gBReading.Controls.Add(this.gBFirstPage);
            this.gBReading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBReading.Location = new System.Drawing.Point(3, 112);
            this.gBReading.Name = "gBReading";
            this.gBReading.Size = new System.Drawing.Size(810, 386);
            this.gBReading.TabIndex = 4;
            this.gBReading.TabStop = false;
            this.gBReading.Text = "Чтение и пересказ";
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
            // gBName
            // 
            this.gBName.Controls.Add(this.txtBName);
            this.gBName.Location = new System.Drawing.Point(6, 65);
            this.gBName.Name = "gBName";
            this.gBName.Size = new System.Drawing.Size(621, 40);
            this.gBName.TabIndex = 1;
            this.gBName.TabStop = false;
            this.gBName.Text = "Наименование пересказа";
            // 
            // txtBName
            // 
            this.txtBName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBName.Location = new System.Drawing.Point(3, 16);
            this.txtBName.MaxLength = 80;
            this.txtBName.Name = "txtBName";
            this.txtBName.ReadOnly = true;
            this.txtBName.Size = new System.Drawing.Size(615, 20);
            this.txtBName.TabIndex = 0;
            // 
            // gBLastPage
            // 
            this.gBLastPage.Controls.Add(this.txtBLastPage);
            this.gBLastPage.Location = new System.Drawing.Point(152, 111);
            this.gBLastPage.Name = "gBLastPage";
            this.gBLastPage.Size = new System.Drawing.Size(67, 40);
            this.gBLastPage.TabIndex = 4;
            this.gBLastPage.TabStop = false;
            this.gBLastPage.Text = "По";
            // 
            // txtBLastPage
            // 
            this.txtBLastPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBLastPage.Location = new System.Drawing.Point(3, 16);
            this.txtBLastPage.MaxLength = 80;
            this.txtBLastPage.Name = "txtBLastPage";
            this.txtBLastPage.ReadOnly = true;
            this.txtBLastPage.Size = new System.Drawing.Size(61, 20);
            this.txtBLastPage.TabIndex = 0;
            // 
            // gBNumber
            // 
            this.gBNumber.Controls.Add(this.txtBNumber);
            this.gBNumber.Location = new System.Drawing.Point(6, 111);
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
            // gBFirstPage
            // 
            this.gBFirstPage.Controls.Add(this.txtBFirstPage);
            this.gBFirstPage.Location = new System.Drawing.Point(79, 111);
            this.gBFirstPage.Name = "gBFirstPage";
            this.gBFirstPage.Size = new System.Drawing.Size(67, 40);
            this.gBFirstPage.TabIndex = 3;
            this.gBFirstPage.TabStop = false;
            this.gBFirstPage.Text = "С";
            // 
            // txtBFirstPage
            // 
            this.txtBFirstPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBFirstPage.Location = new System.Drawing.Point(3, 16);
            this.txtBFirstPage.MaxLength = 80;
            this.txtBFirstPage.Name = "txtBFirstPage";
            this.txtBFirstPage.ReadOnly = true;
            this.txtBFirstPage.Size = new System.Drawing.Size(61, 20);
            this.txtBFirstPage.TabIndex = 0;
            // 
            // gBBook
            // 
            this.gBBook.Controls.Add(this.btnSearchBook);
            this.gBBook.Controls.Add(this.gBBookName);
            this.gBBook.Controls.Add(this.gBBookEdition);
            this.gBBook.Controls.Add(this.gBBookPageCount);
            this.gBBook.Controls.Add(this.gBBookYear);
            this.gBBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBBook.Location = new System.Drawing.Point(3, 3);
            this.gBBook.Name = "gBBook";
            this.gBBook.Size = new System.Drawing.Size(810, 109);
            this.gBBook.TabIndex = 1;
            this.gBBook.TabStop = false;
            this.gBBook.Text = "Книга";
            // 
            // btnSearchBook
            // 
            this.btnSearchBook.Location = new System.Drawing.Point(214, 78);
            this.btnSearchBook.Name = "btnSearchBook";
            this.btnSearchBook.Size = new System.Drawing.Size(75, 23);
            this.btnSearchBook.TabIndex = 4;
            this.btnSearchBook.Text = "Найти";
            this.btnSearchBook.UseVisualStyleBackColor = true;
            this.btnSearchBook.Click += new System.EventHandler(this.btnSearchBook_Click);
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
            // tabPageRetelling
            // 
            this.tabPageRetelling.Controls.Add(this.txtBRetelling);
            this.tabPageRetelling.Location = new System.Drawing.Point(4, 22);
            this.tabPageRetelling.Name = "tabPageRetelling";
            this.tabPageRetelling.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRetelling.Size = new System.Drawing.Size(816, 501);
            this.tabPageRetelling.TabIndex = 3;
            this.tabPageRetelling.Text = "Пересказ";
            this.tabPageRetelling.UseVisualStyleBackColor = true;
            // 
            // txtBRetelling
            // 
            this.txtBRetelling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBRetelling.Location = new System.Drawing.Point(3, 3);
            this.txtBRetelling.Multiline = true;
            this.txtBRetelling.Name = "txtBRetelling";
            this.txtBRetelling.ReadOnly = true;
            this.txtBRetelling.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBRetelling.Size = new System.Drawing.Size(810, 495);
            this.txtBRetelling.TabIndex = 1;
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.Controls.Add(this.txtBSummary);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 22);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSummary.Size = new System.Drawing.Size(816, 501);
            this.tabPageSummary.TabIndex = 4;
            this.tabPageSummary.Text = "Оценка";
            this.tabPageSummary.UseVisualStyleBackColor = true;
            // 
            // txtBSummary
            // 
            this.txtBSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBSummary.Location = new System.Drawing.Point(3, 3);
            this.txtBSummary.Multiline = true;
            this.txtBSummary.Name = "txtBSummary";
            this.txtBSummary.ReadOnly = true;
            this.txtBSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBSummary.Size = new System.Drawing.Size(810, 495);
            this.txtBSummary.TabIndex = 2;
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
            // tabPageBookReview
            // 
            this.tabPageBookReview.Controls.Add(this.txtBBookReview);
            this.tabPageBookReview.Location = new System.Drawing.Point(4, 22);
            this.tabPageBookReview.Name = "tabPageBookReview";
            this.tabPageBookReview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBookReview.Size = new System.Drawing.Size(816, 501);
            this.tabPageBookReview.TabIndex = 7;
            this.tabPageBookReview.Text = "Книга - Рецензия";
            this.tabPageBookReview.UseVisualStyleBackColor = true;
            // 
            // txtBBookReview
            // 
            this.txtBBookReview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBBookReview.Location = new System.Drawing.Point(3, 3);
            this.txtBBookReview.Multiline = true;
            this.txtBBookReview.Name = "txtBBookReview";
            this.txtBBookReview.ReadOnly = true;
            this.txtBBookReview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBBookReview.Size = new System.Drawing.Size(810, 495);
            this.txtBBookReview.TabIndex = 2;
            // 
            // tabPageBookEstimation
            // 
            this.tabPageBookEstimation.Controls.Add(this.txtBBookEstimation);
            this.tabPageBookEstimation.Location = new System.Drawing.Point(4, 22);
            this.tabPageBookEstimation.Name = "tabPageBookEstimation";
            this.tabPageBookEstimation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBookEstimation.Size = new System.Drawing.Size(816, 501);
            this.tabPageBookEstimation.TabIndex = 5;
            this.tabPageBookEstimation.Text = "Книга - Оценка";
            this.tabPageBookEstimation.UseVisualStyleBackColor = true;
            // 
            // txtBBookEstimation
            // 
            this.txtBBookEstimation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBBookEstimation.Location = new System.Drawing.Point(3, 3);
            this.txtBBookEstimation.Multiline = true;
            this.txtBBookEstimation.Name = "txtBBookEstimation";
            this.txtBBookEstimation.ReadOnly = true;
            this.txtBBookEstimation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBBookEstimation.Size = new System.Drawing.Size(810, 495);
            this.txtBBookEstimation.TabIndex = 2;
            // 
            // tabPageBookNote
            // 
            this.tabPageBookNote.Controls.Add(this.txtBBookNote);
            this.tabPageBookNote.Location = new System.Drawing.Point(4, 22);
            this.tabPageBookNote.Name = "tabPageBookNote";
            this.tabPageBookNote.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBookNote.Size = new System.Drawing.Size(816, 501);
            this.tabPageBookNote.TabIndex = 6;
            this.tabPageBookNote.Text = "Книга - Примечание";
            this.tabPageBookNote.UseVisualStyleBackColor = true;
            // 
            // txtBBookNote
            // 
            this.txtBBookNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBBookNote.Location = new System.Drawing.Point(3, 3);
            this.txtBBookNote.Multiline = true;
            this.txtBBookNote.Name = "txtBBookNote";
            this.txtBBookNote.ReadOnly = true;
            this.txtBBookNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBBookNote.Size = new System.Drawing.Size(810, 495);
            this.txtBBookNote.TabIndex = 2;
            // 
            // FormReadingCard
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
            this.Name = "FormReadingCard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Информация о чтении и пересказе";
            this.gBBookName.ResumeLayout(false);
            this.gBBookName.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.gBBookEdition.ResumeLayout(false);
            this.gBBookEdition.PerformLayout();
            this.gBBookYear.ResumeLayout(false);
            this.gBBookYear.PerformLayout();
            this.gBBookPageCount.ResumeLayout(false);
            this.gBBookPageCount.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageInformation.ResumeLayout(false);
            this.gBReading.ResumeLayout(false);
            this.gBCreationDate.ResumeLayout(false);
            this.gBCreationDate.PerformLayout();
            this.gBName.ResumeLayout(false);
            this.gBName.PerformLayout();
            this.gBLastPage.ResumeLayout(false);
            this.gBLastPage.PerformLayout();
            this.gBNumber.ResumeLayout(false);
            this.gBNumber.PerformLayout();
            this.gBFirstPage.ResumeLayout(false);
            this.gBFirstPage.PerformLayout();
            this.gBBook.ResumeLayout(false);
            this.tabPageHint.ResumeLayout(false);
            this.tabPageHint.PerformLayout();
            this.tabPageRetelling.ResumeLayout(false);
            this.tabPageRetelling.PerformLayout();
            this.tabPageSummary.ResumeLayout(false);
            this.tabPageSummary.PerformLayout();
            this.tabPageNote.ResumeLayout(false);
            this.tabPageNote.PerformLayout();
            this.tabPageBookReview.ResumeLayout(false);
            this.tabPageBookReview.PerformLayout();
            this.tabPageBookEstimation.ResumeLayout(false);
            this.tabPageBookEstimation.PerformLayout();
            this.tabPageBookNote.ResumeLayout(false);
            this.tabPageBookNote.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBBookName;
        private System.Windows.Forms.TextBox txtBBookName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tSMIEdit;
        private System.Windows.Forms.GroupBox gBBookEdition;
        private System.Windows.Forms.TextBox txtBBookEdition;
        private System.Windows.Forms.GroupBox gBBookYear;
        private System.Windows.Forms.TextBox txtBBookYear;
        private System.Windows.Forms.GroupBox gBBookPageCount;
        private System.Windows.Forms.TextBox txtBBookPageCount;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageInformation;
        private System.Windows.Forms.TabPage tabPageHint;
        private System.Windows.Forms.TabPage tabPageRetelling;
        private System.Windows.Forms.TabPage tabPageNote;
        private System.Windows.Forms.TextBox txtBHint;
        private System.Windows.Forms.TextBox txtBRetelling;
        private System.Windows.Forms.TextBox txtBNote;
        private System.Windows.Forms.GroupBox gBBook;
        private System.Windows.Forms.GroupBox gBLastPage;
        private System.Windows.Forms.TextBox txtBLastPage;
        private System.Windows.Forms.GroupBox gBFirstPage;
        private System.Windows.Forms.TextBox txtBFirstPage;
        private System.Windows.Forms.GroupBox gBNumber;
        private System.Windows.Forms.TextBox txtBNumber;
        private System.Windows.Forms.GroupBox gBName;
        private System.Windows.Forms.TextBox txtBName;
        private System.Windows.Forms.GroupBox gBReading;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.TextBox txtBSummary;
        private System.Windows.Forms.Button btnSearchBook;
        private System.Windows.Forms.TabPage tabPageBookEstimation;
        private System.Windows.Forms.TabPage tabPageBookNote;
        private System.Windows.Forms.TabPage tabPageBookReview;
        private System.Windows.Forms.TextBox txtBBookReview;
        private System.Windows.Forms.TextBox txtBBookEstimation;
        private System.Windows.Forms.TextBox txtBBookNote;
        private System.Windows.Forms.GroupBox gBCreationDate;
        private System.Windows.Forms.TextBox txtBCreationDate;
        private System.Windows.Forms.ToolStripMenuItem tSMIBookCard;
    }
}