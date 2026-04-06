using System;
using System.Collections.Generic;
using System.Text;
namespace SocialNetworkingPlatform.service;
using SocialNetworkingPlatform.DTO;
using SocialNetworkingPlatform.Repositeries;


public class StoryService
{
    List<Story> stories = new List<Story>();
    IStoryRepo _repo;
    public StoryService(IStoryRepo repo)
    {
        _repo = repo;
    }
    public Story CreateStory(StoryDTO story)
    {
        return _repo.CreateStory(story);
    }
    
    public Story UpdateStory(StoryDTO story) => _repo.UpdateStory(story);

    public Story GetStoryById(Guid id) => _repo.GetStoryById(id);

    public bool RemoveStory(StoryDTO story)
    {
        stories.RemoveAll(s => s.Author == story.author && s.Content == story.content);
        return true;
    }


    //public bool RemoveStory(StoryDTO story)
    //{
    //    var storyToRemove = stories.FirstOrDefault(s => s.Author == story.author && s.Content == story.content);
    //    if (storyToRemove != null)
    //    {
    //        stories.Remove(storyToRemove);
    //        return true;
    //    }
    //    return false;
}
