using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMvcApplicationWithAuthentication.Models
{
    public class Min18YrsIfMembers : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.Dob == null)
                return new ValidationResult("Birth Date is required");
            var age = DateTime.Today.Year - customer.Dob.Year;

            return (age >= 18) ?
ValidationResult.Success : new
ValidationResult("Customer should be atleast 18years old to bea member");

            //return base.IsValid(value, validationContext);
        }
    }
}