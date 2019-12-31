using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using RepeatSystem.DataBase;
using RepeatSystem.Classes;

namespace RepeatSystemForms.Gui
{
    public partial class FormFactList : Form, IFormConfiguration
    {
        #region Конструктор.

        public FormFactList()
        {
            InitializeComponent();

            Application.CurrentInputLanguage = Config.InputLanguageRussian;

            FillComboBoxColumns();

            gridFiltersControl.BeginInit();

            ApplyFilter();

            (gridFiltersControl.FilterFactory as GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory).DefaultShowDateInBetweenOperator = true;

            gridFiltersControl.EndInit();

            tSMIAdd.Enabled = bNAdd.Enabled = true;

            BindTextBoxes();

            LoadFormConfiguration();
        }

        private void BindTextBoxes()
        {
            txtBQuestion.DataBindings.Add("Text", bSList, FactUtils.tableFieldQUESTION);
        }

        private void FillComboBoxColumns()
        {
            string message = string.Empty;
            System.Data.DataTable dataTable = null;

            if (Config.Session.FactTypeUtils.GetAllByTable(out dataTable, out message))
            {
                if (dataTable != null)
                {
                    dGVColFactType.DataSource = dataTable;
                    dGVColFactType.ValueMember = FactTypeUtils.tableFieldNAME;
                    dGVColFactType.DisplayMember = FactTypeUtils.tableFieldNAME;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            gridFiltersControl.RecreateGridFilters();

            ProgramConfiguraton.LoadGridFilter(gridFiltersControl);
        }

        #region Инициализация.

        public void LoadFormConfiguration()
        {
            ProgramConfiguraton.LoadFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size | ConfigFormOption.Maximized);

            ProgramConfiguraton.LoadControlsSize(gBQuestion);

            ProgramConfiguraton.LoadDataGridViewParams(dGVList, ConfigDataGridViewOption.Width);
        }

        public void SaveFormConfiguration()
        {
            ProgramConfiguraton.SaveFormParams(this, ConfigFormOption.Location | ConfigFormOption.Size | ConfigFormOption.Maximized);

            ProgramConfiguraton.SaveDataGridViewParams(dGVList, ConfigDataGridViewOption.Width);

            ProgramConfiguraton.SaveControlsSize(gBQuestion);

            ProgramConfiguraton.SaveGridFilter(gridFiltersControl);

            ProgramConfiguraton.SaveDefaultXmlConfig();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            SaveFormConfiguration();
        }

        #endregion Инициализация.

        #endregion Конструктор.

        #region Список пользователей.

        private bool RefreshList(out DataTable dataTable, out string message)
        {
            bool result = false;
            message = string.Empty;
            dataTable = null;

            try
            {
                if (Config.Session.FactUtils.GetTable(out dataTable, out message))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return result;
        }

        private int? GetCurrentObjectId()
        {
            int? result = null;

            if (dGVList.SelectedRows.Count == 1)
            {
                DataGridViewRow tempRow = dGVList.SelectedRows[0];

                try
                {
                    result = Convert.ToInt32(tempRow.Cells[dGVColID.Name].Value);
                }
                catch (Exception)
                {
                }
            }

            return result;
        }

        #region Menu

        private void tSMIClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tSMIRefresh_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        #endregion Menu

        #endregion Список пользователей.

        #region Фильтр.

        public void ApplyFilter()
        {
            DataTable dataTable = null;
            string message = string.Empty;

            Cursor.Current = Cursors.WaitCursor;

            if (RefreshList(out dataTable, out message))
            {
                int columnInd = dGVList.FirstDisplayedScrollingColumnIndex;
                int rowInd = dGVList.FirstDisplayedScrollingRowIndex;

                DataGridViewColumn sortCol = dGVList.SortedColumn;
                SortOrder sortOrder = dGVList.SortOrder;

                bSList.DataSource = dataTable;

                if (sortOrder != SortOrder.None && sortCol != null)
                {
                    dGVList.Sort(sortCol, sortOrder == SortOrder.Ascending ? System.ComponentModel.ListSortDirection.Ascending : System.ComponentModel.ListSortDirection.Descending);
                }

                if (columnInd != -1 && columnInd < dGVList.ColumnCount)
                {
                    dGVList.FirstDisplayedScrollingColumnIndex = columnInd;
                }

                if (rowInd != -1 && rowInd < dGVList.RowCount)
                {
                    dGVList.FirstDisplayedScrollingRowIndex = rowInd;
                }

                gridFiltersControl.RepositionGridFilters();
            }
            else
            {
                //MessageBox.Show(Common.GenerateMessageAndLog(Resources.ApplicationInitializationError, message));
            }

            Cursor.Current = Cursors.Arrow;
        }

        private Hashtable GetFilterParameters()
        {
            Hashtable hashTable = new Hashtable();

            return hashTable;
        }

        #endregion Фильтр.

        private void tSBRefresh_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void tSBRemoveSort_Click(object sender, EventArgs e)
        {
            bSList.RemoveSort();
        }

        private void dGVWorkerList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void tSBClearFilters_Click(object sender, EventArgs e)
        {
            gridFiltersControl.ClearFilters();
        }

        #region Кнопки изменения пользователей.

        private void tSMIView_Click(object sender, EventArgs e)
        {
            bNView.PerformClick();
        }

        private void tSMIAdd_Click(object sender, EventArgs e)
        {
            bNAdd.PerformClick();
        }

        private void tSMIEdit_Click(object sender, EventArgs e)
        {
            bNEdit.PerformClick();
        }

        private void tSMIDelete_Click(object sender, EventArgs e)
        {
            bNDelete.PerformClick();
        }

        private void bNView_Click(object sender, EventArgs e)
        {
            int? id = GetCurrentObjectId();

            if (id.HasValue)
            {
                Fact obj = Config.Session.FactUtils.GetById(id.Value);

                FormFactCard form = new FormFactCard(obj, FormMode.View);
                form.ShowDialog();

                if (form.IsObjectAddedIntoDataBase)
                {
                    ApplyFilter();
                }
            }
        }

        private void bNAdd_Click(object sender, EventArgs e)
        {
            Fact obj = new Fact();
            obj.CreationDate = DateTime.Now;
            obj.FactType = Config.Session.FactTypeUtils.TypeFact;

            FormFactCard form = new FormFactCard(obj, FormMode.Add);
            form.ShowDialog();

            if (form.IsObjectAddedIntoDataBase)
            {
                ApplyFilter();
            }
        }

        private void bNEdit_Click(object sender, EventArgs e)
        {
            int? id = GetCurrentObjectId();

            if (id.HasValue)
            {
                Fact obj = Config.Session.FactUtils.GetById(id.Value);

                FormFactCard form = new FormFactCard(obj, FormMode.Edit);
                form.ShowDialog();

                if (form.IsObjectAddedIntoDataBase)
                {
                    ApplyFilter();
                }
            }
        }

        private void bNDelete_Click(object sender, EventArgs e)
        {
            int? id = GetCurrentObjectId();

            if (id.HasValue)
            {
                Fact obj = Config.Session.FactUtils.GetById(id.Value);

                if (MessageBox.Show(this, "Вы действительно хотите удалить факт?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                {
                    Config.Session.FactUtils.Delete(obj);
                    ApplyFilter();
                }
            }
        }

        #endregion Кнопки изменения пользователей.

        private void bSList_CurrentItemChanged(object sender, EventArgs e)
        {
            tSMIView.Enabled = bNView.Enabled = bSList.Current != null;

            tSMIEdit.Enabled = bNEdit.Enabled = bSList.Current != null;
            tSMIDelete.Enabled = bNDelete.Enabled = bSList.Current != null;
        }

        private void dGVList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                bNView.PerformClick();
            }
        }
    }
}
