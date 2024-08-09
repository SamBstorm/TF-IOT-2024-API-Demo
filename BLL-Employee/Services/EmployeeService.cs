using BLL_Employee.Entities;
using Common_Employee.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL_Employee.Services
{
    public class EmployeeService : IEmployeeRepository<Employee>
    {
        private List<Employee> _employees;

        public EmployeeService()
        {
            _employees = new List<Employee>(){
                new Employee() { EmployeeId = 1, FirstName="Samuel", LastName="Legrain"},
                new Employee() { EmployeeId = 2, FirstName="Thierry", LastName= "Morre" },
                new Employee() { EmployeeId = 3, FirstName="Steve", LastName= "Lorent" },
                new Employee() { EmployeeId = 4, FirstName="Quentin", LastName= "Geerts" }
            };
        }
        public void Delete(int id)
        {
            _employees.Remove(_employees.SingleOrDefault(e => e.EmployeeId == id));
        }

        public IEnumerable<Employee> Get()
        {
            return _employees;
        }

        public Employee Get(int id)
        {
            return _employees.SingleOrDefault(e => e.EmployeeId == id) ?? throw new ArgumentOutOfRangeException(nameof(id));
        }

        public int Insert(Employee entity)
        {
            int maxId = _employees.Max(e=> e.EmployeeId) + 1;
            entity.EmployeeId = maxId;
            _employees.Add(entity);
            return maxId;
        }

        public void Update(int id, Employee entity)
        {
            Employee? employee = _employees.SingleOrDefault(e => e.EmployeeId == id);
            if (employee is null) throw new Exception();
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;

        }
    }
}
