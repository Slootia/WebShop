using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.ViewModels
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}