using Application.Queries;
using Application.DTOs;
using AutoMapper;
using Domain.Enums;
using Domain.RiotApiModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SummonerController
{
    
    private IMediator _mediator;
    private IMapper _mapper;

    public SummonerController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{region}/{summonerName}/puuid")]
    public async Task<IActionResult> GetSummonerByName(string summonerName, Region region)
    {
        var summoner = await _mediator.Send(new GetSummonerQuery { SummonerName = summonerName, Region = region });
        return new OkObjectResult(_mapper.Map<SummonerDTO>(summoner));
    }
    
    [HttpGet("{region}/{puuid}/profile")]
    public async Task<IActionResult> GetSummonerByPuuid(string puuid, Region region)
    {
        var summonerProfile = await _mediator.Send(new GetSummonerProfileQuery { Puuid = puuid, Region = region });
        return new OkObjectResult(_mapper.Map<SummonerProfile>(summonerProfile));
    }
    
}