using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Database.Models.Response;
using SC.VersionManagement.Enum;
using SC.VersionManagement.Helpers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VersionManagement.Database.Models.Response;

namespace SC.VersionManagement.Features
{
    public class VersionLockDateGetDetailByEnviromentQuery : IRequest<VersionLockDateResponse>
    {
        public EnumEnviroment Environment { get; set; }
        public long TenantId { get; set; }

        public bool IsValid()
        {
            if (Environment < 0)
                throw new SoftComException(nameof(ApplicationCode.INVALID_REQUEST_DATA));
            return true;
        }


        public class VersionLockDateGetDetailByTenantIdQueryHandler : RequestQueryHandlerBase, IRequestHandler<VersionLockDateGetDetailByEnviromentQuery, VersionLockDateResponse>
        {
            public VersionLockDateGetDetailByTenantIdQueryHandler(
            IUnitOfWorkQuery unitOfWork,
            IHttpContextAccessor httpContext,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
            }

            public async Task<VersionLockDateResponse> Handle(VersionLockDateGetDetailByEnviromentQuery query, CancellationToken cancellationToken)
            {
                
                
                 var data = await _unitOfWork.VersionLockDateRepositoryQuery.GetDetail(query.Environment, query.TenantId, _payload.TenantWgId);

                 var response  = _mapper.Map<VersionLockDateResponse>(data);

                 if (response == null)
                    return null;

                var lstVerssion = await _unitOfWork.VersionLockDateRepositoryQuery.GetListVersionEnviromentByVersionLockDateId(
                    new VersionLockDate
                    {
                        Id = response.Id,
                        TenantId = _payload.TenantId,
                        WorkgroupId = _payload.TenantWgId
                    });
                response.ListVersionEnviroments = _mapper.Map<List<VersionEnviromentResponse>>(lstVerssion);
                return response;
            }
        }
    }
}
