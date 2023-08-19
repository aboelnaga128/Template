using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.DAL.Entity
{
    [Table("Employee")]
    public class Employee
    {
        public Employee()
        {

        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public float salary { get; set; }
        public DateTime HireDate { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public Department ? Department { get; set; }






    }
}
