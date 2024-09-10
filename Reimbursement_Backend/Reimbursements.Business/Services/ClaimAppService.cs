using AutoMapper;
using Reimbursements.Business.DTOs;
using Reimbursements.Business.Interfaces;
using Reimbursements.DataAccess.Context.Entities;
using Reimbursements.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Claim = Reimbursements.DataAccess.Context.Entities.Claim;

namespace Reimbursements.Business.Services
{
    public class ClaimAppService : IClaimAppService

    {
        private readonly IMapper _mapper;
        private IClaimsRepository _claimRepository;
        private IBankRepository _bankRepository;
        private ICurrencyRepository _currencyRepository;
        private ITypesRepository _typesRepository;

        public ClaimAppService(IMapper mapper, IClaimsRepository claimRepository, IBankRepository bankRepository, ICurrencyRepository currencyRepository, ITypesRepository typesRepository)
        {
            _mapper = mapper;
            _claimRepository = claimRepository;
            _bankRepository = bankRepository;
            _typesRepository = typesRepository;
            _currencyRepository = currencyRepository;
        }

        /// <summary>
        /// Gete all claims from the repository
        /// </summary>
        /// <returns>Collection of all claims</returns>
        public IEnumerable<ClaimDTO> GetAllClaims()
        {
            var result = _claimRepository.All();
            return _mapper.Map<IEnumerable<ClaimDTO>>(result);
        }

        /// <summary>
        /// retrieve claim by claim Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>claim </returns>
        public ClaimDTO GetClaimById(int id)
        {
            var result = _claimRepository.GetById(id);
            return _mapper.Map<ClaimDTO>(result);
        }

        /// <summary>
        /// creating a claim
        /// </summary>
        /// <param name="claim"></param>
        public void CreateClaim(ClaimDTO claim)
        {
            var claimEntity = _mapper.Map<Claim>(claim);

            _claimRepository.Create(claimEntity);

            
        }

        /// <summary>
        /// updatoiing a claim
        /// </summary>
        /// <param name="id">claim id</param>
        /// <param name="claimdto">claim</param>

        public async void UpdateClaim(int id, ClaimDTO claimdto)
        {
            var claim = _mapper.Map<Claim>(claimdto);   
            claim.Id = id;
            _claimRepository.Update(claim);
           

            
        }

        /// <summary>
        /// deleting a claim
        /// </summary>
        /// <param name="id">claim id</param>
        /// <returns></returns>

        public bool DeleteClaim(int id)
        {
            var claim = _claimRepository.GetById(id);

            if (claim is null)
                return false;

            _claimRepository.Delete(claim);

            return true;
        }
        /// <summary>
        /// retriving all claims by creator email
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ClaimDTO> GetClaimByCreatorId(string id)
        {
            var claim = _claimRepository.Get(cl => cl.Creator == id);

            return _mapper.Map<IEnumerable<ClaimDTO>>(claim); ;
        }

        /// <summary>
        /// retrieving all banks
        /// </summary>
        /// <returns>collection of banks</returns>
        public IEnumerable<BankDTO> GetAllBanks()
        {
            var banks = _bankRepository.All();

            return _mapper.Map<IEnumerable<BankDTO>>(banks);
        }

        /// <summary>
        /// retriving all currencies
        /// </summary>
        /// <returns>collection of currencies</returns>
        public IEnumerable<CurrencyDTO> GetAllCurrencies()
        {
            var currencies = _currencyRepository.All();

            return _mapper.Map<IEnumerable<CurrencyDTO>>(currencies);
        }
        /// <summary>
        /// retreiving all reimbursement types
        /// </summary>
        /// <returns>collection of reimbursement typs</returns>
        public IEnumerable<ReimbursementTypeDTO> GetAllTypes()
        {
            var types = _typesRepository.All();

            return _mapper.Map<IEnumerable<ReimbursementTypeDTO>>(types);
        }

        /// <summary>
        /// retrieve reimbursemnt typ name
        /// </summary>
        /// <param name="id"></param>
        /// <returns>type name</returns>
        public string getTypeName(int id)
        {
            var name = _typesRepository.GetById(id);
            return name.Name;
        }

        /// <summary>
        /// retreive all pending claims
        /// </summary>
        /// <returns>collection of claims</returns>
        public IEnumerable<ClaimDTO> getAllPendingClaims()
        {
            var claims = _claimRepository.Get(claim => claim.Proccessed == false);

            return _mapper.Map<IEnumerable<ClaimDTO>>(claims);
        }
        /// <summary>
        /// retrieve all declined claims
        /// </summary>
        /// <returns>claims</returns>
        public IEnumerable<ClaimDTO> getAllDeclinedCLaims()
        {
            var claims = _claimRepository.Get(claim => claim.Proccessed == true && claim.Approved == false);

            return _mapper.Map<IEnumerable<ClaimDTO>>(claims);
        }
        /// <summary>
        /// retrieve all approved claims
        /// </summary>
        /// <returns>claims</returns>
        public IEnumerable<ClaimDTO> getAllApprovedCLaims()
        {
            var claims = _claimRepository.Get(claim => claim.Proccessed == true && claim.Approved == true);

            return _mapper.Map<IEnumerable<ClaimDTO>>(claims);
        }


    }
}

