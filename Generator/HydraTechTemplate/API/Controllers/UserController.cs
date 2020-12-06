using Core.DTO.Helpers;
using Core.DTO.User;
using Core.Helpers;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _usuarioService;

        public UserController(IUserService usuarioService) 
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedList<DtoUser>>> GetAll([FromQuery] DtoFilterPagedList pagedListParams)
        {
            PagedList<DtoUser> listUsers = await _usuarioService.GetAllUsers(pagedListParams);

            if (listUsers == null || !listUsers.Any())
            {
                return NotFound();
            }

            return Ok(listUsers);
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            DtoUser result = await _usuarioService.GetUserId(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// New User
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DtoUser>> Create([FromBody] DtoUserCreate user)
        {
            int? result = await _usuarioService.CreateUser(user);

            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = result.Value }, result);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<DtoUser>> Update([FromBody] DtoUserUpdate data)
        {
            int? result = await _usuarioService.UpdateUser(data);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id) 
        {
            await _usuarioService.RemoveUser(id);

            return Ok();
        }
    }
}
