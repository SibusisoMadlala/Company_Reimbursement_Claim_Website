using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Reimbursements.Business.DTOs;
using Reimbursements.Business.Interfaces;
using Reimbursements.DataAccess.Context.Entities;
using Reimbursements.WebApi;
using System.IdentityModel.Tokens.Jwt;

namespace Reimbursements.Controllers
{
    [Route("api/accounts")]
    
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ReimbursementsUser> _userManager;
        private readonly IMapper _mapper; 
        private readonly JwtHandler _jwtHandler; // token creator
        private IClaimAppService _claimAppService;
        public AccountsController(UserManager<ReimbursementsUser> userManager, IMapper mapper, JwtHandler jwtHandler, IClaimAppService claimAppService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _claimAppService = claimAppService;
        }

        /// <summary>
        /// Register a new user to the application
        /// </summary>
        /// <param name="userForRegistration"></param>
        /// <returns> if the fetched user data is null return badrequest
        /// if  the usermanager could not create user return badrequest
        /// else return status code 201 for success
        /// </returns>
        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var user = _mapper.Map<ReimbursementsUser>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegitrationResponseDTO { Errors = errors });
            }

            return StatusCode(201);
        }
        /// <summary>
        /// Login user 
        /// </summary>
        /// <param name="userForAuthentication"></param>
        /// <returns>Unauthorized if user is not authenticated
        /// returns AuthRespose with a generated token
        /// </returns>

        [HttpPost("Login")]
        public async Task<IActionResult> Login( UserForAuthenticationDTO userForAuthentication)
        {
            var user = await _userManager.FindByEmailAsync(userForAuthentication.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDTO { ErrorMessage = "Invalid Authentication" });
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseDTO { IsAuthSuccessful = true, Token = token, IsApprover = user.IsApprover });
        }

        /// <summary>
        /// retreive  all banks in the app service
        /// </summary>
        /// <returns>collection of all banks</returns>
        /// <exception cref="Exception"></exception>
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
    }
}
