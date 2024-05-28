using FA.JustBlock.Core.Models;

namespace FA.JustBlock.Core.Repositories
{
    public interface IPostRepository
    {
        Post FindPost(int year, int month, string urlSlug);
        Post FindPost(int postId);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
        void DeletePost(int postId);
        IList<Post> GetAllPosts();
        IList<Post> GetPublisedPosts();
        IList<Post> GetUnpublisedPosts();
        IList<Post> GetLatestPost(int size);
        IList<Post> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(int categoryId);
        IList<Post> GetPostsByCategory(string category);
        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetHighestPosts(int size);
        
    }
}
