using System;
using System.Collections.Generic;
using System.Text;

namespace Snapchat.Repositories
{
    /// <summary>
    /// Нэг удаа үзээд устах төрлийн контент (Snap).
    /// </summary>
    public interface IViewOnce
    {
        bool IsViewed { get; }
        void MarkViewed();
    }
}
