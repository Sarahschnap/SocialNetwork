using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Snapchat.DTO;


namespace Snapchat.Repositories;

public class ChatRepoMemory : IChatRepo
{
    private readonly List<ChatMessage> _messages = new();

    public ChatMessage Send(ChatDTO dto)
    {
        var msg = new ChatMessage
        {
            From = (User)dto.from,
            To = (User)dto.to,
            Text = dto.text
        };
        _messages.Add(msg);
        return msg;
    }

    public List<ChatMessage> GetConversation(User a, User b)
    {
        return _messages
            .Where(m =>
                ((m.From.Email == a.Email && m.To.Email == b.Email) ||
                 (m.From.Email == b.Email && m.To.Email == a.Email)))
            .OrderBy(m => m.SentAt)
            .ToList();
    }
}
