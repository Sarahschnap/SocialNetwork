using System;
using Snapchat.Repositories;
using SocialNetworkingPlatform;
namespace Snapchat
{
    /// <summary>
    /// Snap: илгээгчээс хүлээн авагч руу илгээгддэг, view-once ба хугацаатай контент.
    /// </summary>
    public class Snap : ContentBase, IExpirable, IViewOnce
    {
        // Snap-ийн үндсэн property-үүд
        public required SocialNetworkingPlatform.User Sender { get; set; }
        public required SocialNetworkingPlatform.User Receiver { get; set; }

        /// <summary>
        /// Зураг/Видео гэх мэт төрөл.
        /// Жишээ: "Photo", "Video"
        /// </summary>
        public string MediaType { get; set; } = "Photo";

        /// <summary>
        /// Snap хэдэн секундийн дараа хугацаа дуусах вэ (Snapchat style).
        /// Default: 10 секунд
        /// </summary>
        public int ExpiresInSeconds { get; set; } = 10;

        /// <summary>
        /// Нэг удаа үзсэн эсэх (view-once feature).
        /// </summary>
        public bool IsViewed { get; private set; } = false;

        /// <summary>
        /// IExpirable interface - хугацаа дууссан эсэх.
        /// </summary>
        public bool IsExpired()
        {
            return DateTime.UtcNow > CreatedAt.AddSeconds(ExpiresInSeconds);
        }

        /// <summary>
        /// IViewOnce interface - snap-г үзсэн гэж тэмдэглэх.
        /// Үзсэний дараа auto-delete болно.
        /// </summary>
        public void MarkViewed()
        {
            IsViewed = true;
        }

        public override string ToString()
        {
            var status = IsViewed ? "✓ viewed" : "○ unviewed";
            var expired = IsExpired() ? " expired" : " active";
            return $" Snap[{Id}] from {Sender?.Name} to {Receiver?.Name}: '{Caption}' ({status}, {expired})";
        }
    }
}