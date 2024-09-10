using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reimbursements.Business.DTOs
{
    public class ClaimDTO
    {

        [Key]
        public int id { get; set; } 

      
        
        public DateOnly Date { get; set; } 

      
        public int TypeId { get; set; } 

        public string TypeName { get; set; }

        

        public decimal RequestedValue { get; set; }

        public decimal ApprovedValue { get; set; }


        [Required(ErrorMessage = "The Currency is Required")]
        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public bool Proccessed { get; set; }

        public bool Approved { get; set; }
        public string ApprovedBy { get; set; }

        public string ApproveNote { get; set; }
        public string Creator { get; set; }
        public string Image { get; set; }

    }
}
