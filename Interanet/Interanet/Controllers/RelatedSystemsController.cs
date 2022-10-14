using AutoMapper;
using Interanet.API.Security;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.View;
using Interanet.Model.View.Const;
using Interanet.Model.View.General;
using Interanet.Model.View.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interanet.API.Controllers
{
    public class RelatedSystemsController : AppControllerBase
    {
        private readonly IRelatedSystemService _RelatedSystemsService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;
        public RelatedSystemsController(IRelatedSystemService RelatedSystemsService, IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _RelatedSystemsService = RelatedSystemsService;
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        //################################################### Add ######################################################
        [Authorize(Roles = $"{UserTypes.USER},{UserTypes.ADMIN}")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(VmAddRelatedSystemRequest model)
        {
            VmRelatedSystemData UserData = new VmRelatedSystemData();
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                UserData.UserId = this.User.Identity.GetUserId();
                UserData.PublishDateTime = Convert.ToDateTime(model.PublishDateTime).ToLocalTime();
                Res = await _RelatedSystemsService.Add(model, UserData);
                if (Res.IsDone == false)
                    return BadRequest(Res.Message);
                return Ok(Res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
                //throw ex;
            }
        }
        //################################################### Update ######################################################
        [Authorize(Roles = $"{UserTypes.USER},{UserTypes.ADMIN}")]
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] VmUpdateRelatedSystemRequest model)
        {
            VmRelatedSystemData UserData = new VmRelatedSystemData();
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                UserData.UserId = this.User.Identity.GetUserId();
                UserData.PublishDateTime = Convert.ToDateTime(model.PublishDateTime).ToLocalTime();
                Res = await _RelatedSystemsService.Update(model, UserData);
                if (Res.IsDone == false)
                    return BadRequest(Res.Message);
                return Ok(Res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
                //throw ex;
            }
        }



        //################################################### Delete Single Item ######################################################
        [Authorize(Roles = $"{UserTypes.USER},{UserTypes.ADMIN}")]
        [HttpPost("Delete")]
        public async Task<IActionResult> Update([FromBody] VmDeleteRelatedSystemRequest model)
        {
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Res = await _RelatedSystemsService.Delete(model);
                if (Res.IsDone == false)
                    return BadRequest(Res.Message);
                return Ok(Res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
                //throw ex;
            }
        }


        //################################################### GetAll For Admin ######################################################


        [Authorize(Roles = UserTypes.ADMIN)]
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllForAdmin(Page Page)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = await _RelatedSystemsService.GetAllForAdmin(Page);
                var DataMapped = _mapper.Map<VmGetAdminRelatedSystemResponse>(Data);
                return Ok(DataMapped);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }


        //################################################### GetAll For Employee ######################################################
        [Authorize(Roles = UserTypes.USER)]
        [HttpPost("GetAllForEmp")]
        public async Task<IActionResult> GetAllForEmp(Page Page)
        {
            try
            {

                var CurrentUserId = this.User.Identity.GetUserId();
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = await _RelatedSystemsService.GetAllForEmp(this.User.Identity.GetUserId() , Page);
                var DataMapped = _mapper.Map<VmGetAdminRelatedSystemResponse>(Data);

                return Ok(  DataMapped );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [Authorize(Roles = $"{UserTypes.USER},{UserTypes.ADMIN}")]
        [HttpGet("GetAllRelatedSystemsUsers/{RelatedSystemId}")]
        public async Task<IActionResult> GetAllRelatedSystemsUsers(int RelatedSystemId)
        {
            try
            {
                string[] JoinedTables = { "ApplicationUser" };
                var Data = _UnitOfWork.ApplicationUserRelatedSystems.FindAll(x => x.RelatedSystemId == RelatedSystemId, JoinedTables).Select(x => new
                {
                    id = x.ApplicationUser.Id,
                    name = x.ApplicationUser.FullName
                }).ToList();

                return Ok(Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }




    }
}
