using Application.Features.AdPerformances.Commands.Create;
using Application.Features.AdPerformances.Commands.Delete;
using Application.Features.AdPerformances.Commands.Update;
using Application.Features.AdPerformances.Queries.GetById;
using Application.Features.AdPerformances.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AdPerformances.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAdPerformanceCommand, AdPerformance>();
        CreateMap<AdPerformance, CreatedAdPerformanceResponse>();

        CreateMap<UpdateAdPerformanceCommand, AdPerformance>();
        CreateMap<AdPerformance, UpdatedAdPerformanceResponse>();

        CreateMap<DeleteAdPerformanceCommand, AdPerformance>();
        CreateMap<AdPerformance, DeletedAdPerformanceResponse>();

        CreateMap<AdPerformance, GetByIdAdPerformanceResponse>();

        CreateMap<AdPerformance, GetListAdPerformanceListItemDto>();
        CreateMap<IPaginate<AdPerformance>, GetListResponse<GetListAdPerformanceListItemDto>>();
    }
}