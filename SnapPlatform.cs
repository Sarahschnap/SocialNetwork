using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Snapchat.DTO;
using Snapchat.Repositories;
using Snapchat.Services;
using SocialNetworkingPlatform;
using SocialNetworkingPlatform.service;
using SocialNetworkingPlatform.Repositeries;
namespace Snapchat
{
    /// <summary>
    /// 
    /// Үүрэг:
    /// - Хэрэглэгч удирдах (SignUp, SignIn)
    /// - Service-үүдийг нэгтгэж өгөх
    /// </summary>
    public partial class SnapchatPlatform : Platform
    {

        /// <summary>
        /// Snap үйлдлүүдийн service.
        /// </summary>
        public SnapService SnapService { get; set; } =
            new SnapService(new SnapRepoMemory());

        /// <summary>
        /// Story үйлдлүүдийн service.
        /// </summary>
        public StoryService SnapStoryService { get; set; } =
            new StoryService(new StoryRepoMemory());

        /// <summary>
        /// Chat үйлдлүүдийн service.
        /// </summary>
        public ChatService ChatService { get; set; } =
            new ChatService(new ChatRepoMemory());
        public static SocialNetworkingPlatform.User operator +(SnapchatPlatform platform, UserDTO dto)
        {
            // Base Platform.SignUp ашиглана
            return platform.SignUp(dto.name, dto.email, dto.password)!;
        }
    }

}
