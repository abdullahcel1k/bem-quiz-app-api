using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Resources;
using QuizApp.Api.Validations;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET api/users
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UserResource>>> Get()
        {
            var users = await _userService.GetAll();
            var musicResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(musicResources);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetByUserId(int id)
        {
            var users = await _userService.GetAll();
            var musicResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(musicResources);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<UserResource>> Post([FromBody]SaveUserResource user)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(user);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var createdUser = _mapper.Map<SaveUserResource, User>(user);
            var addedUser = await _userService.CreateUser(createdUser);

            var userResource = _mapper.Map<User, UserResource>(addedUser);

            return Ok(userResource);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserResource>> Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserResource>> Delete(int id)
        {
            return Ok();
        }
    }
}

