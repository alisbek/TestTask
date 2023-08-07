namespace PostEngine.Controllers;

public class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime PublishDate { get; set; }
    public string Message { get; set; }
}