using CBTBlazor.Models.Request;
using CBTBlazor.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Models.Response
{
    public class QuestionItem : QuestionRequestModel
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Utility.QuestionState State { get;  set; }
    }

}
