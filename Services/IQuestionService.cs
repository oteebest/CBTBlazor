using CBTBlazor.Models.Request;
using CBTBlazor.Models.Response;
using CBTBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Services
{
    public interface IQuestionService
    {
        Task<ResponseModelBase> CreateQuestion(QuestionRequestModel model);

        Task<ResponseModelBase> UpdateQuestion(string Id, QuestionRequestModel model);

        Task<QuestionResponseModel> GetQuestion(string Id);

        Task<QuestionListResponseModel> GetQuestions(int pageSize = 10, int pageNumber = 1,string subjectId = "", string difficultyLevelId = "");
    }
}
