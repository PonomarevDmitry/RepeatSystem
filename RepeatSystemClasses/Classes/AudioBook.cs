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
    public class AudioBook
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }

        private Collection<Author> actors = new Collection<Author>();
        /// <summary>
        /// Актеры-читающие
        /// </summary>
        public Collection<Author> Actors { get { return this.actors; } }

        /// <summary>
        /// Издательство
        /// </summary>
        public Publisher Publisher { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public int PublicationYear { get; set; }

        /// <summary>
        /// Книга
        /// </summary>
        public Book Book { get; set; }

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

        public AudioBook()
        {
            this.Review = string.Empty;
            this.Estimation = string.Empty;
            this.Note = string.Empty;
        }

        public override string ToString()
        {
            if (this.Book != null)
            {
                return this.Book.ToString();
            }
            else
            {
                return base.ToString();
            }
        }

        public override int GetHashCode() { return base.GetHashCode(); }
    }
}
