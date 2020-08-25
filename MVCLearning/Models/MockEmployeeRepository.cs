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
                new Employee{Id=1, Name="Mary", Email="mary@email.com", Department=Dept.HR},
                new Employee{Id=2, Name="John", Email="john@email.com", Department=Dept.IT},
                new Employee{Id=3, Name="Sally", Email="sally@email.com", Department=Dept.Payroll}
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

        public Employee AddEmployee(Employee empl)
        {
            empl.Id = _employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(empl);
            return empl;
        }
        
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee empl = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);

            if(empl != null)
            {
                empl.Name = employeeChanges.Name;
                empl.Email = employeeChanges.Email;
                empl.Department = employeeChanges.Department;
            }

            return empl;
        }

        public Employee Delete(int id)
        {
            Employee empl = _employeeList.FirstOrDefault(e => e.Id == id);

            if (empl != null)
            {
                _employeeList.Remove(empl);
            }

            return empl;
        }
    }
}
