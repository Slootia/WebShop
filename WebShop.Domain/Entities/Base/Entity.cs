using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
