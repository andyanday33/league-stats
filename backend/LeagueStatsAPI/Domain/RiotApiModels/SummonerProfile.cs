using Domain.Contracts;

namespace Domain.RiotApiModels;

public class SummonerProfile : IRiotObject
{
    public string Id { get; set; }
    public string AccountId { get; set; }
    public string Puuid { get; set; }
    public string Name { get; set; }
    public int ProfileIconId { get; set; }
    public long RevisionDate { get; set; }
    public long SummonerLevel { get; set; }
}