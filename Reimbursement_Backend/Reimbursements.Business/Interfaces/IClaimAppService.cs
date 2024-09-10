using Reimbursements.Business.DTOs;
using Reimbursements.DataAccess.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reimbursements.Business.Interfaces
{
    public interface IClaimAppService
    {
        IEnumerable<ClaimDTO> GetAllClaims();
        ClaimDTO GetClaimById(int id);
        void CreateClaim(ClaimDTO claim);

        void UpdateClaim(int id, ClaimDTO claim);

        bool DeleteClaim(int id);
        IEnumerable<ClaimDTO> GetClaimByCreatorId(string id);

        IEnumerable<BankDTO> GetAllBanks();
        IEnumerable<CurrencyDTO> GetAllCurrencies();

        IEnumerable<ReimbursementTypeDTO> GetAllTypes();

        string getTypeName(int id);

        IEnumerable<ClaimDTO> getAllPendingClaims();

        IEnumerable<ClaimDTO> getAllDeclinedCLaims();

        IEnumerable<ClaimDTO> getAllApprovedCLaims();
    }
}
