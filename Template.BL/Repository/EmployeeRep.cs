using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.BL.Interface;
using Template.DAL.Database;
using Template.DAL.Entity;

namespace Template.BL.Repository
{
    public class EmployeeRep : IEmployee
    {
        private readonly ApplicationContext db;

        public EmployeeRep(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Employee>> Getasync(Expression<Func<Employee, bool>> filter = null)
        {

            if (filter == null)
            {
                return await db.Employee.Include("Department").ToListAsync();

            }
            else
            {
                return await db.Employee.Where(filter).Include("Department").ToListAsync();
            }
        }

        public async Task<Employee> GetByIdasync(int id)
        {
            var data = await db.Employee.Where(a => a.Id == id).FirstOrDefaultAsync();
            return data;

        }

        public async Task createasync(Employee obj)
        {

            await db.Employee.AddAsync(obj);
            await db.SaveChangesAsync();


        }

        public async Task Updateasync(Employee obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();


        }

        public async Task Deleteasync(int id)
        {
            //db.Entry(id).State = EntityState.Deleted; 
           var oldData = await db.Employee.FindAsync(id);
            oldData.IsDeleted = true;
            oldData.IsActive = false;
            oldData.DeletedDate = DateTime.Now;
            //db.Employee.Remove(oldData);

            await db.SaveChangesAsync();


        }
    }
}
