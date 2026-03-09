using System;
using System.Collections.Generic;
using System.Text;

namespace Snapchat.Repositories
{
    /// <summary>
    /// Хугацаа дуусах боломжтой контент (Snap, Story).
    /// </summary>
    public interface IExpirable
    {
        bool IsExpired();
    }
}
