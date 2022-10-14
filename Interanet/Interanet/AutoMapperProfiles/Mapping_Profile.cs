using AutoMapper;
using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.Announcement;
using Interanet.Model.View.Calender;
using Interanet.Model.View.LookUps;
using Interanet.Model.View.Meetings;
using Interanet.Model.View.Story;
using Interanet.Model.View.Systems;
using Microsoft.AspNetCore.Identity;

namespace Interanet.API.AutoMapperProfiles
{

    //https://tech.playgokids.com/auto-mapper-net6/


    public class Mapping_Profile : Profile
    {

        public Mapping_Profile()
        {

            //############################################## Start  ApplicationUser ################################################


            CreateMap<ApplicationUser, UserLookUpViewModel>().ForMember(
                 dest => dest.Id,
                 opt => opt.MapFrom(src => $"{src.Id}")
             ).ForMember(
                 dest => dest.Name,
                 opt => opt.MapFrom(src => $"{src.FullName}")
             );


            CreateMap<ApplicationUser, VmRecieverUserRequest>().ForMember(
                 dest => dest.Id,
                 opt => opt.MapFrom(src => $"{src.Id}")
             ).ForMember(
                 dest => dest.Name,
                 opt => opt.MapFrom(src => $"{src.FullName}")
             );

            CreateMap<VmRecieverUserRequest,ApplicationUser > ().ForMember(
                 dest => dest.Id,
                 opt => opt.MapFrom(src => $"{src.Id}")
             ).ForMember(
                 dest => dest.FullName,
                 opt => opt.MapFrom(src => $"{src.Name}")
             );

            //############################################## Start Announcements ################################################
            CreateMap<Announcement, VmAnnouncementResponse>()
               .ForMember(
                    dest => dest.InsertUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_InsertUserId.FullName}")
                )
                .ForMember(
                    dest => dest.UpdateUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_UpdateUserId.FullName}")
                )
                 .ForMember(
                    dest => dest.UserGroupName,
                    opt => opt.MapFrom(src => $"{src.UserGroups.Name}")
                )
                  .ForMember(
                    dest => dest.PublishDateTime,
                    opt => opt.MapFrom(src => $"{src.PublishDateTime.Value.ToUniversalTime().ToLocalTime()}")
                    );



