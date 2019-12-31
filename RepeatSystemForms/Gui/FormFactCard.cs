using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;
using RepeatSystem.Classes;
using RepeatSystem.DataBase;
using RepeatSystemForms.Properties;

namespace RepeatSystemForms.Gui
{
    public partial class FormFactCard : Form, IFormConfiguration
    {
        private FormMode mode;

        public Fact Fact { get; private set; }

        public bool IsObjectAddedIntoDataBase { get; private set; }

        public FormFactCard(Fact fact, FormMode mode)
        {
            InitializeComponent();

            this.IsObjectAddedIntoDataBase = false;

            LoadFormConfiguration();

            FillComboBoxes();

            ActivateControls(false);


            this.Fact = fact;
            this.mode = mode;

            SetFormMode();

            SetEventHandlers();

            cmBFactType.Select();
        }

        #region Активация контролов.

        private void SetFormMode()
        {
            LoadFieldsFromObject();

            tSMIEdit.Enabled = tSMIEdit.Visible = mode == FormMode.View && this.Fact.Id.HasValue;

            if (this.mode == FormMode.Add)
            {
                if (this.Fact.Id.HasValue)
                {
                    this.mode = FormMode.View;
                }
            }
            else if (this.mode == FormMode.Edit)
            {
                if (!this.Fact.Id.HasValue)
                {
                    this.mode = FormMode.View;
                }
            }

            switch (mode)
            {
                case FormMode.Add:
                    this.Text = "Добавление информации о факте";
                    ActivateControls(true);
                    break;

                case FormMode.Edit:
                    this.Text = "Редактирование информации о факте";
                    ActivateControls(true);
                    break;

                case FormMode.View:
                default:
                    this.Text = "Просмотр информации о факте";
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

            {
                TextBox[] coll = { txtBName, txtBHint, txtBQuestion, txtBNote, txtBAnswer, txtBNumber };

                foreach (TextBox item in coll)
                {
                    item.ReadOnly = !enabled;
                }
            }

            {
                Control[] coll = { cmBFactType };

                foreach (Control item in coll)
                {
                    item.Enabled = enabled;
                }
            }
        }

        #endregion Активация контролов.

        #region Отслеживание изменений в полях.

        bool isInformationChanged = false;

        private void SetChangeWatcher()
        {
            {
                TextBox[] coll = { txtBName, txtBHint, txtBQuestion, txtBNote, txtBNumber };

                foreach (TextBox control in coll)
                {
                    control.TextChanged += new EventHandler(fieldChanged);
                }
            }

            {
                ComboBox[] coll = { cmBFactType };

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
            Control[] textBoxes = { txtBName, txtBCreationDate, txtBNumber, cmBFactType };

            foreach (Control item in textBoxes)
            {
                item.KeyDown += new KeyEventHandler(item_KeyDown);
            }

            Common.SetTextBoxOnlyNumbers(txtBNumber);
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
                Collection<FactType> collection = Config.Session.FactTypeUtils.GetAll();

                foreach (FactType item in collection)
                {
                    cmBFactType.Items.Add(item);
                }

                cmBFactType.SelectedIndex = 0;
            }
        }

        #region Установка и считывание свойств.

        private void LoadFieldsFromObject()
        {
            if (this.Fact != null)
            {
                txtBCreationDate.Text = this.Fact.CreationDate.ToString();

                txtBName.Text = this.Fact.Name;

                txtBHint.Text = this.Fact.Hint;
                txtBQuestion.Text = this.Fact.Question;
                txtBAnswer.Text = this.Fact.Answer;
                txtBNote.Text = this.Fact.Note;

                txtBNumber.Text = this.Fact.Number.ToString();

                if (this.Fact.FactType != null)
                {
                    if (cmBFactType.Items.Contains(this.Fact.FactType))
                    {
                        cmBFactType.SelectedItem = this.Fact.FactType;
                    }
                }

                isInformationChanged = false;
            }
        }

        private void SetFieldsToObject()
        {
            this.Fact.Name = txtBName.Text.Trim();

            this.Fact.Hint = txtBHint.Text.Trim();
            this.Fact.Question = txtBQuestion.Text.Trim();
            this.Fact.Answer = txtBAnswer.Text.Trim();
            this.Fact.Note = txtBNote.Text.Trim();

            //this.Fact.Number = Common.GetIntOrNull(txtBNumber.Text);

            this.Fact.FactType = cmBFactType.SelectedItem as FactType;
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

            result &= Common.CheckTextboxFill(txtBQuestion, gBQuestion.Text, strBuilder);
            result &= Common.CheckTextboxFill(txtBAnswer, tabPageAnswer.Text, strBuilder);

            result &= Common.CheckComboBoxFill(cmBFactType, gBFactType.Text, strBuilder);

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

            if (Config.Session.FactUtils.Save(this.Fact, out message))
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
