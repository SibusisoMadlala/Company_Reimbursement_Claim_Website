using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Reimbursements.DataAccess.Context.Entities;

// Add profile data for application users by adding properties to the ReimbursementsUser class
public class ReimbursementsUser : IdentityUser
{
    
        //public string Email { get; set; } = string.Empty;


        //public string password { get; set; } = string.Empty;


       // public string UserName { get; set; }



        public string Pan_Number { get; set; }


        [ForeignKey("BankId")]
        public int BankId { get; set; }
        public Bank Bank { get; set; }

        public string Bank_Account_Number { get; set; }


        public bool IsApprover { get; set; } = false;
}

