using Application.Commands;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SummonerController
{
    private readonly IMediator _mediator;
    public SummonerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{region}/{summonerName}")]
    public async Task<IActionResult> GetSummonerByName(string summonerName, Region region)
    {
        var summoner = await _mediator.Send(new GetSummonerQuery { SummonerName = summonerName, Region = region });
        return new OkObjectResult(summoner);
    }
}