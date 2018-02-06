using PFML.Shared.Model.DbDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFML.Shared.ViewModels.Premium.Appeals.EmployerAppeal
{
    [Serializable]
    public class EmployerAppealViewModel
    {
        public EmployerAppealViewModel()
        {
            AddressLinkDto = new AddressLinkDto();
            AddressDto = new AddressDto();
            PremiumAppealDetailDto = new PremiumAppealDetailDto();
            PremiumAppealHeaderDto = new PremiumAppealHeaderDto();
            CorrespondenceDto = new CorrespondenceDto();
            ResourceTemplateDto = new ResourceTemplateDto();
            ReasonNoteDto = new NoteDto();
            ReasonNoteSetDto = new NoteSetDto();
            NonTimelyNoteDto = new NoteDto();
            NonTimelyNoteSetDto = new NoteSetDto();
        }

        public AddressLinkDto AddressLinkDto { get; set; }
        public AddressDto AddressDto { get; set; }
        public PremiumAppealDetailDto PremiumAppealDetailDto { get; set; }
        public PremiumAppealHeaderDto PremiumAppealHeaderDto { get; set; }
        public CorrespondenceDto CorrespondenceDto { get; set; }
        public ResourceTemplateDto ResourceTemplateDto { get; set; }
        public NoteDto ReasonNoteDto { get; set; }
        public NoteSetDto ReasonNoteSetDto { get; set; }
        public NoteDto NonTimelyNoteDto { get; set; }
        public NoteSetDto NonTimelyNoteSetDto { get; set; }

    }
}
