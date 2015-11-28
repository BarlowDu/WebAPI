using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_11.Validator
{
    public class ArrayValidationAttribute : ValidationAttribute
    {
        public object[] _list;


        public ArrayValidationAttribute(params object[] list)
        {
            _list = list;
        }
        public object[] List
        {
            get { return _list; }
            set { _list = value; }
        }
        public override bool IsValid(object value)
        {
            return _list.Contains(value);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("{0}不在区间内.", name);
        }
    }
}