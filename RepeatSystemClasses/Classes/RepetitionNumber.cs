using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Номер повтора
    /// </summary>
    public class RepetitionType
    {
        /// <summary>
        /// Название повтора
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get; private set; }

        public RepetitionType(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }

        /// <summary>
        /// Повтор за прошлый день
        /// </summary>
        public static RepetitionType Yesterday
        {
            get
            {
                return new RepetitionType(1, "1 день");
            }
        }

        /// <summary>
        /// Повтор за 4 дня
        /// </summary>
        public static RepetitionType FourDay
        {
            get
            {
                return new RepetitionType(2, "4 дня");
            }
        }

        /// <summary>
        /// Повтор за неделю
        /// </summary>
        public static RepetitionType Week
        {
            get
            {
                return new RepetitionType(3, "Неделя");
            }
        }

        /// <summary>
        /// Повтор за месяц
        /// </summary>
        public static RepetitionType Month
        {
            get
            {
                return new RepetitionType(4, "Месяц");
            }
        }

        /// <summary>
        /// Повтор за 3 месяца
        /// </summary>
        public static RepetitionType Month3
        {
            get
            {
                return new RepetitionType(5, "3 месяца");
            }
        }

        /// <summary>
        /// Повтор за полгода
        /// </summary>
        public static RepetitionType Month6
        {
            get
            {
                return new RepetitionType(6, "Полгода");
            }
        }

        /// <summary>
        /// Повтор за год
        /// </summary>
        public static RepetitionType Year
        {
            get
            {
                return new RepetitionType(7, "Год");
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Number.ToString(), this.Name);
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            return obj != null && obj is RepetitionType
                && (obj as RepetitionType).Number == this.Number;
        }
    }
}
