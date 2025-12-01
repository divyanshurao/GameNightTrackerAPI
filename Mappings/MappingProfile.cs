using AutoMapper;
using GameNightTrackerAPI.Dtos;
using GameNightTrackerAPI.Models;

namespace GameNightTrackerAPI.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map Game ↔ GameDto (both directions)
        CreateMap<Game, GameDto>().ReverseMap();
        CreateMap<CreateGameDto, Game>();
        CreateMap<UpdateGameDto, Game>();
    }
}