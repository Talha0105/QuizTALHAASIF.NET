using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizTALHAASIF.Models
{
    public class DepartmentModel
    {
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public string DepartmentLocation { get; set; }
        [Required]
        public string DepartmentCellNumber { get; set; }
    }
}