using SocialNetworkingPlatform.DTO;

namespace SocialNetworkingPlatform.Repositeries
{
    public class StoryRepoMemory : IStoryRepo
    {
        private readonly List<Story> _stories = new();

        public Story CreateStory(StoryDTO dto)
        {
            var story = new Story
            {
                Author = dto.author,
                Content = dto.content,  
            };

            _stories.Add(story);
            return story;
        }

        public List<Story> GetAllStories() => _stories.ToList();

        public Story GetStoryById(Guid id)
        {
            var story = _stories.Find(s => s.Id == id);
            if (story == null)
                throw new KeyNotFoundException($"Story with id {id} not found.");
            return story;
        }

        public bool RemoveStory(StoryDTO dto)
        {
            int removed = _stories.RemoveAll(s =>
                s.Author == dto.author &&
                s.Content == dto.content);

            return removed > 0;
        }

        public bool RemoveStory(Guid id)
        {
            var story = _stories.Find(s => s.Id == id);
            if (story == null) return false;
            _stories.Remove(story);
            return true;
        }

        public Story UpdateStory(StoryDTO dto)
        {
            var story = _stories.Find(s => s.Author == dto.author && s.Content == dto.content);
            if (story == null)
                throw new KeyNotFoundException("Story not found for update.");

            story.Content = dto.content; 
            return story;
        }
    }
}