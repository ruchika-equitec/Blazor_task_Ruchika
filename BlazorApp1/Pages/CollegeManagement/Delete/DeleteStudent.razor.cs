using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace BlazorApp1.Pages.CollegeManagement.Delete
{
    public partial class DeleteStudent
    {
        [Parameter]
        public int StudentId { get; set; }
        private List<StudViewResult>? students;
        public string studentSkills;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            students = await StudentService.StudViewAsync();

        }
        //public async Task SoftDeleteStudAsync(int stuid)
        //{
        //    try
        //    {
        //        await StudentService.SoftDeleteStudAsync(stuid);
        //        await JSRuntime.InvokeVoidAsync("location.reload");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //}
        public async Task DoDelete(StudViewResult student)
        {
            NavigationManager.NavigateTo($"/DelConStud/{student.StudentID}");
        }
    }
}
