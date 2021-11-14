using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTaskForJuniorASF.Models
{
    public class TranslationRequestModel
    {
        [Key]
        public int Id { get; set; }       
        public string TextToTranslate { get; set; }
        [Display(Name = "Language")]
        public int LanguageModelId { get; set; }
        [ForeignKey("LanguageModelId")]
        public virtual LanguageModel LanguageModel { get; set; }
    }
}
