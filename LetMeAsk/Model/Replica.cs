namespace Letmeask.Model
{
    public class Replica
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public string Status { get; set; }
        public Guid PollId { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
