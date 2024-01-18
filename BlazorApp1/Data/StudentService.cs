using BlazorApp1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

public class StudentService : IStudentService
{
    private readonly Ruchi_studContext _dbContext;

    public StudentService(Ruchi_studContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<StudViewResult>> StudViewAsync()
    {
        return await _dbContext.Procedures.StudViewAsync();
    }
    public async Task<List<SoftDeletedStudViewResult>> SoftDeletedStudViewAsync()
    {
        return await _dbContext.Procedures.SoftDeletedStudViewAsync();
    }
    public async Task<int> StudAddDeleteAsync(int? studentID, string name, string emailID, int? age, string skills, string gender, int? fees)
    {
        return await _dbContext.Procedures.StudAddDeleteAsync(studentID, name, emailID, age, skills, gender, fees);
    }
    public async Task UpdateStudentAsync(StudTable studs)
    {
        try
        {
            await _dbContext.Procedures.UpdateStudentAsync(studs.StudentId, studs.Name, studs.EmailId, studs.Age, studs.Skills, studs.Fees, studs.Gender);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
    public async Task<StudTable> selectSingle3Async(int stuId)
    {
        StudTable studs = _dbContext.StudTables.Where(x => x.StudentId == stuId).SingleOrDefault();
        if (studs == null)
        {
            return null;
        }
        return studs;
    }
    public async Task SoftDeleteStudAsync(int id)
    {
        try
        {
            var sToDelete = await _dbContext.StudTables.FindAsync(id);
            if (sToDelete != null)
            {
                await _dbContext.Procedures.SoftDeleteStudAsync(sToDelete.StudentId);
                sToDelete.IsDeleted = true; 
                _dbContext.Entry(sToDelete).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw; 
        }
    }
    public async Task RetriveAsync(int id)
    {
        try
        {
            var sToDelete = await _dbContext.StudTables.FindAsync(id);

            if (sToDelete != null)
            {
                await _dbContext.Procedures.RetriveAsync(sToDelete.StudentId);
                sToDelete.IsDeleted = false; 
                _dbContext.Entry(sToDelete).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw; 
        }
    }
    public async Task<StudTable> StudViewByIdAsync(int studentId)
    {
        return await _dbContext.StudTables.FindAsync(studentId);
    }
    public async Task<string> GetSkillsForStudentAsync(int studentID)
    {
        try
        {
            var result = await _dbContext.Procedures.GetSkillsForStudentAsync(studentID);
            return string.Join(", ", result.Select(skill => skill.SkillName));
        }
        catch (Exception ex)
        {          
            Console.WriteLine($"Error fetching student skills: {ex.Message}");
            return "Skills Not Available";
        }
    }
    public async Task AddStudentSkillsAsync(int studentId, string skillIds)
    {
        try
        {          
            await _dbContext.Procedures.AddStudentSkillsAsync(studentId, skillIds);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw; 
        }
    }
    public async Task<int> GetStudentIdByEmailAsync(string email)
    {
        try
        {
            var student = await _dbContext.StudTables
                .Where(s => s.EmailId == email)
                .FirstOrDefaultAsync();

            if (student != null)
            {
                return student.StudentId;
            }
            return -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw; 
        }
    }
}