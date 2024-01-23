using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
namespace BlazorApp1.Pages
{
    public partial class DeleteConfoirm
    {
        [Parameter]
        public int Id { get; set; }
        StudTable studs = new();
        public int StudentId { get; set; }
        EditContext? editContext;
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
            editContext = new(studs);
            studs = await StudentService.StudViewByIdAsync(Id);
            

        }
        public async Task SoftDeleteStudAsync(int stuid)
        {
            try
            {
                await StudentService.SoftDeleteStudAsync(stuid);
                await JSRuntime.InvokeVoidAsync("alert", "Student deleted successfully!");
                    NavigationManager.NavigateTo("/RetrieveStud");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private void GoBack()
        {
            NavigationManager.NavigateTo("/deleteStud");
        }
        public class Skill
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public bool IsSelected { get; set; }
        }
    }
}
