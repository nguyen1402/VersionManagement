using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SC.BaseObject.Response;
using SC.VersionManagement.Database.Models.Request;
using SC.VersionManagement.Database.Models.Response;
using SC.VersionManagement.Helpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace SC.VersionManagement.Features
{
    public class VersionEnvironmentGetByPageQuery : VersionEnvironmentRequestFilterQuery, IRequest<SCPagingResponse<VersionEnvironmentResponse>>
    {

        public bool IsValid()
        {
            var regexPatern = @"[~`!@#$%\^&*=\[\]\\';,{}|\\"" <>\?]";
            if (!string.IsNullOrEmpty(KeyWord) && Regex.IsMatch(KeyWord.Trim(), regexPatern))
                throw new SoftComException(nameof(ApplicationCode.INVALID_TEXT));
            return true;
        }


        public class VersionEnvironmentGetByPageQueryHandler : RequestQueryHandlerBase, IRequestHandler<VersionEnvironmentGetByPageQuery, SCPagingResponse<VersionEnvironmentResponse>>
        {
            public VersionEnvironmentGetByPageQueryHandler(
            IUnitOfWorkQuery unitOfWork,
            IHttpContextAccessor httpContext,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
            }

            public async Task<SCPagingResponse<VersionEnvironmentResponse>> Handle(VersionEnvironmentGetByPageQuery query, CancellationToken cancellationToken)
            {
                var list = await _unitOfWork.VersionEnvironmentRepositoryQuery.GetByPage(query, _payload.TenantId, _payload.TenantWgId);

                if (list.Count > 0)
                {

                    return new SCPagingResponse<VersionEnvironmentResponse>()
                    {
                        PageIndex = query.PageIndex,
                        PageSize = query.PageSize,
                        Result = _mapper.Map<List<VersionEnvironmentResponse>>(list),
                        Total = list.FirstOrDefault() != null ? list.FirstOrDefault().TotalRows : 0
                    };
                }

                return new SCPagingResponse<VersionEnvironmentResponse>()
                {
                    PageIndex = query.PageIndex,
                    PageSize = query.PageSize,
                    Result = null,
                    Total = 0
                };
            }
        }
    }
}
