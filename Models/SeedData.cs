using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChitChat.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ChitChatContext(
                serviceProvider.GetRequiredService<DbContextOptions<ChitChatContext>>()))
            {
                // Look for any movies.
                if (context.PostItem.Count() > 0)
                {
                    return;   // DB has been seeded
                }

                context.PostItem.AddRange(
                    new PostItem
                    {
                        UserID = "1",
                        Upvotes = 5,
                        Downvotes = 1,
                        Title = "Lorem Ipsum",
                        Msg = "This is the users message, Lorem ipsum dolor sit amet consectetur adipisicing elit",
                        Time = "07-10-18 4:20T18:25:43.511Z"
                    }


                );
                context.SaveChanges();
            }
        }
    }
}