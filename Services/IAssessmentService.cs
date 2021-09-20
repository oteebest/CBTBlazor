using CBTBlazor.Models.Request;
using CBTBlazor.Models.Response;
using CBTBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Services
{
    public interface IAssessmentService
    {
        Task<AssessmentResponseModel> CreateAssessment(AssessmentRequestModel model);

        Task<AssessmentResponseModel> UpdateAssessment(string Id, AssessmentRequestModel model);

        Task<AssessmentListResponseModel> GetAssesments();

        Task<AssessmentResponseModel> GetAssesments(string id);

        Task DeleteAssesment(string id);

    }
}
