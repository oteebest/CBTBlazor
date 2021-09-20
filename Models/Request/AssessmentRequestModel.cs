using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Models.Request
{
    public class AssessmentRequestModel
    {
        [Required(ErrorMessage = "Enter assessment name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter assessment instructions")]
        public string Instructions { get; set; }

        [Required(ErrorMessage = "Enter duration in minutes")]
        [Range(0,5000,ErrorMessage = "Duration is invalid. Assessment should be above 1 mins")]
        public int? Duration { get; set; }
    }
}
