using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    public class Listening
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
        /// Аудиокнига
        /// </summary>
        public AudioBook AudioBook { get; set; }

        /// <summary>
        /// Номер части
        /// </summary>
        public int? PartNumber { get; set; }

        /// <summary>
        /// Первая страница
        /// </summary>
        public DateTime TimeBegin { get; set; }

        /// <summary>
        /// Последняя страница
        /// </summary>
        public DateTime TimeEnd { get; set; }

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

        public Listening()
        {
            this.Retelling = string.Empty;
            this.Summary = string.Empty;
            this.Hint = string.Empty;
        }

        #endregion Свойства.

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            if (this.AudioBook != null)
            {
                strBuilder.Append(this.AudioBook.ToString());

                strBuilder.AppendFormat(" {0} - {1}.", this.TimeBegin.ToString(), this.TimeEnd.ToString());
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

        public override int GetHashCode() { return base.GetHashCode(); }
    }
}
