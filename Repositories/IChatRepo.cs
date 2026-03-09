using System;
using System.Collections.Generic;
using System.Text;
using Snapchat.DTO;
namespace Snapchat.Repositories;

public interface IChatRepo
{
    ChatMessage Send(ChatDTO dto);
    List<ChatMessage> GetConversation(User a, User b);
}
