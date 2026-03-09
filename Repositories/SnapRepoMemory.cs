using System;
using System.Collections.Generic;
using System.Linq;
using Snapchat.DTO;

namespace Snapchat.Repositories
{
    /// <summary>
    /// Snap-ийн өгөгдлийг memory-д хадгална.
    /// Interface ISnapRepo-г implement хийнэ.
    /// </summary>
    public class SnapRepoMemory : ISnapRepo
    {
        private readonly List<Snap> _snaps = new List<Snap>();

        public Snap CreateSnap(SnapDTO dto)
        {
            var snap = new Snap
            {
                Id = Guid.NewGuid(),
                Sender = dto.sender,
                Receiver = dto.receiver,
                Caption = dto.caption,                  
                MediaType = dto.mediaType.ToString(),
                ExpiresInSeconds = dto.expiresInSeconds,
                CreatedAt = DateTime.UtcNow
            };
            _snaps.Add(snap);
            return snap;
        }

        /// <summary>
        /// Snap-г ID-р авах.
        /// </summary>
        public Snap GetSnap(Guid id)
        {
            return _snaps.FirstOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Хэрэглэгчийн inbox (авсан snap-ууд).
        /// </summary>
        public List<Snap> GetInbox(SocialNetworkingPlatform.User receiver)
        {
            return _snaps
                .Where(s => s.Receiver.Id == receiver.Id && !s.IsViewed)
                .ToList();
        }

        /// <summary>
        /// Snap-г ID-р устгах.
        /// </summary>
        public bool DeleteSnap(Guid id)
        {
            var snap = _snaps.FirstOrDefault(s => s.Id == id);
            if (snap == null) return false;

            _snaps.Remove(snap);
            return true;
        }
    }
}