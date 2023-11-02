
using Academy.Core.Enums;
using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implementations
{
    public class MenuService
    {
        IStudentService studentService = new StudentService();
        public async Task RunApp()
        {
            
            await Menu();
            string request = Console.ReadLine();
            while (request != "0")
            {
                switch (request)
                {
                    case "1":
                        await CreateStudent();
                        break;
                    case "2":
                        await UpdateStudent();
                        break;
                    case "3":
                        await RemoveStudent();
                        break;
                    case "4":
                        await GetAllStudents();
                        break;
                    case "5":
                        await Get();
                        break;
                    default:
                        break;
                }
                await Menu();
                request = Console.ReadLine();
            }
        }
        async Task CreateStudent()
{
    Console.WriteLine("Add Fullname");
    string Fullname = Console.ReadLine();
    Console.WriteLine("Add Average");
    double.TryParse(Console.ReadLine(), out double Average);
    Console.WriteLine("Add Group");
    string Group = Console.ReadLine();
    int i = 1;

    foreach (var item in Enum.GetValues(typeof(StudentEducation)))
    {
        Console.WriteLine($"{i}.{item}");
        i++;
    }

    bool IsExist;
    int EnumIndex;
    do
    {
        Console.WriteLine("Add StudentCategory");
        int.TryParse(Console.ReadLine(), out EnumIndex);
        IsExist = Enum.IsDefined(typeof(StudentEducation), (StudentEducation)EnumIndex);
    } while (IsExist);
    string result = await studentService.CreateAsync(Fullname, Average, Group, (StudentEducation)EnumIndex);
    Console.WriteLine(result);
}
        async Task UpdateStudent()
        {
            Console.WriteLine("Add Id");
            string Id = Console.ReadLine();
            Console.WriteLine("Add Fullname");
            string Fullname = Console.ReadLine();
            Console.WriteLine("Add Average");
            double.TryParse(Console.ReadLine(), out double Average);
            Console.WriteLine("Add Group");
            string Group = Console.ReadLine();
            int i = 1;

            foreach (var item in Enum.GetValues(typeof(StudentEducation)))
            {
                Console.WriteLine($"{i}.{item}");
                i++;
            }

            bool IsExist;
            int EnumIndex;
            do
            {
                Console.WriteLine("Add StudentCategory");
                int.TryParse(Console.ReadLine(), out EnumIndex);
                IsExist = Enum.IsDefined(typeof(StudentEducation), (StudentEducation)EnumIndex);
            } while (IsExist);
            string result = await studentService.UpdateAsync1(Id, Fullname, Average, Group, (StudentEducation)EnumIndex);
            Console.WriteLine(result);
        }
        async Task RemoveStudent()
        {
            Console.WriteLine("Add Id");
            string Id = Console.ReadLine();
            string result = await studentService.RemoveAsync(Id);
           Console.WriteLine(result);
        }
        async Task GetAllStudents()
        {
            await studentService.GetAllAsync();
        }
        async Task Get()
        {
            Console.WriteLine("Add Id");
            string Id = Console.ReadLine();
            string result = await studentService.GetAsync(Id);
            Console.WriteLine(result);  
        }
        async Task Menu()
        {

            Console.WriteLine("1.Create");
            Console.WriteLine("2.Update");
            Console.WriteLine("3.Remove");
            Console.WriteLine("4.Get");
            Console.WriteLine("5.GetAll");
            Console.WriteLine("0.Close");
        }


    }
}
