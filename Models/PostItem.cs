using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChitChat.Models
{
    public class PostItem
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public string Title { get; set; }
        public string Msg { get; set; }
        public string Time { get; set; }
    }
}
