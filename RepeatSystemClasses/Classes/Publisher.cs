using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Издательство
    /// </summary>
    public class Publisher
    {
        #region Свойства.

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Краткое название
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public City City { get; set; }

        #endregion Свойства.

        public Publisher()
        {
            this.Name = string.Empty;
            this.ShortName = string.Empty;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
