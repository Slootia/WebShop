using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Entities.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        public string Name { get; set; }
    }
}