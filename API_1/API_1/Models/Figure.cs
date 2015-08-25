using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace API_1.Models
{
    [ModelBinder]
    public class Figure
    {
        public Figure()
        { }
        public Figure(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}