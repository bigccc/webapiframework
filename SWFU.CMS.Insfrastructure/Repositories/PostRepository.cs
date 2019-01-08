using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SWFU.CMS.Core.Entities;
using SWFU.CMS.Core.interfaces;
using SWFU.CMS.Insfrastructure.Database;

namespace SWFU.CMS.Insfrastructure.Repositories
{
    public class PostRepository:IPostRepository
    {
        private readonly MyContext _myContext;

        public PostRepository(MyContext myContext )
        {
            _myContext = myContext;
        }


        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _myContext.Posts.ToListAsync();

        }

        public void AddPost(Post post)
        {
            _myContext.Posts.Add(post);
        }
    }
}