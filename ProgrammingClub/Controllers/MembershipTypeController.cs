﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClub.CQRS.Commands;
using ProgrammingClub.CQRS.DTOs;
using ProgrammingClub.CQRS.Queries;
using ProgrammingClub.Models;
using ProgrammingClubAPI.CQRS.Commands;
using ProgrammingClubAPI.CQRS.Queries;

namespace ProgrammingClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MembershipTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/MembershipTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembershipType>>> GetAllMembershipTypes()
        {
            var query = new GetAllMembershipTypesQuery();
            var membershipTypes = await _mediator.Send(query);
            return Ok(membershipTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MembershipType>> GetMembershipTypeById(Guid id)
        {
            var query = new GetMembershipTypeByIdQuery(id);
            var membershipType = await _mediator.Send(query);

            if (membershipType == null)
            {
                return NotFound();
            }
            return Ok(membershipType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMembershipType(MembershipTypeDto dto)
        {
            var command = new CreateMembershipTypeCommand(dto);
            var membershipTypeId = await _mediator.Send(command);
            return Ok(membershipTypeId);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMembershipType(Guid id)
        {
            var command = new DeleteMembershipTypeCommand(id);
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok("Removed");
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMembershipType(Guid id, MembershipType model)
        {
            var command = new UpdateMembershipTypeCommand(model);
            command.Dto.IdMembershipType = id;
            var updatedMembershipType = await _mediator.Send(command);
            return Ok(updatedMembershipType);
        }
    }
}
