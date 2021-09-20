using CBTBlazor.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Component
{
    public class QuestionPagingBase : PagingTemplate
    {

        public int SubjectId { get; set; }

        public int DifficultyId { get; set; }


        [Parameter]
        public EventCallback<QuestionFilterOptionsModel> LoadQuestionCallBack { get; set; }

        public void OnClick()
        {
            QuestionFilterOptionsModel model = new QuestionFilterOptionsModel
            {
                 SubjectId = SubjectId, DifficultyId = DifficultyId
            };

            LoadQuestionCallBack.InvokeAsync(model);

        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
