using Application.Features.SocialMediaAccounts.Commands.Create;
using Application.Features.SocialMediaAccounts.Commands.Delete;
using Application.Features.SocialMediaAccounts.Commands.Update;
using Application.Features.SocialMediaAccounts.Queries.GetById;
using Application.Features.SocialMediaAccounts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SocialMediaAccounts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSocialMediaAccountCommand, SocialMediaAccount>();
        CreateMap<SocialMediaAccount, CreatedSocialMediaAccountResponse>();

        CreateMap<UpdateSocialMediaAccountCommand, SocialMediaAccount>();
        CreateMap<SocialMediaAccount, UpdatedSocialMediaAccountResponse>();

        CreateMap<DeleteSocialMediaAccountCommand, SocialMediaAccount>();
        CreateMap<SocialMediaAccount, DeletedSocialMediaAccountResponse>();

        CreateMap<SocialMediaAccount, GetByIdSocialMediaAccountResponse>();

        CreateMap<SocialMediaAccount, GetListSocialMediaAccountListItemDto>();
        CreateMap<IPaginate<SocialMediaAccount>, GetListResponse<GetListSocialMediaAccountListItemDto>>();
    }
}