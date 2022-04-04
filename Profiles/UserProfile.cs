using AutoMapper;
using KanbanProjectFinal.Data.Dtos;
using KanbanProjectFinal.Entities;

namespace KanbanProjectFinal.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }

    }
}
