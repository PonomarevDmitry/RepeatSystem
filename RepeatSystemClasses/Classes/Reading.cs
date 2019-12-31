using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Чтение книги
    /// </summary>
    public class Reading
    {
        #region Свойства.

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Книга
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// Номер пересказа
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Первая страница
        /// </summary>
        public int? FirstPage { get; set; }

        /// <summary>
        /// Последняя страница
        /// </summary>
        public int? LastPage { get; set; }

        /// <summary>
        /// Пересказ
        /// </summary>
        public string Retelling { get; set; }

        /// <summary>
        /// Заключение
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Подсказка
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }

        #endregion Свойства.

        public Reading()
        {
            this.Name = string.Empty;
            this.Retelling = string.Empty;
            this.Summary = string.Empty;
            this.Hint = string.Empty;
            this.Note = string.Empty;
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            if (this.Book != null)
            {
                strBuilder.Append(this.Book.ToString());

                strBuilder.AppendFormat(" {0} - {1}.", this.FirstPage.ToString(), this.LastPage.ToString());
            }

            if (strBuilder.Length > 0)
            {
                return strBuilder.ToString();
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
