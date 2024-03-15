namespace Letmeask.Model
{
    public class Poll
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public string Status { get; set; }
        public DateTime DateCreate { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
