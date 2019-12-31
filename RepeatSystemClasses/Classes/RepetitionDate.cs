using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Повтор
    /// </summary>
    public class RepetitionDate
    {
        /// <summary>
        /// Номер повтора
        /// </summary>
        public RepetitionType RepetitionType { get; set; }

        /// <summary>
        /// Начало периода повтора
        /// </summary>
        public DateTime DateBegin { get; private set; }

        /// <summary>
        /// Конец периода повтора
        /// </summary>
        public DateTime DateEnd { get; private set; }

        public RepetitionDate(RepetitionType number, DateTime date, int period)
        {
            this.RepetitionType = number;

            this.DateBegin = date.Date.AddDays(-Math.Abs(period));
            this.DateEnd = date.Date.AddDays(Math.Abs(period));
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is RepetitionDate
                && (obj as RepetitionDate).RepetitionType == this.RepetitionType
                && (obj as RepetitionDate).DateBegin == this.DateBegin
                && (obj as RepetitionDate).DateEnd == this.DateEnd;
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.AppendFormat("{0}: {1}", this.RepetitionType.ToString(), this.DateBegin.ToShortDateString());

            if (this.DateBegin != this.DateEnd)
            {
                strBuilder.AppendFormat(" - {0}", this.DateEnd.ToShortDateString());
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// Все повторы за конкретную дату
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static Collection<RepetitionDate> GenerateMemoryDates(DateTime date)
        {
            Collection<RepetitionDate> memoryDates = new Collection<RepetitionDate>();

            {
                int diff = 2;

                memoryDates.Add(new RepetitionDate(RepetitionType.Yesterday, date.AddDays(-1), 0));
                memoryDates.Add(new RepetitionDate(RepetitionType.FourDay, date.AddDays(-4), diff));
                memoryDates.Add(new RepetitionDate(RepetitionType.Week, date.AddDays(-7), diff));
            }

            {
                int diff = 3;

                memoryDates.Add(new RepetitionDate(RepetitionType.Month, date.AddMonths(-1), diff));
                memoryDates.Add(new RepetitionDate(RepetitionType.Month3, date.AddMonths(-3), diff));
                memoryDates.Add(new RepetitionDate(RepetitionType.Month6, date.AddMonths(-6), diff));
            }

            {
                int diff = 7;
                memoryDates.Add(new RepetitionDate(RepetitionType.Year, date.AddYears(-1), diff));
            }

            return memoryDates;
        }
    }
}
