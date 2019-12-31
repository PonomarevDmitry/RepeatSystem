using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;
using RepeatSystem.Classes;
using RepeatSystem.DataBase;
using RepeatSystemForms.Properties;
using System.Data;

namespace RepeatSystemForms.Gui
{
    public partial class FormBookCard : Form, IFormConfiguration
    {
        private FormMode mode;

        public Book Book { get; private set; }

        public bool IsObjectAddedIntoDataBase { get; private set; }

        bool canEditCollections = false;
        bool CanEditCollections
        {
            get
            {
                return this.canEditCollections;
            }

            set
            {
                this.canEditCollections = value;

                ActivateReadingsButtons();
                ActivateTagsButtons();
                ActivateAuthorsButtons();
            }
        }

        public FormBookCard(Book book, FormMode mode)
        {
            InitializeComponent();

            this.IsObjectAddedIntoDataBase = false;

            LoadFormConfiguration();

            ActivateControls(false);
            CanEditCollections = false;


            this.Book = book;
            this.mode = mode;

            SetFormMode();

            SetEventHandlers();

            gFCReadings.BeginInit();

            RefreshAllLists();

            (gFCReadings.FilterFactory as GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory).DefaultShowDateInBetweenOperator = true;

            gFCReadings.EndInit();
        }

        private void RefreshAllLists()
        {
            RefreshReadingsList();
            RefreshAuthorsList();
            RefreshTagsList();
        }

        protected override void OnLoad(EventArgs e)
        {
            gFCReadings.RecreateGridFilters();
        }

        #region Активация контролов.

        private void SetFormMode()
        {
            LoadFieldsFromObject();

            tSMIEdit.Enabled = tSMIEdit.Visible = mode == FormMode.View && this.Book.Id.HasValue;

            if (this.mode == FormMode.Add)
            {
                if (this.Book.Id.HasValue)
                {
                    this.mode = FormMode.View;
                }
            }
            else if (this.mode == FormMode.Edit)
            {
                if (!this.Book.Id.HasValue)
                {
                    this.mode = FormMode.View;
                }
            }

            switch (mode)
            {
                case FormMode.Add:
                    this.Text = "Добавление информации о книге";
                    CanEditCollections = false;
                    ActivateControls(true);
                    break;

                case FormMode.Edit:
                    this.Text = "Редактирование информации о книге";
                    CanEditCollections = true;
                    ActivateControls(true);
                    break;

                case FormMode.View:
                default:
                    this.Text = "Просмотр информации о книге";
                    CanEditCollections = true;
                    ActivateControls(false);
                    break;
            }

            if (mode == FormMode.Add || mode == FormMode.Edit)
            {
                SetChangeWatcher();
            }
        }

        private void ActivateControls(bool enabled)
        {
            btnSave.Visible = btnSave.Enabled = enabled;
            if (enabled)
            {
                btnCancel.Text = "Отмена";
            }
            else
            {
                btnCancel.Text = "Выход";
            }

            btnSearchPublisherOriginal.Enabled = btnSearchPublisher.Enabled = enabled;

            {
                TextBox[] coll = { txtBName, txtBNameOriginal, txtBEdition, txtBYear, txtBYearOriginal, txtBISBN, txtBISBNOriginal, txtBReview, txtBEstimation, txtBNote, txtBPageCount };

                foreach (TextBox item in coll)
                {
                    item.ReadOnly = !enabled;
                }
            }

            //{
            //    Control[] coll = {  };

            //    foreach (Control item in coll)
            //    {
            //        item.Enabled = enabled;
            //    }
            //}
        }

        #endregion Активация контролов.

        #region Отслеживание изменений в полях.

        bool isInformationChanged = false;

        private void SetChangeWatcher()
        {
            {
                TextBox[] coll = { txtBName, txtBNameOriginal, txtBEdition, txtBYear, txtBYearOriginal, txtBISBN, txtBISBNOriginal, txtBPageCount, txtBPublisher, txtBPublisherOriginal };

                foreach (TextBox control in coll)
                {
                    control.TextChanged += new EventHandler(fieldChanged);
                }
            }
        }

