using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DAL.Entity;

namespace Template.BL.Models
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            IsActive = true;
            CreationDate = DateTime.Now;
            IsDeleted = false;

        }
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Required")]
        [MinLength(3,ErrorMessage ="min length 3")]
        [MaxLength(50,ErrorMessage ="max length 50")]
        public string Name { get; set; }

        [Range(2000,100000,ErrorMessage ="Range Btw 2000 : 100000")]
        public float salary { get; set; }
        public DateTime HireDate { get; set; }
        public string Notes { get; set; }
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public int DepartmentID { get; set; }
        public Department?  Department { get; set; }







    }
}
