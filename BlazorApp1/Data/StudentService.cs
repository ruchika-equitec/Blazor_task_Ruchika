using BlazorApp1.Models;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class StudentService : IStudentService
{
    private readonly Ruchi_studContext _dbContext;

    public StudentService(Ruchi_studContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<StudTable>> GetStudentsAsync()
    {
        return await _dbContext.StudTable.ToListAsync();
    }

}
