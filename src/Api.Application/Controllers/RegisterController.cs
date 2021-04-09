using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Register;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Register([FromBody] RegisterRequestDto user, [FromServices] IRegisterService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await service.Register(user);
                return Ok(result);
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}