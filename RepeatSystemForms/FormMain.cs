using System;
using System.Windows.Forms;
using RepeatSystemForms.Gui;
using System.Text;
using System.Collections.ObjectModel;
using System.Reflection;
using RepeatSystemForms.Properties;

namespace RepeatSystemForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        #region События Формы

        #region Инициализация.

        private const string parameterOpenedListForms = "parameterOpenedListForms";

        public void LoadFormConfiguration()
        {
            string tempStr = ProgramConfiguraton.LoadFormCustomParameter(this, parameterOpenedListForms);
            OpenListForms(tempStr);
        }

        private void OpenListForms(string tempStr)
        {
            Collection<string> listForms = new Collection<string>();

            if (!string.IsNullOrEmpty(tempStr))
            {
                string[] split = tempStr.Split(new char[] { ' ', ',' }, System.StringSplitOptions.RemoveEmptyEntries);

                foreach (string value in split)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (!listForms.Contains(value))
                        {
                            listForms.Add(value);
                        }
                    }
                }
            }

            if (listForms.Count > 0)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();

                foreach (string formTypeName in listForms)
                {
                    Type type = assembly.GetType(formTypeName);

                    if (type != null)
                    {
                        CreateListForm(type);
                    }
                }
            }
        }

        public void SaveFormConfiguration()
        {
            {
                StringBuilder temp = new StringBuilder();

                foreach (Form form in this.MdiChildren)
                {
                    if (temp.Length > 0)
                    {
                        temp.Append(", ");
                    }

                    temp.Append(form.GetType().ToString());
                }

                ProgramConfiguraton.SaveFormCustomParameter(this, parameterOpenedListForms, temp.ToString());
            }

            ProgramConfiguraton.SaveDefaultXmlConfig();
        }

        #endregion Инициализация.

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // При загрузке формы автоматически вызывать форму подключения к БД.
            tSMIConnect.PerformClick();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // При закрытие формы отключаемся от БД.
            DisconnectProcedure();
        }

        #endregion События Формы

        #region Менюшка "Окна"

        /// <summary>
        /// Закрыть все дочерние окна.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSMICloseAll_Click(object sender, EventArgs e)
        {
            while (this.MdiChildren.Length > 0)
            {
                this.MdiChildren[0].Close();
            }
        }

        /// <summary>
        /// Событие для кнопки "Разместить каскадом" менюшки "Окна".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSMICascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// Событие для кнопки "Разместить горизонтально" менюшки "Окна".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSMIHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// Событие для кнопки "Разместить вертикально" менюшки "Окна".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSMIVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// Событие для кнопки "Свернуть все" менюшки "Окна".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSMIMinimizeAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                this.MdiChildren[i].WindowState = FormWindowState.Minimized;
            }
        }

        /// <summary>
        /// Событие для кнопки "Упорядочить все" менюшки "Окна".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSMIArrangeAll_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        #endregion Менюшка "Окна"

        #region Менюшка "База Данных"

        /// <summary>
        /// Кнопка "Подключиться" к БД.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSMIConnect_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            // Бесконечный цикл для входа в систему.
            while (true)
            {
                // вызов формы подключения.
                FormPassword formPassword = new FormPassword();

                DialogResult dialogresult = formPassword.ShowDialog(this);

                if (dialogresult == DialogResult.OK)
                {
                    if (formPassword.SelectedFile != null)
                    {
                        if (Config.Session.Connect(formPassword.SelectedFile.FullName, out message))
                        {
                            ActivateControlsAfterConnection();

                            formPassword.Close();
                            formPassword.Dispose();

                            LoadFormConfiguration();

                            break;
                        }
                        else
                        {

                            MessageBox.Show(this, message, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // нажата была кнопка "отмена".
                    break;
                }
            }
        }

        /// <summary>
        /// Кнопка "Отключиться".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSMIDissconnect_Click(object sender, EventArgs e)
        {
            DisconnectProcedure();
        }

        private void DisconnectProcedure()
        {
            string message = string.Empty;
            Config.Session.Disconnect(out message);

            DedativateControlsAfterDisconnect();

            SaveFormConfiguration();

            while (this.MdiChildren.Length > 0)
            {
                this.MdiChildren[0].Close();
            }
        }

        /// <summary>
        /// Активация элементов формы после создания подключения.
        /// </summary>
        private void ActivateControlsAfterConnection()
        {
            // Заполнение статусной строки.

            SetMenuItemsEnableAndVisible(true);
        }

        /// <summary>
        /// Отключение элементов формы после разрыва подключения.
        /// </summary>
        private void DedativateControlsAfterDisconnect()
        {
            SetMenuItemsEnableAndVisible(false);
        }

        private void SetMenuItemsEnableAndVisible(bool enabled)
        {
            // кнопку "подключение" дезактивировать.
            tSMIConnect.Enabled = !enabled;

            // кнопку "отключение" активировать.
            tSMIDisconnect.Enabled = enabled;

            tSMIMemorization.Enabled = tSMIMemorization.Visible = enabled;
            tSMISource.Enabled = tSMISource.Visible = enabled;
            tSMIReference.Enabled = tSMIReference.Visible = enabled;










#if DEBUG
            tSMITest.Enabled = tSMITest.Enabled = enabled;

#else
            tSMITest.Enabled = tSMITest.Enabled = false;
#endif
        }

        /// <summary>
        /// Кнопка "Выход" менюшки "База Данных".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tSMIClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Менюшка "База Данных"

        private void tSMITest_Click(object sender, EventArgs e)
        {

        }

        private void CreateListForm(Type type)
        {
            Form form = null;

            foreach (Form item in this.MdiChildren)
            {
                if (item.GetType() == type)
                {
                    form = item;
                    break;
                }
            }

            if (form == null)
            {
                form = (Form)Activator.CreateInstance(type);
            }

            form.MdiParent = this;

            form.Show();
            form.Activate();
            form.Focus();
        }

        private void tSMICityList_Click(object sender, EventArgs e)
        {
            CreateListForm(typeof(FormCityList));
        }

        private void tSMITagList_Click(object sender, EventArgs e)
        {
            CreateListForm(typeof(FormTagList));
        }

        private void tSMIAuthorList_Click(object sender, EventArgs e)
        {
            CreateListForm(typeof(FormAuthorList));
        }

        private void tSMIPublisherList_Click(object sender, EventArgs e)
        {
            CreateListForm(typeof(FormPublisherList));
        }

        private void tSMIBookList_Click(object sender, EventArgs e)
        {
            CreateListForm(typeof(FormBookList));
        }

        private void tSMIReading_Click(object sender, EventArgs e)
        {
            CreateListForm(typeof(FormReadingList));
        }

        private void tSMIFact_Click(object sender, EventArgs e)
        {
            CreateListForm(typeof(FormFactList));
        }

        private void tSMIPersonList_Click(object sender, EventArgs e)
        {
            CreateListForm(typeof(FormPersonList));
        }

        private void tSMIThought_Click(object sender, EventArgs e)
        {
            CreateListForm(typeof(FormThoughtList));
        }
    }
}
