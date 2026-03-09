// ISnapRepo.cs - Interface
using System;
using System.Collections.Generic;
using Snapchat.DTO;

namespace Snapchat.Repositories
{
    public interface ISnapRepo
    {
        Snap CreateSnap(SnapDTO dto);
        Snap GetSnap(Guid id);
        public List<Snap> GetInbox(SocialNetworkingPlatform.User receiver);
        bool DeleteSnap(Guid id);
    }
}