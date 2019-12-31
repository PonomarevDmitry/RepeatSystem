using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Человек
    /// </summary>
    public class Person
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
        /// День рождения
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// Место встречи
        /// </summary>
        public string MeetingPlace { get; set; }

        /// <summary>
        /// Дата встречи
        /// </summary>
        public DateTime? MeetingDate { get; set; }

        /// <summary>
        /// Файл с фотографией
        /// </summary>
        public string PhotoFileName { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }

        public Person()
        {
            this.Surname = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;

            this.MeetingPlace = string.Empty;

            this.PhotoFileName = string.Empty;
            this.Address = string.Empty;
            this.PhoneNumber = string.Empty;

            this.Description = string.Empty;
            this.Note = string.Empty;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (!string.IsNullOrEmpty(this.Surname))
            {
                result.Append(this.Surname);
            }

            if (!string.IsNullOrEmpty(this.FirstName))
            {
                if (result.Length > 0) { result.Append(" "); }

                result.Append(this.FirstName);
            }

            if (!string.IsNullOrEmpty(this.SecondName))
            {
                if (result.Length > 0) { result.Append(" "); }

                result.Append(this.SecondName);
            }

            return result.ToString();
        }
    }
}
