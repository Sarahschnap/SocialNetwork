using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using SocialNetworkingPlatform.DTO;

namespace SocialNetworkingPlatform.Repositeries
{
    internal class StoryRepoWeb : IStoryRepo
    {
        public Story CreateStory(StoryDTO story)
        {
            return new Story()
            { Author=new User() { Email= "fdhsajdkj@gmail.com", Name="BAt", Password="fds"}, Content="Story Content"};
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
