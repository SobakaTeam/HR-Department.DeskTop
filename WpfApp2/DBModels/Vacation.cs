using System;
using System.Collections.Generic;

namespace WpfApp2.DBModels
{
    public partial class Vacation
    {
        public long Id { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string VacationType { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<PersonVacation> PersonVacations { get; set; } = new List<PersonVacation>();
    }
}
