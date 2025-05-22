using System;
using System.Collections.Generic;

namespace WpfApp2.DBModels
{
    public partial class Child
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MidleName { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<PersonChild> PersonChildren { get; set; } = new List<PersonChild>();
    }
}
