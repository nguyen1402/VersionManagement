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
    public class VersionLockDateCreateCommand : VersionLockDateCreateRequest, IRequest<Guid>
    {

        public bool IsValid()
        {
            if (Enviroment < 0)
                throw new SoftComException(nameof(ApplicationCode.INVALID_REQUEST_DATA));
            return true;
        }

        public VersionLockDateCreateCommand()
        {

        }

        public class VersionLockDateCreateCommandHandler
            : RequestCommandHandlerBase, IRequestHandler<VersionLockDateCreateCommand, Guid>
        {
            public VersionLockDateCreateCommandHandler(
            IUnitOfWorkCommand unitOfWork,
            IHttpContextAccessor httpContext,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
            }

            public async Task<Guid> Handle(VersionLockDateCreateCommand command, CancellationToken cancellationToken)
            {
                var isCommit = _unitOfWork.CreateTransaction();
                var versionLockDate = _mapper.Map<VersionLockDate>(command);
                versionLockDate.Id = Guid.NewGuid();
                versionLockDate.TenantId = _payload.TenantId;
                versionLockDate.WorkgroupId = _payload.TenantWgId;
                versionLockDate.CreatedBy = _payload.UserId;
                versionLockDate.CreatedByName = _payload.UserName;

                
                var responseStatus = await _unitOfWork.VersionLockDateRepositoryCommand.Add(versionLockDate);
                if (isCommit)
                    _unitOfWork.Commit();

                if (responseStatus < 0)
                {
                    throw new SoftComException(ErrorCode.GetApplicationCodegByErrorCode(responseStatus));
                }
                return versionLockDate.Id;
            }
        }
    }
}
