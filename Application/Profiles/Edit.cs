using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string DisplayName { get; set; }
            public string Bio {get; set; }
        }

        
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DisplayName).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                //Get the user record from DB for our current user, by looking up by UserName
                var user = await _context.Users.FirstOrDefaultAsync(
                    x => x.UserName == _userAccessor.GetUserName()
                );

                //If the query returns NULL, return a Failure Result
                if (user == null) return Result<Unit>.Failure("User could not be found.");

                //Now we update the User Model with the values sent in the request 
                //(and if the request doen't have anything, set it to itself (ie, no change))
                user.Bio = request.Bio ?? user.Bio;
                user.DisplayName = request.DisplayName ?? user.DisplayName;

                var result = await _context.SaveChangesAsync() > 0;

                if(!result) return Result<Unit>.Failure("Error when saving changes");

                return Result<Unit>.Success(Unit.Value);



                
            }
        }

    }
}