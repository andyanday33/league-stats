using Application.Queries;
using Domain.RiotApiModels;
using Infrastructure.Clients;
using MediatR;

namespace Application.Handlers;

public class GetSummonerProfileQueryHandler : IRequestHandler<GetSummonerProfileQuery, SummonerProfile>
{
    private RiotHttpClient _riotHttpClient;
    public GetSummonerProfileQueryHandler(RiotHttpClient riotHttpClient)
    {
        _riotHttpClient = riotHttpClient;
    }
    
    public async Task<SummonerProfile> Handle(GetSummonerProfileQuery request, CancellationToken cancellationToken)
    {
        return await _riotHttpClient.GetSummonerProfileByPuuid(request.Puuid, request.Region);
    }
}