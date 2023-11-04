using Academy.Core.Enums;
using Academy.Core.Models;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
using Academy.Service.Services.Interfaces;
using System.Reflection;
namespace Academy.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository = new StudentRepository();

        public  async Task<string> CreateAsync(string fullname, double average, string group, StudentEducation studentEducation)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(fullname))
                 return "Fullname can not be empty ";
            Console.ForegroundColor = ConsoleColor.Red;
            if (average <= 0 || average >100)
                return "The average score can not be a string and it should be between 0 and 100  ";
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(group))
                return "Group can not be empty ";
       
            Student student = new Student(fullname,average,group,studentEducation);
            student.CreatedAt = DateTime.Now.AddHours(4);
            await _studentRepository.AddAsync(student);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Successfully created";

        }

        public async  Task  GetAllAsync()
        {
            List<Student> students = await _studentRepository.GetAllAsync();
            foreach (Student student in students)
            {
                Console.WriteLine($"Id:{student.Id} Fullname:{student.FullName} Average:{student.Average} Group:{student.Group} Education{student.StudentEducation} CreatedAt:{student.CreatedAt} UpdateAt:{student.UpdateAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Student student =  await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student not found";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Id:{student.Id} Fullname:{student.FullName} Average:{student.Average} Group:{student.Group} Education{student.StudentEducation} CreatedAt:{student.CreatedAt} UpdateAt:{student.UpdateAt}");
 
            return "Success";

        }

        public async Task<string> RemoveAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            Console.ForegroundColor = ConsoleColor.Red;
            if (student == null)
                return "Student not found";
           await  _studentRepository.RemoveAsync(student);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Removed successfully";
        }
        
        public async Task<string> UpdateAsync(string id, string fullname, double average, string group, StudentEducation studentEducation)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(fullname))
                return "Fullname can not be empty ";
            Console.ForegroundColor = ConsoleColor.Red;
            if (average <= 0 || average > 100)
                return "The average score can not be a string and it should be between 0 and 100  ";
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(group))
                return "Group can not be empty ";
            student.FullName = fullname;
            student.Average = average;  
            student.Group = group;
            student.StudentEducation= studentEducation;
            student.UpdateAt = DateTime.Now.AddHours(4);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Uptaded successfully";
        }

        
    }
}
