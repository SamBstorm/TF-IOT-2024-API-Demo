using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Employee.Repositories
{
    public interface IEmployeeRepository<TEmployee> : ICRUDRepository<TEmployee,int>
    {
    }
}
