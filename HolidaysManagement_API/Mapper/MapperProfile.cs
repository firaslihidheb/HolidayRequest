using AutoMapper;
using HolidaysManagement_API.Dtos;
using HolidaysManagement_API.Models;

namespace HolidaysManagement_API.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<HolidayRequestDTO, HolidayRequest>().ReverseMap();
            //to add other dtos
        }
    }
}
