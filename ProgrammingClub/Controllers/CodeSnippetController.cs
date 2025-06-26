using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClub.CQRS.Commands;
using ProgrammingClub.CQRS.DTOs;
using ProgrammingClub.CQRS.Queries;
using ProgrammingClub.Models;

namespace ProgrammingClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeSnippetController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CodeSnippetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/CodeSnippets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeSnippet>>> GetAllCodeSnippets()
        {
            var query = new GetAllCodeSnippetsQuery();
            var codeSnippets = await _mediator.Send(query);
            return Ok(codeSnippets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCodeSnippet(CodeSnippetDto dto)
        {
            var command = new CreateCodeSnippetCommand(dto);
            var codeSnippetId = await _mediator.Send(command);
            return Ok(codeSnippetId);
        }
    }
}
