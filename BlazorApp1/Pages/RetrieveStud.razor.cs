using BlazorApp1.Models;
using Microsoft.JSInterop;

namespace BlazorApp1.Pages
{
    public partial class RetrieveStud
    {
        private List<SoftDeletedStudViewResult>? softDeletedStudents;

        protected override async Task OnInitializedAsync()
        {
            await RetrieveData();
        }

        private async Task RetrieveData()
        {
            try
            {
                softDeletedStudents = await StudentService.SoftDeletedStudViewAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving data: {ex.Message}");
                // Handle or log the exception as needed
            }
        }
        public async Task RetriveAsync(int stuid)
        {
            try
            {
                await StudentService.RetriveAsync(stuid);
                await JSRuntime.InvokeVoidAsync("location.reload");
                await JSRuntime.InvokeVoidAsync("alert", "Student deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Handle or log the exception as needed
            }

        }
}
}
