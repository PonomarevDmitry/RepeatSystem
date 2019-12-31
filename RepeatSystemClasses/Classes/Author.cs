using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Автор книги
    /// </summary>
    public class Author
    {
        #region Свойства.

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Фамилия английская
        /// </summary>
        public string SurnameEnglish { get; set; }

        /// <summary>
        /// Имя английское
        /// </summary>
        public string FirstNameEnglish { get; set; }

        /// <summary>
        /// Отчество английское
        /// </summary>
        public string SecondNameEnglish { get; set; }

        #endregion Свойства.

        public Author()
        {
            this.Surname = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;

            this.SurnameEnglish = string.Empty;
            this.FirstNameEnglish = string.Empty;
            this.SecondNameEnglish = string.Empty;
        }

        public override string ToString()
        {
            StringBuilder fullName = new StringBuilder();

            fullName.Append(this.Surname);

            if (!string.IsNullOrEmpty(this.FirstName))
            {
                fullName.AppendFormat(" {0}", this.FirstName);
            }

            if (!string.IsNullOrEmpty(this.SecondName))
            {
                fullName.AppendFormat(" {0}", this.SecondName);
            }

            StringBuilder fullNameEnglish = new StringBuilder();

            fullNameEnglish.Append(this.SurnameEnglish);

            if (!string.IsNullOrEmpty(this.FirstNameEnglish))
            {
                fullNameEnglish.AppendFormat(" {0}", this.FirstNameEnglish);
            }

            if (!string.IsNullOrEmpty(this.SecondNameEnglish))
            {
                fullNameEnglish.AppendFormat(" {0}", this.SecondNameEnglish);
            }



            StringBuilder result = new StringBuilder();

            if (fullNameEnglish.Length > 0)
            {
                result.Append(fullNameEnglish.ToString());
            }

            if (fullName.Length > 0)
            {
                if (result.Length > 0)
                {
                    result.Append(" - ");
                }

                result.Append(fullName.ToString());
            }

            return result.ToString();
        }
    }
}
