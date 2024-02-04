using Domain.Enums;
using Domain.RiotApiModels;
using MediatR;

namespace Application.Queries;

public class GetSummonerProfileQuery : IRequest<SummonerProfile>
{
    public string Puuid { get; set; }
    public Region Region { get; set; }
}