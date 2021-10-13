
using CBTBlazor.Models.Response;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Component
{
    public partial class AssForm
    {
        [Parameter]
        public AssessmentItem model { get; set; } = new AssessmentItem();

        [Parameter]
        public EventCallback<AssessmentItem> OnSubmitCallBack { get; set; }
        
        [Parameter]
        public EventCallback OnCloseCallBack { get; set; }

        public FormWrapper modalForm { get; set; }

        public async Task HandleSubmit()
        {
           await OnSubmitCallBack.InvokeAsync(model);
        }

        private void HandleInvalidSubmit()
        {
            Console.WriteLine("There are invalid submit. Review your entries");
        }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        public void CloseModal()
        {
            OnCloseCallBack.InvokeAsync(null);
        }

        public void ResetForm()
        {
            model = new AssessmentItem();
            StateHasChanged();
        }

        public void LoadEditField(AssessmentItem item)
        {
            model = item;

            StateHasChanged();
        }

    }
}
