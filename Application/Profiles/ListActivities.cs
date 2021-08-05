using System.Runtime.ExceptionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Applicaiton.Activities;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Profiles
{
    public class ListActivities
    {
        public class Query : IRequest<Result<List<UserActivityDto>>> 
        {
            public string Predicate {get; set;}
            public string Username {get; set;}
        }

        public class Handler : IRequestHandler<Query, Result<List<UserActivityDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            public Handler (DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            public async Task<Result<List<UserActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.ActivityAttendees
                    .Where(u => u.AppUser.UserName == request.Username)
                    .OrderBy(a => a.Activity.Date )
                    .ProjectTo<UserActivityDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                    switch(request.Predicate.ToString())
                    {
                        case "future":
                            query = query.Where(a => a.Date >= DateTime.Now);
                            break;
                        case "past":
                            query = query.Where( a => a.Date < DateTime.Now );
                            break;
                        case "hosting":
                            query = query.Where( a =>  a.HostName == request.Username);
                            break;
                        default:
                            break;
                    }

                   // query = request.Predicate switch
                   // {
                   //     "past" => query.Where( a => a.Date < DateTime.Now ),
                  //      "hosting" => query.Where( a =>  a.HostName == request.Username),
                   //     "future" => query.Where(a => a.Date >= DateTime.Now),
                    //    _ => query.Where(a => a.Date >= DateTime.Now)
                  //  };

                    var activities = await query.ToListAsync();

                    return Result<List<UserActivityDto>>.Success(activities);

                

            }
        }
    }
}