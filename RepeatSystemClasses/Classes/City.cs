using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Город
    /// </summary>
    public class City
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        public City()
        {
            this.Name = string.Empty;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
