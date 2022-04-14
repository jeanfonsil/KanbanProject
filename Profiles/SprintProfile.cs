using AutoMapper;
using KanbanProjectFinal.Data.Dtos;
using KanbanProjectFinal.Entities;

namespace KanbanProjectFinal.Profiles
{
    public class SprintProfile : Profile
    {
        public SprintProfile()
        {
            CreateMap<CreateSprintDto, Sprint>();
            CreateMap<Sprint, ReadSprintDto>()
                .ForMember(sprint => sprint.Cards, opts => opts
                .MapFrom(sprint => sprint.Cards.Select
                (c => new { c.Id, c.Title, c.Description, c.Sprint, c.SprintId, c.User, c.UserId, c.Status })));
        }

    }
}
