using Core.DTO.Client;
using Core.DTO.Helpers;
using Core.Helpers;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedList<DtoClient>>> GetAll([FromQuery] DtoFilterPagedList pagedListParams)
        {
            PagedList<DtoClient> listUsers = await _clientService.GetAllClients(pagedListParams);

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
            DtoClient result = await _clientService.GetClientById(id);

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
        public async Task<ActionResult<DtoClient>> Create([FromBody] DtoClientCreate client)
        {
            int? result = await _clientService.CreateClient(client);

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
        public async Task<ActionResult<DtoClient>> Update([FromBody] DtoClientUpdate data)
        {
            int? result = await _clientService.UpdateClient(data);

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
            await _clientService.RemoveClient(id);

            return Ok();
        }
    }
}
