using SWFU.CMS.Core.interfaces;

namespace SWFU.CMS.Core.Entities
{
    public abstract class Entity :IEntity
    {
        public int Id { get; set; }
    }
}