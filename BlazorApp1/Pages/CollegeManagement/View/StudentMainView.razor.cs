﻿using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Pages.CollegeManagement.View
{
    public partial class StudentMainView
    {
        [Parameter]
        public int StudentId { get; set; }
        private List<StudViewResult>? students;
        public string studentSkills;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            students = await StudentService.StudViewAsync();
            foreach (var student in students)
            {
                student.Skills = await StudentService.GetSkillsForStudentAsync(student.StudentID);
            }
        }
        private void AddNewStudent()
        {
            NavigationManager.NavigateTo("/AddStudent");
        }
      
        private void DisplayStudent(StudViewResult student)
        {
            NavigationManager.NavigateTo($"/View/{student.StudentID}");
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
            }
        }
        private void RetrieveData()
        {
            NavigationManager.NavigateTo("/RetrieveStud");
        }
    }
}