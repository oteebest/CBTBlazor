using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBTBlazor.Util;
using Microsoft.AspNetCore.Components;
using CBTBlazor.Models;
using CBTBlazor.Models.Response;

namespace CBTBlazor.Component
{
    public partial class QuestionManager
    {


        public QuestionManagerModel QuestionManagerModel { get; set; } = new QuestionManagerModel();

        [Parameter]
        public QuestionItem Question { get; set; } = new QuestionItem();


        [Parameter]
        public List<SubjectResponseModel> SubjectList { get; set; } = new List<SubjectResponseModel>();

        [Parameter]
        public List<DifficultLevelResponseModel> DifficultytList { get; set; } = new List<DifficultLevelResponseModel>();

        [Parameter]
        public string QuestionType { get; set; }


        [Parameter]
        public EventCallback<QuestionManagerModel> OnSubmitCallBack { get; set; }

        private void SwitchMode(Utility.QuestionState mode)
        {
            QuestionManagerModel.State = mode;

            StateHasChanged();
        }

        private async Task HandleSubmit(QuestionManagerModel question)
        {
            await OnSubmitCallBack.InvokeAsync(question);
        }

        private void ToggleOptionAnswer(ChangeEventArgs e, string optionTemporaryId )
        {
            

            if(QuestionManagerModel.QuestionType == Utility.QuestionType.SingleChoice.ToString())
            {
                bool isAnswer = e.Value.ToString() == "on";

                QuestionManagerModel.Options.ForEach( u =>
                {
                    u.IsAnswer = false;
                });

                QuestionManagerModel.Options.First(u => u.TemporaryId == optionTemporaryId).IsAnswer = isAnswer;
            }
            else
            {
                bool isAnswer = Convert.ToBoolean(e.Value) == true;

                QuestionManagerModel.Options.First(u => u.TemporaryId == optionTemporaryId).IsAnswer = isAnswer;
            }

           
        }

        private void AddOption()
        {
            QuestionManagerModel.Options.Add(new QuestionManagerOptionsModel { IsDefault = true, TemporaryId = Guid.NewGuid().ToString(), Text = "" });
        }


  

        protected override Task OnInitializedAsync()
        {
            QuestionManagerModel = new QuestionManagerModel
            {
                QuestionType = QuestionType,
                State = Utility.QuestionState.Question,
                DifficultyLevelId = DifficultytList.Count() > 0 ? DifficultytList.First().Id : "",
                SubjectId = SubjectList.Count() > 0 ? SubjectList.First().Id : "",
                 Text = Question.Text,
                  ScoreValue = Question.ScoreValue,
                  
            };

            // set default options
            if (string.IsNullOrEmpty(Question.Id))
            {
                QuestionManagerModel.Options.AddRange(new List<QuestionManagerOptionsModel> {
                        new QuestionManagerOptionsModel {IsDefault = true, TemporaryId = Guid.NewGuid().ToString() , Text = ""  },
                        new QuestionManagerOptionsModel {IsDefault = true, TemporaryId = Guid.NewGuid().ToString() , Text = "" },
                        new QuestionManagerOptionsModel {IsDefault = true, TemporaryId = Guid.NewGuid().ToString() , Text = "" } });
            }
            else
            {
                QuestionManagerModel.Options = Question.Options.Select(u => new QuestionManagerOptionsModel { IsAnswer = u.IsAnswer.Value,
                 IsDefault = true, TemporaryId = Guid.NewGuid().ToString(), Text = u.Text
                }).ToList();
            }
            
            return base.OnInitializedAsync();
        }

        private void RemoveOption(string optionId)
        {
            QuestionManagerModel.Options = QuestionManagerModel.Options.Where(u => u.TemporaryId != optionId).ToList();
        }
    }
}