        void fieldChanged(object sender, EventArgs e)
        {
            this.isInformationChanged = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (mode == FormMode.Add || mode == FormMode.Edit)
            {
                if (!this.IsObjectAddedIntoDataBase && this.isInformationChanged)
                {
                    if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.None)
                    {
                        e.Cancel = StopClosing();
                    }
                }
            }
        }

        private bool StopClosing()
        {
            if (!this.isInformationChanged)
            {
                return false;
            }

            DialogResult result = MessageBox.Show(this, "Были произведены изменения. Выйти без сохранения?", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            return result == System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion Отслеживание изменений в полях.

        #region Инициализация.

        public void LoadFormConfiguration()
        {
            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);
        }

        public void SaveFormConfiguration()
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);

            ProgramConfiguraton.SaveDefaultXmlConfig();
        }

        protected override void OnClosed(EventArgs e)
        {
            SaveFormConfiguration();

            base.OnClosed(e);
        }

        #endregion Инициализация.

        #region Переход по полям по Enter.

        private void SetEventHandlers()
        {
            Control[] textBoxes = { txtBName, txtBNameOriginal, txtBEdition, txtBYear, txtBYearOriginal, txtBISBN, txtBISBNOriginal, txtBPageCount, txtBPublisher, txtBPublisherOriginal };

            foreach (Control item in textBoxes)
            {
                item.KeyDown += new KeyEventHandler(item_KeyDown);
            }

            Common.SetTextBoxOnlyNumbers(txtBYear, txtBYearOriginal, txtBEdition, txtBPageCount);
        }

        void item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Control control = sender as Control;

                //this.SelectNextControl(control, true, true, true, true);
                SendKeys.Send("{TAB}");
            }
        }

        #endregion Переход по полям по Enter.

        #region Установка и считывание свойств.

        private void LoadFieldsFromObject()
        {
            if (this.Book != null)
            {
                txtBName.Text = this.Book.Name;
                txtBYear.Text = this.Book.PublicationYear.ToString();
                txtBISBN.Text = this.Book.ISBN;


                txtBNameOriginal.Text = this.Book.NameOriginal;
                txtBYearOriginal.Text = this.Book.PublicationYearOriginal.ToString();
                txtBISBNOriginal.Text = this.Book.ISBNOriginal;


                txtBPageCount.Text = this.Book.PageCount.ToString();

                txtBEdition.Text = this.Book.Edition.ToString();

                txtBReview.Text = this.Book.Review;
                txtBEstimation.Text = this.Book.Estimation;
                txtBNote.Text = this.Book.Note;

                //txtB.Text = this.Book.;
                //txtB.Text = this.Book.;
                //txtB.Text = this.Book.;

                SetPublisher();

                isInformationChanged = false;
            }
        }

        private void SetPublisher()
        {
            txtBPublisher.Text = string.Empty;
            if (this.Book.Publisher != null)
            {
                txtBPublisher.Text = this.Book.Publisher.ToString();
            }

            txtBPublisherOriginal.Text = string.Empty;
            if (this.Book.PublisherOriginal != null)
            {
                txtBPublisherOriginal.Text = this.Book.PublisherOriginal.ToString();
            }
        }

        private void SetFieldsToObject()
        {
            this.Book.Name = txtBName.Text.Trim();
            this.Book.PublicationYear = Common.GetIntOrNull(txtBYear.Text.Trim());
            this.Book.ISBN = txtBISBN.Text.Trim();

            this.Book.NameOriginal = txtBNameOriginal.Text.Trim();
            this.Book.PublicationYearOriginal = Common.GetIntOrNull(txtBYearOriginal.Text.Trim());
            this.Book.ISBNOriginal = txtBISBNOriginal.Text.Trim();


            this.Book.PageCount = Common.GetIntOrNull(txtBPageCount.Text.Trim()) ?? 1;

            this.Book.Edition = Common.GetIntOrNull(txtBEdition.Text.Trim()) ?? 1;

            this.Book.Review = txtBReview.Text.Trim();
            this.Book.Estimation = txtBEstimation.Text.Trim();
            this.Book.Note = txtBNote.Text.Trim();



            //this.Book. = txtB.Text.Trim();
        }

        #endregion Установка и считывание свойств.

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }

            base.OnKeyDown(e);
        }

        #region Сохранение и проверка свойств.

        private bool FieldsIsOk()
        {
            bool result = true;

            StringBuilder strBuilder = new StringBuilder();

            //result &= Common.CheckTextboxFill(txtBSurname, gBSurname.Text, strBuilder);
            //result &= Common.CheckTextboxFill(txtBFirstName, gBFirstName.Text, strBuilder);

            if (!result)
            {
                MessageBox.Show(this, strBuilder.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FieldsIsOk())
            {
                return;
            }

            SetFieldsToObject();

            string message = string.Empty;

            if (Config.Session.BookUtils.Save(this.Book, out message))
            {
                this.isInformationChanged = false;
                this.IsObjectAddedIntoDataBase = true;
                this.Close();
            }
            else
            {
                StringBuilder tmpBld = new StringBuilder();
                tmpBld.AppendLine("Возникла ошибка при сохранении в базу.");
                tmpBld.AppendLine();
                tmpBld.Append(message);

                MessageBox.Show(this, tmpBld.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Сохранение и проверка свойств.

        #region Чтение и пересказы.

        private int? GetCurrentReadingId()
        {
            int? result = null;

            if (bSReadings.Current != null)
            {
                // Текущая строка
                DataRowView row = bSReadings.Current as DataRowView;

                try
                {
                    result = Convert.ToInt32(row[dGVReadingsColID.DataPropertyName]);
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        private Reading GetCurrentReading()
        {
            Reading result = null;

            int? id = GetCurrentReadingId();

            if (id.HasValue)
            {
                result = Config.Session.ReadingUtils.GetById(id.Value);
            }

            return result;
        }

        private void bSReadings_CurrentItemChanged(object sender, EventArgs e)
        {
            ActivateReadingsButtons();
        }

        private void ActivateReadingsButtons()
        {
            bNReadingsView.Enabled = bSReadings.Current != null;

            bNReadingsAdd.Enabled = this.CanEditCollections;

            bNReadingsEdit.Enabled = this.CanEditCollections && bSReadings.Current != null;
            bNReadingsDelete.Enabled = this.CanEditCollections && bSReadings.Current != null;
        }

        private void bNReadingsView_Click(object sender, EventArgs e)
        {
            Reading obj = GetCurrentReading();
            if (obj != null)
            {
                FormReadingCard form = new FormReadingCard(obj, FormMode.View);
                form.ShowDialog(this);
                if (form.IsObjectAddedIntoDataBase)
                {
                    RefreshReadingsList();
                    SelectInReadingsList(obj.Id);
                }
            }
        }

        private void bNReadingsAdd_Click(object sender, EventArgs e)
        {
            Reading obj = new Reading();
            obj.Book = this.Book;
            obj.CreationDate = DateTime.Now;

            FormReadingCard form = new FormReadingCard(obj, FormMode.Add);
            form.ShowDialog(this);
            if (form.IsObjectAddedIntoDataBase)
            {
                RefreshReadingsList();
                SelectInReadingsList(obj.Id);
            }
        }

        private void SelectInReadingsList(int? id)
        {
            if (id.HasValue)
            {
                foreach (DataRowView row in bSReadings)
                {
                    try
                    {
                        int rowId = Convert.ToInt32(row[dGVReadingsColID.DataPropertyName]);

                        if (rowId == id.Value)
                        {
                            bSReadings.Position = bSReadings.IndexOf(row);
                            break;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void bNReadingsEdit_Click(object sender, EventArgs e)
        {
            Reading obj = GetCurrentReading();
            if (obj != null)
            {
                FormReadingCard form = new FormReadingCard(obj, FormMode.Edit);
                form.ShowDialog(this);
                if (form.IsObjectAddedIntoDataBase)
                {
                    RefreshReadingsList();
                    SelectInReadingsList(obj.Id);
                }
            }
        }

        private void bNReadingsDelete_Click(object sender, EventArgs e)
        {
            Reading obj = GetCurrentReading();
            if (obj != null)
            {
                if (MessageBox.Show(this, "Вы действительно хотите удалить информацию о пересказе?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                {
                    Config.Session.ReadingUtils.Delete(obj);
                    RefreshReadingsList();
                }
            }
        }

        private void RefreshReadingsList()
        {
            if (this.Book.Id.HasValue)
            {
                DataTable dataTable = null;
                string message = string.Empty;

                try
                {
                    if (Config.Session.ReadingUtils.GetTableForBook(Book.Id.Value, out dataTable, out message))
                    {
                        // Обновление источника.
                        bSReadings.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            else
            {
                if (bSReadings.DataSource != null && bSReadings.DataSource is DataTable)
                {
                    ((DataTable)bSReadings.DataSource).Clear();
                }
            }
        }

        private void bNReadingsRemoveSort_Click(object sender, EventArgs e)
        {
            if (bSReadings.DataSource != null)
            {
                bSReadings.RemoveSort();
            }
        }

        private void dGVReadings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                bNReadingsView.PerformClick();
            }
        }

        private void tSBReadingsRefresh_Click(object sender, EventArgs e)
        {
            RefreshReadingsList();
        }

        private void tSBReadingsClearFilters_Click(object sender, EventArgs e)
        {
            gFCReadings.ClearFilters();
        }

        #endregion Чтение и пересказы.

        #region Авторы.

        private void ActivateAuthorsButtons()
        {
            bNAuthorsAdd.Enabled = this.CanEditCollections;

            bNAuthorsDelete.Enabled = this.CanEditCollections && bSAuthors.Current != null;
        }

        private int? GetCurrentBookAuthorCompositionId()
        {
            int? result = null;

            if (bSAuthors.Current != null)
            {
                // Текущая строка
                DataRowView row = bSAuthors.Current as DataRowView;

                try
                {
                    result = Convert.ToInt32(row[dGVTagsColId.DataPropertyName]);
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        private BookAuthorComposition GetCurrentBookAuthorComposition()
        {
            BookAuthorComposition result = null;

            int? id = GetCurrentBookAuthorCompositionId();

            if (id.HasValue)
            {
                result = Config.Session.BookAuthorCompositionUtils.GetById(id.Value);
            }

            return result;
        }

        private void RefreshAuthorsList()
        {
            if (this.Book.Id.HasValue)
            {
                DataTable dataTable = null;
                string message = string.Empty;

                try
                {
                    if (Config.Session.BookAuthorCompositionUtils.GetTableForBook(Book.Id.Value, out dataTable, out message))
                    {
                        // Обновление источника.
                        bSAuthors.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            else
            {
                if (bSAuthors.DataSource != null && bSAuthors.DataSource is DataTable)
                {
                    ((DataTable)bSAuthors.DataSource).Clear();
                }
            }
        }

        private void bNAuthorsAdd_Click(object sender, EventArgs e)
        {
            FormAuthorList form = new FormAuthorList();
            form.IsSelect = true;

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (form.SelectedAuthor != null)
                {
                    BookAuthorComposition obj = new BookAuthorComposition();

                    obj.IdBook = this.Book.Id;
                    obj.IdAuthor = form.SelectedAuthor.Id;

                    string message = string.Empty;

                    if (Config.Session.BookAuthorCompositionUtils.Save(obj, out message))
                    {
                    }
                    else
                    {
                        StringBuilder tmpBld = new StringBuilder();
                        tmpBld.AppendLine("Возникла ошибка при сохранении в базу.");
                        tmpBld.AppendLine();
                        tmpBld.Append(message);

                        MessageBox.Show(this, tmpBld.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    RefreshAuthorsList();
                }
            }

            form.Dispose();
        }

        private void bNAuthorsDelete_Click(object sender, EventArgs e)
        {
            BookAuthorComposition obj = GetCurrentBookAuthorComposition();
            if (obj != null)
            {
                if (MessageBox.Show(this, "Вы действительно хотите удалить информацию об авторе?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                {
                    Config.Session.BookAuthorCompositionUtils.Delete(obj);
                    RefreshAuthorsList();
                }
            }
        }

        private void bSAuthors_CurrentItemChanged(object sender, EventArgs e)
        {
            ActivateAuthorsButtons();
        }

        private void bNAuthorsRemoveSort_Click(object sender, EventArgs e)
        {
            if (bSAuthors.DataSource != null)
            {
                bSAuthors.RemoveSort();
            }
        }

        #endregion Авторы.

        #region Тэги.

        private void ActivateTagsButtons()
        {
            bNTagsAdd.Enabled = this.CanEditCollections;

            bNTagsDelete.Enabled = this.CanEditCollections && bSReadings.Current != null;
        }

        private int? GetCurrentBookTagCompositionId()
        {
            int? result = null;

            if (bSTags.Current != null)
            {
                // Текущая строка
                DataRowView row = bSTags.Current as DataRowView;

                try
                {
                    result = Convert.ToInt32(row[dGVTagsColId.DataPropertyName]);
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        private BookTagComposition GetCurrentBookTagComposition()
        {
            BookTagComposition result = null;

            int? id = GetCurrentBookTagCompositionId();

            if (id.HasValue)
            {
                result = Config.Session.BookTagCompositionUtils.GetById(id.Value);
            }

            return result;
        }

        private void RefreshTagsList()
        {
            if (this.Book.Id.HasValue)
            {
                DataTable dataTable = null;
                string message = string.Empty;

                try
                {
                    if (Config.Session.BookTagCompositionUtils.GetTableForBook(Book.Id.Value, out dataTable, out message))
                    {
                        // Обновление источника.
                        bSTags.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }
            else
            {
                if (bSTags.DataSource != null && bSTags.DataSource is DataTable)
                {
                    ((DataTable)bSTags.DataSource).Clear();
                }
            }
        }

        private void bNTagsAdd_Click(object sender, EventArgs e)
        {
            FormTagList form = new FormTagList();
            form.IsSelect = true;

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (form.SelectedTag != null)
                {
                    BookTagComposition obj = new BookTagComposition();

                    obj.IdBook = this.Book.Id;
                    obj.IdTag = form.SelectedTag.Id;

                    string message = string.Empty;

                    if (Config.Session.BookTagCompositionUtils.Save(obj, out message))
                    {
                    }
                    else
                    {
                        StringBuilder tmpBld = new StringBuilder();
                        tmpBld.AppendLine("Возникла ошибка при сохранении в базу.");
                        tmpBld.AppendLine();
                        tmpBld.Append(message);

                        MessageBox.Show(this, tmpBld.ToString(), Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    RefreshTagsList();
                }
            }

            form.Dispose();
        }

        private void bNTagsDelete_Click(object sender, EventArgs e)
        {
            BookTagComposition obj = GetCurrentBookTagComposition();
            if (obj != null)
            {
                if (MessageBox.Show(this, "Вы действительно хотите удалить информацию о тэге?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                {
                    Config.Session.BookTagCompositionUtils.Delete(obj);
                    RefreshTagsList();
                }
            }
        }

        private void bSTags_CurrentItemChanged(object sender, EventArgs e)
        {
            ActivateTagsButtons();
        }

        private void bNTagsRemoveSort_Click(object sender, EventArgs e)
        {
            if (bSTags.DataSource != null)
            {
                bSTags.RemoveSort();
            }
        }

        #endregion Тэги.

        private void tSMIEdit_Click(object sender, EventArgs e)
        {

            {
                this.mode = FormMode.Edit;

                SetFormMode();
            }
        }

        private void btnSearchPublisher_Click(object sender, EventArgs e)
        {
            FormPublisherList form = new FormPublisherList();
            form.IsSelect = true;

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (form.SelectedPublisher != null)
                {
                    this.Book.Publisher = form.SelectedPublisher;
                    SetPublisher();
                }
            }

            form.Dispose();
        }

        private void btnSearchPublisherOriginal_Click(object sender, EventArgs e)
        {
            FormPublisherList form = new FormPublisherList();
            form.IsSelect = true;

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (form.SelectedPublisher != null)
                {
                    this.Book.PublisherOriginal = form.SelectedPublisher;
                    SetPublisher();
                }
            }

            form.Dispose();
        }

        private void tSMIRefresh_Click(object sender, EventArgs e)
        {
            RefreshAllLists();
        }
    }
}
