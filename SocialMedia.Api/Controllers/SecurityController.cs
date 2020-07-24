using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Core.src.DTOs;
using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Enumerations;
using SocialMedia.Core.src.Interfaces.Services;
using SocialMedia.Infrastructure.src.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ISecurityService _securityService;


        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;


        /// <summary>
        /// 
        /// </summary>
        private readonly IUriService _uriService;




        public SecurityController(ISecurityService securityService,
                              IMapper mapper,
                              IUriService uriService)
        {
            _securityService = securityService;
            _mapper = mapper;
            _uriService = uriService;
        }


        [HttpPost]
        public async Task<IActionResult> Post(SecurityDto securityDto)
        {

            var security = _mapper.Map<Security>(securityDto);
            await _securityService.RegisterUser(security);


            securityDto = _mapper.Map<SecurityDto>(security);
            var response = new ApiResponse<SecurityDto>(securityDto);

            return Ok(response);
        }


    }
}
