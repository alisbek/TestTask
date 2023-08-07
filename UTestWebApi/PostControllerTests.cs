
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controllers;
using WebApplication2.Model;
using WebApplication2.Services;

namespace PostEngine.Tests
{
    [TestFixture]
    public class PostControllerTests
    {
        private IPostService _postService;
        private PostController _controller;

        [SetUp]
        public void SetUp()
        {
            _postService = new PostService(new List<Post>
            {
                new Post { Id = 1, UserId = 1, PublishDate = DateTime.Now, Message = "Message 1" },
                new Post { Id = 2, UserId = 2, PublishDate = DateTime.Now, Message = "Message 2" },
                new Post { Id = 3, UserId = 1, PublishDate = DateTime.Now, Message = "Message 3" },
            });

            _controller = new PostController(_postService);
        }

        [Test]
        public void GetUserPosts_ReturnsUserPosts()
        {
            var result = _controller.GetUserPosts(1) as OkObjectResult;
            var userPosts = result.Value as IEnumerable<Post>;

            Assert.IsNotNull(result);
            Assert.AreEqual(2, userPosts.Count());
        }

        [Test]
        public void GetLatestPosts_ReturnsLatestPostsFromMultipleUsers()
        {
            var result = _controller.GetLatestPosts() as OkObjectResult;
            var latestPosts = result.Value as IEnumerable<Post>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, latestPosts.Count());
        }
    }
}
