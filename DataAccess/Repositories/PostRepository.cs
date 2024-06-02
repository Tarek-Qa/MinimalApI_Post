using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialDbContext _ctx;

        public PostRepository(SocialDbContext ctx)
        {
            _ctx = ctx;
        }
        

        public  async Task<Post> CreatePost(Post ToCreate)
        {
            ToCreate.DateCreated = DateTime.Now;
            ToCreate.LastModified = DateTime.Now;
            _ctx.Posts.Add(ToCreate);
            await _ctx.SaveChangesAsync();
            return ToCreate;
        }

        public async Task DeletePost(int PostId)
        {
            var post = await _ctx.Posts
                .FirstOrDefaultAsync(P => P.Id == PostId);
            if (post == null) return;
            _ctx.Posts.Remove(post);
            
            await _ctx.SaveChangesAsync();
                    
        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            return await _ctx.Posts.ToListAsync();
        }

        public async Task <Post> GetPostById(int PostId)
        {
            return await _ctx.Posts.FirstOrDefaultAsync(P => P.Id == PostId);
        }

        public async Task<Post> UpdatePost(string UpdatedContent, int PostId)
        {
            var post = await _ctx.Posts.FirstOrDefaultAsync(P => P.Id == PostId);
            post.LastModified= DateTime.Now;
            post.Content = UpdatedContent;
            await _ctx.SaveChangesAsync();
            return post;
        }
    }
}
