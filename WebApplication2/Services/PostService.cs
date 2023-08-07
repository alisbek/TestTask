using WebApplication2.Model;

namespace WebApplication2.Services;

public class PostService : IPostService
{
    private readonly List<Post> _posts;

    public PostService(List<Post> posts)
    {
        _posts = posts;
    }

    public IEnumerable<Post> GetLatestUserPosts(int userId, int maxCount)
    {
        return _posts.Where(p => p.UserId == userId)
            .OrderByDescending(p => p.PublishDate)
            .Take(maxCount);
    }

    public IEnumerable<Post> GetLatestPostsFromMultipleUsers(int maxCount)
    {
        var users = _posts.Select(p => p.UserId).Distinct();
        var latestPost = new List<Post>();
        foreach (var user in users)
        {
            latestPost.AddRange(GetLatestUserPosts(user, maxCount));
        }
        return latestPost.OrderByDescending(p => p.PublishDate).Take(maxCount);
    }
}