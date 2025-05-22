
using System;
using System.Collections.Generic;

namespace WpfApp2.DBModels
{
    public partial class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MidleName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool? IsWorking { get; set; }

        public bool? IsMarried { get; set; }

        public string NowPlaceLiving { get; set; }

        public DateTime? HireDate { get; set; }

        public virtual ICollection<PersonAuthorization> PersonAuthorizations { get; set; } = new List<PersonAuthorization>();

        public virtual ICollection<PersonChild> PersonChildren { get; set; } = new List<PersonChild>();

        public virtual ICollection<PersonDepartment> PersonDepartments { get; set; } = new List<PersonDepartment>();

        public virtual ICollection<PersonPosition> PersonPositions { get; set; } = new List<PersonPosition>();

        public virtual ICollection<PersonSalary> PersonSalaries { get; set; } = new List<PersonSalary>();

        public virtual ICollection<PersonVacation> PersonVacations { get; set; } = new List<PersonVacation>();

    }
}
