using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    public class BookTagComposition
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; internal set; }

        /// <summary>
        /// Книга
        /// </summary>
        public int? IdBook { get; set; }

        /// <summary>
        /// Тэг
        /// </summary>
        public int? IdTag { get; set; }

        public void ClearId()
        {
            this.Id = null;
        }
    }
}
