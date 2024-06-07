using Application.Features.Ads.Commands.Create;
using Application.Features.Ads.Commands.Delete;
using Application.Features.Ads.Commands.Update;
using Application.Features.Ads.Queries.GetById;
using Application.Features.Ads.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Ads.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAdCommand, Ad>();
        CreateMap<Ad, CreatedAdResponse>();

        CreateMap<UpdateAdCommand, Ad>();
        CreateMap<Ad, UpdatedAdResponse>();

        CreateMap<DeleteAdCommand, Ad>();
        CreateMap<Ad, DeletedAdResponse>();

        CreateMap<Ad, GetByIdAdResponse>();

        CreateMap<Ad, GetListAdListItemDto>();
        CreateMap<IPaginate<Ad>, GetListResponse<GetListAdListItemDto>>();
    }
}