using AutoMapper;
using Interanet.Model.Data;
using Interanet.Model.View.Announcement;
using Interanet.Model.View.Calender;
using Interanet.Model.View.LookUps;
using Interanet.Model.View.Story;
using Microsoft.AspNetCore.Identity;

namespace Interanet.API.AutoMapperProfiles
{

    //https://tech.playgokids.com/auto-mapper-net6/
    public class Mapping_Profile : Profile
    {
        public Mapping_Profile()
        {
            //############################################## Start Announcements ################################################
            CreateMap<Announcements, VmAnnouncementResponse>()
               .ForMember(
                    dest => dest.InsertUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_InsertUserId.UserName}")
                )
                .ForMember(
                    dest => dest.UpdateUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_UpdateUserId.UserName}")
                )
                 .ForMember(
                    dest => dest.UserGroupName,
                    opt => opt.MapFrom(src => $"{src.UserGroups.Name}")
                )
                 .ForMember(
                    dest => dest.UserGroupName,
                    opt => opt.MapFrom(src => $"{src.UserGroups.Name}")
                )
                  .ForMember(
                    dest => dest.PublishDateTime,
                    opt => opt.MapFrom(src => $"{src.PublishDateTime.Value.ToUniversalTime().ToLocalTime()}")
                    );
            


            CreateMap<VmAddAnnouncementRequest, Announcements>().AfterMap((_, dest) =>
            {
                dest.InsertUserDate = DateTime.UtcNow.ToLocalTime();
            });

            CreateMap<VmGetAdminAnnouncementServiceResponse, VmGetAdminAnnouncementResponse>()
                .ForMember(
                    dest => dest.Page,
                    opt => opt.MapFrom(src => src.Page)
                ).ForMember(
                    dest => dest.Data,
                    opt => opt.MapFrom(src => src.Data)
                );

            //############################################## Start UserGroups ################################################
            CreateMap<UserGroups, VmGroups>().ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                ).ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                );




            //############################################## Start  Stroys ################################################

            CreateMap<Storys, VmStoryResponse>()
               .ForMember(
                    dest => dest.InsertUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_InsertUser.UserName}")
                )
                .ForMember(
                    dest => dest.UpdateUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_UpdateUser.UserName}")
                )
                 .ForMember(
                    dest => dest.UserGroupName,
                    opt => opt.MapFrom(src => $"{src.UserGroups.Name}")
                )
                 .ForMember(
                    dest => dest.UserGroupName,
                    opt => opt.MapFrom(src => $"{src.UserGroups.Name}")
                )
                  .ForMember(
                    dest => dest.PublishDateTime,
                    opt => opt.MapFrom(src => $"{src.PublishDateTime.Value.ToUniversalTime().ToLocalTime()}")
                    );



            CreateMap<VmAddStoryRequest, Storys>().AfterMap((_, dest) =>
            {
                dest.InsertUserDate = DateTime.UtcNow.ToLocalTime();
            });

            CreateMap<VmGetAdminStoryServiceResponse, VmGetAdminStoryResponse>()
                .ForMember(
                    dest => dest.Page,
                    opt => opt.MapFrom(src => src.Page)
                ).ForMember(
                    dest => dest.Data,
                    opt => opt.MapFrom(src => src.Data)
                );



            //############################################## Start  CalenderEvents ################################################

            CreateMap<CalenderEvents, VmCalenderEventResponse>()
               .ForMember(
                    dest => dest.InsertUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_InsertUser.UserName}")
                )
                .ForMember(
                    dest => dest.UpdateUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_UpdateUser.UserName}")
                )
                 .ForMember(
                    dest => dest.UserGroupName,
                    opt => opt.MapFrom(src => $"{src.UserGroups.Name}")
                )
                 .ForMember(
                    dest => dest.UserGroupName,
                    opt => opt.MapFrom(src => $"{src.UserGroups.Name}")
                )
                  .ForMember(
                    dest => dest.EventDateTime,
                    opt => opt.MapFrom(src => $"{src.EventDateTime.Value.ToUniversalTime().ToLocalTime()}")
                    );



            CreateMap<VmAddCalenderEventRequest, CalenderEvents>().AfterMap((_, dest) =>
            {
                dest.InsertUserDate = DateTime.UtcNow.ToLocalTime();
            });

            CreateMap<VmGetAdminCalenderEventServiceResponse, VmGetAdminCalenderEventResponse>()
                .ForMember(
                    dest => dest.Data,
                    opt => opt.MapFrom(src => src.Data)
                );

            //############################################## Start  Table Name ################################################
            //############################################## Start  Table Name ################################################
            //############################################## Start  Table Name ################################################
            //############################################## Start  Table Name ################################################


        }
    }
}
