using Domain.Enums;
using Domain.Models;
using MediatR;

namespace Application.Commands;

public class GetSummonerQuery: IRequest<Summoner>
{
    public string SummonerName { get; set; }
    
    public string Region { get; set; } // TODO: Make this more obvious for frontend
}