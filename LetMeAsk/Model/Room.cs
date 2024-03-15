namespace Letmeask.Model
{
    public class Room
    {
        public Guid Id { get; set; }
        public string  Name { get; set; }
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public bool Finished { get; set; }

        public List<Poll> Polls { get; set; }
    }
}
