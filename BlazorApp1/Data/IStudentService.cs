using BlazorApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IStudentService
{
    Task<List<StudTable>> GetStudentsAsync();
}
