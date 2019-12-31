using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    public class BookAuthorComposition
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
        /// Автор
        /// </summary>
        public int? IdAuthor { get; set; }

        public void ClearId()
        {
            this.Id = null;
        }
    }
}
