using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.Profiles;

public class SummonerMappingProfile : Profile
{
    public SummonerMappingProfile()
    {
        CreateMap<Summoner, SummonerDTO>()
            .ForMember(
                dest => dest.Puuid,
                opt => opt.MapFrom(src => src.Puuid)
                )
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
                )
            ;
    }
}