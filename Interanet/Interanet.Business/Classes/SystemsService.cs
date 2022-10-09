using Interanet.Business.Constant;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.General;
using Interanet.Model.View.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Classes
{
    public class SystemsService : ISystemsService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public SystemsService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }


        public async Task<VmAddUpdateDeleteResponse> Add(Systems Request, VmUserData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                var AnnData = _UnitOfWork.Systems.CountAsync(x => x.SystemName == Request.SystemName && x.EmployeeUserId == Request.EmployeeUserId).Result;
                if (AnnData > 0)
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.DUBLICATE_NAME_ERROR_MESSAGE + $" in EmployeeId : {Request.EmployeeUserId}";
                    return Response;
                }

                Request.InsertUserId = UserData.UserId;
                Request.InsertUserDate = DateTime.UtcNow.ToLocalTime();
                Request.PublishDateTime = UserData.PublishDateTime;
                await _UnitOfWork.Systems.AddAsync(Request);
                if (_UnitOfWork.Complete() > 0)
                {
                    Response.IsDone = true;
                    Response.Message = OkMessages.ADD_Ok_MESSAGE;
                    return Response;
                }
                else
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.ADD_ERROR_MESSAGE;
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response.IsDone = false;
                Response.Message = ErrorMessages.ADD_ERROR_MESSAGE;
                throw ex;
            }

        }



        public async Task<VmAddUpdateDeleteResponse> Update(VmUpdateSystemRequest Request, VmUserData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                var AnnData = _UnitOfWork.Systems.CountAsync(x => x.SystemName == Request.SystemName && x.EmployeeUserId == Request.EmployeeUserId && x.Id != Request.Id).Result;
                if (AnnData > 0)
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.DUBLICATE_NAME_ERROR_MESSAGE + $" in EmployeeId Num : {Request.EmployeeUserId}";
                    return Response;
                }

                Systems Data = _UnitOfWork.Systems.GetByIdAsync(Request.Id).Result;
                if (Data is not null)
                {

                    Data.SystemName = Request.SystemName;
                    Data.Link = Request.Link;
                    Data.EmployeeUserId = Request.EmployeeUserId;
                    Data.isScheduledPublish = Request.isScheduledPublish;
                    Data.PublishDateTime = UserData.PublishDateTime;
                    Data.UpdateUserId = UserData.UserId;
                    Data.UpdateUserDate = DateTime.UtcNow.ToLocalTime();
                    _UnitOfWork.Systems.Update(Data);
                    if (_UnitOfWork.Complete() > 0)
                    {
                        Response.IsDone = true;
                        Response.Message = OkMessages.UPDATE_Ok_MESSAGE;
                        return Response;
                    }
                    else
                    {
                        Response.IsDone = false;
                        Response.Message = ErrorMessages.UPDATE_ERROR_MESSAGE;
                        return Response;
                    }
                }
                else
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.NotFount_ERROR_MESSAGE;
                    return Response;
                }

            }
            catch (Exception ex)
            {
                Response.IsDone = false;
                Response.Message = ErrorMessages.UPDATE_ERROR_MESSAGE;
                throw ex;
            }

        }


        public async Task<VmAddUpdateDeleteResponse> Delete(VmDeleteSystemRequest Request)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                Systems Data = _UnitOfWork.Systems.GetByIdAsync(Request.Id).Result;
                if (Data is not null)
                {
                    _UnitOfWork.Systems.Delete(Data);
                    if (_UnitOfWork.Complete() > 0)
                    {
                        Response.IsDone = true;
                        Response.Message = OkMessages.DELETE_Ok_MESSAGE;
                        return Response;
                    }
                    else
                    {
                        Response.IsDone = false;
                        Response.Message = ErrorMessages.DELETE_ERROR_MESSAGE;
                        return Response;
                    }
                }
                else
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.NotFount_ERROR_MESSAGE;
                    return Response;
                }

            }
            catch (Exception ex)
            {
                Response.IsDone = false;
                Response.Message = ErrorMessages.DELETE_ERROR_MESSAGE;
                throw ex;
            }

        }



        public async Task<VmGetAdminSystemServiceResponse> GetAllForAdmin(Page Page)
        {
            VmGetAdminSystemServiceResponse Response = new VmGetAdminSystemServiceResponse();
            try
            {
                bool IsEmpty = false;
                if (string.IsNullOrWhiteSpace(Page.Filter))
                {
                    IsEmpty = true;
                }


                var Data = _UnitOfWork.Systems.FindAll(
                  r => IsEmpty || r.SystemName.Contains(Page.Filter)
                               || r.ApplicationUser_InsertUser.FullName.Contains(Page.Filter)
                               || r.ApplicationUser_UpdateUser.FullName.Contains(Page.Filter))
                    .ToList().OrderByDescending(O => O.Id);

                Page.TotalElements = Data.Count();
                var skipped = Data.Take((Page.PageNumber + 1) * Page.Size).Skip((Page.PageNumber) * Page.Size).ToList();
                Response.Data = skipped;
                if (skipped.Count > 0)
                    Response.Page = Page;
                Response.Data = skipped;
                Response.Page = Page;
                return Response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public async Task<VmGetAdminSystemServiceResponse> GetAllForEmployee(string EmployeeUserId)
        {
            VmGetAdminSystemServiceResponse Response = new VmGetAdminSystemServiceResponse();
            try
            {
                var Data = _UnitOfWork.Systems.FindAll(x => x.PublishDateTime <= DateTime.Now && x.EmployeeUserId == EmployeeUserId).ToList();
                Response.Data = Data;
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}
