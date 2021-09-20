using CBTBlazor.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Models.Response
{
    public class QuestionModel : QuestionRequestModel
    {
        public string Id { get; set; }
        public string DifficultyLevel { get; set; }
        public string Subject { get; set; }
    }

}
