using Domain.Enums;
using Domain.Models;
using MediatR;

namespace Application.Queries;

public class GetSummonerQuery: IRequest<Summoner>
{
    public string SummonerName { get; set; }
    
    public Region Region { get; set; } // TODO: Make this more obvious for frontend
}