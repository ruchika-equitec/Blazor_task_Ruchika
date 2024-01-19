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
            if (studs != null)
            {

                studs.Skills = string.Join(",", skills.Where(skill => skill.IsSelected).Select(skill => skill.Name));
                await StudentService.UpdateStudentAsync(studs);
                int studentId = await StudentService.GetStudentIdByEmailAsync(studs.EmailId);
                string selectedSkillsIds = string.Join(",", skills.Where(skill => skill.IsSelected).Select(skill => skill.ID.ToString()));
                await StudentService.EditStudentSkillsAsync(studentId, selectedSkillsIds);
                NavigationManager.NavigateTo("/MainStud");
            }
        }
        public class Skill
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public bool IsSelected { get; set; }
        }

    }
}
