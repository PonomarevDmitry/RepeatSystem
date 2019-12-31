using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Тип факта
    /// </summary>
    public class FactType
    {
        //Fact = 1 Факт
        //Puzzle = 2 Головоломка

        public int Id { get; internal set; }

        public string Name { get; internal set; }

        public FactType()
        {
            this.Name = string.Empty;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override int GetHashCode() { return base.GetHashCode(); }

        public override bool Equals(object obj)
        {
            return obj != null && obj is FactType && (obj as FactType).Id == this.Id;
        }
    }
}
