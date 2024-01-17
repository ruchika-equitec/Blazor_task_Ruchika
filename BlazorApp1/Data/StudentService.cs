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
        // Assuming StudAddDelete is a stored procedure in your DbContext
        return await _dbContext.Procedures.StudAddDeleteAsync(studentID, name, emailID, age, skills, gender, fees);
    }
    //edit
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
        StudTable studs = _dbContext.StudTable.Where(x => x.StudentId == stuId).SingleOrDefault();
        if (studs == null)
        {
            return null;
        }
        return studs;
    }
    //delete
    public async Task SoftDeleteStudAsync(int id)
    {
        try
        {
            var sToDelete = await _dbContext.StudTable.FindAsync(id);

            if (sToDelete != null)
            {
                await _dbContext.Procedures.SoftDeleteStudAsync(sToDelete.StudentId);

                sToDelete.IsDeleted = true; // Assuming IsActive is the property for soft delete
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
            // Handle or log the exception
            Console.WriteLine($"Error: {ex.Message}");
            throw; // Rethrow the exception if necessary
        }
    }
    public async Task RetriveAsync(int id)
    {
        try
        {
            var sToDelete = await _dbContext.StudTable.FindAsync(id);

            if (sToDelete != null)
            {
                await _dbContext.Procedures.RetriveAsync(sToDelete.StudentId);

                sToDelete.IsDeleted = false; // Assuming IsActive is the property for soft delete
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
            // Handle or log the exception
            Console.WriteLine($"Error: {ex.Message}");
            throw; // Rethrow the exception if necessary
        }
    }
    //view
    public async Task<StudTable> StudViewByIdAsync(int studentId)
    {
        return await _dbContext.StudTable.FindAsync(studentId);
    }

}