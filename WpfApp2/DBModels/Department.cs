using System;
using System.Collections.Generic;

namespace WpfApp2.DBModels
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<DepartmentOrganization> DepartmentOrganizations { get; set; } = new List<DepartmentOrganization>();

        public virtual ICollection<PersonDepartment> PersonDepartments { get; set; } = new List<PersonDepartment>();
    }
}
