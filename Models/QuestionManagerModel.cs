using CBTBlazor.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Models
{
    public class QuestionManagerModel
    {
        public string QuestionType { get; set; }

        public int? ScoreValue { get; set; }

        public string Text { get; set; }

        public bool? ShuffleOptions { get; set; }

        public List<QuestionManagerOptionsModel> Options { get; set; } = new List<QuestionManagerOptionsModel>();


        public string DifficultyLevelId { get; set; }

        public string SubjectId { get; set; }

        public Utility.QuestionState State { get; set; }

       
    }

    public class QuestionManagerOptionsModel
    {
        public string TemporaryId { get; set; }
        public bool IsAnswer { get; set; }
        public string Text { get; set; }

        public bool IsDefault { get; set; }
    }

    
}

   

