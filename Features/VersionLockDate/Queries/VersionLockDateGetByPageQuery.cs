using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SC.BaseObject.Response;
using SC.Utilities.Validation;
using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Database.Models.Request;
using SC.VersionManagement.Database.Models.Response;
using SC.VersionManagement.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using VersionManagement.Database.Models.Response;

namespace SC.VersionManagement.Features
{
    public class VersionLockDateGetByPageQuery : VersionLockDateFillterQuery, IRequest<SCPagingResponse<VersionLockDateResponse>>
    {


        public bool IsValid()
        {
            var regexPatern = @"[~`!@#$%\^&*=\[\]\\';,{}|\\"" <>\?]";
            if (!string.IsNullOrEmpty(KeyWord) && Regex.IsMatch(KeyWord.Trim(), regexPatern))
                throw new SoftComException(nameof(ApplicationCode.INVALID_TEXT));
            return true;
        }


        public class VersionLockDateGetByPageQueryHandler : RequestQueryHandlerBase, IRequestHandler<VersionLockDateGetByPageQuery, SCPagingResponse<VersionLockDateResponse>>
        {
            public VersionLockDateGetByPageQueryHandler(
            IUnitOfWorkQuery unitOfWork,
            IHttpContextAccessor httpContext,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
            }

            public async Task<SCPagingResponse<VersionLockDateResponse>> Handle(VersionLockDateGetByPageQuery query, CancellationToken cancellationToken)
            {
                var response = new List<VersionLockDateResponse>();
               
                var data = await _unitOfWork.VersionLockDateRepositoryQuery.GetByPage(query,_payload.TenantId,_payload.TenantWgId);
                
                if (data.IsNullOrEmpty())
                    return new SCPagingResponse<VersionLockDateResponse>(query.PageIndex, query.PageSize, 0, response);

                response = _mapper.Map<List<VersionLockDateResponse>>(data);
                foreach (var versionLockDateResponse in response)
                {
                    var lstVerssion = await _unitOfWork.VersionLockDateRepositoryQuery.GetListVersionEnviromentByVersionLockDateId(
                        new  VersionLockDate
                        {
                            Id = versionLockDateResponse.Id,
                            TenantId = _payload.TenantId,
                            WorkgroupId = _payload.TenantWgId
                        });
                    versionLockDateResponse.ListVersionEnviroments = _mapper.Map<List<VersionEnviromentResponse>>(lstVerssion);
                }
                return new SCPagingResponse<VersionLockDateResponse>(query.PageIndex, query.PageSize, data.FirstOrDefault().TotalRows, response);
            }
        }
    }
}
