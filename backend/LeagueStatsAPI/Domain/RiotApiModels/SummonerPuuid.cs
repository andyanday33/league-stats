using Domain.Contracts;

namespace Domain.RiotApiModels;

public class SummonerPuuid : IRiotObject
{
    public string Puuid { get; set; }
    public string GameName { get; set; }
    public string TagLine { get; set; }
}