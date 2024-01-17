using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
namespace BlazorApp1.Pages
{
    public partial class StudDetail
    {
        private List<StudViewResult>? students;
        protected override async Task OnInitializedAsync()
        {
            students = await StudentService.StudViewAsync();
        }
        private void AddNewStudent()
        {
            NavigationManager.NavigateTo("/AddStudent");
        }
        private void EditStudent(StudViewResult student)
        {
            // Call the method to navigate to the EditStudent page with the selected student
            NavigationManager.NavigateTo($"/UpdateStudent/{student.StudentID}");
        }
        private void DisplayStudent(StudViewResult student)
        {
            NavigationManager.NavigateTo($"/ViewStudent/{student.StudentID}");
        }
        public async Task SoftDeleteStudAsync(int stuid)
        {
            try
            {
                await StudentService.SoftDeleteStudAsync(stuid);
                await JSRuntime.InvokeVoidAsync("location.reload");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Handle or log the exception as needed
            }
        }
        private void RetrieveData()
        {
            NavigationManager.NavigateTo("/RetrieveStud");
        }
    }
}
