namespace PostEngine.Controllers;

public interface IPostService
{
    IEnumerable<Post> GetLatestUserPosts(int userId, int maxCount);
    IEnumerable<Post> GetLatestPostsFromMultipleUsers(int maxCount);
}