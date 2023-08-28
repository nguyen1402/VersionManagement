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
    public class VersionLockDateUpdateIsPublicByIdCommand : IRequest<long>
    {
        public Guid Id { get; set; }
        public bool IsValid()
        {
            if (Id == Guid.Empty)
                throw new SoftComException(nameof(ApplicationCode.INVALID_REQUEST_DATA));
            return true;
        }

        public VersionLockDateUpdateIsPublicByIdCommand()
        {

        }

        public class VersionLockDateUpdateIsPulicByIdCommandHandler
            : RequestCommandHandlerBase, IRequestHandler<VersionLockDateUpdateIsPublicByIdCommand, long>
        {
            public VersionLockDateUpdateIsPulicByIdCommandHandler(
            IUnitOfWorkCommand unitOfWork,
            IHttpContextAccessor httpContext,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
            }

            public async Task<long> Handle(VersionLockDateUpdateIsPublicByIdCommand command, CancellationToken cancellationToken)
            {
                var versionLockDate = _mapper.Map<VersionLockDate>(command);
                versionLockDate.TenantId = _payload.TenantId;
                versionLockDate.WorkgroupId = _payload.TenantWgId;
                versionLockDate.LastEditedBy = _payload.UserId;
                versionLockDate.LastEditedByName = _payload.UserName;
                var isCommit = _unitOfWork.CreateTransaction();
                var responseStatus = await _unitOfWork.VersionLockDateRepositoryCommand.UpdateIsPublic(versionLockDate);
                if (isCommit)
                    _unitOfWork.Commit();
                if (responseStatus < 0)
                {
                    throw new SoftComException(ErrorCode.GetApplicationCodegByErrorCode(responseStatus));
                }

                return responseStatus;
            }
        }
    }
}
