using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reimbursements.DataAccess.Context.Entities
{
    
    public class BaseEntity
    {
            [Key]
            [Column("ID")]
            public int Id { get; set; }
    }

}
