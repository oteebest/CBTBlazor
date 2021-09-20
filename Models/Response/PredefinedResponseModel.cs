using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace CBTBlazor.Models.Response
{

    public class PredefinedDataResponseModel : ResponseModelBase
    {
        public PredefinedResponseModel data { get; set; }
    }

    public class PredefinedResponseModel
    {
        public List<SubjectResponseModel> subjects { get; set; } = Enumerable.Empty<SubjectResponseModel>().ToList();

        public List<DifficultLevelResponseModel> difficultyLevels { get; set; } = Enumerable.Empty<DifficultLevelResponseModel>().ToList();
    }


    public class SubjectResponseModel
    {
       
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class DifficultLevelResponseModel
    {
       
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
