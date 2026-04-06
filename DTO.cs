using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkingPlatform.DTO;

public record StoryDTO(User author, string content);

public record ReelDTO(User author, string content);

public record UserDTO(string name, string email, string password);