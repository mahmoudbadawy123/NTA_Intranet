using Interanet.Business.Constant;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.Announcement;
using Interanet.Model.View.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Classes
{
    public class AnnouncementsService : IAnnouncementsService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public AnnouncementsService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }


        public async Task<VmAddUpdateDeleteResponse> Add(Announcements Request, VmUserData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                var AnnData = _UnitOfWork.Announcements.CountAsync(x => x.LabelName == Request.LabelName && x.GroupId == Request.GroupId).Result;
                if (AnnData > 0)
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.DUBLICATE_NAME_ERROR_MESSAGE + $" in Group Num : {Request.GroupId}";
                    return Response;
                }

                Request.InsertUserId = UserData.UserId;
                Request.InsertUserDate = DateTime.UtcNow.ToLocalTime();
                Request.PublishDateTime = UserData.PublishDateTime ;
                await _UnitOfWork.Announcements.AddAsync(Request);
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



        public async Task<VmAddUpdateDeleteResponse> Update(VmUpdateAnnouncementRequest Request, VmUserData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                var AnnData = _UnitOfWork.Announcements.CountAsync(x => x.LabelName == Request.LabelName && x.GroupId == Request.GroupId && x.Id != Request.Id).Result;
                if (AnnData > 0)
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.DUBLICATE_NAME_ERROR_MESSAGE + $" in Group Num : {Request.GroupId}";
                    return Response;
                }

                Announcements Data = _UnitOfWork.Announcements.GetByIdAsync(Request.Id).Result;
                if (Data is not null)
                {
        
                    Data.LabelName = Request.LabelName;
                    Data.MessageBody = Request.MessageBody;
                    Data.GroupId = Request.GroupId;
                    Data.isScheduledPublish = Request.isScheduledPublish;
                    Data.PublishDateTime = UserData.PublishDateTime;
                    Data.UpdateUserId = UserData.UserId;
                    Data.UpdateUserDate = DateTime.UtcNow.ToLocalTime();
                    _UnitOfWork.Announcements.Update(Data);
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


        public async Task<VmAddUpdateDeleteResponse> Delete(VmDeleteAnnouncementRequest Request)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                Announcements Data = _UnitOfWork.Announcements.GetByIdAsync(Request.Id).Result;
                if (Data is not null)
                {
                    _UnitOfWork.Announcements.Delete(Data);
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



        public async Task<VmGetAdminAnnouncementServiceResponse> GetAllForAdmin(Page Page)
        {
            VmGetAdminAnnouncementServiceResponse Response = new VmGetAdminAnnouncementServiceResponse();
            try
            {
                // Eager Loading to Solve Problem of  navigation-property Return Null Value instead of Data 
                string[] JoinedTables = { "UserGroups", "ApplicationUser_InsertUserId", "ApplicationUser_UpdateUserId" };
                bool IsEmpty = false;
                if (string.IsNullOrWhiteSpace(Page.Filter))
                {
                    IsEmpty = true;
                }
                var Data = _UnitOfWork.Announcements.FindAll(
                    r => IsEmpty || r.LabelName.Contains(Page.Filter)
                                 || r.ApplicationUser_InsertUserId.FullName.Contains(Page.Filter)
                                 || r.ApplicationUser_UpdateUserId.FullName.Contains(Page.Filter)
                                 , JoinedTables).ToList().OrderByDescending(O => O.Id);

                //var Data = _UnitOfWork.Announcements.FindAll(
                //  r => IsEmpty || r.LabelName.Contains(Page.Filter)
                //               || r.ApplicationUser_InsertUserId.FullName.Contains(Page.Filter)
                //               || r.ApplicationUser_UpdateUserId.FullName.Contains(Page.Filter))
                //    .ToList().OrderByDescending(O => O.Id);

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



        public async Task<VmGetAdminAnnouncementServiceResponse> GetAllForEmployeesByGroup(int GroupId, Page Page)
        {
            VmGetAdminAnnouncementServiceResponse Response = new VmGetAdminAnnouncementServiceResponse();
            try
            {
                //// Eager Loading to Solve 
                string[] JoinedTables = { "UserGroups", "ApplicationUser_InsertUserId", "ApplicationUser_UpdateUserId" };
                var Data = _UnitOfWork.Announcements.FindAll(x => x.PublishDateTime <= DateTime.Now && (x.GroupId == 1 || x.GroupId == GroupId)
                , JoinedTables).ToList().OrderByDescending(O => O.Id);

                //var Data = _UnitOfWork.Announcements.FindAll(x => x.PublishDateTime <= DateTime.Now && (x.GroupId == 1 || x.GroupId == GroupId)).ToList().OrderByDescending(O => O.Id);

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
