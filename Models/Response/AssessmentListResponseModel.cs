using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CBTBlazor.Models.Response
{  
    public class AssessmentListResponseModel : ResponseModelBase
    {
        public List<AssessmentItem> data { get; set; }        

    }

  
}
