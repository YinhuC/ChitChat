using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChitChat.Models
{
    public class ChitChatContext : DbContext
    {
        public ChitChatContext (DbContextOptions<ChitChatContext> options)
            : base(options)
        {
        }

        public DbSet<ChitChat.Models.PostItem> PostItem { get; set; }
        public object MemeItem { get; internal set; }
    }
}
