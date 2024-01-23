using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp1.Pages
{
    public partial class UpdateStudent
    {
        [Parameter]
        public int StudentID { get; set; }
        StudTable studs = new StudTable();
        EditContext? editContext;
        ValidationMessageStore messageStore;
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
            EditContext? editContext;
            studs = await StudentService.selectSingle3Async(StudentID);
            foreach (var skill in skills)
            {
                skill.IsSelected = studs.Skills?.Split(',').Contains(skill.Name) ?? false;
            }
            StateHasChanged();
        }
        public async Task EditStudent()
        {
            editContext = new(studs);
            messageStore?.Clear();
            messageStore = new(editContext);              
            if (await ValidateModel())
            {
                if (!editContext.GetValidationMessages().Any())
                {
                    if (studs != null)
                    {
                        studs.Skills = string.Join(",", skills.Where(skill => skill.IsSelected).Select(skill => skill.Name));
                        await StudentService.UpdateStudentAsync(studs);                                  
                        NavigationManager.NavigateTo("/MainStud");
                    }
                }
                else
                {
                    FieldIdentifier field = new FieldIdentifier(studs, nameof(studs.Name));
                    messageStore.Add(field, "Invalid");
                    editContext.NotifyValidationStateChanged();
                }
            }

        }
        private void ToggleSkill(Skill skill)
        {
            skill.IsSelected = skill.IsSelected;
        }
        public class Skill
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public bool IsSelected { get; set; }
        }
        private async Task<bool> ValidateModel()
        {
            FieldIdentifier nameField = new(studs, nameof(studs.Name));
            FieldIdentifier ageField = new(studs, nameof(studs.Age));
            FieldIdentifier genderField = new(studs, nameof(studs.Gender));
            FieldIdentifier fees = new(studs, nameof(studs.Fees));
            FieldIdentifier emailField = new(studs, nameof(studs.EmailId));
            FieldIdentifier skillsField = new(studs, nameof(studs.Skills));

            if (studs != null)
            {
                if (string.IsNullOrEmpty(studs.Name))
                {
                    messageStore.Add(nameField, "Name cannot be blank");
                }

                if (studs.Age <= 0)
                {
                    messageStore.Add(ageField, "Age must be greater than 0");
                }
                if (string.IsNullOrEmpty(studs.Gender))
                {
                    messageStore.Add(genderField, "Gender must be selected");
                }
                if (studs.Fees <= 0)
                {
                    messageStore.Add(fees, "Fees cannot be negative");
                }

                if (string.IsNullOrEmpty(studs.EmailId))
                {
                    messageStore.Add(emailField, "Email cannot be blank");
                }
                else if (!IsValidEmail(studs.EmailId))
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

            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

    }
}
