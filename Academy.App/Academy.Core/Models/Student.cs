

using Academy.Core.Enums;
using Academy.Core.Models.BaseModels;

namespace Academy.Core.Models
{
    public class Student:BaseModel
    {
        static int _id;
        public string FullName {  get; set; }   
        public double  Average { get; set; }    
        public string Group { get; set; }   
        public StudentEducation StudentEducation { get; set; }

        public Student (string fullname, double average, string group, StudentEducation studentEducation)
        {
            _id++;
            string educationName = StudentEducation.ToString();


            Id = $"{educationName[0]}-{_id}";
            FullName = fullname;
            Average = average;
            Group = group;
            StudentEducation = studentEducation;
        }
    }
}
