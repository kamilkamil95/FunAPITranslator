using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTaskForJuniorASF.Models
{
    public class LanguageModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Language { get; set; }
    }
}
