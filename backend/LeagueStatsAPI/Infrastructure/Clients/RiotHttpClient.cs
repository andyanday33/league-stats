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

    public async Task<SummonerPuuid> GetSummonerByName(string summonerName, string tagLine, Region region)
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
        var summoner = JsonSerializer.Deserialize<SummonerPuuid>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return summoner!;
    }

    public async Task<SummonerProfile> GetSummonerProfileByPuuid(string puuid, Region region)
    {
        var url = $"https://{region.ToString()}.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/{puuid}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("X-Riot-Token", _riotConfig.APIKey);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        Console.WriteLine("Response:");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        
        var responseString = await response.Content.ReadAsStringAsync();
        var summoner = JsonSerializer.Deserialize<SummonerProfile>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return summoner!;
    }
}