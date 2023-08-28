using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SC.VersionManagement.Features
{
    public class VersionEnvironmentUpdateActiveCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public bool IsValid()
        {
            return true;
        }
        public class VersionEnvironmentUpdateActiveCommandHandler : RequestCommandHandlerBase, IRequestHandler<VersionEnvironmentUpdateActiveCommand, bool>
        {
            public VersionEnvironmentUpdateActiveCommandHandler(
            IUnitOfWorkCommand unitOfWork,
            IHttpContextAccessor httpContext,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
            }

            public async Task<bool> Handle(VersionEnvironmentUpdateActiveCommand command, CancellationToken cancellationToken)
            {
                var request = new VersionEnvironment
                {
                    Id = command.Id,
                    TenantId = _payload.TenantId,
                    WorkgroupId = _payload.TenantWgId,
                    LastEditedBy = _payload.UserId
                };
                var isCommit = _unitOfWork.CreateTransaction();
                var responseStatus = await _unitOfWork.VersionEnvironmentRepositoryCommand.UpdateActive(request);
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
