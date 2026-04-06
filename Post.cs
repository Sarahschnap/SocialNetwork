using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkingPlatform
{
    public abstract class Post
    {
        List<Guid> postlikes = new List<Guid>();
        public required string Content { get; set; }
        public required User Author { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public void Like(User user)
        {
            postlikes.Add(user.Id);
        }

        public void Comment(User user, string comment)
        {
        }
    }
}
