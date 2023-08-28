using AutoMapper;
using SC.BaseObject.Entities;
using SC.BaseObject.Request;
using VersionManagement.Database.Models.Response;
using System;
using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Features;
using SC.VersionManagement.Database.Models.Request;
using SC.VersionManagement.Database.Models.Response;
using SC.VersionManagement.Models;

namespace SC.VersionManagement
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EntitiesToResponse());
                mc.AddProfile(new RequestToEntities());
                mc.AddProfile(new EntitiesToEntities());
                mc.AddProfile(new RequestToRequest());
                mc.AddProfile(new ResponseToResponse());
                mc.CreateMap(typeof(PagingResult<>), typeof(PagingResult<>));
            });
        }
    }

    public class EntitiesToResponse : Profile
    {
        private static readonly TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        public EntitiesToResponse()
        {
            CreateMap<VersionLockDate, VersionLockDateResponse>();
            CreateMap<VersionEnvironmentName,VersionEnviromentResponse>();
            CreateMap<VersionEnvironment, VersionEnvironmentResponse>();
            #region Application
            CreateMap<Application, ApplicationResponse>();
            #endregion
        }
    }

    public class RequestToEntities : Profile
    {
        public RequestToEntities()
        {
            CreateMap<SCBaseDataFilterRequest, SCBaseDataFilter>();
            CreateMap<SCBasePagingRequest, SCBasePaging>();

            CreateMap<VersionLockDateCreateCommand, VersionLockDate>();
          
            CreateMap<VersionLockDateUpdateIsPublicByIdCommand, VersionLockDate>();
           

            
            # region VersionEnviroment
            CreateMap<VersionEnviromentCreateRequest, VersionEnvironment>();
            #endregion


            #region Application
            CreateMap<ApplicationCreateRequest, Application>();
            CreateMap<ApplicationUpdateRequest, Application>();
            #endregion

        }
    }

    public class EntitiesToEntities : Profile
    {
        public EntitiesToEntities()
        {
        }
    }

    public class RequestToRequest : Profile
    {
        public RequestToRequest()
        {
            
        }
    }

    public class ResponseToResponse : Profile
    {
        public ResponseToResponse()
        {
        }
    }
}
