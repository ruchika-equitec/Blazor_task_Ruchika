using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages.CollegeManagement.Modify
{
    public partial class ModifyStudent
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
        private void EditStudent(StudViewResult student)
        {
            NavigationManager.NavigateTo($"/UpdateStudent/{student.StudentID}");
        }
    }
}
