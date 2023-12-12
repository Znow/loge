using AutoMapper;
using Loge.Application.Contracts;
using Loge.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TransportOrder, TransportOrderDto>().ReverseMap();
        // CreateMap<TransportOrderCreateRequestDTO, TransportOrder>(MemberList.Source);
        // CreateMap<TransportOrderUpdateRequestDTO, TransportOrder>(MemberList.Source);
    }
}