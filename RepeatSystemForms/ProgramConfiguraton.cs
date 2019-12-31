using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using GridViewExtensions;
using GridViewExtensions.GridFilters;

namespace RepeatSystemForms
{
    /// <summary>
    /// Свойства таблицы для загрузки/сохранения в конфиг-файле.
    /// </summary>
    [Flags]
    internal enum ConfigDataGridViewOption
    {
        /// <summary>
        /// Ширина столбцов.
        /// </summary>
        Width = 1,

        /// <summary>
        /// Отображение столбцов в списке.
        /// </summary>
        Visible = 2,

        /// <summary>
        /// Порядок столбцов в списке.
        /// </summary>
        DisplayIndex = 4/*,

        /// <summary>
        /// Сортировка списка
        /// </summary>
        SortText = 8*/
    }

    /// <summary>
    /// Свойства формы для загрузки/сохранения в конфиг-файле.
    /// </summary>
    [Flags]
    internal enum ConfigFormOption
    {
        /// <summary>
        /// Размер формы.
        /// </summary>
        Size = 1,

        /// <summary>
        /// Расположение формы.
        /// </summary>
        Location = 2,

        /// <summary>
        /// Свойство FormWindowState.Maximized формы.
        /// </summary>
        Maximized = 4
    }

    /// <summary>
    /// Интерфейс для MDI-дочерней формы MainForm для on-line загрузки/сохранения профилей.
    /// </summary>
    internal interface IFormConfiguration
    {
        /// <summary>
        /// Загрузить сохраненные настройки формы.
        /// </summary>
        void LoadFormConfiguration();

        /// <summary>
        /// Записать настройки формы в конфиг-файл.
        /// </summary>
        void SaveFormConfiguration();
    }

    /// <summary>
    /// Статический класс для работы с настройками формы.
    /// </summary>
    public static class ProgramConfiguraton
    {
        private const string programConfigFileName = "RepeatSystemForms.conf";
        private const string programSubdirectoryName = "RepeatSystem";
        private const string programRootNodeName = "RepeatSystem_Configuration";

        /// <summary>
        /// XmlDocument с настройками программы.
        /// </summary>
        private static ConfigXmlDocument programParams = new ConfigXmlDocument();

        #region Стандартные имя файла и его местоположение.

