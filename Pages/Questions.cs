using Blazored.Toast.Services;
using BootstrapPaging.Models;
using CBTBlazor.Component;
using CBTBlazor.Models.Response;
using CBTBlazor.Component;
using CBTBlazor.Services;
using CBTBlazor.Util;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Pages
{
    public partial class Questions
    {

        [Inject]
        private IQuestionService _questionService { get; set; }

        [Inject]
        private IDataService _dataService { get; set; }
      
        [Inject]
        IToastService toastService { get; set; }

        public string SubjectId { get; set; } = "";
        public string DifficultyId { get; set; } = "";

        public int TotalSize { get; set; }
       
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int CurrentIndex { get; set; }

        public int PagerEndIndex { get; set; }
        public int PagerStartIndex { get; set; }
        public bool PagerEnableNext { get; set; }
        public bool PagerEnablePrevious { get; set; }

        public bool UpdatePager { get; set; } = true;

        public bool UseFilter { get; set; }

        public PagingTemplate Pager { get; set; }

        public List<SubjectResponseModel> SubjectList = new List<SubjectResponseModel>();

        public List<DifficultLevelResponseModel> DifficultytList = new List<DifficultLevelResponseModel>();

        public QuestionListResponseModel ClientQuestionData { get; set; } = new QuestionListResponseModel { data = new QuestionDataResponse() };

        public QuestionListResponseModel QuestionData { get; set; } = new QuestionListResponseModel { data = new QuestionDataResponse() };

        public FormWrapper ModalForm { get; set; }

        public QuestionForm QuestionForm { get; set; }

        public ConfirmDialog ConfirmDialog { get; set; }

        private QuestionItem QuestionItem { get; set; } = new QuestionItem { ShuffleOptions = false };

        protected override async Task OnInitializedAsync()
        {
             var PreDefinedData = await _dataService.GetPredefinedData();

            SubjectList = PreDefinedData.data.subjects;

            DifficultytList = PreDefinedData.data.difficultyLevels;

            QuestionData = await _questionService.GetQuestions(10, 1);

            ClientQuestionData = JsonConvert.DeserializeObject<QuestionListResponseModel>( JsonConvert.SerializeObject(QuestionData) );

            
            UpdatePagerParams(ClientQuestionData.data.TotalSize, ClientQuestionData.data.PageSize,                
                 ClientQuestionData.data.PageNumber,5, true);

        }

        private void HandleClose()
        {
            ModalForm.HideModal();
            QuestionForm.ResetForm();
        }

        private void ShowModal()
        {
         
            ModalForm.ShowModal();
        }


        private async Task HandleSubmit(QuestionItem model)
        {
            ResponseModelBase response;

            if (string.IsNullOrEmpty(model.Id))
            {
                response = await _questionService.CreateQuestion(model);
            }
            else
            {
                response = await _questionService.UpdateQuestion(model.Id, model);
            }

            if (response.isSuccessful)
            {
                ModalForm.HideModal();

                await Filter();

                if (string.IsNullOrEmpty(model.Id))
                {
                    
                    toastService.ShowSuccess("Assessment added successfully");

                }
                else
                {
                    toastService.ShowSuccess("Assessment updated successfully");
                } 
            }
            else
            {
                toastService.ShowError(response.message);

            }

        }


        private async Task Filter()
        {           
            if(!string.IsNullOrEmpty(SubjectId) || !string.IsNullOrEmpty(DifficultyId))
            {
                UseFilter = true;
            }
            else
            {
                UseFilter = false;
            }
            QuestionData = await _questionService.GetQuestions(10, 1, SubjectId, DifficultyId);

            ClientQuestionData = JsonConvert.DeserializeObject<QuestionListResponseModel>(JsonConvert.SerializeObject(QuestionData));

            UpdatePagerParams(ClientQuestionData.data.TotalSize, ClientQuestionData.data.PageSize,
                 ClientQuestionData.data.PageNumber,5, true);           

            StateHasChanged();
        }

        private async Task Page(PageClickModel model)
        {

            UpdatePager = model.UpdatePager;

            if(UseFilter)
            {
                QuestionData = await _questionService.GetQuestions(10, model.PageNumber, SubjectId, DifficultyId);

            }
            else
            {
                QuestionData = await _questionService.GetQuestions(10, model.PageNumber);

            }

            ClientQuestionData = JsonConvert.DeserializeObject<QuestionListResponseModel>(JsonConvert.SerializeObject(QuestionData));

            UpdatePagerParams(ClientQuestionData.data.TotalSize, ClientQuestionData.data.PageSize,
                 ClientQuestionData.data.PageNumber,5, UpdatePager);            

            StateHasChanged();

        }

        private async Task ShowModal(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var question = await _questionService.GetQuestion(id);

                var questionItem = question.data.Map();

                QuestionItem = questionItem;
            }

            ModalForm.ShowModal();
        }

        private async Task DeleteItem(bool shouldDelete)
        {

            if (shouldDelete)
            {
              
                toastService.ShowSuccess("Question deleted successfully");

            }

        }


        private void UpdatePagerParams(int totalSize, int pageSize,int pageNumber,int maximuimPagerCountForDisplay,bool updatePager)
        {
            this.TotalSize = totalSize;

            this.PageSize = pageSize;

            this.PageNumber = pageNumber;

            var pagerModel = BootstrapPaging.Util.PagerUtil.GetPagerParams(TotalSize, PageSize, PageNumber, maximuimPagerCountForDisplay,updatePager,
                PagerStartIndex,PagerEndIndex,PagerEnableNext,PagerEnablePrevious);
              
                CurrentIndex = pagerModel.CurrentPagerIndex;
                PagerEnableNext = pagerModel.NextEnabled;
                PagerEndIndex = pagerModel.PagerEndIndex;
                PagerStartIndex = pagerModel.PagerStartIndex;
                PagerEnablePrevious = pagerModel.PreviousEnabled;
          

        }




    }
}
