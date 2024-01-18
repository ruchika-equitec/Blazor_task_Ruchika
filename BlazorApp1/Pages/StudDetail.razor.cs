using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
namespace BlazorApp1.Pages
{
    public partial class StudDetail
    {
        [Parameter]
        public int StudentId { get; set; }
        private List<StudViewResult>? students;
        public string studentSkills;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            students = await StudentService.StudViewAsync();
            foreach (var student in students)
            {
                student.Skills = await StudentService.GetSkillsForStudentAsync(student.StudentID);
            }
        }
        private void AddNewStudent()
        {
            NavigationManager.NavigateTo("/AddStudent");
        }
        private void EditStudent(StudViewResult student)
        {
            NavigationManager.NavigateTo($"/UpdateStudent/{student.StudentID}");
        }
        private void DisplayStudent(StudViewResult student)
        {
            NavigationManager.NavigateTo($"/ViewStudent/{student.StudentID}");
        }
        public async Task SoftDeleteStudAsync(int stuid)
        {
            try
            {
                await StudentService.SoftDeleteStudAsync(stuid);
                await JSRuntime.InvokeVoidAsync("location.reload");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private void RetrieveData()
        {
            NavigationManager.NavigateTo("/RetrieveStud");
        }
    }
}
