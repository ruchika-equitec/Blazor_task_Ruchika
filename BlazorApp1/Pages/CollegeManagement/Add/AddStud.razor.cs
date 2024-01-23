using BlazorApp1.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace BlazorApp1.Pages.CollegeManagement.Add
{
    public partial class AddStud
    {
        private StudTable newStudent = new StudTable { Age = null, Fees=null };
        EditContext? editContext;
    
        ValidationMessageStore messageStore;
        private List<Skill> skills = new List<Skill>
    {
         new Skill { ID = 1, Name = "Java", IsSelected = false },
        new Skill { ID = 2, Name = "Python", IsSelected = false },
        new Skill { ID = 3, Name = "C#", IsSelected = false },
        new Skill { ID = 4, Name = "HTML", IsSelected = false },
        new Skill { ID = 5, Name = "CSS", IsSelected = false }
    };

        protected override async Task OnInitializedAsync()
        {
             editContext= new(newStudent);
            StateHasChanged();
        }
        private async Task AddNewStudent()
         {
            editContext = new(newStudent);
            messageStore?.Clear();
            messageStore = new(editContext);
            //newStudent.Skills = string.Join(",", skills.Where(skill => skill.IsSelected).Select(skill => skill.Name));
            //await StudentService.StudAddDeleteAsync(newStudent.StudentId, newStudent.Name, newStudent.EmailId, newStudent.Age, newStudent.Gender, newStudent.Fees);
            //int studentId = await StudentService.GetStudentIdByEmailAsync(newStudent.EmailId);
            //string selectedSkillsIds = string.Join(",", skills.Where(skill => skill.IsSelected).Select(skill => skill.ID.ToString()));
            //await StudentService.AddStudentSkillsAsync(studentId, selectedSkillsIds);
            //NavigationManager.NavigateTo("/MainStud");
            if (await ValidateModel())
            {
                if (!editContext.GetValidationMessages().Any())
                {
                    if (newStudent != null)
                    {
                        newStudent.Skills = string.Join(",", skills.Where(skill => skill.IsSelected).Select(skill => skill.Name));
                        await StudentService.StudAddDeleteAsync(newStudent.StudentId, newStudent.Name, newStudent.EmailId, newStudent.Age, newStudent.Gender, newStudent.Fees,newStudent.Skills);
                        NavigationManager.NavigateTo("/MainStud");
                    }
                }
                else
                {
                    FieldIdentifier field = new FieldIdentifier(newStudent, nameof(newStudent.Name));
                    messageStore.Add(field, "Invalid");
                    editContext.NotifyValidationStateChanged();
                }
            }
        }
        private async Task<bool> ValidateModel()
        {
            FieldIdentifier nameField = new FieldIdentifier(newStudent, nameof(newStudent.Name));
            FieldIdentifier ageField = new FieldIdentifier(newStudent, nameof(newStudent.Age));
            FieldIdentifier genderField = new FieldIdentifier(newStudent, nameof(newStudent.Gender));
            FieldIdentifier fees = new FieldIdentifier(newStudent, nameof(newStudent.Fees));
            FieldIdentifier emailField = new FieldIdentifier(newStudent, nameof(newStudent.EmailId));
            FieldIdentifier skillsField = new FieldIdentifier(newStudent, nameof(newStudent.Skills));

            if (newStudent != null)
            {
                if (string.IsNullOrEmpty(newStudent.Name))
                {
                    messageStore.Add(nameField, "Name cannot be blank");
                }

                if (newStudent.Age <= 0)
                {
                    messageStore.Add(ageField, "Age must be greater than 0");
                }
                if (string.IsNullOrEmpty(newStudent.Gender))
                {
                    messageStore.Add(genderField, "Gender must be selected");
                }
                if (newStudent.Fees <= 0)
                {
                    messageStore.Add(fees, "Fees cannot be negative");
                }

                if (string.IsNullOrEmpty(newStudent.EmailId))
                {
                    messageStore.Add(emailField, "Email cannot be blank");
                }
                else if (!IsValidEmail(newStudent.EmailId))
                {
                    messageStore.Add(emailField, "Invalid email format");
                }

                if (skills.All(skill => !skill.IsSelected))
                {
                    messageStore.Add(skillsField, "At least one skill must be selected");
                }
            }
            return true;
        }
        private bool IsValidEmail(string email)
        {

            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public class Skill
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public bool IsSelected { get; set; }
        }
    }
}
