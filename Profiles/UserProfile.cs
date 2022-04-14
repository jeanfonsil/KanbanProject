using AutoMapper;
using KanbanProjectFinal.Data.Dtos;
using KanbanProjectFinal.Entities;

namespace KanbanProjectFinal.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ReadUserDto>()
                .ForMember(user => user.Cards, opts => opts
                .MapFrom(user => user.Cards.Select
                (c => new { c.Id, c.Title, c.Description, c.Sprint, c.SprintId, c.User, c.UserId, c.Status })));
        }

    }
}
