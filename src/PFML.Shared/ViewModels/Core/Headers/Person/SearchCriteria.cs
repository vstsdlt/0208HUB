using System;

namespace PFML.Shared.ViewModels.Core.Headers.Person
{

    [Serializable]
    public class SearchCriteria
    {

        public string Ssn { get; set; }

        public string Name { get; set; }

        public string Agency { get; set; }

    }

}
