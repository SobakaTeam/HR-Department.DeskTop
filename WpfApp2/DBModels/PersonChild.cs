using System;
using System.Collections.Generic;

namespace WpfApp2.DBModels
{
    public partial class PersonChild
    {
        public long Id { get; set; }

        public long PersonId { get; set; }

        public long ChildId { get; set; }

        public virtual Child Child { get; set; } = null ;

        public virtual Person Person { get; set; } = null;

        public string Comment { get; set; } // Для связи с таблицей PersonChild
    }
}
