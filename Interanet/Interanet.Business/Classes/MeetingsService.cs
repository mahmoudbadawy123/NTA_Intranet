using Interanet.Business.Constant;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View.General;
using Interanet.Model.View.Meetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Classes
{
    public class MeetingsService : IMeetingsService
    {

        private readonly IUnitOfWork _UnitOfWork;
        public MeetingsService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public async Task<VmAddUpdateDeleteResponse> Add(VmAddMeetingRequest Request, VmMeetingData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                var AnnData = _UnitOfWork. Meetings.CountAsync(x => x.MeatingName == Request.MeatingName).Result;
                if (AnnData > 0)
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.DUBLICATE_NAME_ERROR_MESSAGE + $" in Meating Num : {Request.MeatingName}";
                    return Response;
                }

                Request.InsertUserId = UserData.UserId;
                Request.InsertUserDate = DateTime.UtcNow.ToLocalTime();
                Request.MeatingDateTime = UserData.MeatingDateTime;

                Meeting Data = new Meeting();
                Data.Id = (_UnitOfWork.Meetings.GetAll().Select(x => (int?)x.Id).Max() ?? 0) +1; 
                Data.PublishDateTime = Request.PublishDateTime;
                Data.Description = Request.Description;
                Data.isScheduledPublish = Request.isScheduledPublish;
                Data.InsertUserId = Request.InsertUserId;
                Data.InsertUserDate = Request.InsertUserDate;
                Data.MeatingDateTime = Request.MeatingDateTime;
                Data.MeatingLink = Request.MeatingLink;
                Data.MeatingLocation = Request.MeatingLocation;
                Data.MeatingName = Request.MeatingName;
                Data.MeatingTypeId = Request.MeatingTypeId;
                List<ApplicationUserMeeting> UserMeetings = new List<ApplicationUserMeeting>();
                foreach (var item in Request.RecieverUserIds)
                {
                    ApplicationUserMeeting UserMeeting = new ApplicationUserMeeting();
                    UserMeeting.MeetingId = Data.Id;
                    UserMeeting.ApplicationUserId = item.Id;
                    UserMeetings.Add(UserMeeting);
                }
                Data.ApplicationUserMeetings = UserMeetings;
                await _UnitOfWork.Meetings.AddAsync(Data);

                if (_UnitOfWork.Complete() > 0)
                {
                    var x = Data;
                
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

        public async Task<VmAddUpdateDeleteResponse> Delete(VmDeleteMeetingRequest Request)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                Meeting Data = _UnitOfWork.Meetings.GetByIdAsync(Request.Id).Result;
                if (Data is not null)
                {
                    _UnitOfWork.Meetings.Delete(Data);
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

        public async Task<List<Meeting>> GetAllForAdmin()
        {
            VmGetAdminMeetingServiceResponse Response = new VmGetAdminMeetingServiceResponse();
            try
            {
                string[] JoinedTables = { "ApplicationUserMeetings", "MeetingTypes", "ApplicationUser_InsertUser", "ApplicationUser_UpdateUser" };
                List<Meeting> Data = _UnitOfWork.Meetings.FindAll(x=>true, JoinedTables).ToList();
                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Meeting>> GetAllForEmp(string UserId)
        {
            VmGetAdminMeetingServiceResponse Response = new VmGetAdminMeetingServiceResponse();
            try
            {
                string[] JoinedTables = { "ApplicationUserMeetings", "MeetingTypes", "ApplicationUser_InsertUser", "ApplicationUser_UpdateUser" };
                List<Meeting> Data = _UnitOfWork.Meetings.FindAll(x => x.InsertUserId == UserId
                || x.ApplicationUserMeetings.Select(x=> x.ApplicationUserId).Contains(UserId), JoinedTables).ToList();
                return Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<VmAddUpdateDeleteResponse> Update(VmUpdateMeetingRequest Request, VmMeetingData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                Meeting Data = _UnitOfWork.Meetings.GetByIdAsync(Request.Id).Result;
                Data.PublishDateTime = Request.PublishDateTime;
                Data.Description = Request.Description;
                Data.isScheduledPublish = Request.isScheduledPublish;
                Data.UpdateUserId = UserData.UserId;
                Data.UpdateUserDate = DateTime.UtcNow.ToLocalTime();
                Data.MeatingDateTime = UserData.MeatingDateTime;
                Data.MeatingLink = Request.MeatingLink;
                Data.MeatingLocation = Request.MeatingLocation;
                Data.MeatingName = Request.MeatingName;
                Data.MeatingTypeId = Request.MeatingTypeId;

               var AUM = _UnitOfWork.ApplicationUserMeetings.FindAllAsync(x => x.MeetingId == Data.Id).Result;
                if (AUM is not null )
                {
                    _UnitOfWork.ApplicationUserMeetings.DeleteRange(AUM);
                    _UnitOfWork.Complete();
                }

                List<ApplicationUserMeeting> UserMeetings = new List<ApplicationUserMeeting>();
                foreach (var item in Request.RecieverUserIds)
                {
                    ApplicationUserMeeting UserMeeting = new ApplicationUserMeeting();
                    UserMeeting.MeetingId = Data.Id;
                    UserMeeting.ApplicationUserId = item.Id;
                    UserMeetings.Add(UserMeeting);
                }
                Data.ApplicationUserMeetings = UserMeetings;
                _UnitOfWork.Meetings.Update(Data);

                if (_UnitOfWork.Complete() > 0)
                {
                    var x = Data;

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
    }
}
