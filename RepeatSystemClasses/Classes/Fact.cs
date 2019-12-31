using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Факт
    /// </summary>
    public class Fact
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Тип факта
        /// </summary>
        public FactType FactType { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Вопрос
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Ответ
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Подсказка
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }

        public Fact()
        {
            this.Name = string.Empty;
            this.Question = string.Empty;
            this.Answer = string.Empty;
            this.Hint = string.Empty;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
