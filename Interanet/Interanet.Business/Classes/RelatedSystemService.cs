using Interanet.Business.Constant;
using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.General;
using Interanet.Model.View.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Classes
{
    public class RelatedSystemService : IRelatedSystemService
    {

        private readonly IUnitOfWork _UnitOfWork;
        public  RelatedSystemService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public async Task<VmAddUpdateDeleteResponse> Add(VmAddRelatedSystemRequest Request, VmRelatedSystemData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                var AnnData = _UnitOfWork.RelatedSystems.CountAsync(x => x.SystemName == Request.SystemName).Result;
                if (AnnData > 0)
                {
                    Response.IsDone = false;
                    Response.Message = ErrorMessages.DUBLICATE_NAME_ERROR_MESSAGE + $" in System Name : {Request.SystemName}";
                    return Response;
                }

                Request.InsertUserId = UserData.UserId;
                Request.InsertUserDate = DateTime.UtcNow.ToLocalTime();
                RelatedSystem Data = new RelatedSystem();
                Data.Id = (_UnitOfWork.RelatedSystems.GetAll().Select(x => (int?)x.Id).Max() ?? 0) + 1;
                Data.SystemName = Request.SystemName;
                Data.Link = Request.Link;
                Data.PublishDateTime = Request.PublishDateTime;
                Data.isScheduledPublish = Request.isScheduledPublish;
                Data.InsertUserId = Request.InsertUserId;
                Data.InsertUserDate = Request.InsertUserDate;
                //Data.UpdateUserId = UserData.UpdateUserId;
                //Data.UpdateUserDate = Request.UpdateUserDate;
 
                List<ApplicationUserRelatedSystem> UserRelatedSystems = new List<ApplicationUserRelatedSystem>();
                foreach (var item in Request.RecieverUserIds)
                {
                    ApplicationUserRelatedSystem UserRelatedSystem = new ApplicationUserRelatedSystem();
                    UserRelatedSystem.RelatedSystemId = Data.Id;
                    UserRelatedSystem.ApplicationUserId = item.Id;
                    UserRelatedSystems.Add(UserRelatedSystem);
                }
                //await _UnitOfWork. RelatedSystems.AddAsync(Data);
                Data.ApplicationUserRelatedSystems = UserRelatedSystems;
                await _UnitOfWork.RelatedSystems.AddAsync(Data);

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

        public async Task<VmAddUpdateDeleteResponse> Delete(VmDeleteRelatedSystemRequest Request)
        {

            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                RelatedSystem Data = _UnitOfWork.RelatedSystems.GetByIdAsync(Request.Id).Result;
                if (Data is not null)
                {
                    _UnitOfWork.RelatedSystems.Delete(Data);
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

        public async Task<VmGetAdminRelatedSystemServiceResponse> GetAllForAdmin(Page Page)
        {
            VmGetAdminRelatedSystemServiceResponse Response = new VmGetAdminRelatedSystemServiceResponse();
            try
            {
                //string[] JoinedTables = { "ApplicationUserRelatedSystems", "ApplicationUser_InsertUser", "ApplicationUser_UpdateUser" };
                //List<RelatedSystem> Data = _UnitOfWork.RelatedSystems.FindAll(x => true, JoinedTables).ToList();
                //return Data;




                bool IsEmpty = false;
                if (string.IsNullOrWhiteSpace(Page.Filter))
                {
                    IsEmpty = true;
                }

                string[] JoinedTables = { "ApplicationUserRelatedSystems", "ApplicationUser_InsertUser", "ApplicationUser_UpdateUser" , "ApplicationUsers" };
               var  Data = _UnitOfWork.RelatedSystems.FindAll(
                        r => IsEmpty || r.SystemName.Contains(Page.Filter)
                                 || r.Link.Contains(Page.Filter)
                                 || r.ApplicationUser_InsertUser.FullName.Contains(Page.Filter)
                    , JoinedTables).ToList().OrderByDescending(O => O.Id);
           

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

        public async Task<VmGetAdminRelatedSystemServiceResponse> GetAllForEmp(string UserId , Page Page)
        {
            VmGetAdminRelatedSystemServiceResponse Response = new VmGetAdminRelatedSystemServiceResponse();
            try
            {

                bool IsEmpty = false;
                if (string.IsNullOrWhiteSpace(Page.Filter))
                {
                    IsEmpty = true;
                }
                string[] JoinedTables = { "ApplicationUserRelatedSystems", "ApplicationUser_InsertUser", "ApplicationUser_UpdateUser", "ApplicationUsers" };
                var Data = _UnitOfWork.RelatedSystems.
                    FindAll(r => r.ApplicationUsers.Select(x => x.Id).Contains(UserId)
                    ,JoinedTables).ToList();


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

        public async Task<VmAddUpdateDeleteResponse> Update(VmUpdateRelatedSystemRequest Request, VmRelatedSystemData UserData)
        {
            VmAddUpdateDeleteResponse Response = new VmAddUpdateDeleteResponse();
            try
            {
                RelatedSystem Data = _UnitOfWork.RelatedSystems.GetByIdAsync(Request.Id).Result;
                Data.PublishDateTime = Request.PublishDateTime;
                Data.isScheduledPublish = Request.isScheduledPublish;
                Data.UpdateUserId = UserData.UserId;
                Data.UpdateUserDate = DateTime.UtcNow.ToLocalTime();
                Data.SystemName = Request.SystemName;
                Data.Link = Request.Link;

 


                var AUM = _UnitOfWork.ApplicationUserRelatedSystems.FindAllAsync(x => x.RelatedSystemId == Data.Id).Result;
                if (AUM is not null)
                {
                    _UnitOfWork.ApplicationUserRelatedSystems.DeleteRange(AUM);
                    _UnitOfWork.Complete();
                }

                List<ApplicationUserRelatedSystem> UserRelatedSystems = new List<ApplicationUserRelatedSystem>();
                foreach (var item in Request.RecieverUserIds)
                {
                    ApplicationUserRelatedSystem UserRelatedSystem = new ApplicationUserRelatedSystem();
                    UserRelatedSystem.RelatedSystemId = Data.Id;
                    UserRelatedSystem.ApplicationUserId = item.Id;
                    UserRelatedSystems.Add(UserRelatedSystem);
                }
                //await _UnitOfWork. RelatedSystems.AddAsync(Data);
                Data.ApplicationUserRelatedSystems = UserRelatedSystems;
                _UnitOfWork.RelatedSystems.Update(Data);

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
