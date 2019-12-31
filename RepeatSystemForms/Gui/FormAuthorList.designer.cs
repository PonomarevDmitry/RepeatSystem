namespace RepeatSystemForms.Gui
{
    partial class FormAuthorList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAuthorList));
            GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory defaultGridFilterFactory1 = new GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory();
            this.menuStripList = new System.Windows.Forms.MenuStrip();
            this.tSMIAuthor = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIView = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIClose = new System.Windows.Forms.ToolStripMenuItem();
            this.dGVList = new System.Windows.Forms.DataGridView();
            this.bSList = new System.Windows.Forms.BindingSource(this.components);
            this.bNList = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSBRefresh = new System.Windows.Forms.ToolStripButton();
            this.tSBClearFilters = new System.Windows.Forms.ToolStripButton();
            this.tSBRemoveSort = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            this.bNView = new System.Windows.Forms.ToolStripButton();
            this.bNAdd = new System.Windows.Forms.ToolStripButton();
            this.bNEdit = new System.Windows.Forms.ToolStripButton();
            this.bNDelete = new System.Windows.Forms.ToolStripButton();
            this.tSSSelect = new System.Windows.Forms.ToolStripSeparator();
            this.tSBSelect = new System.Windows.Forms.ToolStripButton();
            this.gridFiltersControl = new GridViewExtensions.GridFiltersControl();
            this.dGVColSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVColFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVColSecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVColFirstNameEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVColSecondNameEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVColSurnameEnglish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStripList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNList)).BeginInit();
            this.bNList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFiltersControl)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripList
            // 
            this.menuStripList.AllowMerge = false;
            this.menuStripList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIAuthor,
            this.tSMIRefresh,
            this.tSMIClose});
            this.menuStripList.Location = new System.Drawing.Point(0, 0);
            this.menuStripList.Name = "menuStripList";
            this.menuStripList.Size = new System.Drawing.Size(749, 24);
            this.menuStripList.TabIndex = 0;
            // 
            // tSMIAuthor
            // 
            this.tSMIAuthor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIView,
            this.tSMIAdd,
            this.tSMIEdit,
            this.tSMIDelete});
            this.tSMIAuthor.Name = "tSMIAuthor";
            this.tSMIAuthor.Size = new System.Drawing.Size(50, 20);
            this.tSMIAuthor.Text = "Автор";
            // 
            // tSMIView
            // 
            this.tSMIView.Enabled = false;
            this.tSMIView.Image = global::RepeatSystemForms.Properties.Resources.Search;
            this.tSMIView.Name = "tSMIView";
            this.tSMIView.Size = new System.Drawing.Size(191, 22);
            this.tSMIView.Text = "Просмотр";
            this.tSMIView.Click += new System.EventHandler(this.tSMIView_Click);
            // 
            // tSMIAdd
            // 
            this.tSMIAdd.Enabled = false;
            this.tSMIAdd.Image = global::RepeatSystemForms.Properties.Resources.Add;
            this.tSMIAdd.Name = "tSMIAdd";
            this.tSMIAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tSMIAdd.Size = new System.Drawing.Size(191, 22);
            this.tSMIAdd.Text = "Добавить";
            this.tSMIAdd.Click += new System.EventHandler(this.tSMIAdd_Click);
            // 
            // tSMIEdit
            // 
            this.tSMIEdit.Enabled = false;
            this.tSMIEdit.Image = global::RepeatSystemForms.Properties.Resources.Edit;
            this.tSMIEdit.Name = "tSMIEdit";
            this.tSMIEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tSMIEdit.Size = new System.Drawing.Size(191, 22);
            this.tSMIEdit.Text = "Редактировать";
            this.tSMIEdit.Click += new System.EventHandler(this.tSMIEdit_Click);
            // 
            // tSMIDelete
            // 
            this.tSMIDelete.Enabled = false;
            this.tSMIDelete.Image = global::RepeatSystemForms.Properties.Resources.Delete;
            this.tSMIDelete.Name = "tSMIDelete";
            this.tSMIDelete.Size = new System.Drawing.Size(191, 22);
            this.tSMIDelete.Text = "Удалить";
            this.tSMIDelete.Click += new System.EventHandler(this.tSMIDelete_Click);
            // 
            // tSMIRefresh
            // 
            this.tSMIRefresh.Image = global::RepeatSystemForms.Properties.Resources._112_RefreshArrow_Blue_24x24_72;
            this.tSMIRefresh.Name = "tSMIRefresh";
            this.tSMIRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tSMIRefresh.Size = new System.Drawing.Size(85, 20);
            this.tSMIRefresh.Text = "Обновить";
            this.tSMIRefresh.Click += new System.EventHandler(this.tSMIRefresh_Click);
            // 
            // tSMIClose
            // 
            this.tSMIClose.Image = global::RepeatSystemForms.Properties.Resources.Delete_black_32x32;
            this.tSMIClose.Name = "tSMIClose";
            this.tSMIClose.Size = new System.Drawing.Size(79, 20);
            this.tSMIClose.Text = "Закрыть";
            this.tSMIClose.Click += new System.EventHandler(this.tSMIClose_Click);
            // 
            // dGVList
            // 
            this.dGVList.AllowUserToAddRows = false;
            this.dGVList.AllowUserToDeleteRows = false;
            this.dGVList.AllowUserToOrderColumns = true;
            this.dGVList.AllowUserToResizeRows = false;
            this.dGVList.AutoGenerateColumns = false;
            this.dGVList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dGVColSurname,
            this.dGVColFirstName,
            this.dGVColSecondName,
            this.dGVColFirstNameEnglish,
            this.dGVColSecondNameEnglish,
            this.dGVColSurnameEnglish,
            this.dGVColID});
            this.dGVList.DataSource = this.bSList;
            this.dGVList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGVList.Location = new System.Drawing.Point(0, 69);
            this.dGVList.MultiSelect = false;
            this.dGVList.Name = "dGVList";
            this.dGVList.ReadOnly = true;
            this.dGVList.RowHeadersVisible = false;
            this.dGVList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Azure;
            this.dGVList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVList.Size = new System.Drawing.Size(749, 180);
            this.dGVList.StandardTab = true;
            this.dGVList.TabIndex = 0;
            this.dGVList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVList_CellDoubleClick);
            this.dGVList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dGVWorkerList_DataError);
            // 
            // bSList
            // 
            this.bSList.AllowNew = false;
            this.bSList.CurrentItemChanged += new System.EventHandler(this.bSList_CurrentItemChanged);
            // 
            // bNList
            // 
            this.bNList.AddNewItem = null;
            this.bNList.BindingSource = this.bSList;
            this.bNList.CountItem = this.bindingNavigatorCountItem;
            this.bNList.CountItemFormat = "из {0}";
            this.bNList.DeleteItem = null;
            this.bNList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bNList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.toolStripSeparator4,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator1,
            this.tSBRefresh,
            this.tSBClearFilters,
            this.tSBRemoveSort,
            this.toolStripSeparator30,
            this.bNView,
            this.bNAdd,
            this.bNEdit,
            this.bNDelete,
            this.tSSSelect,
            this.tSBSelect});
            this.bNList.Location = new System.Drawing.Point(0, 24);
            this.bNList.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bNList.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bNList.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bNList.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bNList.Name = "bNList";
            this.bNList.PositionItem = this.bindingNavigatorPositionItem;
            this.bNList.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bNList.Size = new System.Drawing.Size(749, 25);
            this.bNList.TabIndex = 2;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "из {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Всего записей в списке";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "В начало списка";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Предыдущая запись";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Номер текущей записи";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Следующая запись";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "В конец списка";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tSBRefresh
            // 
            this.tSBRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBRefresh.Image = global::RepeatSystemForms.Properties.Resources._112_RefreshArrow_Blue_24x24_72;
            this.tSBRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBRefresh.Name = "tSBRefresh";
            this.tSBRefresh.Size = new System.Drawing.Size(23, 22);
            this.tSBRefresh.Text = "Обновить список - F5";
            this.tSBRefresh.Click += new System.EventHandler(this.tSBRefresh_Click);
            // 
            // tSBClearFilters
            // 
            this.tSBClearFilters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBClearFilters.Image = global::RepeatSystemForms.Properties.Resources.CleanFilter;
            this.tSBClearFilters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBClearFilters.Name = "tSBClearFilters";
            this.tSBClearFilters.Size = new System.Drawing.Size(23, 22);
            this.tSBClearFilters.Text = "Очистить фильтр таблицы";
            this.tSBClearFilters.Click += new System.EventHandler(this.tSBClearFilters_Click);
            // 
            // tSBRemoveSort
            // 
            this.tSBRemoveSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBRemoveSort.Image = global::RepeatSystemForms.Properties.Resources.Erase;
            this.tSBRemoveSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBRemoveSort.Name = "tSBRemoveSort";
            this.tSBRemoveSort.Size = new System.Drawing.Size(23, 22);
            this.tSBRemoveSort.Text = "Отменить сортировку списка";
            this.tSBRemoveSort.Click += new System.EventHandler(this.tSBRemoveSort_Click);
            // 
            // toolStripSeparator30
            // 
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            this.toolStripSeparator30.Size = new System.Drawing.Size(6, 25);
            // 
            // bNView
            // 
            this.bNView.Enabled = false;
            this.bNView.Image = global::RepeatSystemForms.Properties.Resources.Search;
            this.bNView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNView.Name = "bNView";
            this.bNView.Size = new System.Drawing.Size(75, 22);
            this.bNView.Text = "Просмотр";
            this.bNView.Click += new System.EventHandler(this.bNView_Click);
            // 
            // bNAdd
            // 
            this.bNAdd.Enabled = false;
            this.bNAdd.Image = global::RepeatSystemForms.Properties.Resources.Add;
            this.bNAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNAdd.Name = "bNAdd";
            this.bNAdd.Size = new System.Drawing.Size(77, 22);
            this.bNAdd.Text = "Добавить";
            this.bNAdd.Click += new System.EventHandler(this.bNAdd_Click);
            // 
            // bNEdit
            // 
            this.bNEdit.Enabled = false;
            this.bNEdit.Image = global::RepeatSystemForms.Properties.Resources.Edit;
            this.bNEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNEdit.Name = "bNEdit";
            this.bNEdit.Size = new System.Drawing.Size(75, 22);
            this.bNEdit.Text = "Изменить";
            this.bNEdit.Click += new System.EventHandler(this.bNEdit_Click);
            // 
            // bNDelete
            // 
            this.bNDelete.Enabled = false;
            this.bNDelete.Image = global::RepeatSystemForms.Properties.Resources.Delete;
            this.bNDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bNDelete.Name = "bNDelete";
            this.bNDelete.Size = new System.Drawing.Size(71, 22);
            this.bNDelete.Text = "Удалить";
            this.bNDelete.Click += new System.EventHandler(this.bNDelete_Click);
            // 
            // tSSSelect
            // 
            this.tSSSelect.Name = "tSSSelect";
            this.tSSSelect.Size = new System.Drawing.Size(6, 25);
            this.tSSSelect.Visible = false;
            // 
            // tSBSelect
            // 
            this.tSBSelect.Enabled = false;
            this.tSBSelect.Image = global::RepeatSystemForms.Properties.Resources._112_Tick_Green_32x32_72;
            this.tSBSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBSelect.Name = "tSBSelect";
            this.tSBSelect.Size = new System.Drawing.Size(59, 22);
            this.tSBSelect.Text = "Выбор";
            this.tSBSelect.Visible = false;
            this.tSBSelect.Click += new System.EventHandler(this.tSBSelect_Click);
            // 
            // gridFiltersControl
            // 
            this.gridFiltersControl.DataGridView = this.dGVList;
            this.gridFiltersControl.Dock = System.Windows.Forms.DockStyle.Top;
            defaultGridFilterFactory1.CreateDistinctGridFilters = false;
            defaultGridFilterFactory1.DefaultGridFilterType = typeof(GridViewExtensions.GridFilters.TextGridFilter);
            defaultGridFilterFactory1.DefaultShowDateInBetweenOperator = false;
            defaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = false;
            defaultGridFilterFactory1.HandleEnumerationTypes = true;
            defaultGridFilterFactory1.MaximumDistinctValues = 20;
            this.gridFiltersControl.FilterFactory = defaultGridFilterFactory1;
            this.gridFiltersControl.FilterText = null;
            this.gridFiltersControl.Location = new System.Drawing.Point(0, 49);
            this.gridFiltersControl.Name = "gridFiltersControl";
            this.gridFiltersControl.Size = new System.Drawing.Size(749, 20);
            this.gridFiltersControl.TabIndex = 3;
            // 
            // dGVColSurname
            // 
            this.dGVColSurname.DataPropertyName = "SURNAME";
            this.dGVColSurname.HeaderText = "Фамилия";
            this.dGVColSurname.Name = "dGVColSurname";
            this.dGVColSurname.ReadOnly = true;
            this.dGVColSurname.Width = 120;
            // 
            // dGVColFirstName
            // 
            this.dGVColFirstName.DataPropertyName = "FIRSTNAME";
            this.dGVColFirstName.HeaderText = "Имя";
            this.dGVColFirstName.Name = "dGVColFirstName";
            this.dGVColFirstName.ReadOnly = true;
            this.dGVColFirstName.Width = 120;
            // 
            // dGVColSecondName
            // 
            this.dGVColSecondName.DataPropertyName = "SECONDNAME";
            this.dGVColSecondName.HeaderText = "Отчество";
            this.dGVColSecondName.Name = "dGVColSecondName";
            this.dGVColSecondName.ReadOnly = true;
            this.dGVColSecondName.Width = 120;
            // 
            // dGVColFirstNameEnglish
            // 
            this.dGVColFirstNameEnglish.DataPropertyName = "FIRSTNAME_ENGLISH";
            this.dGVColFirstNameEnglish.HeaderText = "First name";
            this.dGVColFirstNameEnglish.Name = "dGVColFirstNameEnglish";
            this.dGVColFirstNameEnglish.ReadOnly = true;
            this.dGVColFirstNameEnglish.Width = 120;
            // 
            // dGVColSecondNameEnglish
            // 
            this.dGVColSecondNameEnglish.DataPropertyName = "SECONDNAME_ENGLISH";
            this.dGVColSecondNameEnglish.HeaderText = "Second name";
            this.dGVColSecondNameEnglish.Name = "dGVColSecondNameEnglish";
            this.dGVColSecondNameEnglish.ReadOnly = true;
            this.dGVColSecondNameEnglish.Width = 120;
            // 
            // dGVColSurnameEnglish
            // 
            this.dGVColSurnameEnglish.DataPropertyName = "SURNAME_ENGLISH";
            this.dGVColSurnameEnglish.HeaderText = "Surname";
            this.dGVColSurnameEnglish.Name = "dGVColSurnameEnglish";
            this.dGVColSurnameEnglish.ReadOnly = true;
            this.dGVColSurnameEnglish.Width = 120;
            // 
            // dGVColID
            // 
            this.dGVColID.DataPropertyName = "ID";
            this.dGVColID.HeaderText = "ID";
            this.dGVColID.Name = "dGVColID";
            this.dGVColID.ReadOnly = true;
            this.dGVColID.Visible = false;
            // 
            // FormAuthorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 249);
            this.Controls.Add(this.dGVList);
            this.Controls.Add(this.gridFiltersControl);
            this.Controls.Add(this.bNList);
            this.Controls.Add(this.menuStripList);
            this.MainMenuStrip = this.menuStripList;
            this.Name = "FormAuthorList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Список авторов";
            this.menuStripList.ResumeLayout(false);
            this.menuStripList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bNList)).EndInit();
            this.bNList.ResumeLayout(false);
            this.bNList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFiltersControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripList;
        private System.Windows.Forms.DataGridView dGVList;
        private System.Windows.Forms.ToolStripMenuItem tSMIAuthor;
        private System.Windows.Forms.ToolStripMenuItem tSMIRefresh;
        private System.Windows.Forms.ToolStripMenuItem tSMIClose;
        private System.Windows.Forms.ToolStripMenuItem tSMIEdit;
        private System.Windows.Forms.ToolStripMenuItem tSMIDelete;
        private System.Windows.Forms.BindingSource bSList;
        private System.Windows.Forms.BindingNavigator bNList;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tSBRefresh;
        private System.Windows.Forms.ToolStripButton tSBRemoveSort;
        private System.Windows.Forms.ToolStripButton tSBClearFilters;
        private System.Windows.Forms.ToolStripMenuItem tSMIAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator30;
        private System.Windows.Forms.ToolStripButton bNView;
        private System.Windows.Forms.ToolStripButton bNAdd;
        private System.Windows.Forms.ToolStripButton bNEdit;
        private System.Windows.Forms.ToolStripButton bNDelete;
        private System.Windows.Forms.ToolStripMenuItem tSMIView;
        private GridViewExtensions.GridFiltersControl gridFiltersControl;
        private System.Windows.Forms.ToolStripSeparator tSSSelect;
        private System.Windows.Forms.ToolStripButton tSBSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn dGVColSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dGVColFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dGVColSecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dGVColFirstNameEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn dGVColSecondNameEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn dGVColSurnameEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn dGVColID;
    }
}