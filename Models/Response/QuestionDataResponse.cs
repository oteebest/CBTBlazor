using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Models.Response
{
    public class QuestionDataResponse
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalSize { get; set; }

        public List<QuestionModel> Items { get; set; } = new List<QuestionModel>();

    }
}
