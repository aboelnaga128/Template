using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.BL.Models;
using Template.DAL.Entity;

namespace Template.BL.Interface
{
    public interface Idepartment
    {
        Task<IEnumerable<Department>> Getasync();
        Task<Department> GetByIdasync(int id);
        Task createasync(Department obj);
        Task Updateasync(Department obj);
        Task Deleteasync(int id);

        

    }
}
