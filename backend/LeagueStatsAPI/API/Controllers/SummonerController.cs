using Application.Commands;
using Application.DTOs;
using AutoMapper;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SummonerController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public SummonerController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{region}/{summonerName}")]
    public async Task<IActionResult> GetSummonerByName(string summonerName, Region region)
    {
        var summoner = await _mediator.Send(new GetSummonerQuery { SummonerName = summonerName, Region = region });
        return new OkObjectResult(_mapper.Map<SummonerDTO>(summoner));
    }
}