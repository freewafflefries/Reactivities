using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,
            UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any() && !context.Activities.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName = "Wayne", UserName="wayne", Email="wayne@letterkenny.com"},
                    new AppUser{DisplayName = "McMurray", UserName="mcmurray", Email="mcmurray@pieceofshit.com"},
                    new AppUser{DisplayName = "Stuart", UserName="stuart", Email="stuart@gaesex.com"},
                    new AppUser{DisplayName = "Bonnie McMurray",  UserName="bonnie.mcmurray", Email="bonnie.mcmurray@yew.com"},
                    new AppUser{DisplayName = "Coach",  UserName="coach", Email="coach@FuckingEmbarrassing.com"},
                    new AppUser{DisplayName = "Reilly & Jonesy",  UserName="reillyandjonesy", Email="reilly.jonesy@ferda.com"},
                    new AppUser{DisplayName = "Bartz",  UserName="barts", Email="YouLittleBitch@LetterkennyIrish.com"},
                    new AppUser{DisplayName = "Yorkie",  UserName="yorkie", Email="Yorkie@LetterkennyIrish.com"},
                    new AppUser{DisplayName = "Shultzy",  UserName="shultzy", Email="Pussy@LetterkennyIrish.com"},
                    new AppUser{DisplayName = "Fisky",  UserName="fisky", Email="Fisky@LetterkennyIrish.com"},
                    new AppUser{DisplayName = "Boomtown",  UserName="boomtown", Email="ImAGoodMan@ILoveMyWife.com"},
                    new AppUser{DisplayName = "Shoresy",  UserName="shoresy", Email="GiveYourBallsATug@ReillyAndJonesysMums.com"}
                    

                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "5Point15incheS");
                }

                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Chorin'",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 2 months ago",
                        Category = "chorin",
                        City = "Letterkenny",
                        Venue = "Produce Stand",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[0],
                                IsHost = true
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Hockey Game",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Activity 1 month ago",
                        Category = "sports",
                        City = "Letterkenny",
                        Venue = "Rink",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[4],
                                IsHost = true
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[5],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[6],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[7],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[8],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[9],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[10],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[11],
                                IsHost = false
                            }

                        }
                    },
                    new Activity
                    {
                        Title = "Shred the Red",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Activity 1 month in future",
                        Category = "food",
                        City = "Big City",
                        Venue = "Hockey Rink",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[5],
                                IsHost = true
                            }
                            
                        }
                    },
                    new Activity
                    {
                        Title = "Fuss at the Ag Hall",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Activity 2 months in future",
                        Category = "culture",
                        City = "Letterkenny",
                        Venue = "Ag Hall",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[1],
                                IsHost = true
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[0],
                                IsHost = false
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Day Beers Day",
                        Date = DateTime.Now.AddMonths(3),
                        Description = "Activity 3 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[3],
                                IsHost = true                            
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[0],
                                IsHost = false                            
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[1],
                                IsHost = true                            
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[2],
                                IsHost = false                            
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[4],
                                IsHost = true
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[5],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[6],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[7],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[8],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[9],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[10],
                                IsHost = false
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[11],
                                IsHost = false
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 4",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "Activity 4 months in future",
                        Category = "culture",
                        City = "London",
                        Venue = "British Museum",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[1],
                                IsHost = true                            
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 5",
                        Date = DateTime.Now.AddMonths(5),
                        Description = "Activity 5 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Punch and Judy",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[0],
                                IsHost = true                            
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[1],
                                IsHost = false                            
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 6",
                        Date = DateTime.Now.AddMonths(6),
                        Description = "Activity 6 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "O2 Arena",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[2],
                                IsHost = true                            
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[1],
                                IsHost = false                            
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 7",
                        Date = DateTime.Now.AddMonths(7),
                        Description = "Activity 7 months in future",
                        Category = "travel",
                        City = "Berlin",
                        Venue = "All",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[0],
                                IsHost = true                            
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[2],
                                IsHost = false                            
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Future Activity 8",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Activity 8 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[2],
                                IsHost = true                            
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[1],
                                IsHost = false                            
                            },
                        }
                    }
                };

                await context.Activities.AddRangeAsync(activities);
                await context.SaveChangesAsync();
            }
        }
    }
}
