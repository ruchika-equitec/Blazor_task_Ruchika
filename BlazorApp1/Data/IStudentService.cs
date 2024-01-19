using BlazorApp1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IStudentService
{
    Task<List<StudViewResult>> StudViewAsync();
    Task<int> StudAddDeleteAsync(int? studentID, string name, string emailID, int? age, string gender, int? fees);
    Task UpdateStudentAsync(StudTable studs);
    Task<StudTable> selectSingle3Async(int stuId);
    Task SoftDeleteStudAsync(int stuid);
    Task<List<SoftDeletedStudViewResult>> SoftDeletedStudViewAsync();
    Task RetriveAsync(int id);
    Task<StudTable> StudViewByIdAsync(int studentId);
    Task<string> GetSkillsForStudentAsync(int studentID);
    Task AddStudentSkillsAsync(int studentId, string skillIds);
    Task<int> GetStudentIdByEmailAsync(string email);
    Task EditStudentSkillsAsync(int studentId, string skillIds);
}
