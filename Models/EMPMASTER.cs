using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CODEWITHMVC.Models
{
    public class EMPMASTER   
    {
        [Key]
        public int Id { get; set; }
        public string Emp_Code { get; set; }
        public string Emp_Name { get; set; }
        public string Designation { get; set; }
        

    }
}
