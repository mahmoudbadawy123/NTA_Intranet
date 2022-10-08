using AutoMapper;
using Interanet.API.Security;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View.Calender;
using Interanet.Model.View.Const;
using Interanet.Model.View.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interanet.API.Controllers
{
 
    public class CalenderEventsController : AppControllerBase
    {
        private readonly ICalenderEventsService _CalenderEventsService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;
        public CalenderEventsController(ICalenderEventsService CalenderEventsService, IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _CalenderEventsService = CalenderEventsService;
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        //################################################### Add ######################################################
        [Authorize(Roles = UserTypes.ADMIN)]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] VmAddCalenderEventRequest model)
        {
            VmEventUserData UserData = new VmEventUserData();
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = _mapper.Map<CalenderEvents>(model);
                UserData.UserId = this.User.Identity.GetUserId();
                UserData.EventDateTime = Convert.ToDateTime(model.EventDateTime).ToLocalTime();
                Res = await _CalenderEventsService.Add(Data, UserData);
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
        [Authorize(Roles = UserTypes.ADMIN)]
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] VmUpdateCalenderEventRequest model)
        {
            VmEventUserData UserData = new VmEventUserData();
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                UserData.UserId = this.User.Identity.GetUserId();
                UserData.EventDateTime = Convert.ToDateTime(model.EventDateTime).ToLocalTime();
                Res = await _CalenderEventsService.Update(model, UserData);
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
        public async Task<IActionResult> Update([FromBody] VmDeleteCalenderEventRequest model)
        {
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Res = await _CalenderEventsService.Delete(model);
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
            VmGetAdminCalenderEventResponse Res = new VmGetAdminCalenderEventResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = await _CalenderEventsService.GetAllForAdmin();
                var DataMapped = _mapper.Map<VmGetAdminCalenderEventResponse>(Data);
                //Res.Data = _mapper.Map<List<VmCalenderEventResponse>>(Data.Data);
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
        [HttpGet("GetAllForEmp")]
        public async Task<IActionResult> GetAllForEmployeesByGroup()
        {
            int GroupId = 1;  // that mean All Groups 
            int.TryParse(this.User.Identity.GetUserGroupId(), out GroupId);

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = await _CalenderEventsService.GetAllForEmployeesByGroup(GroupId);
                var DataMapped = _mapper.Map<VmGetAdminCalenderEventResponse>(Data);
                return Ok(DataMapped);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }





    }
}
