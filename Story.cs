using System;
using System.Collections.Generic;
using System.Text;
using Snapchat.Repositories;

namespace Snapchat
{
    /// <summary>
    /// Story: 24 цагийн хугацаатай нийтлэл.
    /// </summary>
    public class Story : ContentBase, IExpirable
    {
        public required User Author { get; set; }

        public string MediaType { get; set; } = "Photo";

        /// <summary>Story хэдэн цагийн дараа дуусах вэ (default: 24)</summary>
        public int ExpiresInHours { get; set; } = 24;

        public bool IsExpired()
        {
            return DateTime.UtcNow > CreatedAt.AddHours(ExpiresInHours);
        }

    }
}