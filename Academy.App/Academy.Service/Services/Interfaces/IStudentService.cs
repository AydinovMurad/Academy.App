using Academy.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Academy.Service.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<string> CreateAsync(string fullname,double average,string group, StudentEducation studentEducation);
        public Task<string> UpdateAsync(string id, string fullname, double average, string group, StudentEducation studentEducation);
        public Task<string> RemoveAsync(string id);
        public Task<string> GetAsync(string id);
        public Task  GetAllAsync();
        Task<string> UpdateAsync1(string? id, string? fullname, double average, string? group, StudentEducation enumIndex);
    }
}
