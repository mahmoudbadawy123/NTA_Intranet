using Interanet.Business.Constant;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.General;
using Interanet.Model.View.Story;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Classes
{
    public class StorysService : IStorysService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public StorysService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }


        public async Task<VmAddUpdateDeleteResponse> Add(Storys Request, VmUserData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                var AnnData = _UnitOfWork.Storys.CountAsync(x => x.Header == Request.Header && x.GroupId == Request.GroupId).Result;
                if (AnnData > 0)
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.DUBLICATE_NAME_ERROR_MESSAGE + $" in Group Num : {Request.GroupId}";
                    return Response;
                }

                Request.InsertUserId = UserData.UserId;
                Request.InsertUserDate = DateTime.UtcNow.ToLocalTime();
                Request.PublishDateTime = UserData.PublishDateTime;
                await _UnitOfWork.Storys.AddAsync(Request);
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






        public async Task<VmAddUpdateDeleteResponse> Update(VmUpdateStoryRequest Request, VmUserData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                var AnnData = _UnitOfWork.Storys.CountAsync(x => x.Header == Request.Header && x.GroupId == Request.GroupId && x.Id != Request.Id).Result;
                if (AnnData > 0)
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.DUBLICATE_NAME_ERROR_MESSAGE + $" in Group Num : {Request.GroupId}";
                    return Response;
                }

                Storys Data = _UnitOfWork.Storys.GetByIdAsync(Request.Id).Result;
                if (Data is not null)
                {

                    Data.Header = Request.Header;
                    Data.Body = Request.Body;
                    Data.GroupId = Request.GroupId;
                    Data.isScheduledPublish = Request.isScheduledPublish;
                    Data.PublishDateTime = UserData.PublishDateTime;
                    Data.UpdateUserId = UserData.UserId;
                    Data.UpdateUserDate = DateTime.UtcNow.ToLocalTime();
                    _UnitOfWork.Storys.Update(Data);
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









        public async Task<VmAddUpdateDeleteResponse> Delete(VmDeleteStoryRequest Request)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                Storys Data = _UnitOfWork.Storys.GetByIdAsync(Request.Id).Result;
                if (Data is not null)
                {
                    _UnitOfWork.Storys.Delete(Data);
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






        public async Task<VmGetAdminStoryServiceResponse> GetAllForAdmin(Page Page)
        {
            VmGetAdminStoryServiceResponse Response = new VmGetAdminStoryServiceResponse();
            try
            {
                bool IsEmpty = false;
                if (string.IsNullOrWhiteSpace(Page.Filter))
                {
                    IsEmpty = true;
                }
                var Data = _UnitOfWork.Storys.FindAll(
                  r => IsEmpty || r.Header.Contains(Page.Filter)
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



        public async Task<VmGetAdminStoryServiceResponse> GetAllForEmployeesByGroup(int GroupId, Page Page)
        {
            VmGetAdminStoryServiceResponse Response = new VmGetAdminStoryServiceResponse();
            try
            {
                var Data = _UnitOfWork.Storys.FindAll(x => x.PublishDateTime <= DateTime.Now && (x.GroupId == 1 || x.GroupId == GroupId)).ToList().OrderByDescending(O => O.Id);
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


    }
}