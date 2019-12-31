namespace RepeatSystemForms
{
    partial class FormMain
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.tSMIDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMIClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIMemorization = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIReading = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIFact = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIThought = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMILissening = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIViewing = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMISource = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIBookList = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIPersonList = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIAudiobookList = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMICourseList = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIReference = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIPublisherList = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMICityList = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIAuthorList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMITagList = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMICloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMICascade = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIMinimizeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIArrangeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tSMIHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIHelpFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMITest = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.AllowMerge = false;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIDataBase,
            this.tSMIMemorization,
            this.tSMISource,
            this.tSMIReference,
            this.tSMIWindows,
            this.tSMIHelp});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.MdiWindowListItem = this.tSMIWindows;
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.ShowItemToolTips = true;
            this.mainMenuStrip.Size = new System.Drawing.Size(904, 24);
            this.mainMenuStrip.TabIndex = 2;
            // 
            // tSMIDataBase
            // 
            this.tSMIDataBase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIConnect,
            this.tSMIDisconnect,
            this.toolStripSeparator1,
            this.tSMIClose});
            this.tSMIDataBase.Name = "tSMIDataBase";
            this.tSMIDataBase.Size = new System.Drawing.Size(106, 20);
            this.tSMIDataBase.Text = "Соединение с БД";
            this.tSMIDataBase.ToolTipText = "Процедуры подключения к Базе Данных.";
            // 
            // tSMIConnect
            // 
            this.tSMIConnect.Name = "tSMIConnect";
            this.tSMIConnect.Size = new System.Drawing.Size(150, 22);
            this.tSMIConnect.Text = "Подключиться";
            this.tSMIConnect.ToolTipText = "Подключиться к серверу Базы Данных";
            this.tSMIConnect.Click += new System.EventHandler(this.tSMIConnect_Click);
            // 
            // tSMIDisconnect
            // 
            this.tSMIDisconnect.Enabled = false;
            this.tSMIDisconnect.Name = "tSMIDisconnect";
            this.tSMIDisconnect.Size = new System.Drawing.Size(150, 22);
            this.tSMIDisconnect.Text = "Отключиться";
            this.tSMIDisconnect.ToolTipText = "Отключиться от сервера Базы Данных";
            this.tSMIDisconnect.Click += new System.EventHandler(this.tSMIDissconnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
            // 
            // tSMIClose
            // 
            this.tSMIClose.Name = "tSMIClose";
            this.tSMIClose.Size = new System.Drawing.Size(150, 22);
            this.tSMIClose.Text = "Выход";
            this.tSMIClose.ToolTipText = "Выйти из программы";
            this.tSMIClose.Click += new System.EventHandler(this.tSMIClose_Click);
            // 
            // tSMIMemorization
            // 
            this.tSMIMemorization.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIReading,
            this.tSMIFact,
            this.tSMIThought,
            this.tSMIPerson,
            this.tSMILissening,
            this.tSMIViewing});
            this.tSMIMemorization.Enabled = false;
            this.tSMIMemorization.Name = "tSMIMemorization";
            this.tSMIMemorization.Size = new System.Drawing.Size(85, 20);
            this.tSMIMemorization.Text = "Запоминание";
            this.tSMIMemorization.Visible = false;
            // 
            // tSMIReading
            // 
            this.tSMIReading.Name = "tSMIReading";
            this.tSMIReading.Size = new System.Drawing.Size(212, 22);
            this.tSMIReading.Text = "Чтение книг";
            this.tSMIReading.Click += new System.EventHandler(this.tSMIReading_Click);
            // 
            // tSMIFact
            // 
            this.tSMIFact.Name = "tSMIFact";
            this.tSMIFact.Size = new System.Drawing.Size(212, 22);
            this.tSMIFact.Text = "Запоминание фактов";
            this.tSMIFact.Click += new System.EventHandler(this.tSMIFact_Click);
            // 
            // tSMIThought
            // 
            this.tSMIThought.Name = "tSMIThought";
            this.tSMIThought.Size = new System.Drawing.Size(212, 22);
            this.tSMIThought.Text = "Запоминание размышлений";
            this.tSMIThought.Click += new System.EventHandler(this.tSMIThought_Click);
            // 
            // tSMIPerson
            // 
            this.tSMIPerson.Enabled = false;
            this.tSMIPerson.Name = "tSMIPerson";
            this.tSMIPerson.Size = new System.Drawing.Size(212, 22);
            this.tSMIPerson.Text = "Запоминание людей";
            // 
            // tSMILissening
            // 
            this.tSMILissening.Enabled = false;
            this.tSMILissening.Name = "tSMILissening";
            this.tSMILissening.Size = new System.Drawing.Size(212, 22);
            this.tSMILissening.Text = "Прослушивание аудиокниг";
            // 
            // tSMIViewing
            // 
            this.tSMIViewing.Enabled = false;
            this.tSMIViewing.Name = "tSMIViewing";
            this.tSMIViewing.Size = new System.Drawing.Size(212, 22);
            this.tSMIViewing.Text = "Просмотр видеокурсов";
            // 
            // tSMISource
            // 
            this.tSMISource.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIBookList,
            this.tSMIPersonList,
            this.tSMIAudiobookList,
            this.tSMICourseList});
            this.tSMISource.Enabled = false;
            this.tSMISource.Name = "tSMISource";
            this.tSMISource.Size = new System.Drawing.Size(73, 20);
            this.tSMISource.Text = "Источники";
            this.tSMISource.Visible = false;
            // 
            // tSMIBookList
            // 
            this.tSMIBookList.Name = "tSMIBookList";
            this.tSMIBookList.Size = new System.Drawing.Size(152, 22);
            this.tSMIBookList.Text = "Книги";
            this.tSMIBookList.Click += new System.EventHandler(this.tSMIBookList_Click);
            // 
            // tSMIPersonList
            // 
            this.tSMIPersonList.Name = "tSMIPersonList";
            this.tSMIPersonList.Size = new System.Drawing.Size(152, 22);
            this.tSMIPersonList.Text = "Люди";
            this.tSMIPersonList.Click += new System.EventHandler(this.tSMIPersonList_Click);
            // 
            // tSMIAudiobookList
            // 
            this.tSMIAudiobookList.Enabled = false;
            this.tSMIAudiobookList.Name = "tSMIAudiobookList";
            this.tSMIAudiobookList.Size = new System.Drawing.Size(152, 22);
            this.tSMIAudiobookList.Text = "Аудиокниги";
            // 
            // tSMICourseList
            // 
            this.tSMICourseList.Enabled = false;
            this.tSMICourseList.Name = "tSMICourseList";
            this.tSMICourseList.Size = new System.Drawing.Size(152, 22);
            this.tSMICourseList.Text = "Курсы";
            // 
            // tSMIReference
            // 
            this.tSMIReference.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIPublisherList,
            this.tSMICityList,
            this.tSMIAuthorList,
            this.toolStripSeparator4,
            this.tSMITagList});
            this.tSMIReference.Enabled = false;
            this.tSMIReference.Name = "tSMIReference";
            this.tSMIReference.Size = new System.Drawing.Size(86, 20);
            this.tSMIReference.Text = "Справочники";
            this.tSMIReference.Visible = false;
            // 
            // tSMIPublisherList
            // 
            this.tSMIPublisherList.Name = "tSMIPublisherList";
            this.tSMIPublisherList.Size = new System.Drawing.Size(152, 22);
            this.tSMIPublisherList.Text = "Издательства";
            this.tSMIPublisherList.Click += new System.EventHandler(this.tSMIPublisherList_Click);
            // 
            // tSMICityList
            // 
            this.tSMICityList.Name = "tSMICityList";
            this.tSMICityList.Size = new System.Drawing.Size(152, 22);
            this.tSMICityList.Text = "Города";
            this.tSMICityList.Click += new System.EventHandler(this.tSMICityList_Click);
            // 
            // tSMIAuthorList
            // 
            this.tSMIAuthorList.Name = "tSMIAuthorList";
            this.tSMIAuthorList.Size = new System.Drawing.Size(152, 22);
            this.tSMIAuthorList.Text = "Авторы";
            this.tSMIAuthorList.Click += new System.EventHandler(this.tSMIAuthorList_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // tSMITagList
            // 
            this.tSMITagList.Name = "tSMITagList";
            this.tSMITagList.Size = new System.Drawing.Size(152, 22);
            this.tSMITagList.Text = "Тэги";
            this.tSMITagList.Click += new System.EventHandler(this.tSMITagList_Click);
            // 
            // tSMIWindows
            // 
            this.tSMIWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMICloseAll,
            this.tSMICascade,
            this.tSMIHorizontal,
            this.tSMIVertical,
            this.tSMIMinimizeAll,
            this.tSMIArrangeAll,
            this.toolStripSeparator2});
            this.tSMIWindows.Name = "tSMIWindows";
            this.tSMIWindows.Size = new System.Drawing.Size(45, 20);
            this.tSMIWindows.Text = "Окна";
            // 
            // tSMICloseAll
            // 
            this.tSMICloseAll.Name = "tSMICloseAll";
            this.tSMICloseAll.Size = new System.Drawing.Size(211, 22);
            this.tSMICloseAll.Text = "Закрыть все";
            this.tSMICloseAll.ToolTipText = "Закрыть все окна";
            this.tSMICloseAll.Click += new System.EventHandler(this.tSMICloseAll_Click);
            // 
            // tSMICascade
            // 
            this.tSMICascade.Name = "tSMICascade";
            this.tSMICascade.Size = new System.Drawing.Size(211, 22);
            this.tSMICascade.Text = "Разместить каскадом";
            this.tSMICascade.ToolTipText = "Разместить все открытые окна каскадом";
            this.tSMICascade.Click += new System.EventHandler(this.tSMICascade_Click);
            // 
            // tSMIHorizontal
            // 
            this.tSMIHorizontal.Name = "tSMIHorizontal";
            this.tSMIHorizontal.Size = new System.Drawing.Size(211, 22);
            this.tSMIHorizontal.Text = "Разместить горизонтально";
            this.tSMIHorizontal.ToolTipText = "Разместить все открытые окна горизонтально";
            this.tSMIHorizontal.Click += new System.EventHandler(this.tSMIHorizontal_Click);
            // 
            // tSMIVertical
            // 
            this.tSMIVertical.Name = "tSMIVertical";
            this.tSMIVertical.Size = new System.Drawing.Size(211, 22);
            this.tSMIVertical.Text = "Разместить вертикально";
            this.tSMIVertical.ToolTipText = "Разместить все открытые окна вертикально";
            this.tSMIVertical.Click += new System.EventHandler(this.tSMIVertical_Click);
            // 
            // tSMIMinimizeAll
            // 
            this.tSMIMinimizeAll.Name = "tSMIMinimizeAll";
            this.tSMIMinimizeAll.Size = new System.Drawing.Size(211, 22);
            this.tSMIMinimizeAll.Text = "Свернуть все";
            this.tSMIMinimizeAll.ToolTipText = "Свернуть все открытые окна";
            this.tSMIMinimizeAll.Click += new System.EventHandler(this.tSMIMinimizeAll_Click);
            // 
            // tSMIArrangeAll
            // 
            this.tSMIArrangeAll.Name = "tSMIArrangeAll";
            this.tSMIArrangeAll.Size = new System.Drawing.Size(211, 22);
            this.tSMIArrangeAll.Text = "Упорядочить окна";
            this.tSMIArrangeAll.ToolTipText = "Упорядочить все открытые окна";
            this.tSMIArrangeAll.Click += new System.EventHandler(this.tSMIArrangeAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(208, 6);
            // 
            // tSMIHelp
            // 
            this.tSMIHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIHelpFile,
            this.tSMIAbout,
            this.tSMITest});
            this.tSMIHelp.Name = "tSMIHelp";
            this.tSMIHelp.Size = new System.Drawing.Size(62, 20);
            this.tSMIHelp.Text = "Справка";
            // 
            // tSMIHelpFile
            // 
            this.tSMIHelpFile.Name = "tSMIHelpFile";
            this.tSMIHelpFile.ShortcutKeyDisplayString = "";
            this.tSMIHelpFile.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tSMIHelpFile.Size = new System.Drawing.Size(138, 22);
            this.tSMIHelpFile.Text = "Помощь";
            // 
            // tSMIAbout
            // 
            this.tSMIAbout.Name = "tSMIAbout";
            this.tSMIAbout.Size = new System.Drawing.Size(138, 22);
            this.tSMIAbout.Text = "О программе";
            // 
            // tSMITest
            // 
            this.tSMITest.Name = "tSMITest";
            this.tSMITest.Size = new System.Drawing.Size(138, 22);
            this.tSMITest.Text = "Test";
            this.tSMITest.Click += new System.EventHandler(this.tSMITest_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Location = new System.Drawing.Point(0, 621);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(904, 22);
            this.statusStripMain.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 643);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.mainMenuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "FormMain";
            this.Text = "Система запоминания и повторения";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tSMIDataBase;
        private System.Windows.Forms.ToolStripMenuItem tSMIConnect;
        private System.Windows.Forms.ToolStripMenuItem tSMIDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tSMIClose;
        private System.Windows.Forms.ToolStripMenuItem tSMIWindows;
        private System.Windows.Forms.ToolStripMenuItem tSMICloseAll;
        private System.Windows.Forms.ToolStripMenuItem tSMICascade;
        private System.Windows.Forms.ToolStripMenuItem tSMIHorizontal;
        private System.Windows.Forms.ToolStripMenuItem tSMIVertical;
        private System.Windows.Forms.ToolStripMenuItem tSMIMinimizeAll;
        private System.Windows.Forms.ToolStripMenuItem tSMIArrangeAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tSMIHelp;
        private System.Windows.Forms.ToolStripMenuItem tSMIHelpFile;
        private System.Windows.Forms.ToolStripMenuItem tSMIAbout;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripMenuItem tSMITest;
        private System.Windows.Forms.ToolStripMenuItem tSMIMemorization;
        private System.Windows.Forms.ToolStripMenuItem tSMIReference;
        private System.Windows.Forms.ToolStripMenuItem tSMIPublisherList;
        private System.Windows.Forms.ToolStripMenuItem tSMIAuthorList;
        private System.Windows.Forms.ToolStripMenuItem tSMIReading;
        private System.Windows.Forms.ToolStripMenuItem tSMICityList;
        private System.Windows.Forms.ToolStripMenuItem tSMILissening;
        private System.Windows.Forms.ToolStripMenuItem tSMIViewing;
        private System.Windows.Forms.ToolStripMenuItem tSMIPerson;
        private System.Windows.Forms.ToolStripMenuItem tSMIFact;
        private System.Windows.Forms.ToolStripMenuItem tSMITagList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tSMISource;
        private System.Windows.Forms.ToolStripMenuItem tSMIBookList;
        private System.Windows.Forms.ToolStripMenuItem tSMIAudiobookList;
        private System.Windows.Forms.ToolStripMenuItem tSMICourseList;
        private System.Windows.Forms.ToolStripMenuItem tSMIPersonList;
        private System.Windows.Forms.ToolStripMenuItem tSMIThought;
    }
}

