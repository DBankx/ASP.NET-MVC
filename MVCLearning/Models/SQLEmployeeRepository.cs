using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLearning.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }


        public Employee AddEmployee(Employee empl)
        {
            context.Employees.Add(empl);
            context.SaveChanges();
            return empl;
        }

        public Employee Delete(int id)
        {
            Employee empl = context.Employees.Find(id);
            if(empl != null)
            {
                context.Employees.Remove(empl);
                context.SaveChanges();
            }
            return empl;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }

        public Employee Update(Employee employeeChanges)
        {
           var employee = context.Employees.Attach(employeeChanges);
            employee.State = EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
