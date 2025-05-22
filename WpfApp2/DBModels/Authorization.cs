using System;
using System.Collections.Generic;

namespace WpfApp2.DBModels
{
    public partial class Authorization
    {
        public long Id { get; set; }

        public string Login { get; set; } = null;

        public string PasswordHash { get; set; } = null;

        public string PasswordSalt { get; set; }

        public string Role { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<PersonAuthorization> PersonAuthorizations { get; set; } = new List<PersonAuthorization>();
    }
}
