using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Template.BL.Interface;
using Template.BL.Models;
using Template.BL.Repository;
using Template.DAL.Entity;

namespace Template.PL.Controllers
{ 
public class DepartmentController : Controller
{

       
        private readonly Idepartment department ; //loosely coupled    
        private readonly IMapper mapper;

        public DepartmentController(Idepartment department,IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
        }
        public async Task <IActionResult> Index()
        {

            //data binding 

            // ViewData["x"] = "welcome to department view data  ";
            /*
             * بيخزن الداتا ك obj
             * مبيعرفش نوعها ولا في ال complie ولا ال runtime
             * */

            // ViewBag.y = "welcome to department view bag";
            /*
             * افضلهم في ال perfromance 
             * بيخزن الداتا جواه ك dynamic 
             * مبيعرفش نوعها في الcompile 
             * بس بيعرف نوعها في ال runtime 
             * النوعين دول local variables بيتشافوا في الفيو بتاع الاكشن فقط 
             */


            // TempData["z"] = "welcome to department Temp Data ";
            /*
             * نفس ال view data في الخصائص 
             * بتتشاف برا في view غير بتاعة الاكشن اللي اتعرفت فيه 
             */




            //var Emp1 = new Employee() { id = 1, name = "Abdelrahman", salary = 8000 };
            //var Emp2 = new Employee() { id = 2, name = "sara", salary = 7000 };
            //var Emp3 = new Employee() { id = 3, name = "ali", salary = 6000 };
            //List<Employee> Emps = new List<Employee>();
            //Emps.Add(Emp1);
            //Emps.Add(Emp2);
            //Emps.Add(Emp3);
            //ViewBag.data = Emps;




            //var data = await _department.Getasync();
            //var result = mapper.Map <IEnumerable<departmentVM>>(data);
            var result = mapper.Map<IEnumerable<departmentVM>>(await department.Getasync());

            return View(result);
             
        //return RedirectToAction("create");
    }
        public IActionResult create()
        {
             return View();

        }
        [HttpPost]
        public async Task <IActionResult> create(departmentVM dname)
        {
           try
            {
                if (ModelState.IsValid == true)
                {
                    var data = mapper.Map<Department>(dname);    
                    await department.createasync(data);
                    return RedirectToAction("index");


                }
                TempData["Msg"] = "Validation Error";
                return View(dname);


            }
            catch (Exception ex )
            {
                return View(dname);
                 
            }
            
        }










        public async Task<IActionResult> Details(int id)
        {
            //var data = await _department.GetByIdasync(id);
            var result = mapper.Map<departmentVM>(await department.GetByIdasync(id));
            return View(result);

        }








        public async Task <IActionResult> Update(int id)
        {
           //var data = await _department.GetByIdasync(id);
            var result = mapper.Map<departmentVM>(await department.GetByIdasync(id));
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> Update(departmentVM dname)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    var data = mapper.Map<Department>(dname);
                    await department.Updateasync(data);
                    return RedirectToAction("index");


                }
                TempData["Msg"] = "Validation Error";
                return View(dname);


            }
            catch (Exception ex)
            {
                return View(dname);

            }

        }











        public async Task<IActionResult> Delete(int id)
        {
            
            //var data = await _department.GetByIdasync(id);
            var result = mapper.Map<departmentVM>(await department.GetByIdasync(id));
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(departmentVM dname)
        {
            try
            {
                
                    var data = mapper.Map<Department>(dname);
                    await department.Deleteasync(dname.Id);
                    return RedirectToAction("index");


                


            }
            catch (Exception ex)
            {
                return View(dname);
                

            }

        }
    } 
}