            CreateMap<VmAddAnnouncementRequest, Announcement>().AfterMap((_, dest) =>
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
            CreateMap<UserGroup, VmGroups>().ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                ).ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                );
            //############################################## Start  Stories ################################################

            CreateMap<Story, VmStoryResponse>()
               .ForMember(
                    dest => dest.InsertUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_InsertUser.FullName}")
                )
                .ForMember(
                    dest => dest.UpdateUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_UpdateUser.FullName}")
                )
                 .ForMember(
                    dest => dest.UserGroupName,
                    opt => opt.MapFrom(src => $"{src.UserGroups.Name}")
                )
                  .ForMember(
                    dest => dest.PublishDateTime,
                    opt => opt.MapFrom(src => $"{src.PublishDateTime.Value.ToUniversalTime().ToLocalTime()}")
                    );



            CreateMap<VmAddStoryRequest, Story>().AfterMap((_, dest) =>
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

            CreateMap<CalenderEvent, VmCalenderEventResponse>()
               .ForMember(
                    dest => dest.InsertUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_InsertUser.FullName}")
                )
                .ForMember(
                    dest => dest.UpdateUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_UpdateUser.FullName}")
                )
                 .ForMember(
                    dest => dest.UserGroupName,
                    opt => opt.MapFrom(src => $"{src.UserGroups.Name}")
                )
                .ForMember(
                    dest => dest.EventDateTime,
                    opt => opt.MapFrom(src => $"{src.EventDateTime.Value.ToUniversalTime().ToLocalTime()}")
                    );



            CreateMap<VmAddCalenderEventRequest, CalenderEvent>().AfterMap((_, dest) =>
                {
                    dest.InsertUserDate = DateTime.UtcNow.ToLocalTime();
                });

            CreateMap<VmGetAdminCalenderEventServiceResponse, VmGetAdminCalenderEventResponse>()
                .ForMember(
                    dest => dest.Data,
                    opt => opt.MapFrom(src => src.Data)
                );

            //############################################## Start  MeetingTypes ################################################
            CreateMap<MeetingType, VmMeetingTypes>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => $"{src.Id}")
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.Name}")
            );

            //############################################## Start  Meetings ################################################
            //AutoMapper.Mapper.CreateMap<SourceClass, DestinationClass>();


            CreateMap<Meeting, VmMeetingResponse>()
               .ForMember(
                    dest => dest.InsertUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_InsertUser.FullName}")
                )
                .ForMember(
                    dest => dest.UpdateUserName,
                    opt => opt.MapFrom(src => $"{src.ApplicationUser_UpdateUser.FullName}")
                )
                 .ForMember(
                    dest => dest.MeatingTypeName,
                    opt => opt.MapFrom(src => $"{src.MeetingTypes.Name}")
                )
                  .ForMember(
                    dest => dest.MeatingDateTime,
                    opt => opt.MapFrom(src => $"{src.MeatingDateTime.Value.ToUniversalTime().ToLocalTime()}")
                    )
               .ForMember(
                    dest => dest.PublishDateTime,
                    opt => opt.MapFrom(src => $"{src.PublishDateTime.Value.ToUniversalTime().ToLocalTime()}")
                    )

                .ForMember(
                    dest => dest.PublishDateTime,
                    opt => opt.MapFrom(src => $"{src.PublishDateTime.Value.ToUniversalTime().ToLocalTime()}")
                    )


                .ForMember(
                    dest => dest.ApplicationUserMeetings,
                    opt => opt.MapFrom(src => src.ApplicationUserMeetings)
                    )

               ;



            CreateMap<ApplicationUserMeeting, VmApplicationUserMeeting>()
            .ForMember(
                dest => dest.MeetingId,
                opt => opt.MapFrom(src => src.MeetingId)
                )
             .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.ApplicationUserId)
                )
             .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.ApplicationUser.FullName)
                )
            ;

            CreateMap<ApplicationUser, VmRecieverUserRequest>().ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                ).ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FullName}")
                );


            //CreateMap<VmAddMeetingRequest, Meeting>().ForMember(
            //        dest => dest.ApplicationUsers,
            //        opt => opt.MapFrom(src => $"{src.RecieverUserIds}")
            //        )

            //        .AfterMap((_, dest) =>
            //        {
            //            dest.InsertUserDate = DateTime.UtcNow.ToLocalTime();
            //        });

            //CreateMap<VmGetAdminMeetingServiceResponse, VmGetAdminMeetingResponse>()
            //    .ForMember(
            //        dest => dest.Data,
            //        opt => opt.MapFrom(src => src.Data)
            //    );




            //############################################## Start  RelatedSystem  ################################################

            CreateMap<RelatedSystem, VmRelatedSystemResponse>()
                .ForMember(
                     dest => dest.InsertUserName,
                     opt => opt.MapFrom(src => $"{src.ApplicationUser_InsertUser.FullName}")
                 )
                 .ForMember(
                     dest => dest.UpdateUserName,
                     opt => opt.MapFrom(src => $"{src.ApplicationUser_UpdateUser.FullName}")
                 )
              
             

                 .ForMember(
                     dest => dest.PublishDateTime,
                     opt => opt.MapFrom(src => $"{src.PublishDateTime.Value.ToUniversalTime().ToLocalTime()}")
                     )


                 .ForMember(
                     dest => dest.ApplicationUserRelatedSystems,
                     opt => opt.MapFrom(src => src.ApplicationUserRelatedSystems)
                     )

                ;



            CreateMap<ApplicationUserRelatedSystem, VmApplicationUserRelatedSystem>()
            .ForMember(
                dest => dest.RelatedSystemId,
                opt => opt.MapFrom(src => src.RelatedSystemId)
                )
             .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.ApplicationUserId)
                )

              .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.ApplicationUser.FullName)
                )

            ;

            CreateMap<ApplicationUser, VmRecieverUserRequest>().ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                ).ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FullName}")
                );







            CreateMap<VmAddRelatedSystemRequest, RelatedSystem>().AfterMap((_, dest) =>
            {
                dest.InsertUserDate = DateTime.UtcNow.ToLocalTime();
            });

            CreateMap<VmGetAdminRelatedSystemServiceResponse, VmGetAdminRelatedSystemResponse>()
                .ForMember(
                    dest => dest.Page,
                    opt => opt.MapFrom(src => src.Page)
                ).ForMember(
                    dest => dest.Data,
                    opt => opt.MapFrom(src => src.Data)
                );

            //############################################## Start  Table Name ################################################
            //############################################## Start  Table Name ################################################
            //############################################## Start  Table Name ################################################


        }
    }
}
