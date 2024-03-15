namespace Letmeask.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string  Name { get; set; }
        public string  Photo { get; set; }
        public string Email { get; set; }
        public string SocialId { get; set; }

        public Room Rooms { get; set; }
        
    }
}
