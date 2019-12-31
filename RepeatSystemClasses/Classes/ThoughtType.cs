using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepeatSystem.Classes
{
    /// <summary>
    /// Тип размышления
    /// </summary>
    public class ThoughtType
    {
        public int Id { get; internal set; }

        public string Name { get; internal set; }

        public ThoughtType()
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
            return obj != null && obj is ThoughtType && (obj as ThoughtType).Id == this.Id;
        }
    }
}
