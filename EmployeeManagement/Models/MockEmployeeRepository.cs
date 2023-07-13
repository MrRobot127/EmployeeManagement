using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>();
            _employeeList.Add(new Employee() { Id = 1, Name = "Girish", Email = "girish@boutique.in", Department = Dept.IT }); ;
            _employeeList.Add(new Employee() { Id = 2, Name = "Vikas", Email = "vikas@boutique.in", Department = Dept.HR }); ;
            _employeeList.Add(new Employee() { Id = 2, Name = "vaibhav", Email = "vaibhav@boutique.in", Department = Dept.Account }); ;

        }

        public Employee Add(Employee emloyee)
        {
            emloyee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(emloyee);
            return emloyee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }
    }
}
