using System;

namespace PFML.Shared.ViewModels.Core.Headers.Agency
{

    [Serializable]
    public class Record
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Status { get; set; }

    }

}
