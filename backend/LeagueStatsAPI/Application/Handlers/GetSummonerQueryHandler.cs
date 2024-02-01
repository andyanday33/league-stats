using Application.Commands;
using Domain.Config;
using Domain.Models;
using MediatR;

namespace Application.Handlers;

public class GetSummonerQueryHandler : IRequestHandler<GetSummonerQuery, Summoner>
{
    private RiotConfig _riotConfig;
    public GetSummonerQueryHandler(RiotConfig riotConfig)
    {
        _riotConfig = riotConfig;
    }

    public async Task<Summoner> Handle(GetSummonerQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}