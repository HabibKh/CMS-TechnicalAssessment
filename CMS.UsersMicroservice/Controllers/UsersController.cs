using System.Collections.Generic;
using System.Threading.Tasks;
using CMS.UsersMicroservice.Application.Interfaces;
using CMS.UsersMicroservice.Models.Dto;
using CMS.UsersMicroservice.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.UsersMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (! await IsUserExist(id))
            {
                return NotFound($"User with this id {id} does not exist in the system.");
            }

            var user = await _userService.GetById(id);
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userService.GetByName(viewModel.Name);
            
            if (user != null)
            {
                return Ok("This user already exist, please try a different user name.");
            }

            var id = await _userService.Add(new UserDto() { Name = viewModel.Name });
            return Ok(id);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await IsUserExist(id))
            {
                return NotFound($"User with this id {id} does not exist in the system.");
            }

            await _userService.Update(new UserDto() { Id = id, Name = viewModel.Name });
            return Ok();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await IsUserExist(id))
            {
                return NotFound($"User with this id {id} does not exist in the system.");
            }

            await _userService.DeleteById(id);
            return Ok();
        }

        private async Task<bool> IsUserExist(int id)
        {
            var user = await _userService.GetById(id);
            
            if (user != null)
            {
                return true;
            }

            return false;
        }
    }
}
