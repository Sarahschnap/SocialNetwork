using System;
using System.Collections.Generic;
using SocialNetworkingPlatform;

namespace Snapchat
{
    /// <summary>
    /// Snapchat-ийн User class.
    /// </summary>
    public class User : SocialNetworkingPlatform.User
    {
        // Snapchat-д зөвхөн байх features
        public List<Snap> Inbox { get; set; } = new List<Snap>();
        public List<Story> Stories { get; set; } = new List<Story>();
        public int SnapStreak { get; set; } = 0;

    }
}