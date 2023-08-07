namespace PostEngine.Controllers;

public class PostService : IPostService
{
    private readonly List<Post> _posts;

    public PostService(List<Post> posts)
    {
        _posts = posts;
    }

    public IEnumerable<Post> GetLatestUserPosts(int userId, int maxCount)
    {
        return _posts
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.PublishDate)
            .Take(maxCount);
    }

    public IEnumerable<Post> GetLatestPostsFromMultipleUsers(int maxCount)
    {
        var distinctUserIds = _posts.Select(p => p.UserId).Distinct();
        var latestPosts = new List<Post>();

        foreach (var userId in distinctUserIds)
        {
            latestPosts.AddRange(GetLatestUserPosts(userId, maxCount));
        }

        return latestPosts.OrderByDescending(p => p.PublishDate).Take(maxCount);
    }
}