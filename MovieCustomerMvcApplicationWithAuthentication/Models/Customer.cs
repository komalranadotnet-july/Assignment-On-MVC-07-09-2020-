using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MovieCustomerMvcApplicationWithAuthentication.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer Name is mandatory")]
        [StringLength(40, ErrorMessage = "Customer Name should not exceed 40")]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        [Min18YrsIfMembers]
        public DateTime Dob { get; set; }

    }
}