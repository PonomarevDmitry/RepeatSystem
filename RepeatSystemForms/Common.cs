using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;
using ru.sevmash.pkb.Controls;

namespace RepeatSystemForms
{
    internal static class Common
    {
        #region Установленные компоненты.

        /// <summary>
        /// Проверка на установленный NET Framework v2 SP2, без которого отчеты нормально не показываются.
        /// </summary>
        /// <returns></returns>
        public static bool CheckFrameWorkVersion()
        {
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\NET Framework Setup\NDP\v2.0.50727");

            if (regKey != null)
            {
                object value = regKey.GetValue("SP");

                if (value != null && value is int)
                {
                    if (Convert.ToInt32(value) >= 2)
                    {
                        return true;
                    }
                }
            }

//            MessageBox.Show(@"Для отображения отчета на компьютере должен быть установлен Microsoft .NET Framework Version 2, Service Pack 2.
//Обратитесь к вашим администраторам сети.", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        /// <summary>
        /// Проверка на установленный Excel.
        /// </summary>
        /// <returns></returns>
        public static bool isExcelInstalled()
        {
            RegistryKey hkcr = Registry.ClassesRoot;
            RegistryKey excelKey = hkcr.OpenSubKey("Excel.Application");

            return excelKey != null;
        }

        #endregion Установленные компоненты.

        #region Проверка полей.

        internal static bool CheckDateTimeFill(NullableDateTimePicker picker, string name, StringBuilder strBuilder)
        {
            if (!picker.Value.HasValue)
            {
                if (strBuilder.Length > 0) { strBuilder.AppendLine(); }
                strBuilder.AppendFormat("Поле '{0}' не заполнено.", name);

                return false;
            }

            return true;
        }

        internal static bool CheckComboBoxFill(ComboBox comboBox, string name, StringBuilder strBuilder)
        {
            bool valueIsNull = false;

            if (comboBox.SelectedItem == null || comboBox.SelectedIndex == -1)
            {
                valueIsNull = true;
            }
            else
            {
                string text = comboBox.SelectedItem.ToString();

                if (string.IsNullOrEmpty(text))
                {
                    valueIsNull = true;
                }
            }

            if (valueIsNull)
            {
                if (strBuilder.Length > 0) { strBuilder.AppendLine(); }
                strBuilder.AppendFormat("Поле '{0}' не заполнено.", name);

                return false;
            }

            return true;
        }

        internal static bool CheckTextboxFillAndNumber(TextBox textBox, string name, StringBuilder strBuilder, bool allowZero)
        {
            if (!CheckTextboxFill(textBox, name, strBuilder))
            {
                return false;
            }

            if (!CheckTextboxForNumber(textBox, name, strBuilder, allowZero))
            {
                return false;
            }

            return true;
        }

        internal static bool CheckTextboxForNumber(TextBox textBox, string name, StringBuilder strBuilder, bool allowZero)
        {
            string str = textBox.Text.Trim();

            if (!string.IsNullOrEmpty(str))
            {
                long tempInt;

                if (long.TryParse(str, out tempInt))
                {
                    if (tempInt < 0)
                    {
                        if (strBuilder.Length > 0) { strBuilder.AppendLine(); }
                        strBuilder.AppendFormat("В поле '{0}' записано отрицательное число.", name);

                        return false;
                    }
                    else if (!allowZero && tempInt == 0)
                    {
                        if (strBuilder.Length > 0) { strBuilder.AppendLine(); }
                        strBuilder.AppendFormat("В поле '{0}' записан ноль.", name);

                        return false;
                    }
                }
                else
                {
                    if (strBuilder.Length > 0) { strBuilder.AppendLine(); }
                    strBuilder.AppendFormat("В поле '{0}' записано не число.", name);

                    return false;
                }
            }

            return true;
        }

        internal static bool CheckTextboxForDouble(TextBox textBox, string name, StringBuilder strBuilder)
        {
            string str = textBox.Text.Trim();

            if (!string.IsNullOrEmpty(str))
            {
                double? temp = GetDoubleOrNull(str);

                if (temp.HasValue)
                {
                    if (temp < 0)
                    {
                        if (strBuilder.Length > 0) { strBuilder.AppendLine(); }
                        strBuilder.AppendFormat("В поле '{0}' записано отрицательное число.", name);

                        return false;
                    }
                }
                else
                {
                    if (strBuilder.Length > 0) { strBuilder.AppendLine(); }
                    strBuilder.AppendFormat("В поле '{0}' записано не число.", name);

                    return false;
                }
            }

            return true;
        }

        internal static bool CheckTextboxFill(TextBox textBox, string name, StringBuilder strBuilder)
        {
            string str = textBox.Text.Trim();

            if (string.IsNullOrEmpty(str))
            {
                if (strBuilder.Length > 0) { strBuilder.AppendLine(); }
                strBuilder.AppendFormat("Поле '{0}' не заполнено.", name);

                return false;
            }

            return true;
        }

        #endregion Проверка полей.

        #region Получение значений.

        internal static DateTime? GetOnlyDate(DateTime? value)
        {
            DateTime? result = null;

            if (value.HasValue)
            {
                result = value.Value.Date;
            }

            return result;
        }

        internal static int GetIntOrZero(string text)
        {
            int result = 0;
            int tempInt = 0;

            text = text.Trim();

            if (int.TryParse(text, out tempInt))
            {
                if (tempInt >= 0)
                {
                    result = tempInt;
                }
            }

            return result;
        }

        internal static int? GetIntOrNull(string text)
        {
            int? result = null;
            int tempInt = 0;

            text = text.Trim();

            if (int.TryParse(text, out tempInt))
            {
                if (tempInt > 0)
                {
                    result = tempInt;
                }
            }

            return result;
        }

        internal static long? GetLongOrNull(string text)
        {
            long? result = null;
            long temp = 0;

            text = text.Trim();

            if (long.TryParse(text, out temp))
            {
                if (temp > 0)
                {
                    result = temp;
                }
            }

            return result;
        }

        internal static double? GetDoubleOrNull(string text)
        {
            text = text.Trim();

            double tempD = 0;

            text = text.Replace(",", ".");
            if (double.TryParse(text, out tempD))
            {
                return tempD;
            }

            try
            {
                tempD = Convert.ToDouble(text);

                return tempD;
            }
            catch (Exception) { }

            text = text.Replace(".", ",");
            if (double.TryParse(text, out tempD))
            {
                return tempD;
            }

            try
            {
                tempD = Convert.ToDouble(text);

                return tempD;
            }
            catch (Exception) { }


            return null;
        }

        #endregion Получение значений.

        #region Обработчики для TextBox.

        internal static void SetTextBoxOnlyNumbers(params TextBox[] boxes)
        {
            foreach (TextBox textBox in boxes)
            {
                textBox.TextChanged += new EventHandler(textBoxOnlyNumbers_TextChanged);
                textBox.KeyPress += new KeyPressEventHandler(textBoxOnlyNumbers_KeyPress);
            }
        }

        private static void textBoxOnlyNumbers_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            string tempString = Regex.Replace(textBox.Text, @"[^0-9]", string.Empty);

            if (tempString != textBox.Text)
            {
                int selected = textBox.SelectionStart;

                textBox.Text = tempString;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private static void textBoxOnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }

            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        internal static void SetTextBoxNumbersAndSpace(params TextBox[] boxes)
        {
            foreach (TextBox textBox in boxes)
            {
                textBox.TextChanged += new EventHandler(textBoxNumbersAndSpace_TextChanged);
                textBox.KeyPress += new KeyPressEventHandler(textBoxNumbersAndSpace_KeyPress);
            }
        }

        private static void textBoxNumbersAndSpace_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            string tempString = Regex.Replace(textBox.Text, @"[^0-9\s]", string.Empty);

            if (tempString != textBox.Text)
            {
                int selected = textBox.SelectionStart;

                textBox.Text = tempString;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private static void textBoxNumbersAndSpace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        internal static void SetTextBoxNumbersAndDash(params TextBox[] boxes)
        {
            foreach (TextBox textBox in boxes)
            {
                textBox.TextChanged += new EventHandler(textBoxNumbersAndDash_TextChanged);
                textBox.KeyPress += new KeyPressEventHandler(textBoxNumbersAndDash_KeyPress);

            }
        }

        private static void textBoxNumbersAndDash_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            string tempString = Regex.Replace(textBox.Text, @"[^0-9\-]", string.Empty);

            if (tempString != textBox.Text)
            {
                int selected = textBox.SelectionStart;

                textBox.Text = tempString;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private static void textBoxNumbersAndDash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        internal static void SetTextBoxDecimal(params TextBox[] boxes)
        {
            foreach (TextBox textBox in boxes)
            {
                textBox.TextChanged += new EventHandler(textBoxDouble_TextChanged);
                textBox.KeyPress += new KeyPressEventHandler(textBoxDouble_KeyPress);

            }
        }

        private static void textBoxDouble_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            string tempString = Regex.Replace(textBox.Text, @"[^0-9,.]", string.Empty);

            if (tempString != textBox.Text)
            {
                int selected = textBox.SelectionStart;

                textBox.Text = tempString;
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private static void textBoxDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }

            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        #endregion Обработчики для TextBox.

        #region Excel-процедуры.

        //internal static void SetBorders(Excel.Range range, Excel.XlBorderWeight xlBorderWeight)
        //{
        //    range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = xlBorderWeight;
        //    range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = xlBorderWeight;
        //    range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = xlBorderWeight;
        //    range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = xlBorderWeight;
        //}

        //internal static void SaveTableIntoWorkSheet(string[] arrayColNames, DataTable table, Excel.Worksheet worksheet)
        //{
        //    Excel.Range rangeColHeaders = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, arrayColNames.Length]];
        //    rangeColHeaders.Value2 = arrayColNames;
        //    rangeColHeaders.Font.Bold = true;

        //    // Выделяем место под содержание таблицы.
        //    Excel.Range range2 = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[1 + table.Rows.Count, table.Columns.Count]);

        //    //Заполняем массив данными из грида.
        //    string[,] array2 = new string[table.Rows.Count, table.Columns.Count];
        //    for (int i = 0; i < table.Rows.Count; i++)
        //    {
        //        DataRow row = table.Rows[i];

        //        for (int j = 0; j < table.Columns.Count; j++)
        //        {
        //            array2[i, j] = row[j].ToString();
        //        }
        //    }

        //    // Записывем данные.
        //    range2.Value2 = array2;

        //    //// Выделяем всю область для выравнивания столбцов.
        //    Excel.Range range3 = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1 + table.Rows.Count, table.Columns.Count]);
        //    range3.Columns.AutoFit();

        //    SetBorders(range3, Excel.XlBorderWeight.xlThin);
        //}

        //public static void AutoExcel(DataGridView dataGridView, string worksheetName)
        //{
        //    if (!isExcelInstalled())
        //    {
        //        MessageBox.Show(Resources.ErrExcelIsNotIntalled, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (dataGridView.RowCount > 0)
        //    {
        //        Collection<DataGridViewColumn> sortedColumns = SortedColumns(dataGridView);

        //        if (sortedColumns.Count > 0)
        //        {
        //            // Открываем приложение
        //            Excel.Application app = new Excel.Application();

        //            if (app != null)
        //            {
        //                // Скрываем приложение.
        //                app.Visible = false;

        //                // Рабочии книги
        //                Excel.Workbooks workbooks = app.Workbooks;

        //                // Добавляем новый Лист.
        //                Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
        //                Excel.Sheets sheets = workbook.Worksheets;

        //                // Получаем этот лист.
        //                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
        //                worksheet.Name = worksheetName;

        //                // Количество столбцов и строк.
        //                int nCol = sortedColumns.Count;
        //                int nRows = dataGridView.RowCount;

        //                for (int i = 0; i < nCol; i++)
        //                {
        //                    if (sortedColumns[i].ValueType == typeof(string))
        //                    {
        //                        worksheet.Range[worksheet.Cells[2, 1 + i], worksheet.Cells[1 + nRows, 1 + i]].NumberFormat = "@";
        //                    }
        //                    else if (sortedColumns[i].ValueType == typeof(DateTime))
        //                    {
        //                        worksheet.Range[worksheet.Cells[2, 1 + i], worksheet.Cells[1 + nRows, 1 + i]].NumberFormat = "ДД\\.ММ\\.ГГГГ";
        //                    }
        //                }

        //                {
        //                    // Массив с заголовками таблицы.
        //                    string[] arrayHeaders = new string[nCol];
        //                    // Массив комментарий из ToolTip
        //                    string[] arrayToolTips = new string[nCol];

        //                    for (int i = 0; i < nCol; i++)
        //                    {
        //                        arrayHeaders[i] = sortedColumns[i].HeaderText;
        //                        arrayToolTips[i] = sortedColumns[i].ToolTipText;
        //                    }

        //                    // Получем область под заголовки.
        //                    // Выделяем черным.
        //                    Excel.Range range1 = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, nCol]);
        //                    range1.Value2 = arrayHeaders;
        //                    range1.HorizontalAlignment = Excel.Constants.xlCenter;
        //                    range1.Font.Bold = true;

        //                    {
        //                        for (int index = 0; index < arrayToolTips.Length; index++)
        //                        {
        //                            if (!string.IsNullOrEmpty(arrayToolTips[index]))
        //                            {
        //                                range1 = (Excel.Range)worksheet.Cells[1, 1 + index];
        //                                range1.AddComment(arrayToolTips[index]);
        //                                range1.Comment.Visible = false;
        //                            }
        //                        }
        //                    }
        //                }

        //                // Выделяем место под содержание таблицы.
        //                Excel.Range range2 = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[1 + nRows, nCol]);

        //                //Заполняем массив данными из грида.
        //                object[,] array2 = new object[nRows, nCol];
        //                for (int i = 0; i < nRows; i++)
        //                {
        //                    for (int j = 0; j < nCol; j++)
        //                    {
        //                        DataGridViewCell cell = dataGridView[sortedColumns[j].Name, i];

        //                        object value = cell.Value;

        //                        if (sortedColumns[j].ValueType == typeof(string))
        //                        {
        //                            string tempo = value.ToString();

        //                            if (tempo.Length > 910)
        //                            {
        //                                tempo = tempo.Substring(0, 900);
        //                            }

        //                            array2[i, j] = tempo;
        //                        }
        //                        else
        //                        {
        //                            array2[i, j] = value;
        //                        }
        //                    }
        //                }

        //                // Записывем данные.
        //                range2.Value2 = array2;

        //                // Выделяем всю область для выравнивания столбцов.
        //                Excel.Range range3 = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1 + nRows, nCol]);
        //                range3.Columns.AutoFit();
        //                range3.Rows.AutoFit();

        //                {
        //                    double addition = 1;
        //                    for (int rowIndex = 0; rowIndex < nCol; rowIndex++)
        //                    {
        //                        Excel.Range range = null;
        //                        range = worksheet.get_Range(worksheet.Cells[1, 1 + rowIndex], worksheet.Cells[1 + nRows, 1 + rowIndex]);

        //                        try
        //                        {
        //                            double temp = Convert.ToDouble(range.ColumnWidth);
        //                            range.ColumnWidth = temp + addition;
        //                        }
        //                        catch (Exception) { }
        //                    }
        //                }

        //                ((Excel.Range)worksheet.Cells[2, 1]).Select();
        //                app.ActiveWindow.FreezePanes = true;
        //                ((Excel.Range)worksheet.Cells[1, 1]).Select();

        //                // Показываем приложение.
        //                app.Visible = true;
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// Просортированный список видимых столбцов DataGridView.
        ///// </summary>
        ///// <param name="dataGridView"></param>
        ///// <returns></returns>
        //private static Collection<DataGridViewColumn> SortedColumns(DataGridView dataGridView)
        //{
        //    Collection<DataGridViewColumn> result = new Collection<DataGridViewColumn>();

        //    DataGridViewColumn column = dataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible);

        //    if (column == null)
        //    {
        //        return result;
        //    }

        //    result.Add(column);

        //    while ((column = dataGridView.Columns.GetNextColumn(column, DataGridViewElementStates.Visible, DataGridViewElementStates.None)) != null)
        //    {
        //        result.Add(column);
        //    }

        //    return result;
        //}

        //public static void CreateExcelFile(DataTable table, string worksheetName, string[] arrayHeaders, string[] arrayComments)
        //{
        //    string formatDateTime = "ДД\\.ММ\\.ГГГГ чч:мм:сс";
        //    string formatString = "@";
        //    string formatDate = "ДД\\.ММ\\.ГГГГ";
        //    string formatNumber = "0";

        //    if (table.Rows.Count > 0 && table.Columns.Count > 0)
        //    {
        //        // Открываем приложение
        //        Excel.Application app = new Excel.Application();

        //        if (app != null)
        //        {
        //            // Скрываем приложение.
        //            app.Visible = false;

        //            // Рабочии книги
        //            Excel.Workbooks workbooks = app.Workbooks;

        //            // Добавляем новый Лист.
        //            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
        //            Excel.Sheets sheets = workbook.Worksheets;

        //            // Получаем этот лист.
        //            Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
        //            worksheet.Name = worksheetName;

        //            // Количество столбцов и строк.
        //            int nCol = table.Columns.Count;
        //            int nRows = table.Rows.Count;

        //            for (int i = 0; i < nCol; i++)
        //            {
        //                if (table.Columns[i].DataType == typeof(string))
        //                {
        //                    worksheet.Range[worksheet.Cells[2, 1 + i], worksheet.Cells[1 + nRows, 1 + i]].NumberFormat = formatString;
        //                }
        //                else if (table.Columns[i].DataType == typeof(DateTime))
        //                {
        //                    string formatForColumn = formatDate;

        //                    foreach (DataRow row in table.Rows)
        //                    {
        //                        if (row[table.Columns[i]] != DBNull.Value && row[table.Columns[i]] != null)
        //                        {
        //                            try
        //                            {
        //                                DateTime date = Convert.ToDateTime(row[table.Columns[i]]);

        //                                if (date.TimeOfDay.Ticks != 0)
        //                                {
        //                                    formatForColumn = formatDateTime;
        //                                    break;
        //                                }
        //                            }
        //                            catch (Exception) { }
        //                        }
        //                    }

        //                    worksheet.Range[worksheet.Cells[2, 1 + i], worksheet.Cells[1 + nRows, 1 + i]].NumberFormat = formatForColumn;
        //                }
        //                else if (table.Columns[i].DataType == typeof(Int32) || table.Columns[i].DataType == typeof(Int16) || table.Columns[i].DataType == typeof(decimal))
        //                {
        //                    worksheet.Range[worksheet.Cells[2, 1 + i], worksheet.Cells[1 + nRows, 1 + i]].NumberFormat = formatNumber;
        //                }
        //            }

        //            {

        //                // Получем область под заголовки.
        //                // Выделяем черным.
        //                Excel.Range range1 = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, arrayHeaders.Length]);
        //                range1.Value2 = arrayHeaders;
        //                range1.HorizontalAlignment = Excel.Constants.xlCenter;
        //                range1.Font.Bold = true;

        //                {
        //                    for (int index = 0; index < arrayComments.Length; index++)
        //                    {
        //                        if (!string.IsNullOrEmpty(arrayComments[index]))
        //                        {
        //                            range1 = (Excel.Range)worksheet.Cells[1, 1 + index];
        //                            range1.AddComment(arrayComments[index]);
        //                            range1.Comment.Visible = false;
        //                        }
        //                    }
        //                }
        //            }

        //            // Выделяем место под содержание таблицы.
        //            Excel.Range range2 = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[1 + nRows, nCol]);

        //            //Заполняем массив данными из грида.
        //            object[,] array2 = new object[nRows, nCol];
        //            for (int i = 0; i < nRows; i++)
        //            {
        //                for (int j = 0; j < nCol; j++)
        //                {
        //                    object value = table.Rows[i][table.Columns[j]];

        //                    if (table.Columns[j].DataType == typeof(string))
        //                    {
        //                        string tempo = value.ToString();

        //                        if (tempo.Length > 910)
        //                        {
        //                            tempo = tempo.Substring(0, 900);
        //                        }

        //                        array2[i, j] = tempo;
        //                    }
        //                    else
        //                    {
        //                        array2[i, j] = value;
        //                    }
        //                }
        //            }

        //            // Записывем данные.
        //            range2.Value2 = array2;

        //            // Выделяем всю область для выравнивания столбцов.
        //            Excel.Range range3 = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1 + nRows, nCol]);
        //            range3.Columns.AutoFit();
        //            range3.Rows.AutoFit();

        //            {
        //                double addition = 1;
        //                for (int rowIndex = 0; rowIndex < nCol; rowIndex++)
        //                {
        //                    Excel.Range range = null;
        //                    range = worksheet.get_Range(worksheet.Cells[1, 1 + rowIndex], worksheet.Cells[1 + nRows, 1 + rowIndex]);

        //                    try
        //                    {
        //                        double temp = Convert.ToDouble(range.ColumnWidth);
        //                        range.ColumnWidth = temp + addition;
        //                    }
        //                    catch (Exception) { }
        //                }
        //            }

        //            ((Excel.Range)worksheet.Cells[2, 1]).Select();
        //            app.ActiveWindow.FreezePanes = true;
        //            ((Excel.Range)worksheet.Cells[1, 1]).Select();

        //            // Показываем приложение.
        //            app.Visible = true;
        //        }
        //    }
        //}

        #endregion Excel-процедуры.

        internal static DateTime GetDateInYear(DateTime date, int year)
        {
            if (date.Month == 2 && date.Day == 29)
            {
                if (DateTime.IsLeapYear(year))
                {
                    return new DateTime(year, 2, 29);
                }
                else
                {
                    return new DateTime(year, 2, 28);
                }
            }
            else
            {
                return new DateTime(year, date.Month, date.Day);
            }
        }

        internal static Collection<char> separator = new Collection<char> { ' ', '-', '.', '.' };

        internal static string GetInitCap(string text)
        {
            StringBuilder strBuilder = new StringBuilder();

            for (int index = 0; index < text.Length; index++)
            {
                if (index == 0 || separator.Contains(text[index - 1]))
                {
                    strBuilder.Append(Char.ToUpper(text[index]));
                }
                else
                {
                    strBuilder.Append(Char.ToLower(text[index]));
                }
            }

            return strBuilder.ToString();
        }

        #region Поиск в базе данных.

        //internal static int? FindWorkerByTabnumber(string text, bool onlyWorking, bool showSelectForm, Form parentForm)
        //{
        //    int? idWorker = null;

        //    int tabNumber = 0;

        //    if (int.TryParse(text, out tabNumber))
        //    {
        //        SearchResult search = WorkerUtils.SearchByTabnumber(tabNumber, onlyWorking);

        //        idWorker = search.ID;

        //        if (!idWorker.HasValue && showSelectForm && search.TableForChoise != null)
        //        {
        //            if (search.TableForChoise.Rows.Count > 0)
        //            {
        //                FormWorkerSelection form = new FormWorkerSelection(search.TableForChoise);
        //                form.ShowDialog(parentForm);

        //                idWorker = form.SelectedIdWorker;
        //            }
        //        }
        //    }

        //    return idWorker;
        //}

        //internal static int? FindWorkerByLkNumber(string text, bool onlyWorking)
        //{
        //    int? idWorker = null;

        //    int lkNumber = 0;

        //    if (int.TryParse(text, out lkNumber))
        //    {
        //        idWorker = WorkerUtils.SearchByLkNumber(lkNumber, onlyWorking);
        //    }

        //    return idWorker;
        //}

        //internal static int? FindWorkerByPsName(string text, bool onlyWorking, bool showSelectForm, Form parentForm)
        //{
        //    int? idWorker = null;

        //    string temp = text.Trim();

        //    if (!string.IsNullOrEmpty(temp))
        //    {
        //        SearchResult search = WorkerUtils.SearchByPsName(temp, onlyWorking);

        //        idWorker = search.ID;

        //        if (!idWorker.HasValue && showSelectForm && search.TableForChoise != null)
        //        {
        //            if (search.TableForChoise.Rows.Count > 0)
        //            {
        //                FormWorkerSelection form = new FormWorkerSelection(search.TableForChoise);
        //                form.ShowDialog(parentForm);

        //                idWorker = form.SelectedIdWorker;
        //            }
        //        }
        //    }

        //    return idWorker;
        //}

        //internal static int? FindPublicEventByName(string text, bool showSelectForm, Form parentForm)
        //{
        //    int? idPublicEvent = null;

        //    string temp = text.Trim();

        //    if (!string.IsNullOrEmpty(temp))
        //    {
        //        SearchResult search = PublicEventUtils.SearchByName(temp);

        //        idPublicEvent = search.ID;

        //        if (!idPublicEvent.HasValue && showSelectForm && search.TableForChoise != null)
        //        {
        //            if (search.TableForChoise.Rows.Count > 0)
        //            {
        //                FormPublicEventSelection form = new FormPublicEventSelection(search.TableForChoise);
        //                form.ShowDialog(parentForm);

        //                idPublicEvent = form.SelectedIdWorker;
        //            }
        //        }
        //    }

        //    return idPublicEvent;
        //}

        #endregion Поиск в базе данных.
    }
}
