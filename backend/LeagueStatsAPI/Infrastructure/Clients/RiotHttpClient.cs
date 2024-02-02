using System.Text.Json;
using Domain.Enums;
using Infrastructure.Config;
using Domain.RiotApiModels;

namespace Infrastructure.Clients;

public class RiotHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly RiotConfig _riotConfig;

    public RiotHttpClient(HttpClient httpClient, RiotConfig riotConfig)
    {
        _httpClient = httpClient;
        _riotConfig = riotConfig;
    }

    public async Task<SummonerByPuuid> GetSummonerByName(string summonerName, string tagLine, Region region)
    {
        // TODO: Implement region checks
        var apiZone = APIZone.europe;
        
        var url = $"https://{apiZone}.api.riotgames.com/riot/account/v1/accounts/by-riot-id/{summonerName}/{tagLine}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("X-Riot-Token", _riotConfig.APIKey);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        Console.WriteLine("Response:");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        
        var responseString = await response.Content.ReadAsStringAsync();
        var summoner = JsonSerializer.Deserialize<SummonerByPuuid>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return summoner!;
    }
}