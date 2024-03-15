namespace Letmeask.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public Guid PollId { get; set; }
        public DateTime DateCreate { get; set; }
        public List<Replica> Replicas { get; set; }
    }
}
