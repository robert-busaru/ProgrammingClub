using Microsoft.AspNetCore.Mvc;
using ProgrammingClub.Helpers;
using ProgrammingClub.Services;
using System.Net;
using System.Threading.Tasks;


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
        public async Task<IActionResult> GetAllMembers()
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
        public async Task<IActionResult> GetMembersById(Guid id)
        {
            try
            {
                var member = await _membersService.GetMemberByIdAsync(id);
                if (member == null)
                {
                    return StatusCode((int)HttpStatusCode.NotFound,
                        ErrorMessageEnum.GetErrorMessage(ErrorMessageEnum.ErrorMessage.NotFound));
                }
                return Ok(member);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    ErrorMessageEnum.GetErrorMessage(ErrorMessageEnum.ErrorMessage.InternalServerError) + ": " + ex.Message);
            }
        }

        // POST api/<MembersController>
        [HttpPost]
        public void Post([FromBody] Models.Member member)
        {
            
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.Member member)
        {
            if (member == null)
            {
                return BadRequest(ErrorMessageEnum.GetErrorMessage(ErrorMessageEnum.ErrorMessage.BadRequest));
            }

            try
            {
                var updatedMember = _membersService.UpdateMemberAsync(member);
                if (updatedMember == null)
                {
                    return StatusCode((int)HttpStatusCode.NotFound,
                        ErrorMessageEnum.GetErrorMessage(ErrorMessageEnum.ErrorMessage.NotFound));
                }
                return Ok(updatedMember);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    ErrorMessageEnum.GetErrorMessage(ErrorMessageEnum.ErrorMessage.InternalServerError) + ": " + ex.Message);
            }
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
