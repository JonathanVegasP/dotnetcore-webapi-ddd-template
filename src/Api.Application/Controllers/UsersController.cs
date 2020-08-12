using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> getAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var index = 0;
                var count = 10;
                if (Request.Query.ContainsKey("index"))
                {
                    if (int.TryParse(Request.Query["index"], out int value))
                        index = value;
                }
                if (Request.Query.ContainsKey("count"))
                {
                    if (int.TryParse(Request.Query["count"], out int value))
                        count = value;
                }
                return Ok(await _service.getAll(index, count));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> getById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.get(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> post([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.post(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.id })), result);
                }
                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InsufficientStorage, ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> put([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.put(user);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InsufficientStorage, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.delete(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InsufficientStorage, ex.Message);
            }
        }
    }
}
