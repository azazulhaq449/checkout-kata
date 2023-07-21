using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSite.Exceptions;
using MSite.Implementation;
using MSite.Interface;
using MSite.Model;
using MSite.Types;
using System.Collections.Generic;
using System.Linq;

namespace MSite.Test
{
    [TestClass]
    public class DepartmentServiceTest
    {
        private IDepartmentService _departmentService;

        [TestInitialize] public void Init() {
            var departments = GetMockDepartments();
            _departmentService = new DepartmentService(departments);
        }


        [TestMethod]
        public void GetSurnamesInDepartment_ExistingDepartment_ReturnsSurnames()
        {
            // Arrange
            var expectedSurnames = new List<string> { "Smith", "Jones", "Bradshaw" };

            // Act
            var surnames = _departmentService.GetSurnamesInDepartment("Purchasing");

            // Assert
            Assert.AreEqual(surnames.Count, expectedSurnames.Count);
            expectedSurnames.ForEach(i => Assert.IsTrue(surnames.Contains(i)));
        }

        [TestMethod]
        public void GetSurnamesInDepartment_NonExistingDepartment_ReturnsEmptyList()
        {
            Assert.ThrowsException<MSiteException>(() => _departmentService.GetSurnamesInDepartment("IT"));
        }

        [TestMethod]
        public void GetDepartmentsForPerson_ExistingPerson_ReturnsDepartments()
        {
            // Act
            var departments = _departmentService.GetDepartmentsForPerson("Smith", "John");

            // Assert
            Assert.AreEqual("Purchasing", departments.First());
        }

        [TestMethod]
        public void GetDepartmentsForPerson_NonExistingPerson_ReturnsEmptyList()
        {
            // Assert
            Assert.ThrowsException<MSiteException>(() => _departmentService.GetDepartmentsForPerson("Azaz","ul haq"));
        }

        #region MockData

        private IList<Department> GetMockDepartments()
        {
            return new List<Department>
            {
                new Department
                {
                    Name = "Purchasing",
                    Location = "Top floor",
                    Members = new List<Person>
                    {
                        new Person { Surname = "Smith", Forename = "John", Title = Title.Mr },
                        new Person { Surname = "Jones", Forename = "Steve", Title = Title.Mr },
                        new Person { Surname = "Bradshaw", Forename = "Lisa", Title = Title.Mrs }
                    }
                },
                new Department
                {
                    Name = "Sales",
                    Location = "Bottom floor",
                    Members = new List<Person>
                    {
                        new Person { Surname = "Bradshaw", Forename = "Lisa", Title = Title.Mrs },
                        new Person { Surname = "Thompson", Forename = "Joanne", Title = Title.Miss },
                        new Person { Surname = "Johnson", Forename = "David", Title = Title.Mr }
                    }
                }
            };
        }

        #endregion
        [TestCleanup]
        public void Cleanup()
        {
            _departmentService = null;
        }
    }
}
