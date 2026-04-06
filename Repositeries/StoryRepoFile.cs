using System;
using System.Collections.Generic;
using System.Text;
using SocialNetworkingPlatform.DTO;

namespace SocialNetworkingPlatform.Repositeries
{
    internal class StoryRepoFile : IStoryRepo
    {
        public Story CreateStory(StoryDTO story)
        {
            var newstory = new Story()
            {
                Author = story.author,
                Content = story.content
            };
            File.AppendAllText("stories.txt", $"{newstory.Author}:{newstory.Content}\n");
            return newstory;
        }

        public List<Story> GetAllStories()
        {
            throw new NotImplementedException();
        }

        public Story GetStoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStory(StoryDTO story)
        {
            throw new NotImplementedException();
        }

        public Story UpdateStory(StoryDTO story)
        {
            throw new NotImplementedException();
        }
    }
}
