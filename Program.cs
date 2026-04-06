using SocialNetworkingPlatform;
using System.Linq;
using System;
using SocialNetworkingPlatform.DTO;
namespace SocialNetworkingPlatform
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var platform = new Platform()
            {
                Name = "MySocialApp",
                Version = "1.0"
            };

            var newUser1 = platform.SignUp("Alice", "alice@gmail.com", "pass123");
            var user = new User()
            {
                Name = "Bob",
                Email = "bob@gmail.com",
                Password = "pass456"
            };
            var newUser2 =  platform.SignUp(user);

            var post1 = platform.createPost(newUser1!, "Hello, this is my first post!", PostType.Reel);
            var post2 = platform.createPost(newUser2!, "Hi everyone, excited to join!", PostType.Story);
            var post3 = platform.createStory(newUser1!, "Enjoying the platform so far!");


            var newStory = platform.StoryService.CreateStory(new StoryDTO(newUser2!, "New Story"));
            var newStoryByOperator = platform + new StoryDTO(newUser1!, "Another Story");
            var isSucceed = platform - new StoryDTO(newUser1!, "Another Story");
            var newUserByOperator = platform + new UserDTO ("Charlie","Hello@gmail.com","pass789");


            post1.Like(newUser2!);
            post2.Like(newUser1!);
            post3.Comment(newUser2!, "Glad to hear that!");

            Console.Write($"{platform.Name} {platform.Version}");

            Console.WriteLine($"\nNew user {newUser1}");
            Console.WriteLine($"\nNew user {newUser2}");

            Console.WriteLine($"\nPost by {post1.Author.Name}: {post1.Content}");
            Console.WriteLine($"\nPost by {post2.Author.Name}: {post2.Content}");
        }
    }
}
