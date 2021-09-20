using Blazored.Toast.Services;
using CBTBlazor.Component;
using CBTBlazor.Models.Response;
using CBTBlazor.Services;
using CBTBlazor.Component;
using CBTBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.Pages
{
    public partial class Assess
    {
       
        private string SearchText = "";

        private AssessmentItem AssessmentItem { get; set; } = new AssessmentItem();
    
        public List<AssessmentItem> Assessments { get; set; } = new List<AssessmentItem>();

        public List<AssessmentItem> ClientAssessments { get; set; } = new List<AssessmentItem>();

        public FormWrapper ModalForm { get; set; }

        public AssForm AssessmentForm { get; set; }

        public ConfirmDialog ConfirmDialog { get; set; }

        public string DeleteAssessmentId { get; set; }


        [Inject]
        public IAssessmentService _assessmentService { get; set; }

        [Inject]
        IToastService toastService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            

            var response = await _assessmentService.GetAssesments();

            if (response.isSuccessful)
            {
                Assessments = response.data.OrderByDescending(u => u.CreatedOn).ToList();

                ClientAssessments = Assessments.ToList();

                
            }
            else
            {
                Console.Write(response.message);
            }
        }

        private void ShowModal()
        {
            AssessmentItem = new AssessmentItem();

            ModalForm.ShowModal();
        }

      

        private async Task HandleSubmit(AssessmentItem model)
        {
            AssessmentResponseModel response;

            if(string.IsNullOrEmpty(model.Id))
            {
                response =  await _assessmentService.CreateAssessment(model);
            }
            else
            {
                response = await _assessmentService.UpdateAssessment(model.Id, model);
            }

            if (response.isSuccessful)
            {
                var assessmentItem = response.data;

                if (string.IsNullOrEmpty(model.Id))
                {
                    Assessments = Assessments.Prepend(assessmentItem).ToList();

                    toastService.ShowSuccess("Assessment added successfully");

                }
                else
                {
                    var item = Assessments.First(u => u.Id == model.Id);

                    item.Duration = assessmentItem.Duration;
                    item.Instructions = assessmentItem.Instructions;
                    item.Name = assessmentItem.Name;


                    toastService.ShowSuccess("Assessment updated successfully");
                   


                }


                RefreshAssessments(SearchText);

                ModalForm.HideModal();

                StateHasChanged();

            }
            else
            {
                Console.WriteLine(response.message);
            }

        }

        private async Task OpenForEdit(string assessmentId)
        {
            var assessment = Assessments.First(u => u.Id == assessmentId);

            AssessmentItem = assessment;

            ModalForm.ShowModal();
           
        }

        private async Task DeleteItem(bool shouldDelete)
        {

            if(shouldDelete)
            {
                await _assessmentService.DeleteAssesment(DeleteAssessmentId);

                Assessments = Assessments.Where( u => u.Id != DeleteAssessmentId).ToList();

                RefreshAssessments(SearchText);

                DeleteAssessmentId = string.Empty;

                toastService.ShowSuccess("Assessment deleted successfully");

            }

        }


        private async Task ConfirmDelete(string assessmentId)
        {
            DeleteAssessmentId = assessmentId;

            ConfirmDialog.Show();            

        }

        private void HandleClose()
        {
            ModalForm.HideModal();
            AssessmentForm.ResetForm();
        }

        private void Search(ChangeEventArgs e)
        {
            SearchText = e.Value.ToString();

            RefreshAssessments(SearchText);

        }

        private void RefreshAssessments(string searchText)
        {            

            if (!string.IsNullOrEmpty(searchText))
            {
                ClientAssessments = Assessments.Where(u => u.Name.Contains(searchText,StringComparison.OrdinalIgnoreCase)).ToList();

                StateHasChanged();
            }
            else
            {
                ClientAssessments = Assessments.ToList();

                StateHasChanged();
            }
        }
    }
}
