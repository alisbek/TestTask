using Microsoft.AspNetCore.Mvc;

namespace PostEngine.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService ?? throw new ArgumentNullException(nameof(postService));
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetUserPosts(int userId, int maxCount = 10)
    {
        var userPosts = _postService.GetLatestUserPosts(userId, maxCount);
        return Ok(userPosts);
    }

    [HttpGet("latest")]
    public IActionResult GetLatestPosts(int maxCount = 10)
    {
        var latestPosts = _postService.GetLatestPostsFromMultipleUsers(maxCount);
        return Ok(latestPosts);
    }
}