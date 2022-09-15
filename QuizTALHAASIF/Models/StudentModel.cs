using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuizTALHAASIF.Models
{
    public class StudentModel
    {
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        [Required]
        public string  CellNumber {get;set;}
        [Required]
        public string Address {get;set;}
    }
}