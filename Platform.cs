using System;
using System.Collections.Generic;
using System.Text;
using SocialNetworkingPlatform.Repositeries;
using SocialNetworkingPlatform.service;
using SocialNetworkingPlatform.DTO;
namespace SocialNetworkingPlatform;

public class Platform
{
    required public string Name { get; set; }
    public string Version { get; set; }
    const int maxUsers = 10;
    public User[] users = new User[maxUsers];
    private int userCount = 0;
    private List<Post> _posts = new List<Post>(maxUsers * 10);
    public StoryService StoryService { get; set; } = new StoryService(new StoryRepoFile());
    public StoryService StoryServiceWeb { get; set; } = new StoryService(new StoryRepoWeb());
    public List<Post> posts
    {
        get { return _posts.ToList(); }
    }


    public User? SignUp(string name, string email, string password)
    {
        var user = new User()
        {
            Name = name,
            Email = email,
            Password = password
        };
        users[userCount] = user;
        userCount++;
        if (userCount >= maxUsers)
        {
            return null;
        }
        return user;

    }

    public User? SignUp (User user)
    {
        users[userCount] = user;
        userCount++;
        if (userCount >= maxUsers)
        {
            return null;
        }
        return user;

    }
    public User? SignIn(string email, string password)
    {

        for (int i = 0; i < userCount; i++)
        {
            var u = users[i];
            if (u == null) continue;

            if (u.Email == email && u.Password == password)
                return u;
        }

        return null;
    }
    public Post createPost(User author, string content, PostType type)
    {
        return type == PostType.Reel ? createReel(author, content) : createStory(author, content);
    }
    public Reel createReel(User author, string content)
    {
        var reel = new Reel()
        {
            Author = author,
            Content = content
        };
        _posts.Add(reel);
        return reel;
    }
     public Story createStory(User author, string content)
    {
        var story = new Story()
        {
            Author = author,
            Content = content
        };
        _posts.Add(story);
        return story;
    }

    public static Story operator +(Platform platform, StoryDTO storyDTO)
    {
        return platform.StoryService.CreateStory(storyDTO);
    }

    public static User operator +(Platform platform, UserDTO userDTO)
    {
        return platform.SignUp(userDTO.name, userDTO.email, userDTO.password)!;
    }

    public static bool operator -(Platform platform, StoryDTO storyDTO)
    {
        return platform.StoryService.RemoveStory(storyDTO);
    }
}