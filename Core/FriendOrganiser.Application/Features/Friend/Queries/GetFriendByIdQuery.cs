using AutoMapper;
using FriendOrganiser.Application.Contracts.Persistence;
using FriendOrganiser.Application.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FriendOrganiser.Application.Features.Friend
{
    public class GetFriendById : IRequest<FriendViewModel>
    {
        public int FriendId { get; set; }
        public GetFriendById(int friendId)
        {
            FriendId = friendId;
        }
    }

    public class GetFriendByIdQueryHandler : IRequestHandler<GetFriendById, FriendViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Friend> _friendRepository;
        private readonly ILogger<GetFriendByIdQueryHandler> _logger;

        public GetFriendByIdQueryHandler(IMapper mapper, IAsyncRepository<FriendOrganiser.Domain.Entities.Friend> friendRepository, ILogger<GetFriendByIdQueryHandler> logger)
        {
            _mapper = mapper;
            _friendRepository = friendRepository;
            _logger = logger;
        }

        public async Task<FriendViewModel> Handle(GetFriendById query, CancellationToken cancellationToken)
        {
            var friend = await _friendRepository.GetByIdAsync(query.FriendId);
            return _mapper.Map<FriendViewModel>(friend);
        }
    }
}
