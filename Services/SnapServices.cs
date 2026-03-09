using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Snapchat.DTO;
using Snapchat.Repositories;
namespace Snapchat.Services
{
    /// <summary>
    /// Snap-тэй холбоотой бизнес логик.
    /// Repository нь зөвхөн өгөгдөл хадгалах/унших үүрэгтэй,
    /// Service нь дүрэм (view once, expire) хэрэгжүүлнэ.
    /// </summary>
    public class SnapService
    {
        private readonly ISnapRepo _repo;

        public SnapService(ISnapRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Snap илгээх.
        /// </summary>
        public Snap SendSnap(SnapDTO dto)
        {
            return _repo.CreateSnap(dto);
        }

        /// <summary>
        /// Snap үзэх үед Snapchat дүрэм: нэг удаа үзээд устгана.
        /// </summary>
        public Snap ViewSnap(Guid id)
        {
            var snap = _repo.GetSnap(id);

            // хугацаа дууссан бол шууд устгаж болно
            if (snap.IsExpired())
            {
                _repo.DeleteSnap(id);
                return snap;
            }

            // үзсэн тэмдэглэгээ
            snap.MarkViewed();

            // view once -> устгана
            _repo.DeleteSnap(id);

            return snap;
        }

        /// <summary>
        /// Inbox: хугацаа дууссан Snap-уудыг автоматаар шүүнэ.
        /// </summary>
        public List<Snap> GetInbox(SocialNetworkingPlatform.User receiver)
        {
            return _repo.GetInbox(receiver).Where(s => !s.IsExpired()).ToList();
        }

        public bool RemoveSnap(Guid id) => _repo.DeleteSnap(id);
    }
}