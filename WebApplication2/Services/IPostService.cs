using WebApplication2.Model;

namespace WebApplication2.Services;

public interface IPostService
{
    IEnumerable<Post> GetLatestUserPosts(int userId, int maxCount);
    IEnumerable<Post> GetLatestPostsFromMultipleUsers(int maxCount);
}