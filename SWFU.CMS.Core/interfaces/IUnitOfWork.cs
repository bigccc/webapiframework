using System.Threading.Tasks;

namespace SWFU.CMS.Core.interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();  
    }
}