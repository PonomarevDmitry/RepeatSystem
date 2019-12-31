using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;
using RepeatSystem.Classes;
using RepeatSystem.DataBase;
using RepeatSystemForms.Properties;

namespace RepeatSystemForms.Gui
{
    public partial class FormReadingCard : Form, IFormConfiguration
    {
        private FormMode mode;

        public Reading Reading { get; private set; }

        public bool IsObjectAddedIntoDataBase { get; private set; }

        public FormReadingCard(Reading reading, FormMode mode)
        {
            InitializeComponent();

            this.Reading = reading;
            this.mode = mode;

            this.IsObjectAddedIntoDataBase = false;

            LoadFormConfiguration();

            ActivateControls(false);

            SetFormMode();

            SetEventHandlers();

            txtBNumber.Select();
        }

        #region Активация контролов.

        private void SetFormMode()
        {
            LoadFieldsFromObject();

            tSMIEdit.Enabled = tSMIEdit.Visible = mode == FormMode.View && this.Reading.Id.HasValue;

            if (this.mode == FormMode.Add)
            {
                if (this.Reading.Id.HasValue)
                {
                    this.mode = FormMode.View;
                }
            }
            else if (this.mode == FormMode.Edit)
            {
                if (!this.Reading.Id.HasValue)
                {
                    this.mode = FormMode.View;
                }
            }

            switch (mode)
            {
                case FormMode.Add:
                    this.Text = "Добавление информации о чтении и пересказе";
                    ActivateControls(true);
                    break;

                case FormMode.Edit:
                    this.Text = "Редактирование информации о чтении и пересказе";
                    ActivateControls(true);
                    break;

                case FormMode.View:
                default:
                    this.Text = "Просмотр информации о чтении и пересказе";
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

            btnSearchBook.Enabled = enabled;

            {
                TextBox[] coll = { txtBName, txtBHint, txtBRetelling, txtBNote, txtBFirstPage, txtBLastPage, txtBNumber, txtBSummary };

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
                TextBox[] coll = { txtBName, txtBHint, txtBRetelling, txtBNote, txtBFirstPage, txtBLastPage, txtBNumber, txtBBookName };

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

        private const string parameterLastBookId = "LastBookId";

        public void LoadFormConfiguration()
        {
            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location);

            if (this.mode == FormMode.Add && this.Reading.Book == null)
            {
                string value = ProgramConfiguraton.LoadFormCustomParameter(this, parameterLastBookId);
                if (!string.IsNullOrEmpty(value))
                {
                    int tempInt = 0;
                    if (int.TryParse(value, out tempInt))
                    {
                        Book book = Config.Session.BookUtils.GetById(tempInt);
                        this.Reading.Book = book;
                    }
                }
            }
        }

        public void SaveFormConfiguration()
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location);

            {
                string lastIdBook = string.Empty;
                if (mode == FormMode.Add)
                {

                    if (this.Reading.Book != null)
                    {
                        lastIdBook = this.Reading.Book.Id.ToString();
                    }
                }
                ProgramConfiguraton.SaveFormCustomParameter(this, parameterLastBookId, lastIdBook);
            }

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
            Control[] textBoxes = { txtBBookEdition, txtBBookName, txtBBookPageCount, txtBBookYear, txtBFirstPage, txtBLastPage, txtBName, txtBNumber };

            foreach (Control item in textBoxes)
            {
                item.KeyDown += new KeyEventHandler(item_KeyDown);
            }

            Common.SetTextBoxOnlyNumbers(txtBFirstPage, txtBLastPage, txtBNumber);
        }

        void item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Control control = sender as Control;

                this.SelectNextControl(control, true, true, true, true);
            }
        }

        #endregion Переход по полям по Enter.

        #region Установка и считывание свойств.

        private void LoadFieldsFromObject()
        {
            if (this.Reading != null)
            {
                txtBName.Text = this.Reading.Name;

                txtBFirstPage.Text = this.Reading.FirstPage.ToString();
                txtBLastPage.Text = this.Reading.LastPage.ToString();

                txtBNumber.Text = this.Reading.Number.ToString();

                txtBHint.Text = this.Reading.Hint;
                txtBRetelling.Text = this.Reading.Retelling;
                txtBSummary.Text = this.Reading.Summary;
                txtBNote.Text = this.Reading.Note;

                txtBCreationDate.Text = this.Reading.CreationDate.ToString();

                SetBook();

                //txtB.Text = this.Reading.;
                //txtB.Text = this.Reading.;
                //txtB.Text = this.Reading.;

                isInformationChanged = false;
            }
        }

        private void SetBook()
        {
            txtBBookEdition.Text = string.Empty;
            txtBBookName.Text = string.Empty;
            txtBBookPageCount.Text = string.Empty;
            txtBBookYear.Text = string.Empty;

            txtBBookReview.Text = string.Empty;
            txtBBookEstimation.Text = string.Empty;
            txtBBookNote.Text = string.Empty;

            if (this.Reading != null && this.Reading.Book != null)
            {
                txtBBookEdition.Text = this.Reading.Book.Edition.ToString();
                txtBBookName.Text = this.Reading.Book.Name;
                txtBBookPageCount.Text = this.Reading.Book.PageCount.ToString();
                txtBBookYear.Text = this.Reading.Book.PublicationYear.ToString();

                txtBBookReview.Text = this.Reading.Book.Review;
                txtBBookEstimation.Text = this.Reading.Book.Estimation;
                txtBBookNote.Text = this.Reading.Book.Note;
            }

            tSMIBookCard.Enabled = tSMIBookCard.Visible = this.Reading != null && this.Reading.Book != null;
        }

        private void SetFieldsToObject()
        {
            this.Reading.Name = txtBName.Text.Trim();

            this.Reading.FirstPage = Common.GetIntOrNull(txtBFirstPage.Text);
            this.Reading.LastPage = Common.GetIntOrNull(txtBLastPage.Text);

            this.Reading.Number = Common.GetIntOrNull(txtBNumber.Text);

            this.Reading.Hint = txtBHint.Text.Trim();
            this.Reading.Retelling = txtBRetelling.Text.Trim();
            this.Reading.Summary = txtBSummary.Text.Trim();
            this.Reading.Note = txtBNote.Text.Trim();
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

            if (Config.Session.ReadingUtils.Save(this.Reading, out message))
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

        private void tSMIEdit_Click(object sender, EventArgs e)
        {

            {
                this.mode = FormMode.Edit;

                SetFormMode();
            }
        }

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            FormBookList form = new FormBookList();
            form.IsSelect = true;

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (form.SelectedBook != null)
                {
                    this.Reading.Book = form.SelectedBook;
                    SetBook();
                }
            }

            form.Dispose();
        }

        private void tSMIBookCard_Click(object sender, EventArgs e)
        {
            if (this.Reading.Book != null)
            {
                FormBookCard form = new FormBookCard(this.Reading.Book, FormMode.View);
                form.ShowDialog();

                if (form.IsObjectAddedIntoDataBase)
                {
                    SetBook();
                }
            }
        }
    }
}
