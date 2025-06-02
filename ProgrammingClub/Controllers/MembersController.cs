using Microsoft.AspNetCore.Mvc;
using ProgrammingClub.Helpers;
using ProgrammingClub.Services;
using System.Net;


namespace ProgrammingClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;

        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }

        // GET: api/<MembersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var members = await _membersService.GetAllMembersAsync();
                if (members == null || !members.Any())
                {
                    return StatusCode((int)HttpStatusCode.NotFound,
                        ErrorMessageEnum.GetErrorMessage(ErrorMessageEnum.ErrorMessage.NotFound));
                }
                return Ok(members);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    ErrorMessageEnum.GetErrorMessage(ErrorMessageEnum.ErrorMessage.InternalServerError) + ": " + ex.Message);
            }
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MembersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
