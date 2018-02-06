using System;

namespace PFML.Shared.ViewModels.Core.Headers.Person
{

    [Serializable]
    public class ResultRecord
    {

        public int Id { get; set; }

        public string Ssn { get; set; }

        public string Name { get; set; }

        public int AgencyNum { get; set; }

        public string PlanCode { get; set; }

        public DateTime? LastCheckDate { get; set; }

        public bool IsRetired { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string GenderCode { get; set; }

    }

}
