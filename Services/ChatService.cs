using System;
using System.Collections.Generic;
using System.Text;
using Snapchat.DTO;
using Snapchat.Repositories;

namespace Snapchat.Services;


public class ChatService
{
    private readonly IChatRepo _repo;
    public ChatService(IChatRepo repo) => _repo = repo;

    public ChatMessage Send(ChatDTO dto) => _repo.Send(dto);

    public List<ChatMessage> GetConversation(User a, User b) => _repo.GetConversation(a, b);
}