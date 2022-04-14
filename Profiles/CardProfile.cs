using AutoMapper;
using KanbanProjectFinal.Data.Dtos;
using KanbanProjectFinal.Entities;

namespace KanbanProjectFinal.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CreateCardDto, Card>();
            CreateMap<Card, ReadCardDto>();
            CreateMap<UpdateCardDto, Card>();
        }

    }
}
