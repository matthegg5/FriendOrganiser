using AutoMapper;
using FriendOrganiser.Application.Contracts.Persistence;
using FriendOrganiser.Application.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FriendOrganiser.Application.Features.Friend
{
    public class GetFriendLookup : IRequest<IList<LookupItemViewModel>>
    {
        
    }

    public class GetFriendLookupQueryHandler : IRequestHandler<GetFriendLookup, IList<LookupItemViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Friend> _friendRepository;
        private readonly ILogger<GetFriendLookupQueryHandler> _logger;

        public GetFriendLookupQueryHandler(IMapper mapper, IAsyncRepository<FriendOrganiser.Domain.Entities.Friend> friendRepository, ILogger<GetFriendLookupQueryHandler> logger)
        {
            _mapper = mapper;
            _friendRepository = friendRepository;
            _logger = logger;
        }

        public async Task<IList<LookupItemViewModel>> Handle(GetFriendLookup query, CancellationToken cancellationToken)
        {
            var friendlookup = (await _friendRepository
                .ListAllAsync())
                .Select(x => new LookupItemViewModel
                {
                    Id = x.Id,
                    DisplayMember = x.FirstName + " " + x.LastName
                }).OrderBy(x => x.Id);

            return _mapper.Map<IList<LookupItemViewModel>>(friendlookup);
        }
    }
}
