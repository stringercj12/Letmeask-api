using System.Collections.Generic;

namespace Letmeask.Models;


public class UserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public string Email { get; set; }
    public string SocialId { get; set; }

}