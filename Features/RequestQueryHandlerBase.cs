using AutoMapper;
using IdentityServer.TokenValidation.Share;
using Microsoft.AspNetCore.Http;

namespace SC.VersionManagement.Features
{
    public class RequestQueryHandlerBase
    {
        protected  IUnitOfWorkQuery _unitOfWork { get; private set; }
        protected  IHttpContextAccessor _httpContext { get; private set; }
        protected  IMapper _mapper { get; private set; }

        public RequestQueryHandlerBase(IUnitOfWorkQuery unitOfWork,
                                       IHttpContextAccessor httpContext,
                                       IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _httpContext = httpContext;
            _mapper = mapper;
        }
        protected string _token => _httpContext.HttpContext.Request.Headers["Authorization"].ToString().StartsWith("Bearer  ")
           ? _httpContext.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer  ", "") : _httpContext.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        protected JWTAuthenticationIdentity _payload => AuthencationModule.PopulateUserIdentity(_httpContext.HttpContext);
    }
}
