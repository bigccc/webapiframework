using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SWFU.CMS.Core.Entities;

namespace SWFU.CMS.Core.interfaces
{
    
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        void AddPost(Post post);
    }
}