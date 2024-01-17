using BlazorApp1.Models;

namespace BlazorApp1.Pages
{
    public partial class AddStudent
    {
        private StudViewResult newStudent = new StudViewResult();

        private List<Skill> skills = new List<Skill>
    {
        new Skill { Name = "Java", IsSelected = false },
        new Skill { Name = "Python", IsSelected = false },
        new Skill { Name = "C#", IsSelected = false },
        new Skill { Name = "HTML", IsSelected = false },
        new Skill { Name = "CSS", IsSelected = false }
    };

        private async Task AddNewStudent()
        {

            newStudent.Skills = string.Join(",", skills.Where(skill => skill.IsSelected).Select(skill => skill.Name));

            await StudentService.StudAddDeleteAsync(newStudent.StudentID, newStudent.Name, newStudent.EmailID, newStudent.Age, newStudent.Skills, newStudent.Gender, newStudent.Fees);


            NavigationManager.NavigateTo("/StudDetails");
        }
        public class Skill
        {
            public string? Name { get; set; }
            public bool IsSelected { get; set; }
        }
    }
}
