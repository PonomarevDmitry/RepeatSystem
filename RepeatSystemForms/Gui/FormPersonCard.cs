﻿using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Forms;
using RepeatSystem.Classes;
using RepeatSystem.DataBase;
using RepeatSystemForms.Properties;

namespace RepeatSystemForms.Gui
{
    public partial class FormPersonCard : Form, IFormConfiguration
    {
        private FormMode mode;

        public Person Person { get; private set; }

        public bool IsObjectAddedIntoDataBase { get; private set; }

        public FormPersonCard(Person person, FormMode mode)
        {
            InitializeComponent();

            this.IsObjectAddedIntoDataBase = false;

            LoadFormConfiguration();

            ActivateControls(false);


            this.Person = person;
            this.mode = mode;

            SetFormMode();

            SetEventHandlers();

            txtBSurname.Select();
        }

        #region Активация контролов.

        private void SetFormMode()
        {
            LoadFieldsFromObject();

            tSMIEdit.Enabled = tSMIEdit.Visible = mode == FormMode.View && this.Person.Id.HasValue;

            if (this.mode == FormMode.Add)
            {
                if (this.Person.Id.HasValue)
                {
                    this.mode = FormMode.View;
                }
            }
            else if (this.mode == FormMode.Edit)
            {
                if (!this.Person.Id.HasValue)
                {
                    this.mode = FormMode.View;
                }
            }

            switch (mode)
            {
                case FormMode.Add:
                    this.Text = "Добавление информации о человеке";
                    ActivateControls(true);
                    break;

                case FormMode.Edit:
                    this.Text = "Редактирование информации о человеке";
                    ActivateControls(true);
                    break;

                case FormMode.View:
                default:
                    this.Text = "Просмотр информации о человеке";
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
                TextBox[] coll = { txtBAddress, txtBDescription, txtBFirstName, txtBMeetingPlace, txtBNote, txtBPhoneNumber, txtBPhotoFileName, txtBSecondName, txtBSurname };

                foreach (TextBox item in coll)
                {
                    item.ReadOnly = !enabled;
                }
            }

            {
                Control[] coll = { nDTPBirthDay, nDTPMeetingDate };

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
                TextBox[] coll = { txtBAddress, txtBDescription, txtBFirstName, txtBMeetingPlace, txtBNote, txtBPhoneNumber, txtBPhotoFileName, txtBSecondName, txtBSurname };

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
            Control[] textBoxes = { txtBAddress, txtBFirstName, txtBPhoneNumber, txtBPhotoFileName, txtBSecondName, txtBSurname };

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

        #region Установка и считывание свойств.

        private void LoadFieldsFromObject()
        {
            if (this.Person != null)
            {
                txtBCreationDate.Text = this.Person.CreationDate.ToString();

                txtBSurname.Text = this.Person.Surname;
                txtBFirstName.Text = this.Person.FirstName;
                txtBSecondName.Text = this.Person.SecondName;

                nDTPBirthDay.Value = this.Person.BirthDay;
                nDTPMeetingDate.Value = this.Person.MeetingDate;

                txtBMeetingPlace.Text = this.Person.MeetingPlace;
                txtBAddress.Text = this.Person.Address;

                txtBPhoneNumber.Text = this.Person.PhoneNumber;
                txtBPhotoFileName.Text = this.Person.PhotoFileName;

                txtBDescription.Text = this.Person.Description;
                txtBNote.Text = this.Person.Note;

                //txtB.Text = this.Person.;
                //txtB.Text = this.Person.;

                isInformationChanged = false;
            }
        }

        private void SetFieldsToObject()
        {
            this.Person.Surname = txtBSurname.Text.Trim();
            this.Person.FirstName = txtBFirstName.Text.Trim();
            this.Person.SecondName = txtBSecondName.Text.Trim();

            this.Person.BirthDay = Common.GetOnlyDate(nDTPBirthDay.Value);
            this.Person.MeetingDate = Common.GetOnlyDate(nDTPMeetingDate.Value);

            this.Person.MeetingPlace = txtBMeetingPlace.Text.Trim();
            this.Person.Address = txtBAddress.Text.Trim();

            this.Person.PhoneNumber = txtBPhoneNumber.Text.Trim();
            this.Person.PhotoFileName = txtBPhotoFileName.Text.Trim();

            this.Person.Description = txtBDescription.Text.Trim();
            this.Person.Note = txtBNote.Text.Trim();
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

            if (Config.Session.PersonUtils.Save(this.Person, out message))
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
