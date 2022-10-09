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
                Data.PublishDateTime = Request.MeatingDateTime;
                Data.Description = Request.Description;
                Data.isScheduledPublish = Request.isScheduledPublish;
                Data.InsertUserId = Request.InsertUserId;
                Data.InsertUserDate = Request.InsertUserDate;
                //Data.UpdateUserId = UserData.UpdateUserId;
                //Data.UpdateUserDate = Request.UpdateUserDate;
                Data.MeatingDateTime = Request.MeatingDateTime;
                Data.MeatingLink = Request.MeatingLink;
                Data.MeatingLocation = Request.MeatingLocation;
                Data.MeatingDateTime = Request.MeatingDateTime;
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
                //await _UnitOfWork. Meetings.AddAsync(Data);
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
            throw new NotImplementedException();
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

        public async Task<VmGetAdminMeetingServiceResponse> GetAllForEmployeesByGroup(string UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<VmAddUpdateDeleteResponse> Update(VmUpdateMeetingRequest Request, VmMeetingData UserData)
        {
            throw new NotImplementedException();
        }
    }
}
