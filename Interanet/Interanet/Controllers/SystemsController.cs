using AutoMapper;
using Interanet.API.Security;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.Const;
using Interanet.Model.View.General;
using Interanet.Model.View.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interanet.API.Controllers
{
    public class SystemsController : AppControllerBase
    {
        private readonly ISystemsService _SystemsService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;
        public SystemsController(ISystemsService SystemsService, IMapper mapper, IUnitOfWork UnitOfWork)
        {
            _SystemsService = SystemsService;
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
        }

        //################################################### Add ######################################################
        [Authorize(Roles = UserTypes.ADMIN)]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] VmAddSystemRequest model)
        {
            VmUserData UserData = new VmUserData();
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = _mapper.Map<Systems>(model);
                UserData.UserId = this.User.Identity.GetUserId();
                UserData.PublishDateTime = Convert.ToDateTime(model.PublishDateTime).ToLocalTime();
                Res = await _SystemsService.Add(Data, UserData);
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
        public async Task<IActionResult> Update([FromBody] VmUpdateSystemRequest model)
        {
            VmUserData UserData = new VmUserData();
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                UserData.UserId = this.User.Identity.GetUserId();
                UserData.PublishDateTime = Convert.ToDateTime(model.PublishDateTime).ToLocalTime();
                Res = await _SystemsService.Update(model, UserData);
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
        public async Task<IActionResult> Update([FromBody] VmDeleteSystemRequest model)
        {
            VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                Res = await _SystemsService.Delete(model);
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
            VmGetAdminSystemResponse Res = new VmGetAdminSystemResponse();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = await _SystemsService.GetAllForAdmin(Page);
                var DataMapped = _mapper.Map<VmGetAdminSystemResponse>(Data);
                //Res.Data = _mapper.Map<List<VmSystemResponse>>(Data.Data);
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
        
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var Data = await _SystemsService.GetAllForEmployee(this.User.Identity.GetUserId());
                var DataMapped = _mapper.Map<VmGetAdminSystemResponse>(Data);
                return Ok(DataMapped);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }


        [Authorize(Roles = UserTypes.USER)]
        [HttpPost("RedirectToAnotherApp")]
        public async Task<IActionResult> RedirectToAnotherApp()
        {

            try
            {
                //if (!ModelState.IsValid)
                //    return BadRequest(ModelState);
                //var Data = await _SystemsService.GetAllForEmployee(this.User.Identity.GetUserId());
                //var DataMapped = _mapper.Map<VmGetAdminSystemResponse>(Data);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }





    }
}
