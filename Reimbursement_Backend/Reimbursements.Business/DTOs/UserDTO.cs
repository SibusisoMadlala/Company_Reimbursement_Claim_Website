using Reimbursements.DataAccess.Context.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reimbursements.Business.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        public string? password { get; set; } = string.Empty;


        public string Full_name { get; set; }


        
        public string Pan_Number { get; set; }

        [ForeignKey("BankId")]
        public int  BankId { get; set; }

       // public BankDTO Bank {  get; set; }





        public string Bank_Account_Number { get; set; }


    }
}
