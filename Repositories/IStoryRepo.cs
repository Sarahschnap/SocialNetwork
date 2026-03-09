using System;
using System.Collections.Generic;
using System.Text;
using Snapchat.DTO;
namespace Snapchat.Repositories;

public interface IStoryRepo
{
    Story CreateStory(StoryDTO dto);
    Story GetStoryById(Guid id);
    List<Story> GetActiveStories(User author);
    bool RemoveStory(Guid id);
}
