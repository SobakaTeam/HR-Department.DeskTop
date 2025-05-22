using System;
using System.Collections.Generic;

namespace WpfApp2.DBModels
{
    public partial class Salary
    {
        public long Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<PersonSalary> PersonSalaries { get; set; } = new List<PersonSalary>();
    }
}
