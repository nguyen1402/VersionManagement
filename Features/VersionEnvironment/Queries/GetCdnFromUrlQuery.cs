using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SC.Utilities.Http;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SC.VersionManagement.Features
{
    public class GetCdnFromUrlQuery :IRequest<string>
    {

        public string UrlFile { get; set; }
        public bool IsValid()
        {
            return true;
        }
        public class GetCdnFromUrlQueryHandler : RequestQueryHandlerBase, IRequestHandler<GetCdnFromUrlQuery,string>
        {
            private IConfiguration _configuration;
            private readonly IHttpClientFactory _httpClientFactory;
            private readonly HttpBaseServices _httpClient;
            private readonly ILogger<VersionEnvironmentCreateCommand> _logger;
            public GetCdnFromUrlQueryHandler(
            IUnitOfWorkQuery unitOfWork,
            IHttpContextAccessor httpContext,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            ILoggerFactory logger,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
                _configuration = configuration;
                _httpClientFactory = httpClientFactory;
                _logger = logger.CreateLogger<VersionEnvironmentCreateCommand>();
                _httpClient = new HttpBaseServices("CDN", httpClientFactory, logger);
            }

            public async Task<string?> Handle(GetCdnFromUrlQuery query, CancellationToken cancellationToken)
            {
                string fullUrl = "";
                string baseUrl = baseUrl = _configuration.GetValue<string>("CDN:Domain");
                string getApi = "";

                string extension = Path.GetExtension(query.UrlFile);

                if (extension == ".js")
                {
                    getApi = _configuration.GetValue<string>("CDN:GetApiJs");
                    fullUrl = baseUrl + getApi + Uri.EscapeUriString(query.UrlFile);
                }
                else if (extension == ".css")
                {
                    getApi = _configuration.GetValue<string>("CDN:GetApiCss");
                    fullUrl = baseUrl + getApi + Uri.EscapeUriString(query.UrlFile);
                }
                else
                {
                    return null;
                }


                // var response = await _httpClient.GetAsync<SCResponse<string>>(fullUrl);
                var clientFactory = _httpClientFactory.CreateClient();
                var response = await clientFactory.GetAsync(fullUrl);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                if (responseBody != null)
                {
                    return responseBody;
                }
                return null;
            }
        }
    }
}
