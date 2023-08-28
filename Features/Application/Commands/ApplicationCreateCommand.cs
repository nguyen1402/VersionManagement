using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Database.Models.Request;
using SC.VersionManagement.Helpers;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static SC.VersionManagement.Helpers.ErrorCode;

namespace SC.VersionManagement.Features
{
    public class ApplicationCreateCommand : ApplicationCreateRequest, IRequest<Guid>
    {
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
                throw new SoftComException(nameof(ApplicationCode.INVALID_TEXT));
            return true;
        }
        public class ApplicationCreateCommandHandler : RequestCommandHandlerBase, IRequestHandler<ApplicationCreateCommand, Guid>
        {
            public ApplicationCreateCommandHandler(
            IUnitOfWorkCommand unitOfWork,
            IHttpContextAccessor httpContext,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
            }

            public async Task<Guid> Handle(ApplicationCreateCommand command, CancellationToken cancellationToken)
            {

                var application = _mapper.Map<Application>(command);
                application.Id = Guid.NewGuid();
                application.TenantId = _payload.TenantId;
                application.WorkgroupId = _payload.TenantWgId;
                application.CreatedByName = _payload.UserName;
                application.CreatedBy = _payload.UserId;
                application.CreatedByName = _payload.UserName;
                var isCommit = _unitOfWork.CreateTransaction();
                var responseStatus = await _unitOfWork.ApplicationRepositoryCommand.Add(application);
                if (isCommit)
                    _unitOfWork.Commit();

                if (responseStatus < 0)
                {
                    throw new SoftComException(GetApplicationCodegByErrorCode(responseStatus));
                }
                return application.Id;
            }
        }
    }
}
