using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTaskForJuniorASF.Models
{
    public class TranslationRequestVM
    {
        public TranslationRequestModel TranslationModel { get; set; }
        public IEnumerable<SelectListItem> AvaiableLanguages { get; set; }
    }
}
