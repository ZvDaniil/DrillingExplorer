using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using DE.Application.HolePoints.ViewModels;
using DE.Application.HolePoints.Queries.GetHolePoints;
using DE.Application.HolePoints.Commands.CreateHolePoint;
using DE.Application.HolePoints.Commands.UpdateHolePoint;
using DE.Application.HolePoints.Commands.DeleteHolePoint;

using DE.Application.Holes.ViewModels;
using DE.Application.Holes.Queries.GetHoles;
using DE.Application.Holes.Queries.GetHoleDetails;
using DE.Application.Holes.Commands.CreateHole;
using DE.Application.Holes.Commands.UpdateHole;
using DE.Application.Holes.Commands.DeleteHole;

using DE.WebApi.Controllers.Base;
using DE.WebApi.Models.Hole;
using DE.WebApi.Models.HolePoint;

namespace DE.WebApi.Controllers;

[Route("api/[controller]")]
public class HolesController : BaseController
{
    private readonly IMapper _mapper;

    public HolesController(IMapper mapper) => _mapper = mapper;

    #region Hole CRUD

    [HttpGet]
    public async Task<ActionResult<HoleListVm>> GetAll()
    {
        var query = new GetHolesQuery();
        var vm = await Sender.Send(query);

        return Ok(vm);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<HoleDetailsVm>> Get(Guid id)
    {
        var query = new GetHoleDetailsQuery(id);
        var vm = await Sender.Send(query);

        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateHoleDto createHoleDto)
    {
        var command = _mapper.Map<CreateHoleCommand>(createHoleDto);
        var id = await Sender.Send(command);

        return Ok(id);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateHoleDto updateHoleDto)
    {
        var command = _mapper.Map<UpdateHoleCommand>(updateHoleDto);
        await Sender.Send(command);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteHoleCommand(id);
        await Sender.Send(command);

        return NoContent();
    }

    #endregion

    #region HolePoint CRUD

    [HttpGet("{id:guid}/holepoint")]
    public async Task<ActionResult<HolePointDto>> GetHolePoint(Guid id)
    {
        var query = new GetHolePointQuery(id);
        var point = await Sender.Send(query);

        return point is null
            ? NotFound()
            : Ok(point);
    }

    [HttpPost("{id:guid}/holepoint")]
    public async Task<ActionResult> CreateHolePoint(Guid id, CreateHolePointDto createHolePointDto)
    {
        var command = _mapper.Map<CreateHolePointCommand>(createHolePointDto, opts => opts.Items["HoleId"] = id);
        var pointId = await Sender.Send(command);

        return NoContent();
    }

    [HttpPut("{id:guid}/holepoint")]
    public async Task<ActionResult> UpdateHolePoint(Guid id, UpdateHolePointDto updateHolePointDto)
    {
        var command = _mapper.Map<UpdateHolePointCommand>(updateHolePointDto, opts => opts.Items["HoleId"] = id);
        await Sender.Send(command);

        return NoContent();
    }

    [HttpDelete("{id:guid}/holepoint")]
    public async Task<ActionResult> DeleteHolePoint(Guid id)
    {
        var command = new DeleteHolePointCommand(id);
        await Sender.Send(command);

        return NoContent();
    }

    #endregion
}