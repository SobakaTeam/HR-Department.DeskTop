using System;
using System.Collections.Generic;

namespace WpfApp2.DBModels
{
    public partial class Position
    {
        public long Id { get; set; }

        public string Name { get; set; } = null;

        public string    Desctription { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<PersonPosition> PersonPositions { get; set; } = new List<PersonPosition>();
    }
}
