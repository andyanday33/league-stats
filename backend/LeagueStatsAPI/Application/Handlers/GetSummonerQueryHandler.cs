using Application.Commands;
using Domain.Models;
using MediatR;

namespace Application.Handlers;

public class GetSummonerQueryHandler : IRequestHandler<GetSummonerQuery, Summoner>
{
    public async Task<Summoner> Handle(GetSummonerQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}