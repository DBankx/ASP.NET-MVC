using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLearning.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>
            {
                new Employee{Id=1, Name="Mary", Email="mary@email.com", Department="IT Dept"},
                new Employee{Id=2, Name="John", Email="john@email.com", Department="Marketing Dept"},
                new Employee{Id=3, Name="Sally", Email="sally@email.com", Department="CEO Dept"}
            };
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public List<Employee> RemoveEmployee(int Id)
        {
            foreach (var item in _employeeList)
            {
                if(item.Id == Id)
                {
                    _employeeList.Remove(item);
                }
            };

            return _employeeList;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }
    }
}
