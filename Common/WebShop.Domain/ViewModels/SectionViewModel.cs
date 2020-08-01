using System.Collections.Generic;
using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.ViewModels
{
    public class SectionViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public List<SectionViewModel> ChildSections { get; set; } = new List<SectionViewModel>();

        public SectionViewModel ParentSection { get; set; }
    }
}
