using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.BL.Models
{
    public class departmentVM
    {
        
        public int Id { get; set; }
        
        
        [Required(ErrorMessage ="Name Required")]
        [MinLength(3,ErrorMessage ="min len 3")]
        [MaxLength(50,ErrorMessage ="max len 50")]
        public string ?Name { get; set; }

    }
}
