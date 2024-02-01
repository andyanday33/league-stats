using Application.Commands;
using Domain.Clients;
using Domain.Config;
using Domain.Models;
using MediatR;

namespace Application.Handlers;

public class GetSummonerQueryHandler : IRequestHandler<GetSummonerQuery, Summoner>
{
    private readonly RiotHttpClient _riotHttpClient;
    public GetSummonerQueryHandler(RiotHttpClient riotHttpClient)
    {
        _riotHttpClient = riotHttpClient;
    }

    public async Task<Summoner> Handle(GetSummonerQuery request, CancellationToken cancellationToken)
    {
        var summonerName = request.SummonerName;

        if (!summonerName.Contains('#')) throw new ArgumentException("Summoner name is not valid");
        
        var summonerNameSplit = summonerName.Split('#');
        var summoner = await _riotHttpClient.GetSummonerByName(summonerNameSplit[0], summonerNameSplit[1], request.Region);
        
        return new Summoner
        {
            Puuid = summoner.Puuid,
            Name = summonerName
        };
    }
}