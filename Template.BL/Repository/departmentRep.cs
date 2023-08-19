using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.BL.Interface;
using Template.BL.Models;
using Template.DAL.Database;
using Template.DAL.Entity;


namespace Template.BL.Repository
{
    public class departmentRep : Idepartment
    {
        private readonly ApplicationContext db;

        public departmentRep(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Department>> Getasync()
        {
            var data = await db.departments.ToListAsync();
            return data;

        }

        public async Task<Department> GetByIdasync(int id)
        {
            var data = await db.departments.Where(a=>a.Id==id).FirstOrDefaultAsync();
            return data;

        }

        public async Task createasync(Department obj)
        {
            
            await db.departments.AddAsync(obj);
            await db.SaveChangesAsync();


        }

        public async Task Updateasync(Department obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();


        }

        public async Task Deleteasync(int id)
        {
            //db.Entry(id).State = EntityState.Deleted; 
            var oldData = await db.departments.FindAsync(id);
            db.departments.Remove(oldData);
            await db.SaveChangesAsync();


        }
    }
}
