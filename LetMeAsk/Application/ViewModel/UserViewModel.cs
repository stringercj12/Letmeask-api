
using Letmeask.Entities;

namespace Letmeask.ViewModel;

public class UserViewModel
{
    public Guid userId { get; set; }
    public string name { get; set; }
    public string photo { get; set; }
    public string email { get; set; }
    public string socialId { get; set; }




    public static UserViewModel Mapear(User user)
    {
        return new UserViewModel()
        {
            userId = user.Id,
            name = user.Email,
            photo = user.Photo,
            email = user.Email,
            socialId = user.SocialId
        };
    }
}