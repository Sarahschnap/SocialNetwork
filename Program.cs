using System;
using Snapchat;
using Snapchat.DTO;
using Snapchat.Services;
using Snapchat.Repositories;
namespace SnapChatCloneApp
{
    public class Program
    {
        static void Main(string[] args)
        {
          
            var app = new SnapchatPlatform
            {
                Name = "MySnapchatClone",
                Version = "1.0"
            };

            // User бүртгэх
            var sara = app.SignUp("Sara", "sara@gmail.com", "pass123");
            var od = app.SignUp("Od", "od@gmail.com", "pass456");

            if (sara == null || od == null)
            {
                Console.WriteLine("SignUp failed");
                return;
            }

            // Snap илгээх
            var snap1 = app.SnapService.SendSnap(new SnapDTO(
                sender: sara,
                receiver: od,
                caption: "Sainuu od!",
                mediaType: MediaType.Photo,
                expiresInSeconds: 10
            ));

            // 4Inbox харуулах
            var inbox = app.SnapService.GetInbox(od);
            Console.WriteLine($"Od's inbox: {inbox?.Count ?? 0} unviewed snaps");

            // Snap view хийх (view-once)
            if (snap1 != null)
            {
                var viewed = app.SnapService.ViewSnap(snap1.Id);
                Console.WriteLine($"Snap viewed: {viewed?.Caption}");
            }

            // Inbox дахиад шалгахад хоосон болно
            var inboxAfter = app.SnapService.GetInbox(od);
            Console.WriteLine($" Od's inbox after view: {inboxAfter?.Count ?? 0} snaps");

            // 7️⃣ Story үүсгэх
            var story = new StoryDTO(sara, "My day", MediaType.Photo);
            Console.WriteLine($"📖 Story created: {story.caption}");

            // 8️⃣ Chat
            var chat = new ChatDTO(sara, od, "Did you see my snap?");
            Console.WriteLine($"{chat.from.Name} → {chat.to.Name}: {chat.text}");

            Console.WriteLine("\n Done!");
        }
    }
}