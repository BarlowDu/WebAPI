using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_11.Validator
{
    public class ArrayValidator
    {
        /// <summary>
        /// 为CustomerValidationAttribute提供的验证方法（一个参数）
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static ValidationResult Check(object val)
        {
            string[] list = new string[] { "Stack", "Other" };
            if (list.Contains(val))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("不在区间内");
            }
        }

        /// <summary>
        /// 为CustomerValidationAttribute提供的验证方法（两个参数）
        /// </summary>
        /// <param name="val"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static ValidationResult CheckString(string val, ValidationContext context)
        {
            string[] list = new string[] { "Stack", "Other" };
            if (list.Contains(val))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("不在区间内");
            }
        }

    }
}