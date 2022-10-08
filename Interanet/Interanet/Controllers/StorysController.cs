using AutoMapper;
using Interanet.API.Security;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.Const;
using Interanet.Model.View.General;
using Interanet.Model.View.Story;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interanet.API.Controllers
{
    public class StorysController :AppControllerBase
    {
        private readonly IStorysService _StorysService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _UnitOfWork;
    public StorysController(IStorysService StorysService, IMapper mapper, IUnitOfWork UnitOfWork)
    {
        _StorysService = StorysService;
        _mapper = mapper;
        _UnitOfWork = UnitOfWork;
    }

    //################################################### Add ######################################################
    [Authorize(Roles = UserTypes.ADMIN)]
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] VmAddStoryRequest model)
    {
        VmUserData UserData = new VmUserData();
        VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Data = _mapper.Map<Storys>(model);
            UserData.UserId = this.User.Identity.GetUserId();
            UserData.PublishDateTime = Convert.ToDateTime(model.PublishDateTime).ToLocalTime();
            Res = await _StorysService.Add(Data, UserData);
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
    public async Task<IActionResult> Update([FromBody] VmUpdateStoryRequest model)
    {
        VmUserData UserData = new VmUserData();
        VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            UserData.UserId = this.User.Identity.GetUserId();
            UserData.PublishDateTime = Convert.ToDateTime(model.PublishDateTime).ToLocalTime();
            Res = await _StorysService.Update(model, UserData);
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
    public async Task<IActionResult> Update([FromBody] VmDeleteStoryRequest model)
    {
        VmAddUpdateDeleteResponse Res = new VmAddUpdateDeleteResponse();
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Res = await _StorysService.Delete(model);
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
        VmGetAdminStoryResponse Res = new VmGetAdminStoryResponse();
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Data = await _StorysService.GetAllForAdmin(Page);
            var DataMapped = _mapper.Map<VmGetAdminStoryResponse>(Data);
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
    public async Task<IActionResult> GetAllForEmployeesByGroup(Page Page)
    {
        int GroupId = 1;  // that mean All Groups 
        int.TryParse(this.User.Identity.GetUserGroupId(), out GroupId);

        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Data = await _StorysService.GetAllForEmployeesByGroup(GroupId, Page);
            var DataMapped = _mapper.Map<VmGetAdminStoryResponse>(Data);
            return Ok(DataMapped);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException);
        }
    }





}
}
