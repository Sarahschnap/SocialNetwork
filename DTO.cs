using System;
using SocialNetworkingPlatform;

namespace Snapchat.DTO
{
    /// <summary>
    /// Хэрэглэгч бүртгэхэд ашиглагдах өгөгдлийн дамжуулах объект.
    /// </summary>
    public record UserDTO(string name, string email, string password, byte age);

    /// <summary>
    /// Snap илгээх үед ашиглагдах DTO.
    /// </summary>
    public record SnapDTO(
        SocialNetworkingPlatform.User sender,
        SocialNetworkingPlatform.User receiver,
        string caption,
        MediaType mediaType = MediaType.Photo,
        int expiresInSeconds = 10
    );

    /// <summary>
    /// Story үүсгэхэд ашиглагдах DTO.
    /// Story нь 24 цагийн хугацаатай контент.
    /// </summary>
    public record StoryDTO(
        SocialNetworkingPlatform.User author,
        string caption,
        MediaType mediaType = MediaType.Photo
    );

    /// <summary>
    /// Chat мессеж илгээхэд ашиглагдах DTO.
    /// </summary>
    public record ChatDTO(
        SocialNetworkingPlatform.User from,
        SocialNetworkingPlatform.User to,
        string text
    );
}