        /// <summary>
        /// Стандартная папка для хранения конфиг-файла.
        /// </summary>
        private static string DefaultFileDirectory
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + programSubdirectoryName;
            }
        }

        /// <summary>
        /// Стандартное имя конфиг-файла.
        /// </summary>
        private static string DefaultFileName
        {
            get
            {
                return DefaultFileDirectory + @"\" + programConfigFileName;
            }
        }

        #endregion Стандартные имя файла и его местоположение.

        #region Работа с файлами.

        /// <summary>
        /// Загрузить конфиг-файл.
        /// </summary>
        internal static void LoadDefaultXmlConfig()
        {
            string fileName = DefaultFileName;

            bool create = false;

            if (File.Exists(fileName))
            {
                try
                {
                    programParams.Load(fileName);
                }
                catch (Exception)
                {
                    create = true;
                }
            }
            else
            {
                create = true;
            }

            if (create)
            {
                programParams = new ConfigXmlDocument();

                XmlDeclaration declaration = programParams.CreateXmlDeclaration("1.0", "utf-8", "yes");
                programParams.AppendChild(declaration);
                XmlNode root = programParams.CreateElement(programRootNodeName);
                programParams.AppendChild(root);
            }
        }

        /// <summary>
        /// Сохранить конфиг-файл.
        /// </summary>
        internal static void SaveDefaultXmlConfig()
        {
            string dirName = DefaultFileDirectory;

            if (!Directory.Exists(DefaultFileDirectory))
            {
                Directory.CreateDirectory(DefaultFileDirectory);
            }

            programParams.Save(DefaultFileName);
        }

        /// <summary>
        /// Считать внешний конфиг-файл.
        /// </summary>
        /// <param name="fileName"></param>
        internal static void LoadXmlConfigFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                programParams.Load(fileName);
                SaveDefaultXmlConfig();
            }
        }

        /// <summary>
        /// Сохранить во внешний файл содержимое текущего конфиг-файла.
        /// </summary>
        /// <param name="fileName"></param>
        internal static void SaveXmlConfigIntoFile(string fileName)
        {
            SaveDefaultXmlConfig();
            programParams.Save(fileName);
        }

        #endregion Работа с файлами.

        #region Методы для работы интерфейсом форм.

        #region Формы.

        #region Свободный параметр формы.

        /// <summary>
        /// Загрузить свободный параметр формы.
        /// </summary>
        /// <param name="form">Форма, которой нужен параметр.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <returns>Значение параметра как строка, если параметра нет, то возвращается пустая строка.</returns>
        internal static string LoadFormCustomParameter(Form form, string paramName)
        {
            // Результат.
            string result = string.Empty;

            // Форма не нуль, имя формы не пустое, имя параметра не нуль.
            if (!string.IsNullOrEmpty(paramName) && form != null && !string.IsNullOrEmpty(form.Name))
            {
                // Корневой элемент конфигурации программы.
                XmlNode root = programParams[programRootNodeName];
                if (root != null)
                {
                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode != null)
                    {
                        // Элемент параметра.
                        XmlNode formParamValue = formNode[paramName];
                        if (formParamValue != null)
                        {
                            // Загрузка значения.
                            result = formParamValue.InnerText;
                        }
                    }
                }
            }

            // Проверка правильности сохранения параметра не входит в список обязанностей этой функции.
            return result;
        }

        /// <summary>
        /// Сохранить свободный параметр формы.
        /// </summary>
        /// <param name="form">Форма, которой принадлежит этот параметр.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <param name="paramValue">Значение параметра в виде строки.</param>
        internal static void SaveFormCustomParameter(Form form, string paramName, string paramValue)
        {
            // Форма не нуль, имя формы не нуль, имя параметра не нуль.
            if (!string.IsNullOrEmpty(paramName) && form != null && !string.IsNullOrEmpty(form.Name))
            {
                // Корневой элемент конфигурации программы.
                XmlNode root = programParams[programRootNodeName];
                if (root == null)
                {
                    // Создаем корень, если его нет.
                    root = programParams.CreateElement(programRootNodeName);
                    programParams.AppendChild(root);
                }

                // Элемент формы.
                XmlNode formNode = root[form.Name];
                if (formNode == null)
                {
                    // Создаем его, если нет.
                    formNode = programParams.CreateElement(form.Name);
                    root.AppendChild(formNode);
                }

                // Элемент параметра.
                XmlNode formParamValue = formNode[paramName];
                if (formParamValue == null)
                {
                    // Создаем его, если нет.
                    formParamValue = programParams.CreateElement(paramName);
                    formNode.AppendChild(formParamValue);
                }
                // Сохраняем значение параметра.
                formParamValue.InnerText = paramValue;
            }
        }

        #endregion Свободный параметр формы.

        #region Стандартные настройки форм.

        /// <summary>
        /// Загрузка стандартных параметров формы по указанному списку флагов.
        /// </summary>
        /// <param name="form">Форма для загрузки параметров.</param>
        /// <param name="options">Флаги параметров.</param>
        internal static void LoadFormParams(Form form, ConfigFormOption options)
        {
            // Форма не нулевая и с непустым именем.
            if (form != null && !string.IsNullOrEmpty(form.Name))
            {
                // Ищем конфигурационный корень в файле.
                XmlNode root = programParams[programRootNodeName];
                if (root != null)
                {
                    // Ищем элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode != null)
                    {
                        // Переменная для конвертирования текста элементов.
                        int value = 0;

                        // Если есть флаг размеров.
                        if ((options & ConfigFormOption.Size) == ConfigFormOption.Size)
                        {
                            // Ширина.
                            XmlNode formWidth = formNode["Width"];
                            if (formWidth != null)
                            {
                                if (int.TryParse(formWidth.InnerText, out value))
                                {
                                    form.Width = value;
                                }
                            }

                            // Высота.
                            XmlNode formHeight = formNode["Height"];
                            if (formHeight != null)
                            {
                                if (int.TryParse(formHeight.InnerText, out value))
                                {
                                    form.Height = value;
                                }
                            }
                        }

                        // Если есть флаг расположения.
                        if ((options & ConfigFormOption.Location) == ConfigFormOption.Location)
                        {
                            bool locationIsNull = true;

                            // Горизонталь.
                            XmlNode formLeft = formNode["Left"];
                            if (formLeft != null)
                            {
                                if (int.TryParse(formLeft.InnerText, out value))
                                {
                                    locationIsNull = false;
                                    form.Left = value;
                                }
                            }

                            // Вертикаль.
                            XmlNode formTop = formNode["Top"];
                            if (formTop != null)
                            {
                                if (int.TryParse(formTop.InnerText, out value))
                                {
                                    locationIsNull = false;
                                    form.Top = value;
                                }
                            }

                            // Если элемент формы есть, но расположение не сохранено, то показываем форму в центре.
                            if (locationIsNull)
                            {
                                form.StartPosition = FormStartPosition.CenterScreen;
                            }
                            else
                            {
                                form.StartPosition = FormStartPosition.Manual;
                            }
                        }

                        // Если считываем Состояним Максимизации.
                        if ((options & ConfigFormOption.Maximized) == ConfigFormOption.Maximized)
                        {
                            XmlNode formMaximized = formNode[ConfigFormOption.Maximized.ToString()];
                            // Если элемент есть и его значение "1".
                            if (formMaximized != null && formMaximized.InnerText == "1")
                            {
                                form.WindowState = FormWindowState.Maximized;
                            }
                            else
                            {
                                form.WindowState = FormWindowState.Normal;
                            }
                        }
                    }
                    // Если нет элемента формы и есть считывание расположения, то задаем стандартное положение - в центре.
                    else if ((options & ConfigFormOption.Location) == ConfigFormOption.Location)
                    {
                        form.StartPosition = FormStartPosition.CenterScreen;
                    }
                }
            }
        }

        /// <summary>
        /// Сохранение в конфиг-файле настроек формы по указанному списку свойств.
        /// </summary>
        /// <param name="form">Форма для сохранения ее параметров.</param>
        /// <param name="options">Набор флагов для сохранения параметров.</param>
        internal static void SaveFormParams(Form form, ConfigFormOption options)
        {
            // Форма не нуль и имя формы непустое.
            if (form != null && !string.IsNullOrEmpty(form.Name))
            {
                // Ищем корень конфигурации программы.
                XmlNode root = programParams[programRootNodeName];
                if (root == null)
                {
                    // Создаем корень, если его нет.
                    root = programParams.CreateElement(programRootNodeName);
                    programParams.AppendChild(root);
                }

                // Ищем элемент формы.
                XmlNode formNode = root[form.Name];
                if (formNode == null)
                {
                    // Создаем его, если его нет.
                    formNode = programParams.CreateElement(form.Name);
                    root.AppendChild(formNode);
                }

                // Сохраняем расположение и размер, только если форма не в Максимизированном состоянии.
                if (form.WindowState == FormWindowState.Normal)
                {
                    // Если сохраняем размер.
                    if ((options & ConfigFormOption.Size) == ConfigFormOption.Size)
                    {
                        // Элемент ширины.
                        XmlNode formWidth = formNode["Width"];
                        if (formWidth == null)
                        {
                            // Создаем его, если нет.
                            formWidth = programParams.CreateElement("Width");
                            formNode.AppendChild(formWidth);
                        }
                        // Сохраняем ширину.
                        formWidth.InnerText = form.Width.ToString();

                        // Элемент высоты.
                        XmlNode formHeight = formNode["Height"];
                        if (formHeight == null)
                        {
                            // Создаем его, если нет.
                            formHeight = programParams.CreateElement("Height");
                            formNode.AppendChild(formHeight);
                        }
                        // Сохраняем высоту.
                        formHeight.InnerText = form.Height.ToString();
                    }

                    // Если сохраняем расположение.
                    if ((options & ConfigFormOption.Location) == ConfigFormOption.Location)
                    {
                        // Элемент горизонтали.
                        XmlNode formLeft = formNode["Left"];
                        if (formLeft == null)
                        {
                            // Создаем его, если нет.
                            formLeft = programParams.CreateElement("Left");
                            formNode.AppendChild(formLeft);
                        }
                        // Сохраняем горизонталь.
                        formLeft.InnerText = form.Left.ToString();

                        // Элемент вертикали.
                        XmlNode formTop = formNode["Top"];
                        if (formTop == null)
                        {
                            // Создаем его, если нет.
                            formTop = programParams.CreateElement("Top");
                            formNode.AppendChild(formTop);
                        }
                        // Сохраняем вертикаль.
                        formTop.InnerText = form.Top.ToString();
                    }
                }

                // Если сохраняем состояние окна.
                if ((options & ConfigFormOption.Maximized) == ConfigFormOption.Maximized)
                {
                    // Элемент максимизации.
                    XmlNode formMaximized = formNode[ConfigFormOption.Maximized.ToString()];
                    if (formMaximized == null)
                    {
                        // Создаем его, если нет.
                        formMaximized = programParams.CreateElement(ConfigFormOption.Maximized.ToString());
                        formNode.AppendChild(formMaximized);
                    }
                    // Сохраняем максимизацию.
                    formMaximized.InnerText = form.WindowState == FormWindowState.Maximized ? "1" : "0";
                }
            }
        }

        #endregion Стандартные настройки форм.

        #endregion Формы.

        #region Столбцы таблиц.

        /// <summary>
        /// Загрузка из конфиг-файла параметров таблицы по списку свойств.
        /// </summary>
        /// <param name="dataGridView">DataGridView, для которой считывать настройки.</param>
        /// <param name="options">Флаги параметров для загрузки.</param>
        internal static void LoadDataGridViewParams(DataGridView dataGridView, ConfigDataGridViewOption options)
        {
            // DataGridView не пустой, его имя не пустое, и у него есть столбцы.
            if (dataGridView != null && !string.IsNullOrEmpty(dataGridView.Name) && dataGridView.Columns.Count > 0)
            {
                // Ищем форму, содержкащую таблицу.
                Form form = dataGridView.FindForm();
                // Форма не нулевая, имя ее не пустое.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Ищем корневой элемент настроек программы.
                    XmlNode root = programParams[programRootNodeName];
                    if (root != null)
                    {
                        // Ищем элемент формы.
                        XmlNode formNode = root[form.Name];
                        if (formNode != null)
                        {
                            // Ищем элемент таблицы.
                            XmlNode dataGridViewNode = formNode[dataGridView.Name];
                            if (dataGridViewNode != null)
                            {
                                // Если загружаем порядковый номер отображения.
                                if ((options & ConfigDataGridViewOption.DisplayIndex) == ConfigDataGridViewOption.DisplayIndex)
                                {
                                    // Список для сортировки, если загружаются индексы отображения.
                                    SortedList list = new SortedList();

                                    foreach (DataGridViewColumn column in dataGridView.Columns)
                                    {
                                        // Имя столбца не пустое. Обрабатываются все, кроме системных столбцов.
                                        if (!string.IsNullOrEmpty(column.Name) && !column.Name.ToLower().Contains("syscol"))
                                        {
                                            XmlNode columnNode = dataGridViewNode[column.Name];
                                            if (columnNode != null)
                                            {
                                                // Элемент порядкового номера.
                                                XmlNode columnDisplayIndex = columnNode[ConfigDataGridViewOption.DisplayIndex.ToString()];
                                                if (columnDisplayIndex != null)
                                                {
                                                    int tempIndex = 0;

                                                    if (int.TryParse(columnDisplayIndex.InnerText, out tempIndex))
                                                    {
                                                        // Добавляем в список сортировки.
                                                        list.Add(tempIndex, column);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    foreach (int key in list.Keys)
                                    {
                                        if (key < dataGridView.ColumnCount)
                                        {
                                            // Устанавливаем столбцам порядковые номера.
                                            ((DataGridViewColumn)list[key]).DisplayIndex = key;
                                        }
                                    }
                                }

                                // Цикл по всем столбцам таблицы.
                                foreach (DataGridViewColumn column in dataGridView.Columns)
                                {
                                    // Имя столбца не пустое. Обрабатываются все, кроме системных столбцов.
                                    if (!string.IsNullOrEmpty(column.Name) && !column.Name.ToLower().Contains("syscol"))
                                    {
                                        // Элмент столбца.
                                        XmlNode columnNode = dataGridViewNode[column.Name];
                                        if (columnNode != null)
                                        {
                                            // Если загружаем ширину.
                                            if ((options & ConfigDataGridViewOption.Width) == ConfigDataGridViewOption.Width)
                                            {
                                                if (column.AutoSizeMode != DataGridViewAutoSizeColumnMode.Fill)
                                                {
                                                    // Элемент ширины.
                                                    XmlNode columnWidth = columnNode[ConfigDataGridViewOption.Width.ToString()];
                                                    if (columnWidth != null)
                                                    {
                                                        int tempWidth = 0;

                                                        if (int.TryParse(columnWidth.InnerText, out tempWidth))
                                                        {
                                                            column.Width = tempWidth;
                                                        }
                                                    }
                                                }
                                            }

                                            // Если загружаем свойство отображения.
                                            if ((options & ConfigDataGridViewOption.Visible) == ConfigDataGridViewOption.Visible)
                                            {
                                                // Элмент отображения.
                                                XmlNode columnVisible = columnNode[ConfigDataGridViewOption.Visible.ToString()];
                                                if (columnVisible != null)
                                                {
                                                    column.Visible = columnVisible.InnerText == "1";
                                                }
                                            }
                                        }
                                    }
                                }

                                // Была попытка сохранять сортировку списка, но пока это вызывает ошибки.
                                // Признано ненужным.

                                //if ((options & ConfigDataGridViewOption.SortText) == ConfigDataGridViewOption.SortText)
                                //{
                                //    XmlAttribute sortTexNode = dataGridViewNode.Attributes[ConfigDataGridViewOption.SortText.ToString()];

                                //    if (sortTexNode != null && dataGridView.DataSource is BindingSource)
                                //    {
                                //        ((BindingSource)dataGridView.DataSource).Sort = sortTexNode.Value;
                                //    }
                                //}
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Сохранение в конфиг-файле параметров таблицы по списку свойств.
        /// </summary>
        /// <param name="dataGridView">DataGridView, настройки которой нужно сохранять.</param>
        /// <param name="options">Флаги настроек на сохранение.</param>
        internal static void SaveDataGridViewParams(DataGridView dataGridView, ConfigDataGridViewOption options)
        {
            // Таблица не нуль, ее имя не нуль, и количество столбцов больше нуля.
            if (dataGridView != null && !string.IsNullOrEmpty(dataGridView.Name) && dataGridView.ColumnCount > 0)
            {
                // Форма, содержащая таблицу.
                Form form = dataGridView.FindForm();
                // Форма не нуль, ее имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент настроек программы.
                    XmlNode root = programParams[programRootNodeName];
                    if (root == null)
                    {
                        // Создаем корень, если его нет.
                        root = programParams.CreateElement(programRootNodeName);
                        programParams.AppendChild(root);
                    }

                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создаем его, если его нет.
                        formNode = programParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }

                    // Элемент таблицы.
                    XmlNode dataGridViewNode = formNode[dataGridView.Name];
                    if (dataGridViewNode == null)
                    {
                        // Создаем его, если его нет.
                        dataGridViewNode = programParams.CreateElement(dataGridView.Name);
                        formNode.AppendChild(dataGridViewNode);
                    }

                    // Сохранение сортировки списка.
                    // Признано ненужным.

                    //if ((options & ConfigDataGridViewOption.SortText) == ConfigDataGridViewOption.SortText && dataGridView.DataSource is BindingSource)
                    //{
                    //    XmlAttribute sortTexNode = dataGridViewNode.Attributes[ConfigDataGridViewOption.SortText.ToString()];

                    //    if (sortTexNode == null)
                    //    {
                    //        sortTexNode = programParams.CreateAttribute(ConfigDataGridViewOption.SortText.ToString());
                    //        dataGridViewNode.Attributes.Append(sortTexNode);
                    //    }

                    //    sortTexNode.Value = ((BindingSource)dataGridView.DataSource).Sort;
                    //}

                    // По всем столбцам.
                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                    {
                        DataGridViewColumn item = dataGridView.Columns[i];
                        // Имя столбца не нуль, и не системное.
                        if (!string.IsNullOrEmpty(item.Name) && !item.Name.ToLower().Contains("syscol"))
                        {
                            // Элемент столбца.
                            XmlNode columnNode = dataGridViewNode[item.Name];
                            if (columnNode == null)
                            {
                                // Создаем его, если его нет.
                                columnNode = programParams.CreateElement(item.Name);
                                dataGridViewNode.AppendChild(columnNode);
                            }

                            // Если сохраняем ширину.
                            if ((options & ConfigDataGridViewOption.Width) == ConfigDataGridViewOption.Width)
                            {
                                if (item.AutoSizeMode != DataGridViewAutoSizeColumnMode.Fill)
                                {
                                    // Элемент ширины.
                                    XmlNode columnWidth = columnNode[ConfigDataGridViewOption.Width.ToString()];
                                    if (columnWidth == null)
                                    {
                                        // Создаем его, если его нет.
                                        columnWidth = programParams.CreateElement(ConfigDataGridViewOption.Width.ToString());
                                        columnNode.AppendChild(columnWidth);
                                    }
                                    // Сохраняем ширину.
                                    columnWidth.InnerText = item.Width.ToString();
                                }
                            }

                            // Если сохраняем свойство отображения.
                            if ((options & ConfigDataGridViewOption.Visible) == ConfigDataGridViewOption.Visible)
                            {
                                // Элемент отображения.
                                XmlNode columnVisible = columnNode[ConfigDataGridViewOption.Visible.ToString()];
                                if (columnVisible == null)
                                {
                                    // Создаем его, если его нет.
                                    columnVisible = programParams.CreateElement(ConfigDataGridViewOption.Visible.ToString());
                                    columnNode.AppendChild(columnVisible);
                                }
                                // Сохраняем отображение.
                                columnVisible.InnerText = item.Visible ? "1" : "0";
                            }

                            // Если сохраняем порядковый номер.
                            if ((options & ConfigDataGridViewOption.DisplayIndex) == ConfigDataGridViewOption.DisplayIndex)
                            {
                                // Элемент порядкового номера.
                                XmlNode columnDisplayIndex = columnNode[ConfigDataGridViewOption.DisplayIndex.ToString()];
                                if (columnDisplayIndex == null)
                                {
                                    // Создаем его, если его нет.
                                    columnDisplayIndex = programParams.CreateElement(ConfigDataGridViewOption.DisplayIndex.ToString());
                                    columnNode.AppendChild(columnDisplayIndex);
                                }
                                // Сохраняем порядковый номер.
                                columnDisplayIndex.InnerText = item.DisplayIndex.ToString();
                            }
                        }
                    }
                }
            }
        }

        #endregion Столбцы таблиц.

        #region Контролы.

        #region Свободного параметр контрола.

        /// <summary>
        /// Загрузка кастомного параметра контрола из конфиг-файла.
        /// </summary>
        /// <param name="control">Контрол, которому принадлежит параметр.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <returns>Сохраненное значение параметра.</returns>
        internal static string LoadControlCustomParameter(Control control, string paramName)
        {
            string result = string.Empty;
            // Если имя параметра не нулевое, контрое и его имя не нуль.
            if (!string.IsNullOrEmpty(paramName) && control != null && !string.IsNullOrEmpty(control.Name))
            {
                // Форма, содержащая данный контрол.
                Form form = control.FindForm();
                // Форма и его имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[programRootNodeName];
                    if (root != null)
                    {
                        // Элемент формы.
                        XmlNode formNode = root[form.Name];
                        if (formNode != null)
                        {
                            // Элемент контрола.
                            XmlNode controlNode = formNode[control.Name];
                            if (controlNode != null)
                            {
                                // Элемент параметра.
                                XmlNode controlParamValue = controlNode[paramName];
                                if (controlParamValue != null)
                                {
                                    // Считываем параметр.
                                    result = controlParamValue.InnerText;
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Сохранение в конфиг-файл кастомного параметра контрола.
        /// </summary>
        /// <param name="control">Контрол, которому принадлежит параметр.</param>
        /// <param name="paramName">Имя параметра.</param>
        /// <param name="paramValue">Значение параметра.</param>
        internal static void SaveControlCustomParameter(Control control, string paramName, string paramValue)
        {
            // Если имя параметра, контрол и его имя не нулевые.
            if (!string.IsNullOrEmpty(paramName) && control != null && !string.IsNullOrEmpty(control.Name))
            {
                // Форма, содержащая данную форму.
                Form form = control.FindForm();
                // Форма и его имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфиг-файла.
                    XmlNode root = programParams[programRootNodeName];
                    if (root == null)
                    {
                        // Создаем корневой элемент, если его нет.
                        root = programParams.CreateElement(programRootNodeName);
                        programParams.AppendChild(root);
                    }

                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создаем его, если его нет.
                        formNode = programParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }

                    // Элемент контрола.
                    XmlNode controlNode = formNode[control.Name];
                    if (controlNode == null)
                    {
                        // Создаем его, если его нет.
                        controlNode = programParams.CreateElement(control.Name);
                        formNode.AppendChild(controlNode);
                    }

                    // Элемент параметра.
                    XmlNode controlParamValue = controlNode[paramName];
                    if (controlParamValue == null)
                    {
                        // Создаем его, если его нет.
                        controlParamValue = programParams.CreateElement(paramName);
                        controlNode.AppendChild(controlParamValue);
                    }
                    // Сохраняем параметр.
                    controlParamValue.InnerText = paramValue;
                }
            }
        }

        #endregion Свободного параметр контрола.

        #region Размеры контролов.

        /// <summary>
        /// Загрузка размеров списка контролов из конфиг-файла.
        /// </summary>
        /// <param name="controls">Массив контролов, для считывания размеров.</param>
        internal static void LoadControlsSize(params Control[] controls)
        {
            // Массив не нулевая и в нем более одного элемента.
            if (controls != null && controls.Length > 0)
            {
                // Форма, содержащая данные контролы (считывается с первого контрола).
                Form form = controls[0].FindForm();
                // Форма и ее имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[programRootNodeName];
                    if (root != null)
                    {
                        // Элемент формы.
                        XmlNode formNode = root[form.Name];
                        if (formNode != null)
                        {
                            // Переменная для конверта текста в число.
                            int value = 0;
                            // По всем контролам.
                            for (int i = 0; i < controls.Length; i++)
                            {
                                Control control = controls[i];
                                // Имя контрола не нуль.
                                if (!string.IsNullOrEmpty(control.Name) && control.Dock != DockStyle.Fill)
                                {
                                    // Элемент контрола.
                                    XmlNode controlNode = formNode[control.Name];
                                    if (controlNode != null)
                                    {

                                        if (control.Dock != DockStyle.Bottom && control.Dock != DockStyle.Top)
                                        {
                                            // Элемент ширины.
                                            XmlNode controlWidth = controlNode["Width"];
                                            if (controlWidth != null)
                                            {
                                                if (int.TryParse(controlWidth.InnerText, out value))
                                                {
                                                    // Загружаем ширину.
                                                    control.Width = value;
                                                }
                                            }
                                        }

                                        if (control.Dock != DockStyle.Left && control.Dock != DockStyle.Right)
                                        {
                                            // Элемент высоты.
                                            XmlNode controlHeight = controlNode["Height"];
                                            if (controlHeight != null)
                                            {
                                                if (int.TryParse(controlHeight.InnerText, out value))
                                                {
                                                    // Загружаем высоту.
                                                    control.Height = value;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Сохранение конфиг-файл размеров контролов.
        /// </summary>
        /// <param name="controls">Массив контролов для сохранения размеров.</param>
        internal static void SaveControlsSize(params Control[] controls)
        {
            // Массив контролов не нулевой и в нем есть хоть один элемент.
            if (controls != null && controls.Length > 0)
            {
                // Форма, содержащая эти контролы.
                Form form = controls[0].FindForm();
                // Форма и ее имя не нулевые.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[programRootNodeName];
                    if (root == null)
                    {
                        // Создать корневой элемент.
                        root = programParams.CreateElement(programRootNodeName);
                        programParams.AppendChild(root);
                    }
                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создать его, если его нет.
                        formNode = programParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }
                    // По всему массиву.
                    for (int i = 0; i < controls.Length; i++)
                    {
                        Control control = controls[i];
                        // Имя контрола не нулевое.
                        if (!string.IsNullOrEmpty(control.Name) && control.Dock != DockStyle.Fill)
                        {
                            // Элемент контрола.
                            XmlNode controlNode = formNode[control.Name];
                            if (controlNode == null)
                            {
                                // Создать его, если его нет.
                                controlNode = programParams.CreateElement(control.Name);
                                formNode.AppendChild(controlNode);
                            }


                            // Элемент ширины.
                            XmlNode controlWidth = controlNode["Width"];
                            if (controlWidth == null)
                            {
                                // Создать его, если его нет.
                                controlWidth = programParams.CreateElement("Width");
                                controlNode.AppendChild(controlWidth);
                            }

                            if (control.Dock != DockStyle.Bottom && control.Dock != DockStyle.Top)
                            {
                                // Сохраняем ширину.
                                controlWidth.InnerText = control.Width.ToString();
                            }
                            else
                            {
                                controlNode.RemoveChild(controlWidth);
                            }


                            // Элемент высоты.
                            XmlNode controlHeight = controlNode["Height"];
                            if (controlHeight == null)
                            {
                                // Создать его, если его нет.
                                controlHeight = programParams.CreateElement("Height");
                                controlNode.AppendChild(controlHeight);
                            }

                            if (control.Dock != DockStyle.Left && control.Dock != DockStyle.Right)
                            {
                                // Сохраняем высоту.
                                controlHeight.InnerText = control.Height.ToString();
                            }
                            else
                            {
                                controlNode.RemoveChild(controlHeight);
                            }
                        }
                    }
                }
            }
        }

        #endregion Размеры контролов.

        #region Отображаемость контролов.

        /// <summary>
        /// Загрузка свойства отображения набора контролов из конфиг-файла.
        /// </summary>
        /// <param name="controls">Массив контролов, для которых считывается отображаемость.</param>
        internal static void LoadControlsVisible(params Control[] controls)
        {
            // Массив не нуль, и в нем хоть один элемент.
            if (controls != null && controls.Length > 0)
            {
                // Форма, содержащая эти контролы.
                Form form = controls[0].FindForm();
                // Форма и ее имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[programRootNodeName];
                    if (root != null)
                    {
                        // Элемент формы.
                        XmlNode formNode = root[form.Name];
                        if (formNode != null)
                        {
                            // По всему массиву.
                            for (int i = 0; i < controls.Length; i++)
                            {
                                Control control = controls[i];
                                // Имя контрола не нуль.
                                if (!string.IsNullOrEmpty(control.Name))
                                {
                                    // Элемент контрола.
                                    XmlNode controlNode = formNode[control.Name];
                                    if (controlNode != null)
                                    {
                                        // Элемент отображаемости.
                                        XmlNode controlVisible = controlNode["Visible"];
                                        if (controlVisible != null)
                                        {
                                            // Устанавливаем отображаемость.
                                            control.Visible = controlVisible.InnerText == "1";
                                            if (control.Parent != null)
                                            {
                                                // Заставляем родителя переформировать отступы.
                                                control.Parent.PerformLayout();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Сохранение в конфиг-файл свойства отображения набора контролов.
        /// </summary>
        /// <param name="controls">Контролы, отображаемость которых надо сохранять.</param>
        internal static void SaveControlsVisible(params Control[] controls)
        {
            // Массив не нуль, и в нем хоть один элемент.
            if (controls != null && controls.Length > 0)
            {
                // Форма, содержащая данный контрол.
                Form form = controls[0].FindForm();
                // Форма и ее имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[programRootNodeName];
                    if (root == null)
                    {
                        // Создаем корневой элемент.
                        root = programParams.CreateElement(programRootNodeName);
                        programParams.AppendChild(root);
                    }
                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создаем его, если его нет.
                        formNode = programParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }
                    // По всему массиву.
                    for (int i = 0; i < controls.Length; i++)
                    {
                        Control control = controls[i];
                        // Имя контрола не нуль.
                        if (!string.IsNullOrEmpty(control.Name))
                        {
                            // Элемент контрола.
                            XmlNode controlNode = formNode[control.Name];
                            if (controlNode == null)
                            {
                                // Создаем его, если его нет.
                                controlNode = programParams.CreateElement(control.Name);
                                formNode.AppendChild(controlNode);
                            }
                            // Элемент отображаемости.
                            XmlNode controlVisible = controlNode["Visible"];
                            if (controlVisible == null)
                            {
                                // Создаем его, если его нет.
                                controlVisible = programParams.CreateElement("Visible");
                                controlNode.AppendChild(controlVisible);
                            }
                            // Сохраняем отображаемость.
                            controlVisible.InnerText = control.Visible ? "1" : "0";
                        }
                    }
                }
            }
        }

        #endregion Отображаемость контролов.

        #endregion Контролы.

        #region Сохранение фильтров таблиц.

        /// <summary>
        /// Загрузить сохраненные фильтры из конфиг-файла.
        /// </summary>
        /// <param name="gridFilterControl">Фильтр-контрол, для которого считывать значения фильтров.</param>
        internal static void LoadGridFilter(GridFiltersControl gridFilterControl)
        {
            // Фильтр-контрол и его имя не нулевые, также он должен быть подсоединен к таблице.
            if (gridFilterControl != null && !string.IsNullOrEmpty(gridFilterControl.Name) && gridFilterControl.DataGridView != null)
            {
                // Форма, содержащая данный фильр.
                Form form = gridFilterControl.FindForm();
                // Форма и его имя не нулевые.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[programRootNodeName];
                    if (root != null)
                    {
                        // Элемент формы.
                        XmlNode formNode = root[form.Name];
                        if (formNode != null)
                        {
                            // Элемент Фильтр-контрол.
                            XmlNode gridFilterControlwNode = formNode[gridFilterControl.Name];
                            if (gridFilterControlwNode != null)
                            {
                                // Таблица, к которой присоединен фильтр-контрол.
                                DataGridView dataGridView = gridFilterControl.DataGridView;
                                // Коллекция фильтров.
                                GridFilterCollection gridFilterCollection = gridFilterControl.GetGridFilters();

                                // Сохраненные значения.
                                Hashtable savedFilters = new Hashtable();
                                // По всем столбцам таблицы.
                                for (int i = 0; i < dataGridView.ColumnCount; i++)
                                {
                                    DataGridViewColumn item = dataGridView.Columns[i];
                                    // Имя столбца ненулевое и не системное.
                                    if (!string.IsNullOrEmpty(item.Name) && !item.Name.ToLower().Contains("syscol"))
                                    {
                                        // Элемент столбца.
                                        XmlNode columnNode = gridFilterControlwNode[item.Name];
                                        if (columnNode != null)
                                        {
                                            // Записать в сохраненные значения.
                                            savedFilters.Add(item.Name, columnNode.InnerText);
                                            // Если фильтр данного столбца по дате.
                                            DateGridFilter gridFilter = gridFilterCollection[item] as DateGridFilter;
                                            if (gridFilter != null)
                                            {
                                                // Атрибут старой ширины.
                                                XmlAttribute lastWidthAttribute = columnNode.Attributes["LastWidth"];
                                                if (lastWidthAttribute != null)
                                                {
                                                    int value = 0;
                                                    if (int.TryParse(lastWidthAttribute.Value, out value))
                                                    {
                                                        // Устанавливаем старое значение фильтру.
                                                        gridFilter.LastWidth = value;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                // Загружаем в фильтр-контрол значения фильтров.
                                gridFilterControl.SetFilters(savedFilters);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Сохранить в конфиг-файл значения фильтров.
        /// </summary>
        /// <param name="gridFilterControl">Фильтр-контрол, с которого сохраняются значения фильтров.</param>
        internal static void SaveGridFilter(GridFiltersControl gridFilterControl)
        {
            // Фильтр-контрол и его имя не нулевое.
            if (gridFilterControl != null && !string.IsNullOrEmpty(gridFilterControl.Name))
            {
                // Форма, которой принадлежит фильтр-контрол.
                Form form = gridFilterControl.FindForm();

                // Сохраненные значения фильтров.
                Hashtable filterValues = gridFilterControl.GetFilters();
                // Форма и ее имя не нуль, есть сохраненные значения
                if (form != null && !string.IsNullOrEmpty(form.Name) && filterValues.Count > 0)
                {
                    // Элемент корневого элемента.
                    XmlNode root = programParams[programRootNodeName];
                    if (root == null)
                    {
                        // Создаем корневой элемент.
                        root = programParams.CreateElement(programRootNodeName);
                        programParams.AppendChild(root);
                    }
                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создаем его, если его нет.
                        formNode = programParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }
                    // Элемент фильтр-контрола.
                    XmlNode gridFilterControlNode = formNode[gridFilterControl.Name];
                    if (gridFilterControlNode == null)
                    {
                        // Создаем его, если его нет.
                        gridFilterControlNode = programParams.CreateElement(gridFilterControl.Name);
                        formNode.AppendChild(gridFilterControlNode);
                    }

                    // Получаем коллекцию фильтров.
                    GridFilterCollection gridFilterCollection = gridFilterControl.GetGridFilters();
                    // По всем элементам в сохраненных значениям.
                    foreach (DictionaryEntry de in filterValues)
                    {
                        // Имя столбца.
                        string columnName = de.Key.ToString();
                        // Имя столбца не нулевое и не системное.
                        if (!string.IsNullOrEmpty(columnName) && !columnName.ToLower().Contains("syscol"))
                        {
                            // Элемент столбца.
                            XmlNode columnNode = gridFilterControlNode[columnName];
                            if (columnNode == null)
                            {
                                // Создаем его, если его нет.
                                columnNode = programParams.CreateElement(columnName);
                                gridFilterControlNode.AppendChild(columnNode);
                            }
                            // Сохраняем значение фильтра.
                            columnNode.InnerText = de.Value.ToString();

                            // Если фильтр по дате.
                            DateGridFilter gridFilter = gridFilterCollection.GetByName(columnName) as DateGridFilter;
                            if (gridFilter != null)
                            {
                                // Аттрибут старая ширина.
                                XmlAttribute lastWidthAttribute = columnNode.Attributes["LastWidth"];
                                if (lastWidthAttribute == null)
                                {
                                    // Создаем его, если его нет.
                                    lastWidthAttribute = programParams.CreateAttribute("LastWidth");
                                    columnNode.Attributes.Append(lastWidthAttribute);
                                }
                                // Сохраняем старую ширину.
                                lastWidthAttribute.Value = gridFilter.LastWidth.ToString();
                            }
                        }
                    }
                }
            }
        }

        #endregion Сохранение фильтров таблиц.

        #region Список выбранных элементов в списке.

        internal static void LoadListCheckedItems(CheckedListBox listBox, string listName)
        {
            if (!string.IsNullOrEmpty(listBox.Name))
            {
                // Форма, содержащая данные контролы (считывается с первого контрола).
                Form form = listBox.FindForm();
                // Форма и ее имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфигурации программы.
                    XmlNode root = programParams[programRootNodeName];
                    if (root != null)
                    {
                        // Элемент формы.
                        XmlNode formNode = root[form.Name];
                        if (formNode != null)
                        {
                            // Элемент контрола.
                            XmlNode controlNode = formNode[listBox.Name];
                            if (controlNode != null)
                            {
                                XmlNode checkedLists = controlNode["CheckedLists"];
                                if (checkedLists != null)
                                {
                                    XmlNode interestList = null;

                                    foreach (XmlNode itemList in checkedLists.ChildNodes)
                                    {
                                        XmlAttribute attr = itemList.Attributes["ListName"];
                                        if (attr != null && !string.IsNullOrEmpty(attr.Value))
                                        {
                                            if (attr.Value == listName)
                                            {
                                                interestList = itemList;
                                                break;
                                            }
                                        }
                                    }

                                    if (interestList != null)
                                    {
                                        foreach (XmlNode checkedItem in interestList.ChildNodes)
                                        {
                                            for (int i = 0; i < listBox.Items.Count; i++)
                                            {
                                                object listItem = listBox.Items[i];
                                                if (listItem.ToString() == checkedItem.InnerText)
                                                {
                                                    listBox.SetItemChecked(i, true);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static void SaveListCheckedItems(CheckedListBox listBox, string listName)
        {
            // Если имя параметра, контрол и его имя не нулевые.
            if (listBox != null && !string.IsNullOrEmpty(listBox.Name))
            {
                // Форма, содержащая данную форму.
                Form form = listBox.FindForm();
                // Форма и его имя не нуль.
                if (form != null && !string.IsNullOrEmpty(form.Name))
                {
                    // Корневой элемент конфиг-файла.
                    XmlNode root = programParams[programRootNodeName];
                    if (root == null)
                    {
                        // Создаем корневой элемент, если его нет.
                        root = programParams.CreateElement(programRootNodeName);
                        programParams.AppendChild(root);
                    }

                    // Элемент формы.
                    XmlNode formNode = root[form.Name];
                    if (formNode == null)
                    {
                        // Создаем его, если его нет.
                        formNode = programParams.CreateElement(form.Name);
                        root.AppendChild(formNode);
                    }

                    // Элемент контрола.
                    XmlNode listNode = formNode[listBox.Name];
                    if (listNode == null)
                    {
                        // Создаем его, если его нет.
                        listNode = programParams.CreateElement(listBox.Name);
                        formNode.AppendChild(listNode);
                    }

                    // Элемент Списка выбранных элементов.
                    XmlNode checkedListsNode = listNode["CheckedLists"];
                    if (checkedListsNode == null)
                    {
                        // Создаем его, если его нет.
                        checkedListsNode = programParams.CreateElement("CheckedLists");
                        listNode.AppendChild(checkedListsNode);
                    }

                    XmlNode interestList = null;

                    foreach (XmlNode itemList in checkedListsNode.ChildNodes)
                    {
                        XmlAttribute attr = itemList.Attributes["ListName"];
                        if (attr != null && !string.IsNullOrEmpty(attr.Value))
                        {
                            if (attr.Value == listName)
                            {
                                interestList = itemList;
                                break;
                            }
                        }
                    }

                    if (interestList == null)
                    {
                        interestList = programParams.CreateElement("ListWithCheckedItems");
                        checkedListsNode.AppendChild(interestList);

                        XmlAttribute attr = programParams.CreateAttribute("ListName");
                        attr.Value = listName;
                        interestList.Attributes.Append(attr);
                    }

                    interestList.InnerText = string.Empty;
                    foreach (object item in listBox.CheckedItems)
                    {
                        XmlNode controlParamValue = programParams.CreateElement("Item");
                        interestList.AppendChild(controlParamValue);

                        controlParamValue.InnerText = item.ToString();
                    }
                }
            }
        }

        #endregion Список выбранных элементов в списке.

        #endregion Методы для работы интерфейсом форм.

        #region Контекстное меню для скрывания столбцов таблицы.

        /// <summary>
        /// Загрузка из реестра порядковго номера столбцов и свойства Visible.
        /// </summary>
        public static void AttachContextMenu(DataGridView dataGridView)
        {
            ContextMenuStrip dataGridViewHeaderContextMenu = new ContextMenuStrip();

            dataGridViewHeaderContextMenu.Name = dataGridView.Name + "ContextMenu";
            dataGridViewHeaderContextMenu.Opening += new System.ComponentModel.CancelEventHandler(dataGridViewHeaderContextMenu_Opening);

            // По всем столбцам.
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                DataGridViewColumn col = dataGridView.Columns[i];

                // Системные столбцы игнорируем.
                if (!col.Name.ToLower().Contains("syscol"))
                {
                    // Элемент в контекстное меню
                    ToolStripMenuItem columnVisibilityMI = new ToolStripMenuItem();
                    columnVisibilityMI.Text = col.HeaderText;
                    columnVisibilityMI.ToolTipText = col.ToolTipText;
                    columnVisibilityMI.Tag = col;
                    columnVisibilityMI.CheckOnClick = true;
                    columnVisibilityMI.Checked = col.Visible;
                    columnVisibilityMI.Click += new EventHandler(columnVisibilityMI_Click);

                    dataGridViewHeaderContextMenu.Items.Add(columnVisibilityMI);

                    col.HeaderCell.ContextMenuStrip = dataGridViewHeaderContextMenu;
                }
            }
        }

        /// <summary>
        /// Обработчик клика на элементе контекстного меню. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void columnVisibilityMI_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            if (mi != null && mi.Tag != null && mi.Tag is DataGridViewColumn)
            {
                ((DataGridViewColumn)mi.Tag).Visible = mi.Checked;
            }
        }

        /// <summary>
        /// Сортировка элементов контекстного меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void dataGridViewHeaderContextMenu_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip dataGridViewHeaderContextMenu = sender as ContextMenuStrip;

            SortedList list = new SortedList();

            foreach (ToolStripMenuItem item in dataGridViewHeaderContextMenu.Items)
            {
                list.Add(((DataGridViewColumn)item.Tag).DisplayIndex, item);
            }

            dataGridViewHeaderContextMenu.Items.Clear();

            foreach (int key in list.Keys)
            {
                dataGridViewHeaderContextMenu.Items.Add((ToolStripMenuItem)list[key]);
            }
        }

        #endregion Контекстное меню для скрывания столбцов таблицы.
    }
}
