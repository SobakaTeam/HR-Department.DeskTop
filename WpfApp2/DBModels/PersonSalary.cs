using System;
using System.Collections.Generic;
using WpfApp2.DBModels.Types;

namespace WpfApp2.DBModels
{
    public partial class PersonSalary 
    {
        public long Id { get; set; }

        public long PersonId { get; set; }

        public long SalaryId { get; set; }

        public virtual Person Person { get; set; } = null;

        public virtual Salary Salary { get; set; } = null;

        // Удобные свойства для отображения
        public decimal Amount => Salary != null ? Salary.Amount : 0;
        public DateTime Date => Salary != null ? Salary.BeginDate : DateTime.MinValue;
        public string Comment => Salary != null ? $"Оклад с {Salary.BeginDate:dd.MM.yyyy}" : string.Empty;
    }
}
