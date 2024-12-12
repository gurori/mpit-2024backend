using AutoMapper;
using mpit.Core.Models;
using mpit.DataAccess.Entities;

namespace mpit.Infastructure.Mapping
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<UserEntity, User>();
        }
    }
}
