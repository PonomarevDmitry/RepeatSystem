using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Размышление
    /// </summary>
    public class Thought
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
        /// Тип размышления
        /// </summary>
        public ThoughtType ThoughtType { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Idea { get; set; }

        /// <summary>
        /// Пересказ
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }

        #endregion Свойства.

        public Thought()
        {
            this.Idea = string.Empty;
            this.Description = string.Empty;
            this.Note = string.Empty;
        }
    }
}
