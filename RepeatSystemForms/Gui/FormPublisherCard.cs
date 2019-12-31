using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;
using RepeatSystem.Classes;
using RepeatSystem.DataBase;
using RepeatSystemForms.Properties;

namespace RepeatSystemForms.Gui
{
    public partial class FormPublisherCard : Form, IFormConfiguration
    {
        private FormMode mode;

        public Publisher Publisher { get; private set; }

        public bool IsObjectAddedIntoDataBase { get; private set; }

        public FormPublisherCard(Publisher publisher, FormMode mode)
        {
            InitializeComponent();

            this.IsObjectAddedIntoDataBase = false;

            LoadFormConfiguration();

            FillComboBoxes();

            ActivateControls(false);


            this.Publisher = publisher;
            this.mode = mode;

            SetFormMode();

            SetEventHandlers();
        }

        #region Активация контролов.

        private void SetFormMode()
        {
            LoadFieldsFromObject();

            tSMIEdit.Enabled = tSMIEdit.Visible = mode == FormMode.View && this.Publisher.Id.HasValue;

            if (this.mode == FormMode.Add)
            {
                if (this.Publisher.Id.HasValue)
                {
                    this.mode = FormMode.View;
                }
            }
            else if (this.mode == FormMode.Edit)
            {
                if (!this.Publisher.Id.HasValue)
                {
                    this.mode = FormMode.View;
                }
            }

            switch (mode)
            {
                case FormMode.Add:
                    this.Text = "Добавление информации об издательстве";
                    ActivateControls(true);
                    break;

                case FormMode.Edit:
                    this.Text = "Редактирование информации об издательстве";
                    ActivateControls(true);
                    break;

                case FormMode.View:
                default:
                    this.Text = "Просмотр информации об издательстве";
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

            txtBName.ReadOnly = !enabled;
            txtBShortName.ReadOnly = !enabled;

            cmBCity.Enabled = enabled;
        }

        #endregion Активация контролов.

        #region Отслеживание изменений в полях.

        bool isInformationChanged = false;

        private void SetChangeWatcher()
        {
            {
                TextBox[] coll = { txtBName, txtBShortName };

                foreach (TextBox control in coll)
                {
                    control.TextChanged += new EventHandler(fieldChanged);
                }
            }

            {
                ComboBox[] coll = { cmBCity };

                foreach (ComboBox control in coll)
                {
                    control.SelectedIndexChanged += new EventHandler(fieldChanged);
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
            Control[] textBoxes = { txtBName, txtBShortName, cmBCity };

            foreach (Control item in textBoxes)
            {
                item.KeyDown += new KeyEventHandler(item_KeyDown);
            }
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

        private void FillComboBoxes()
        {
            {
                Collection<City> collection = Config.Session.CityUtils.GetAll();

                foreach (City item in collection)
                {
                    cmBCity.Items.Add(item);
                }
            }
        }

        #region Установка и считывание свойств.

        private void LoadFieldsFromObject()
        {
            if (this.Publisher != null)
            {
                txtBName.Text = this.Publisher.Name;
                txtBShortName.Text = this.Publisher.ShortName;

                if (this.Publisher.City != null)
                {
                    if (cmBCity.Items.Contains(this.Publisher.City))
                    {
                        cmBCity.SelectedItem = this.Publisher.City;
                    }
                }

                isInformationChanged = false;
            }
        }

        private void SetFieldsToObject()
        {
            this.Publisher.Name = txtBName.Text.Trim();
            this.Publisher.ShortName = txtBShortName.Text.Trim();

            this.Publisher.City = cmBCity.SelectedItem as City;
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

            result &= Common.CheckTextboxFill(txtBName, gBName.Text, strBuilder);

            result &= Common.CheckComboBoxFill(cmBCity, gBCity.Text, strBuilder);


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

            if (Config.Session.PublisherUtils.Save(this.Publisher, out message))
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
    }
}
