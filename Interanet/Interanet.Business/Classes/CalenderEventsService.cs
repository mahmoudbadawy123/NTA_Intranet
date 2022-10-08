using Interanet.Business.Constant;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View.Calender;
using Interanet.Model.View.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Classes
{
    public class CalenderEventsService : ICalenderEventsService
    {

        private readonly IUnitOfWork _UnitOfWork;
        public CalenderEventsService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }


        public async Task<VmAddUpdateDeleteResponse> Add(CalenderEvents Request, VmEventUserData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                var AnnData = _UnitOfWork.CalenderEvents.CountAsync(x => x.EventName == Request.EventName && x.GroupId == Request.GroupId).Result;
                if (AnnData > 0)
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.DUBLICATE_NAME_ERROR_MESSAGE + $" in Group Num : {Request.GroupId}";
                    return Response;
                }

                Request.InsertUserId = UserData.UserId;
                Request.InsertUserDate = DateTime.UtcNow.ToLocalTime();
                Request.EventDateTime = UserData.EventDateTime;
                await _UnitOfWork.CalenderEvents.AddAsync(Request);
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



        public async Task<VmAddUpdateDeleteResponse> Update(VmUpdateCalenderEventRequest Request, VmEventUserData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                var AnnData = _UnitOfWork.CalenderEvents.CountAsync(x => x.EventName == Request.EventName && x.GroupId == Request.GroupId && x.Id != Request.Id).Result;
                if (AnnData > 0)
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.DUBLICATE_NAME_ERROR_MESSAGE + $" in Group Num : {Request.GroupId}";
                    return Response;
                }

                CalenderEvents Data = _UnitOfWork.CalenderEvents.GetByIdAsync(Request.Id).Result;
                if (Data is not null)
                {

                    Data.EventName = Request.EventName;
                    Data.Description = Request.Description;
                    Data.GroupId = Request.GroupId;
                    Data.EventDateTime = UserData.EventDateTime;
                    Data.UpdateUserId = UserData.UserId;
                    Data.UpdateUserDate = DateTime.UtcNow.ToLocalTime();
                    _UnitOfWork.CalenderEvents.Update(Data);
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


        public async Task<VmAddUpdateDeleteResponse> Delete(VmDeleteCalenderEventRequest Request)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                CalenderEvents Data = _UnitOfWork.CalenderEvents.GetByIdAsync(Request.Id).Result;
                if (Data is not null)
                {
                    _UnitOfWork.CalenderEvents.Delete(Data);
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



        public async Task<VmGetAdminCalenderEventServiceResponse> GetAllForAdmin()
        {
            VmGetAdminCalenderEventServiceResponse Response = new VmGetAdminCalenderEventServiceResponse();
            try
            {
                var Data = _UnitOfWork.CalenderEvents.GetAll().ToList();
                Response.Data = Data;
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public async Task<VmGetAdminCalenderEventServiceResponse> GetAllForEmployeesByGroup(int GroupId)
        {
            VmGetAdminCalenderEventServiceResponse Response = new VmGetAdminCalenderEventServiceResponse();
            try
            {
                var Data = _UnitOfWork.CalenderEvents.FindAll(x => x.GroupId == 1 || x.GroupId == GroupId).ToList();
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
