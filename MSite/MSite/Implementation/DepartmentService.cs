using MSite.Exceptions;
using MSite.Interface;
using MSite.Model;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MSite.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private Dictionary<string, Department> _departments;

        public DepartmentService(IList<Department> departmentList)
        {
            //We can also implement a repository for adding departments but it is not asked
            _departments = departmentList.ToDictionary(d => d.Name);
        }

        public IList<string> GetSurnamesInDepartment(string departmentName)
        {
            _departments.TryGetValue(departmentName, out var department);
            if (department == null)
            {
                throw new MSiteException("Department not found", departmentName);
            }
            return department.Members.Select(m => m.Surname).ToList();
        }

        public IList<string> GetDepartmentsForPerson(string surname, string forename)
        {
            var departments = _departments.Values
                .Where(d => d.Members.Any(m => m.Surname == surname && m.Forename == forename));
            if (departments.Any())
            {
                return departments
                .Select(d => d.Name)
                .ToList();
            }
            throw new MSiteException("Associate surname and forename does'nt exist on any of the department", surname, forename);
        }
    }
}
