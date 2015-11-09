using API_11.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace API_11.Models
{
    public class Figure
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        //[ArrayValidation("Stack","Snow")]
        //[CustomValidation(typeof(ArrayValidator),"CheckString")]
        public string LastName { get; set; }
    }

}