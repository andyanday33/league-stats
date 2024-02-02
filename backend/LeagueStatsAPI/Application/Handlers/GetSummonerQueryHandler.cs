using Application.Commands;
using Domain.Enums;
using Infrastructure.Clients;
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

        var region = request.Region switch
        {
            "TR" => Region.TR,
            "EUW" => Region.EUW,
            "EUNE" => Region.EUNE,
            "NA" => Region.NA, // TODO: Add more regions
        };
        
        var summoner = await _riotHttpClient.GetSummonerByName(summonerNameSplit[0], summonerNameSplit[1], region);
        
        return new Summoner
        {
            Puuid = summoner.Puuid,
            Name = summonerName
        };
    }
}