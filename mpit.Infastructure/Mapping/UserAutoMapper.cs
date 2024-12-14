using AutoMapper;
using mpit.Core.DTO;
using mpit.Core.DTO.User;
using mpit.Core.Models;
using mpit.DataAccess.Entities;

namespace mpit.Infastructure.Mapping
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<UserEntity, User>();
            CreateMap<UserEntity, UserDto>();

            CreateMap<VacancyEntity, Vacancy>();
            CreateMap<VacancyEntity, VacancyDto>();
        }
    }
}
