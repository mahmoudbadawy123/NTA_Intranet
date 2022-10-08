using AutoMapper;
using Interanet.API.Security;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.Announcement;
using Interanet.Model.View.Const;
using Interanet.Model.View.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interanet.API.Controllers
{

    public class AnnouncementsController : AppControllerBase
    {
        private readonly IAnnouncementsService _AnnouncementsService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;
        public AnnouncementsController(IAnnouncementsService AnnouncementsService , IMapper mapper  , IUnitOfWork UnitOfWork)
        {
            _AnnouncementsService=AnnouncementsService;
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        //################################################### Add ######################################################
        [Authorize(Roles = UserTypes.ADMIN)]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] VmAddAnnouncementRequest model)
        {
            VmUserData UserData = new VmUserData();
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = _mapper.Map<Announcements>(model);
                UserData.UserId = this.User.Identity.GetUserId();
                UserData.PublishDateTime = Convert.ToDateTime(model.PublishDateTime).ToLocalTime();
                Res =  await _AnnouncementsService.Add(Data , UserData );
                if(Res.IsDone == false)
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
        [Authorize(Roles = UserTypes.ADMIN)]
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] VmUpdateAnnouncementRequest model)
        {
            VmUserData UserData = new VmUserData();
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                UserData.UserId = this.User.Identity.GetUserId();
                UserData.PublishDateTime = Convert.ToDateTime(model.PublishDateTime).ToLocalTime();
                Res = await _AnnouncementsService.Update(model, UserData);
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
        [Authorize(Roles = UserTypes.ADMIN)]
        [HttpPost("Delete")]
        public async Task<IActionResult> Update([FromBody] VmDeleteAnnouncementRequest model)
        {
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Res = await _AnnouncementsService.Delete(model);
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
            VmGetAdminAnnouncementResponse Res = new VmGetAdminAnnouncementResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = await _AnnouncementsService.GetAllForAdmin(Page);
                var DataMapped =  _mapper.Map<VmGetAdminAnnouncementResponse>(Data) ;
                //Res.Data = _mapper.Map<List<VmAnnouncementResponse>>(Data.Data);
                //Res.Page = Data.Page;
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
        public async Task<IActionResult> GetAllForEmployeesByGroup(  Page Page)
        {
            int GroupId = 1;  // that mean All Groups 
            int.TryParse( this.User.Identity.GetUserGroupId(), out  GroupId);
            
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = await _AnnouncementsService.GetAllForEmployeesByGroup(GroupId, Page);
                var DataMapped = _mapper.Map<VmGetAdminAnnouncementResponse>(Data);
                return Ok(DataMapped);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }





    }
}
