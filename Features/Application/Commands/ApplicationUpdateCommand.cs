using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Database.Models.Request;
using SC.VersionManagement.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SC.VersionManagement.Features
{
    public class ApplicationUpdateCommand :  IRequest<bool>
    {
        public ApplicationUpdateRequest ApplicationUpdateRequest { get; set; }
        public Guid Id { get; set; }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(ApplicationUpdateRequest.Name))
                throw new SoftComException(nameof(ApplicationCode.INVALID_TEXT));
            return true;
        }
        public class ApplicationUpdateCommandHandler : RequestCommandHandlerBase, IRequestHandler<ApplicationUpdateCommand, bool>
        {
            public ApplicationUpdateCommandHandler(
            IUnitOfWorkCommand unitOfWork,
            IHttpContextAccessor httpContext,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
            }

            public async Task<bool> Handle(ApplicationUpdateCommand command, CancellationToken cancellationToken)
            {

                var application = _mapper.Map<Application>(command.ApplicationUpdateRequest);
                application.Id = command.Id;
                application.TenantId = _payload.TenantId;
                application.WorkgroupId = _payload.TenantWgId;
                application.LastEditedBy = _payload.UserId;
                application.LastEditedByName = _payload.UserName;
                var isCommit = _unitOfWork.CreateTransaction();
                var responseStatus = await _unitOfWork.ApplicationRepositoryCommand.Update(application);
                if (isCommit)
                    _unitOfWork.Commit();

                if (responseStatus < 0)
                {
                    throw new SoftComException(ErrorCode.GetApplicationCodegByErrorCode(responseStatus));
                }
                return true;
            }
        }
    }
}