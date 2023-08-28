using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SC.BaseObject.Response;
using SC.NewsApi.Features;
using SC.VersionManagement.Database.Models.Request;
using SC.VersionManagement.Database.Models.Response;
using SC.VersionManagement.Features;
using SC.VersionManagement.Models;
using System;
using System.Threading.Tasks;
using VersionManagement.Database.Models.Response;

namespace SC.VersionManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        #region GetByPage
        [HttpPost("get-by-page")]
        public async Task<IActionResult> GetByPage([FromBody] ApplicationGetByPageQuery query)
        {
            if (query.IsValid())
            {
                var result = await Mediator.Send(query);
                return Ok(new SuccessResponse<SCPagingResponse<ApplicationResponse>>(result));
            }
            return BadRequest();
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ApplicationCreateCommand command)
        {
            if (command.IsValid())
            {
                var result = await Mediator.Send(command);
                return Ok(new SuccessResponse<Guid>(result));
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id)
        {
            var command = new ApplicationGetDetailByIdQuery { Id = id};
            if (command.IsValid())
            {
                var result = await Mediator.Send(command);
                return Ok(new SuccessResponse<ApplicationResponse>(result));
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ApplicationUpdateRequest request)
        {
            var command = new ApplicationUpdateCommand { Id = id , ApplicationUpdateRequest = request };
            if (command.IsValid())
            {
                var result = await Mediator.Send(command);
                return Ok(new SuccessResponse<bool>(result));
            }
            return BadRequest();
        }

    }
}
