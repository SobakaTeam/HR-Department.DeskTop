using System;

namespace WpfApp2.DBModels
{
    public class PersonDTO
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MidleName { get; set; }

        public  string Phone { get; set; }

        public string Email { get; set; }

        public DateTime ? Birthday { get; set; }

        public bool? IsWorking { get; set; }

        public bool? IsMarried { get; set; }

        public string NowPlaceLiving { get; set; }

        public DateTime? HireDate { get; set; }
    }
}
