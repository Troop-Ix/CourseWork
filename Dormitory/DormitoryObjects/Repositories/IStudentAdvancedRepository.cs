using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    public interface IStudentAdvancedRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetStudentsBySurname(string surname);
        Task<IEnumerable<Student>> GetDebtors();
    }
}
