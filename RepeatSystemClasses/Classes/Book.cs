using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Книга
    /// </summary>
    public class Book
    {
        #region Свойства.

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Издание
        /// </summary>
        public int Edition { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Издательство
        /// </summary>
        public Publisher Publisher { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public int? PublicationYear { get; set; }

        /// <summary>
        /// ISBN
        /// </summary>
        public string ISBN { get; set; }




        /// <summary>
        /// Название оригинала
        /// </summary>
        public string NameOriginal { get; set; }

        /// <summary>
        /// Издательство оригинала
        /// </summary>
        public Publisher PublisherOriginal { get; set; }

        /// <summary>
        /// Год издания оригинала
        /// </summary>
        public int? PublicationYearOriginal { get; set; }

        /// <summary>
        /// ISBN оригинала
        /// </summary>
        public string ISBNOriginal { get; set; }




        /// <summary>
        /// Рецензия
        /// </summary>
        public string Review { get; set; }

        /// <summary>
        /// Мнение
        /// </summary>
        public string Estimation { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }

        #endregion Свойства.

        public Book()
        {
            this.Name = string.Empty;
            this.NameOriginal = string.Empty;

            this.ISBN = string.Empty;
            this.ISBNOriginal = string.Empty;

            this.Review = string.Empty;
            this.Estimation = string.Empty;
            this.Note = string.Empty;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
