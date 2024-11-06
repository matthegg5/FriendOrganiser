using AutoMapper;
using FluentValidation;
using FriendOrganiser.Application.Contracts.Persistence;
using FriendOrganiser.Application.ViewModels;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganiser.Application.Features.Friend.Commands
{
    public class UpdateFriend
    {
        public class Command : IRequest<FriendViewModel>
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }

        public class Validation : AbstractValidator<UpdateFriend.Command>
        {
            public Validation()
            {
                RuleFor(properties => properties.FirstName)
                    .NotEmpty()
                    .NotNull();

                RuleFor(properties => properties.LastName)
                    .NotEmpty()
                    .NotNull();

                RuleFor(properties => properties.Email)
                    .NotEmpty()
                    .NotNull();
            }
        }
    }

    public class UpdateFriendCommandHandler : IRequestHandler<UpdateFriend.Command, FriendViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Friend> _friendRepository;
        private readonly ILogger<UpdateFriendCommandHandler> _logger;

        public UpdateFriendCommandHandler(IMapper mapper, IAsyncRepository<FriendOrganiser.Domain.Entities.Friend> friendRepository, ILogger<UpdateFriendCommandHandler> logger)
        {
            _mapper = mapper;
            _friendRepository = friendRepository;
            _logger = logger;
        }
        public async Task<FriendViewModel> Handle(UpdateFriend.Command request, CancellationToken cancellationToken)
        {
            var friend = await _friendRepository.GetByIdAsync(request.Id);

            if (friend == null) 
            { 
                throw new Exception($"Friend id {request.Id} not found!");
            }

            friend.FirstName = request.FirstName;
            friend.LastName = request.LastName;
            friend.Email = request.Email;

            await _friendRepository.UpdateAsync(friend);

            var result = _mapper.Map<FriendViewModel>(friend);

            return result;
        }
    }
}
