using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace API_13.Models
{
    public class FilterModel
    {
        public string FilterTypeName { get; set; }
        public FilterScope? FilterScope { get; set; }

        public string Message { get; set; }

        public FilterModel()
        { }
        public FilterModel(Type filterType, FilterScope? filterScope)
        {
            FilterTypeName = filterType.FullName;
            FilterScope = filterScope;
        }

        public FilterModel(Type filterType, FilterScope? filterScope, string message)
        {
            FilterTypeName = filterType.FullName;
            FilterScope = filterScope;
            Message = message;
        }

    }
}