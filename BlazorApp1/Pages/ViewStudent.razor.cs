using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Pages
{
    public partial class ViewStudent
    {
        // private StudViewResult student;
        StudTable studs = new StudTable();

        [Parameter]
        public int StudentId { get; set; }
        private List<Skill> skills = new List<Skill>
        {
           new Skill { ID = 1, Name = "Java", IsSelected = false },
        new Skill { ID = 2, Name = "Python", IsSelected = false },
        new Skill { ID = 3, Name = "C#", IsSelected = false },
        new Skill { ID = 4, Name = "HTML", IsSelected = false },
        new Skill { ID = 5, Name = "CSS", IsSelected = false }
        };
        private List<StudViewResult>? students;
        protected override async Task OnInitializedAsync()
        {
            studs = await StudentService.StudViewByIdAsync(StudentId);
            foreach (var skill in skills)
            {
                skill.IsSelected = studs.Skills?.Split(',').Contains(skill.Name) ?? false;
            }
            //students = await StudentService.StudViewAsync();
            //foreach (var student in students)
            //{
            //    student.Skills = await StudentService.GetSkillsForStudentAsync(student.StudentID);
            //}

        }
        private void ToggleSkill(Skill skill)
        {
            skill.IsSelected = skill.IsSelected;
        }

        private void GoBack()
        {
            NavigationManager.NavigateTo("/MainStud");
        }
        public class Skill
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public bool IsSelected { get; set; }
        }
    }
}
