using AutoMapper;
using Interanet.Business.Interfaces;
using Interanet.Model.View.LookUps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interanet.API.Controllers
{

    public class UserGroupsController : AppControllerBase
    {
        private readonly IUserGroupsService _UserGroupsService;
        private readonly IMapper _mapper;
        public UserGroupsController(IUserGroupsService UserGroupsService, IMapper mapper)
        {
            _UserGroupsService = UserGroupsService;
            _mapper = mapper;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllGroups()
        {
            try
            {
                var Data =  _UserGroupsService.GetAllGroups().Result;
                var DataMapped = _mapper.Map<List<VmGroups>>(Data);
                return Ok(DataMapped);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }


    }
}
