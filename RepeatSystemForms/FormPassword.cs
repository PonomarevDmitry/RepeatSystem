using System;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using RepeatSystemForms.Properties;

namespace RepeatSystemForms
{
    public partial class FormPassword : Form
    {
        public FileInfo SelectedFile { get; private set; }

        public FormPassword()
        {
            InitializeComponent();

            Application.CurrentInputLanguage = Config.InputLanguageEnglish;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadFormConfiguration();
        }

        private const string parameterDataBaseFile = "parameterDataBaseFile";

        public void LoadFormConfiguration()
        {
            string text;

            text = ProgramConfiguraton.LoadFormCustomParameter(this, parameterDataBaseFile);

            if (!string.IsNullOrEmpty(text))
            {
                OperateFile(text);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (this.DialogResult == DialogResult.OK)
            {
                string text = string.Empty;

                if (this.SelectedFile != null)
                {
                    text = this.SelectedFile.FullName;
                }

                ProgramConfiguraton.SaveFormCustomParameter(this, parameterDataBaseFile, text);

                ProgramConfiguraton.SaveDefaultXmlConfig();
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (this.SelectedFile == null)
            {
                MessageBox.Show("Не выбран файл базы данных.", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (this.SelectedFile != null && !this.SelectedFile.Exists)
            {
                MessageBox.Show("Файл базы данных отсутсвует.", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }
        }

        private void btnChoseDataBaseFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "DataBase File (*.mdf)|*.mdf";
            openFileDialog.FilterIndex = 0;

            if (openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                OperateFile(openFileDialog.FileName);
            }
        }

        private void OperateFile(string filePath)
        {
            this.SelectedFile = null;

            FileInfo file = new FileInfo(filePath);

            if (file.Exists)
            {
                this.SelectedFile = file;
            }

            string text = string.Empty;

            if (this.SelectedFile != null)
            {
                text = this.SelectedFile.FullName;
            }

            txtBDataBaseFilePath.Text = text;
        }
    }
}
