using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SC.VersionManagement.Database.Models.Response;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SC.VersionManagement.Features
{
    public class ApplicationGetDetailByIdQuery : IRequest<ApplicationResponse>
    {
        public Guid Id { get; set; }
        public bool IsValid()
        {
            return true;
        }
        public class ApplicationGetDetailByIdQueryHandler : RequestQueryHandlerBase, IRequestHandler<ApplicationGetDetailByIdQuery, ApplicationResponse>
        {
            public ApplicationGetDetailByIdQueryHandler(
            IUnitOfWorkQuery unitOfWork,
            IHttpContextAccessor httpContext,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
            }

            public async Task<ApplicationResponse> Handle(ApplicationGetDetailByIdQuery command, CancellationToken cancellationToken)
            {
                var result = await _unitOfWork.ApplicationRepositoryQuery.GetDetailById(command.Id,_payload.TenantId,_payload.TenantWgId);

                var aplicationResponse = _mapper.Map<ApplicationResponse>(result);

                return aplicationResponse;
            }
        }
    }
}