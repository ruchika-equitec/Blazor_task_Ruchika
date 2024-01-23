using BlazorApp1.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp1.Pages
{
    public partial class AddStudent
    {
        private StudTable newStudent = new StudTable();
        private List<Skill> skills = new List<Skill>
    {
       new Skill { ID = 1, Name = "Java", IsSelected = false },
    new Skill { ID = 2, Name = "Python", IsSelected = false },
    new Skill { ID = 3, Name = "C#", IsSelected = false },
    new Skill { ID = 4, Name = "HTML", IsSelected = false },
    new Skill { ID = 5, Name = "CSS", IsSelected = false }
    };  
        private async Task AddNewStudent()
        {
            if (IsValid())
            {
                newStudent.Skills = string.Join(",", skills.Where(skill => skill.IsSelected).Select(skill => skill.Name));
                await StudentService.StudAddDeleteAsync(newStudent.StudentId, newStudent.Name, newStudent.EmailId, newStudent.Age,  newStudent.Gender, newStudent.Fees,newStudent.Skills);
                int studentId = await StudentService.GetStudentIdByEmailAsync(newStudent.EmailId);
                string selectedSkillsIds = string.Join(",", skills.Where(skill => skill.IsSelected).Select(skill => skill.ID.ToString()));
                await StudentService.AddStudentSkillsAsync(studentId, selectedSkillsIds);
                NavigationManager.NavigateTo("/StudDetails");
            }
        }
        private bool IsValid()
        {
            var editContext = new EditContext(newStudent);
            return editContext.Validate();
        }
        public class Skill
        {
            public int ID { get; set; }  
            public string Name { get; set; }
            public bool IsSelected { get; set; }
        }
    }
}
