using Application.Enums;
using Domain.Models;
using MediatR;

namespace Application.Commands;

public class GetSummonerQuery: IRequest<Summoner>
{
    public string SummonerName { get; set; }
    public Region Region { get; set; }
}