using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reimbursements.DataAccess.Context.Entities
{
    public class Claim : BaseEntity
    {
        
        public DateOnly Date { get; set; } 

        [Required]
        [ForeignKey("ReimbursementType")]
        public int TypeId { get; set; }

        public string typeName { get; set; }
        public ReimbursementType Type { get; set; }

        
        public decimal RequestedValue { get; set; }

        public decimal ApprovedValue { get; set; }

        [Required]
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }
        public Currency Currency { get; set; }

       

        public string Image { get; set; }

        

        public bool Proccessed { get; set; }

        public bool Approved { get; set; }

        public string Creator { get; set; }

        public string ApprovedBy {  get; set; } 

        public string ApproveNote { get; set; }
    }
}
