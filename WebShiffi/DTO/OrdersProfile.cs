using AutoMapper;
using webApi.models;

namespace WebShiffi.DTO
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<OrdersDTO, Orders>()
             //      .ForMember(
             // dest => dest.OrderDate,
             //opt => opt.MapFrom(src => DateTime.Now))

             //       .ForMember(
             //dest => dest.OrdersId,
             //opt => opt.MapFrom(src => Guid.NewGuid())

             //   ).ForMember(dest => dest.Gift
             //, opt => opt.MapFrom(src => src.Gift)

             .ForMember(dest => dest.GiftId
             , opt => opt.MapFrom(src => src.GiftId))

             .ForMember(dest => dest.UsersId
             , opt => opt.MapFrom(src => src.UsersId));
            
             //    .ForMember(dest => dest.Status
             //, opt => opt.MapFrom(src => "chart"));
        }
    }

}
