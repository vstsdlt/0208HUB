using System;

namespace PFML.Shared.ViewModels.Core.Headers.Person
{

    [Serializable]
    public class Record
    {

        public int ID { get; set; }

        public string Ssn { get; set; }

        public string Name { get; set; }

        public string FormattedAddressLine1 { get; set; }

        public string FormattedAddressLine2 { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public string GenderCode { get; set; }

    }

}
