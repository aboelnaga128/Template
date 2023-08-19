using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Template.BL.Interface;
using Template.BL.Models;
using Template.DAL.Entity;

namespace Template.PL.Controllers
{
    public class EmployeeController : Controller
    {
        #region Fields

        private readonly IEmployee employee;
        private readonly IMapper mapper;
        private readonly Idepartment department;



        #endregion



        #region Ctor

        public EmployeeController(IEmployee employee,IMapper mapper,Idepartment department )
        {
            this.employee = employee;
            this.mapper = mapper;
            this.department = department;
            
        }


        #endregion



        #region Actions



        public async  Task<IActionResult> Index(string searchValue = null)
        {
            if (searchValue == null)
            {
                var data = await employee.Getasync(a => a.IsActive == true && a.IsDeleted == false );
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);

                return View(result);
            }
            else
            {

                var data = await employee.Getasync(a => a.IsActive == true && a.IsDeleted == false && a.Name.Contains(searchValue));
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);

                return View(result);
            }

            
        }

        public async Task< IActionResult> create()
        {   
            ViewBag.DepartmentList=new SelectList(await department.Getasync(),"Id","Name");
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> create(EmployeeVM dname)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    var data = mapper.Map<Employee>(dname);
                    await employee.createasync(data);
                    return RedirectToAction("index");


                }
                TempData["Msg"] = "Validation Error";
                ViewBag.DepartmentList = new SelectList(await department.Getasync(), "Id", "Name", dname.DepartmentID); 
                return View(dname);


            }
            catch (Exception ex)
            {
                ViewBag.DepartmentList = new SelectList(await department.Getasync(), "Id", "Name", dname.DepartmentID); 
                return View(dname);

            }

        }










        public async Task<IActionResult> Details(int id)
        {
            //var data = await _department.GetByIdasync(id);
            var result = mapper.Map<EmployeeVM>(await employee.GetByIdasync(id));
            ViewBag.DepartmentList = new SelectList(await department.Getasync(), "Id", "Name");
            return View(result);

        }








        public async Task<IActionResult> Update(int id)
        {
            //var data = await _department.GetByIdasync(id);
            var result = mapper.Map<EmployeeVM>(await employee.GetByIdasync(id));
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeVM dname)
        {
            try
            {
                if (ModelState.IsValid == true)
                {

                    var data = mapper.Map<Employee>(dname);
                    data.IsUpdated = true;
                    data.UpdatedDate = DateTime.Now;
                    await employee.Updateasync(data);
                    return RedirectToAction("index");


                }
                TempData["Msg"] = "Validation Error";
                ViewBag.DepartmentList = new SelectList(await department.Getasync(), "Id", "Name");

                return View(dname);


            }
            catch (Exception ex)
            {
                ViewBag.DepartmentList = new SelectList(await department.Getasync(), "Id", "Name");

                return View(dname);

            }

        }











        public async Task<IActionResult> Delete(int id)
        {

            //var data = await _department.GetByIdasync(id);
            var result = mapper.Map<EmployeeVM>(await employee.GetByIdasync(id));
            ViewBag.DepartmentList = new SelectList(await department.Getasync(), "Id", "Name");
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeVM dname)
        {
            try
            {

                var data = mapper.Map<Employee>(dname);
                await employee.Deleteasync(dname.Id);
                return RedirectToAction("index");





            }
            catch (Exception ex)
            {
                ViewBag.DepartmentList = new SelectList(await department.Getasync(), "Id", "Name");

                return View(dname);


            }

        }




        #endregion



        #region Json




        #endregion


    }
}