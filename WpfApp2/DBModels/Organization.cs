using System;
using System.Collections.Generic;

namespace WpfApp2.DBModels
{
    public partial class Organization
    {
        public long Id { get; set; }

        public string Name { get; set; } = null;

        public DateTime RegistrDate { get; set; }

        public string Adress { get; set; }

        public  DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<DepartmentOrganization> DepartmentOrganizations { get; set; } = new List<DepartmentOrganization>();
    }
}
