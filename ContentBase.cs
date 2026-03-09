using System;
using System.Collections.Generic;
using System.Text;

namespace Snapchat
{
    public abstract class ContentBase
    {
        /// <summary>Контентийн unique ID</summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>Контент үүссэн цаг</summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>Контентийн тайлбар текст (caption)</summary>
        public string Caption { get; set; } = string.Empty;
    }


}
