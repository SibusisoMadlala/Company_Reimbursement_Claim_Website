using Reimbursements.DataAccess.Context;
using Reimbursements.DataAccess.Context.Entities;
using Reimbursements.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reimbursements.DataAccess.Repositories
{
    public class ClaimsRepository : Repository<Claim>, IClaimsRepository
    {
        public ClaimsRepository(ClaimsDbContext context) : base(context) { }
    }
}
