using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class UpdateStudent
    {
        [Parameter]
        public int StudentID { get; set; }
        StudTable studs = new StudTable();
        private List<Skill> skills = new List<Skill>
    {
        new Skill { Name = "Java", IsSelected = false },
        new Skill { Name = "Python", IsSelected = false },
        new Skill { Name = "C#", IsSelected = false },
        new Skill { Name = "HTML", IsSelected = false },
        new Skill { Name = "CSS", IsSelected = false }
    };
        protected override async Task OnInitializedAsync()
        {
            studs = await StudentService.selectSingle3Async(StudentID);
        }
        public async Task EditStudent()
        {
            studs.Skills = string.Join(",", skills.Where(skill => skill.IsSelected).Select(skill => skill.Name));
            await StudentService.UpdateStudentAsync(studs);
            NavigationManager.NavigateTo("/StudDetails");
        }

        public class Skill
        {
            public string? Name { get; set; }
            public bool IsSelected { get; set; }
        }
    
}
}
