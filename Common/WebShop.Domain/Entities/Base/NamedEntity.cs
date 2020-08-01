using System.ComponentModel.DataAnnotations;
using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Entities.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}