using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reimbursements.DataAccess.Context.Entities
{
    public class Bank : BaseEntity
    {
        public string BankName { get; set; }

        public virtual ICollection<ReimbursementsUser> Users { get; set; }
    }
}
