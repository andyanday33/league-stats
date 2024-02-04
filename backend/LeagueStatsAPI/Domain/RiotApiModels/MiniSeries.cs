using Domain.Contracts;

namespace Domain.RiotApiModels;

public class MiniSeries : IRiotObject
{
    public int Losses { get; set; }
    public string Progress { get; set; }
    public int Target { get; set; }
    public int Wins { get; set; }
}