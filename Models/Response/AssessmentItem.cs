using CBTBlazor.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Models.Response
{
   
    public class AssessmentItem: AssessmentRequestModel
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

    }
}
