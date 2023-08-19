using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.DAL.Entity;

namespace Template.BL.Interface
{
    public interface IEmployee
    {

        Task<IEnumerable<Employee>> Getasync(Expression<Func<Employee, bool>> filter = null);
        Task<Employee> GetByIdasync(int id);
        Task createasync(Employee obj);
        Task Updateasync(Employee obj);
        Task Deleteasync(int id);
    }
}
