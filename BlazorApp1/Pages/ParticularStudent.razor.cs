using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
namespace BlazorApp1.Pages
{
    public partial class ParticularStudent
    {
        StudTable studs = new StudTable();
        [Parameter]
        public int StudentId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            studs = await StudentService.StudViewByIdAsync(StudentId);
        }
        private StudTable newStudent = new StudTable();

        private void GoBack()
        {
            NavigationManager.NavigateTo("/MainStud");
        }
    }
}
