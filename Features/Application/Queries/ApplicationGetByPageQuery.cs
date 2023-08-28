using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SC.BaseObject.Response;
using SC.VersionManagement.Database.Entities;
using SC.VersionManagement.Database.Models.Request;
using SC.VersionManagement.Database.Models.Response;
using SC.VersionManagement.Features;
using SC.VersionManagement.Helpers;
using SC.VersionManagement;
using static QRCoder.PayloadGenerator;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using VersionManagement.Database.Models.Response;
using SC.Utilities.Validation;
using System.Linq;
using SC.BaseObject.Entities;
using SC.VersionManagement.Enum;

namespace SC.NewsApi.Features
{
    public class ApplicationGetByPageQuery : ApplicationRequestFillterQuery, IRequest<SCPagingResponse<ApplicationResponse>>
    {

        public bool IsValid()
        {
            var regexPatern = @"[~`!@#$%\^&*=\[\]\\';,{}|\\"" <>\?]";
            if (!string.IsNullOrEmpty(KeyWord) && Regex.IsMatch(KeyWord.Trim(), regexPatern))
                throw new SoftComException(nameof(ApplicationCode.INVALID_TEXT));
            return true;
        }


        public class ApplicationGetByPageQueryHandler : RequestQueryHandlerBase, IRequestHandler<ApplicationGetByPageQuery, SCPagingResponse<ApplicationResponse>>
        {
            public ApplicationGetByPageQueryHandler(
            IUnitOfWorkQuery unitOfWork,
            IHttpContextAccessor httpContext,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
            }

            public async Task<SCPagingResponse<ApplicationResponse>> Handle(ApplicationGetByPageQuery query, CancellationToken cancellationToken)
            {
                var list = await _unitOfWork.ApplicationRepositoryQuery.GetByPage(query, _payload.TenantId, _payload.TenantWgId);

                if (list.Count > 0)
                {

                    return new SCPagingResponse<ApplicationResponse>()
                    {
                        PageIndex = query.PageIndex,
                        PageSize = query.PageSize,
                        Result = _mapper.Map<List<ApplicationResponse>>(list),
                        Total = list.FirstOrDefault() != null ? list.FirstOrDefault().TotalRows : 0
                    };
                }

                return new SCPagingResponse<ApplicationResponse>()
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
