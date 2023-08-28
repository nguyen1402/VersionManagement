using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SC.BaseObject.Response;
using SC.NewsApi.Features;
using SC.VersionManagement.Database.Models.Response;
using SC.VersionManagement.Features;
using SC.VersionManagement.Models;
using System;
using System.Threading.Tasks;

namespace SC.VersionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionEnviromentController : ControllerBase
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        #region GetByPage
        [HttpPost("get-by-page")]
        public async Task<IActionResult> GetByPage([FromBody] VersionEnvironmentGetByPageQuery query)
        {
            if (query.IsValid())
            {
                var result = await Mediator.Send(query);
                return Ok(new SuccessResponse<SCPagingResponse<VersionEnvironmentResponse>>(result));
            }
            return BadRequest();
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] VersionEnvironmentCreateCommand command)
        {
            if (command.IsValid())
            {
                var result = await Mediator.Send(command);
                    return Ok(new SuccessResponse<Guid>(result));
            }
            return BadRequest();
        }

        [HttpPut("{id}/active")]
        public async Task<IActionResult> Active([FromRoute] Guid id)
        {
            var command = new VersionEnvironmentUpdateActiveCommand { Id = id};
            if (command.IsValid())
            {
                var result = await Mediator.Send(command);
                return Ok(new SuccessResponse<bool>(result));
            }
            return BadRequest();
        }
    }
    
}
