using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IPostRepository
    {
        Task <ICollection<Post>> GetAllPosts();

        Task<Post> GetPostById(int PostId);
        Task<Post> CreatePost(Post ToCreate);

        Task<Post> UpDatePost(string UpdatedContent, int PostId);

        Task<Post> DeletePost(int PostId);
    }
}
