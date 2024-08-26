using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reimbursements.Business.DTOs;
using Reimbursements.Business.Interfaces;

namespace Reimbursements.WebApi.Controllers
{
    [Route("api/claims")]
    [ApiController]
    [Authorize]
    public class ClaimsController : Controller
    {

        private IClaimAppService _claimAppService;
        private readonly IMapper _mapper;

        public ClaimsController(IClaimAppService claimAppService, IMapper mapper)
        {
            _claimAppService = claimAppService;
            _mapper = mapper;
        }

        [HttpGet("GetClaimById/:id")]
        public ClaimDTO Get(int id)
        {
            try {
                var claim = _claimAppService.GetClaimById(id);
                return claim;
            }
            catch
            {
                throw new Exception("Bad Request");
            }
        }

        

        // POST: ClaimsController/Create
        [HttpPost("CreateClaim")]
        
        public ActionResult Create([FromBody] ClaimDTO claimDTO)
        {
            //if (claimDTO == null || !ModelState.IsValid)
            //    return BadRequest();

            _claimAppService.CreateClaim(claimDTO);

            return StatusCode(201);
        }

        // GET: ClaimsController/Edit/5
       

        // POST: ClaimsController/Edit/5
        [HttpPatch("UpdateClaim/:id")]
        
        public ActionResult Update(int id, [FromBody] ClaimDTO claim)
        {

            try
            {
                _claimAppService.UpdateClaim(id,claim);
                return StatusCode(201);
            }
            catch (Exception)
            {
                return BadRequest();
                
            }

            
        }

        // GET: ClaimsController/Delete/5
        

        // POST: ClaimsController/Delete/5
        [HttpDelete("DeleteClaim/:id")]
     
        public ActionResult Delete(int id)
        {
            try
            {
                _claimAppService.DeleteClaim(id);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }

            
        }

        [HttpGet("GetAllClaims")]

        public IEnumerable<ClaimDTO> GetAllClaims()
        {
            try
            {
                var result =  _claimAppService.GetAllClaims();
                return result;
            }
            catch
            {
                throw new Exception("BadRequest");
            }
            
        }

        [HttpGet("GetAllClaimsByUserId/:id")]

        public IEnumerable<ClaimDTO> GetByCreator(string id) 
        {
            try
            {
                var result = _claimAppService.GetClaimByCreatorId(id);
                
                return result;
            }
            catch
            {
                throw new Exception("Bad request");
            }
        }


        [HttpGet("GetAllBanks")]
        public IEnumerable<BankDTO> GetBankDTOs()
        {
            try
            {
                var results = _claimAppService.GetAllBanks();
                return results;
            }
            catch
            {
                throw new Exception("bad request");
            }
        }

        [HttpGet("GetAllCurrencies")]

        public IEnumerable<CurrencyDTO> GetAllCurrencies()
        {
            try
            {
                var results = _claimAppService.GetAllCurrencies();
                return results;
            }
            catch
            {
                throw new Exception("bad request");
            }
        }

        [HttpGet("GetAllReimbursementTypes")]

        public IEnumerable<ReimbursementTypeDTO> GetAllTypes()
        {
            try
            {
                var results = _claimAppService.GetAllTypes();
                return results;
            }
            catch
            {
                throw new Exception("bad request");
            }
        }

        [HttpGet("Gettypename/:id")]

        public string GetNameOftype(int id)
        {
            try
            {
                var name = _claimAppService.getTypeName(id);
                return name;
            }
            catch
            {
                throw new Exception("bad request");
            }
        }


        [HttpGet("GetAllPendingClaims")]

        public IEnumerable<ClaimDTO> GetPendingClaims()
        {
            try
            {
                var claims = _claimAppService.getAllPendingClaims();
                return claims;
            }
            catch
            {
                throw new Exception("Bad Request");
            }
        }

        [HttpGet("GetAllDeclinedClaims")]

        public IEnumerable<ClaimDTO> GetDeclinedClaims()
        {
            try
            {
                var claims = _claimAppService.getAllDeclinedCLaims();
                return claims;
            }
            catch
            {
                throw new Exception("Bad Request");
            }
        }

        [HttpGet("GetAllApprovedClaims")]

        public IEnumerable<ClaimDTO> GetApprovedClaims()
        {
            try
            {
                var claims = _claimAppService.getAllApprovedCLaims();
                return claims;
            }
            catch
            {
                throw new Exception("Bad Request");
            }
        }

        
    }
}
