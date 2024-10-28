using AutoMapper;
using FriendOrganiser.Application.Contracts.Persistence;
using FriendOrganiser.Application.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FriendOrganiser.Application.Features.Friend
{
    public class GetAllFriendsQuery : IRequest<IList<FriendViewModel>>
    {
        
    }

    public class GetAllFriendsQueryHandler : IRequestHandler<GetAllFriendsQuery, IList<FriendViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Friend> _friendRepository;
        private readonly ILogger<GetAllFriendsQueryHandler> _logger;

        public GetAllFriendsQueryHandler(IMapper mapper, IAsyncRepository<FriendOrganiser.Domain.Entities.Friend> friendRepository, ILogger<GetAllFriendsQueryHandler> logger)
        {
            _mapper = mapper;
            _friendRepository = friendRepository;
            _logger = logger;
        }

        public async Task<IList<FriendViewModel>> Handle(GetAllFriendsQuery query, CancellationToken cancellationToken)
        {
            var allFriends = (await _friendRepository.ListAllAsync()).OrderBy(x => x.Id);
            return _mapper.Map<IList<FriendViewModel>>(allFriends);
        }
    }
}
