using AutoMapper;
using Interanet.API.Security;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View.Const;
using Interanet.Model.View.General;
using Interanet.Model.View.Meetings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interanet.API.Controllers
{
    public class MeetingsController : AppControllerBase
    {
        private readonly IMeetingsService _MeetingsService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;
        public MeetingsController(IMeetingsService MeetingsService, IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _MeetingsService = MeetingsService;
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        //################################################### Add ######################################################
        [Authorize(Roles = $"{UserTypes.USER},{UserTypes.ADMIN}")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add( VmAddMeetingRequest model)
        {
            VmMeetingData UserData = new VmMeetingData();
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                UserData.UserId = this.User.Identity.GetUserId();
                UserData.PublishDateTime = Convert.ToDateTime(model.PublishDateTime).ToLocalTime();
                UserData.MeatingDateTime = Convert.ToDateTime(model.MeatingDateTime).ToLocalTime();
                Res = await _MeetingsService.Add(model, UserData);
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
        public async Task<IActionResult> Update([FromBody] VmUpdateMeetingRequest model)
        {
            VmMeetingData UserData = new VmMeetingData();
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                UserData.UserId = this.User.Identity.GetUserId();
                UserData.PublishDateTime = Convert.ToDateTime(model.PublishDateTime).ToUniversalTime().ToLocalTime();
                UserData.MeatingDateTime = Convert.ToDateTime(model.MeatingDateTime).ToUniversalTime().ToLocalTime();
                Res = await _MeetingsService.Update(model, UserData);
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
        public async Task<IActionResult> Update([FromBody] VmDeleteMeetingRequest model)
        {
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Res = await _MeetingsService.Delete(model);
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
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllForAdmin()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = await _MeetingsService.GetAllForAdmin();
                var DataMapped = _mapper.Map<List<VmMeetingResponse>>(Data);
                return Ok(DataMapped);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }


        //################################################### GetAll For Employee ######################################################
        [Authorize(Roles = UserTypes.USER)]
        [HttpGet("GetAllForEmp")]
        public async Task<IActionResult> GetAllForEmp()
        {
            try
            {

                var CurrentUserId = this.User.Identity.GetUserId();
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = await _MeetingsService.GetAllForEmp(this.User.Identity.GetUserId());
                var DataMapped = _mapper.Map<List<VmMeetingResponse>>(Data);
                
                return Ok(new { CurrentUser =CurrentUserId,Data= DataMapped});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        //[Authorize(Roles = $"{UserTypes.USER},{UserTypes.ADMIN}")]
        //[HttpGet("GetAllMeetingsUsers/{MeetingId}")]
        //public async Task<IActionResult> GetAllMeetingsUsers(int MeetingId)
        //{
        //    try
        //    {
        //        string[] JoinedTables = { "ApplicationUser" };
        //        var Data = _UnitOfWork.ApplicationUserMeetings.FindAll(x => x.MeetingId == MeetingId, JoinedTables).Select(x=>new
        //        {
        //            id=x.ApplicationUser.Id,
        //            name = x.ApplicationUser.FullName
        //        }).ToList();

        //        return Ok(Data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.InnerException);
        //    }
        //}




    }
}
