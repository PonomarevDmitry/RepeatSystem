using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RepeatSystem.Classes
{
    public class MediaCourse
    {
        #region Свойства.

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Тип курса
        /// </summary>
        public CourseType CourseType { get; set; }

        private Collection<Author> authors = new Collection<Author>();
        /// <summary>
        /// Авторы книги
        /// </summary>
        public Collection<Author> Authors { get { return this.authors; } }

        /// <summary>
        /// Издательство
        /// </summary>
        public Publisher Publisher { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public int PublicationDate { get; set; }

        private Collection<Tag> tags = new Collection<Tag>();
        /// <summary>
        /// Жанры
        /// </summary>
        public Collection<Tag> Tags { get { return this.tags; } }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Издание
        /// </summary>
        public int Edition { get; set; }

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

        public MediaCourse()
        {
            this.Name = string.Empty;
            this.Review = string.Empty;
            this.Estimation = string.Empty;
            this.Note = string.Empty;
        }

        #endregion Свойства.

        public override string ToString()
        {
            return this.Name;
        }
    }
}
