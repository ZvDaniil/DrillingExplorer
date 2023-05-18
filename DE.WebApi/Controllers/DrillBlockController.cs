using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using DE.Application.DrillBlocks.ViewModels;
using DE.Application.DrillBlocks.Queries.GetDrillBlocks;
using DE.Application.DrillBlocks.Queries.GetDrillBlockDetails;
using DE.Application.DrillBlocks.Commands.CreateDrillBlock;
using DE.Application.DrillBlocks.Commands.UpdateDrillBlock;
using DE.Application.DrillBlocks.Commands.DeleteDrillBlock;

using DE.Application.DrillBlockPoints.ViewModels;
using DE.Application.DrillBlockPoints.Queries.GetDrillBlockPoints;
using DE.Application.DrillBlockPoints.Queries.GetDrillBlockPointDetails;
using DE.Application.DrillBlockPoints.Commands.CreatePoint;
using DE.Application.DrillBlockPoints.Commands.UpdatePoint;
using DE.Application.DrillBlockPoints.Commands.DeletePoint;


using DE.WebApi.Controllers.Base;
using DE.WebApi.Models.DrillBlock;
using DE.WebApi.Models.DrillBlockPoint;

namespace DE.WebApi.Controllers;

[Route("api/[controller]")]
public class DrillBlockController : BaseController
{
    private readonly IMapper _mapper;

    public DrillBlockController(IMapper mapper) => _mapper = mapper;

    #region DrillBlock CRUD

    [HttpGet]
    public async Task<ActionResult<DrillBlockListVm>> GetAll()
    {
        var query = new GetDrillBlocksQuery();
        var vm = await Sender.Send(query);

        return Ok(vm);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DrillBlockDetailsVm>> Get(Guid id)
    {
        var query = new GetDrillBlockDetailsQuery(id);
        var vm = await Sender.Send(query);

        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateDrillBlockDto createDrillBlockDto)
    {
        var command = _mapper.Map<CreateDrillBlockCommand>(createDrillBlockDto);
        var id = await Sender.Send(command);

        return Ok(id);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateDrillBlockDto updateDrillBlockDto)
    {
        var command = _mapper.Map<UpdateDrillBlockCommand>(updateDrillBlockDto);
        await Sender.Send(command);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteDrillBlockCommand(id);
        await Sender.Send(command);

        return NoContent();
    }

    #endregion

    #region DrillBlockPoint CRUD

    [HttpGet("{id:guid}/drillblockpoints")]
    public async Task<ActionResult<IEnumerable<DrillBlockPointDto>>> GetDrillBlockPoints(Guid id)
    {
        var query = new GetDrillBlockPointsQuery(id);
        var points = await Sender.Send(query);

        return Ok(points);
    }

    [HttpGet("{id:guid}/drillblockpoints/{pointId}")]
    public async Task<ActionResult<DrillBlockPointDto>> GetDrillBlockPoint(Guid id, Guid pointId)
    {
        var query = new GetDrillBlockPointDetailsQuery(id, pointId);
        var vm = await Sender.Send(query);

        return Ok(vm);
    }

    [HttpPost("{id:guid}/drillblockpoints")]
    public async Task<ActionResult<Guid>> CreateDrillBlockPoint(Guid id, [FromBody] CreateDrillBlockPointDto createDto)
    {
        var command = _mapper.Map<CreateDrillBlockPointCommand>(createDto, opts => opts.Items["DrillBlockId"] = id);
        var pointId = await Sender.Send(command);

        return Ok(pointId);
    }

    [HttpPut("{id:guid}/drillblockpoints")]
    public async Task<ActionResult> UpdateDrillBlockPoint(Guid id, [FromBody] UpdateDrillBlockPointDto updateDto)
    {
        var command = _mapper.Map<UpdateDrillBlockPointCommand>(updateDto, opts => opts.Items["DrillBlockId"] = id);
        await Sender.Send(command);

        return NoContent();
    }

    [HttpDelete("{id:guid}/drillblockpoints/{pointId}")]
    public async Task<IActionResult> DeleteDrillBlockPoint(Guid id, Guid pointId)
    {
        var command = new DeleteDrillBlockPointCommand(id, pointId);
        await Sender.Send(command);

        return NoContent();
    }

    #endregion
}