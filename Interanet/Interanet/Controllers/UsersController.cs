using AutoMapper;
using Interanet.API.Security;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interanet.API.Controllers
{

    public class UsersController : AppControllerBase
    {
        //private readonly IUserGroupsService _UserGroupsService;
                private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public UsersController( IMapper mapper , IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

      

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var Data = _unitOfWork.ApplicationUser.FindAllAsync(x=>x.Id != this.User.Identity.GetUserId()).Result;
                var DataMapped = _mapper.Map<List<UserLookUpViewModel>>(Data);
                return Ok(DataMapped);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }


    }
}
