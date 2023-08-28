using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SC.BaseObject.Response;
using SC.VersionManagement.Features;
using SC.VersionManagement.Models;
using System;
using System.Threading.Tasks;
using VersionManagement.Database.Models.Response;

namespace SC.VersionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionLockDateController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

       

        #region Add
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] VersionLockDateCreateCommand command)
        {
            if (command.IsValid())
            {
                var result = await Mediator.Send(command);
                return Ok(new SuccessResponse<Guid>(result));
            }
            return BadRequest();
        }
        #endregion

        #region Get Detail
        [HttpGet]
        public async Task<IActionResult> GetDetail([FromQuery] VersionLockDateGetDetailByEnviromentQuery query)
        {
            
            if (query.IsValid())
            {
                var result = await Mediator.Send(query);
                return Ok(new SuccessResponse<VersionLockDateResponse>(result));
            }
            return BadRequest();
        }
        #endregion

        #region OnlineIsPublic
        [HttpPut("{id}/update-ispublic")]
        public async Task<IActionResult> UpdateIsPublic([FromRoute] Guid id)
        {
            var command = new VersionLockDateUpdateIsPublicByIdCommand { Id = id};
            if (command.IsValid())
            {
                var result = await Mediator.Send(command);
                return Ok(new SuccessResponse<long>(result));
            }
            return BadRequest();
        }
        #endregion

        #region GetByPage
        [HttpPost("get-by-page")]
        public async Task<IActionResult> GetByPage([FromBody] VersionLockDateGetByPageQuery query)
        {
            if (query.IsValid())
            {
                var result = await Mediator.Send(query);
                return Ok(new SuccessResponse<SCPagingResponse<VersionLockDateResponse>>(result));
            }
            return BadRequest();
        }
        #endregion
    }
}
