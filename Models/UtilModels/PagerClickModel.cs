using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Models.UtilModels
{
    public class PagerClickModel
    {
        public int PageNumber { get; set; }

        public bool ChangePager { get; set; }
    }
}
