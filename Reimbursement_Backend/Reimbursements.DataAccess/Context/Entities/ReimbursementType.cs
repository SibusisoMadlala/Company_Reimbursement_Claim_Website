using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reimbursements.DataAccess.Context.Entities
{
    public class ReimbursementType : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
    }
}
