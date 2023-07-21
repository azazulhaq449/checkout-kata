
using System.Collections.Generic;

namespace MSite.Interface
{
    public interface IDepartmentService
    {
        IList<string> GetSurnamesInDepartment(string departmentName);
        IList<string> GetDepartmentsForPerson(string surname, string forename);
    }
}
