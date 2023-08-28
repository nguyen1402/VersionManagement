using AutoMapper;
using MediatR;
using System.Text.RegularExpressions;
using SC.Utilities.Http;
using SC.BaseObject.Response;
using SC.VersionManagement.Database.Models.Request;
using System;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SC.VersionManagement.Database.Models.Response;
using SC.VersionManagement.Helpers;
using static SC.VersionManagement.Helpers.ErrorCode;
using System.IO;
using System.Linq;
using SC.VersionManagement.Database.Entities;

namespace SC.VersionManagement.Features
{
    public class VersionEnvironmentCreateCommand : VersionEnviromentCreateRequest, IRequest<Guid>
    {
        public bool IsValid()
        {
            return true;
        }


        public class VersionEnvironmentCreateCommandHandler : RequestCommandHandlerBase, IRequestHandler<VersionEnvironmentCreateCommand, Guid>
        {
            private IConfiguration _configuration;
            private readonly IHttpClientFactory _httpClientFactory;
            private readonly HttpBaseServices _httpClient;
            private readonly ILogger<VersionEnvironmentCreateCommand> _logger;
            public VersionEnvironmentCreateCommandHandler(
            IUnitOfWorkCommand unitOfWork,
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContext,
            IConfiguration configuration,
            ILoggerFactory logger,
            IMapper mapper) : base(unitOfWork, httpContext, mapper)
            {
                _configuration = configuration;
                _httpClientFactory = httpClientFactory;
                _logger = logger.CreateLogger<VersionEnvironmentCreateCommand>();
                _httpClient = new HttpBaseServices("CDN", httpClientFactory, logger);
            }

            public async Task<Guid> Handle(VersionEnvironmentCreateCommand command, CancellationToken cancellationToken)
            {

                string urlFile = "";
                #region GET-URL-CDN

                var form = new MultipartFormDataContent();
                var fileContent = new StreamContent(command.File.OpenReadStream());
                form.Add(fileContent, command.File.Name, command.File.FileName);
                var response = await _httpClient.PostFileAsync<SCResponse<List<DataItem>>>(_configuration.GetValue<string>("CDN:UploadApi"), form, _token);
                var dataList = response.Data;
                foreach (var data in dataList)
                {
                    urlFile = data.Url;
                }
                #endregion

                #region Đổi tên file khi trùng
                if (string.IsNullOrEmpty(urlFile))
                    throw new SoftComException(GetApplicationCodegByErrorCode((int)EnumErrorCode.INVALID_TEXT));

                // VD :urlFile = /Tickets/digipost-plugin-event-alpha.js
                string originalFileName = Path.GetFileName(urlFile);  // digipost-plugin-event-alpha.json

                string directoryPath = Path.GetDirectoryName(urlFile); // //Tickets
                // Đường dẫn thư mục
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName); // digipost-plugin-event-alpha

                //Kiểm tra fileNameWithoutExtension có bị chứa kí tự đặc biệt không ?
                var regexPatern = @"[~`!@#$%\^&*=\[\]\\';,{}|\\""<>\?]";
                if (!string.IsNullOrEmpty(fileNameWithoutExtension))
                    fileNameWithoutExtension = fileNameWithoutExtension.ToLower().Trim();
                if (!string.IsNullOrEmpty(fileNameWithoutExtension) && Regex.IsMatch(fileNameWithoutExtension, regexPatern))
                    throw new SoftComException(GetApplicationCodegByErrorCode((int)EnumErrorCode.INVALID_TEXT));

                // Tên tập tin không có phần mở rộng
                string extension = Path.GetExtension(originalFileName); //.js
                //if (!string.IsNullOrEmpty(extension) && extension != ".js")
                //    throw new SoftComException(GetApplicationCodegByErrorCode((int)EnumErrorCode.INVALID_TEXT));

                // Phần mở rộng tập tin
                string newFileUrl = originalFileName;
                var isCommit = _unitOfWork.CreateTransaction();

                //Lấy ra listUrlFile từ IdNameVision
                var listUrlFile = await _unitOfWork.VersionEnvironmentRepositoryCommand.GetListUrlByIdNameVersion(command.IdApplication, (int)command.Environment);

                //Lưu tạm 1 list để lấy ra  1 list fileNameWithoutExtension
                List<string> listUrlFromDb = new List<string>();
                if (listUrlFile != null && listUrlFile.Count() > 0)
                {
                    foreach (var item in listUrlFile)
                    {
                        var urlOriginal = Path.GetFileNameWithoutExtension(item).ToLower().Trim();
                        listUrlFromDb.Add(urlOriginal);
                    }
                }

                //Kiểm tra tồn tại 1 tên bằng với fileNameWithoutExtension thì đếm Count StartsWith(fileNameWithoutExtension) + 1 để không bị trùng tên Url
                if (listUrlFromDb.Any(c => c == fileNameWithoutExtension))
                {
                    newFileUrl = Path.Combine(directoryPath, $"{fileNameWithoutExtension}-{listUrlFromDb.Where(c => c.StartsWith(fileNameWithoutExtension)).Count() + 1}{extension}");
                }
                else
                {
                    newFileUrl = Path.Combine(directoryPath, $"{fileNameWithoutExtension}{extension}");
                }
                #endregion

                #region Thực hiện map và thêm vào VersionEnviroment
                var versionEnvironment = _mapper.Map<VersionEnvironment>(command);
                versionEnvironment.Id = Guid.NewGuid();
                versionEnvironment.UrlFile = newFileUrl.Replace("\\", "/");
                versionEnvironment.TenantId = _payload.TenantId;
                versionEnvironment.WorkgroupId = _payload.TenantWgId;
                versionEnvironment.CreatedBy = _payload.UserId;
                versionEnvironment.CreatedByName = _payload.UserName;

                var responseStatus = await _unitOfWork.VersionEnvironmentRepositoryCommand.Add(versionEnvironment);
                if (isCommit)
                    _unitOfWork.Commit();
                #endregion

                if (responseStatus < 0)
                {
                    throw new SoftComException(GetApplicationCodegByErrorCode(responseStatus));
                }
                return versionEnvironment.Id;
            }
        }
    }
}


