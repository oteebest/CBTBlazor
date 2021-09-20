using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Models.Response
{
   
    public class ResponseModelBase
    {        
       
        public bool isSuccessful { get; set; }
        public string message { get; set; }
    }

   
}
