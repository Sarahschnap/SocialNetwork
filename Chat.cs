using System;
using System.Collections.Generic;
using System.Text;

namespace Snapchat;

public class ChatMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required User From { get; set; }
    public required User To { get; set; }

    public required string Text { get; set; }
    public DateTime SentAt { get; set; } = DateTime.UtcNow;

}