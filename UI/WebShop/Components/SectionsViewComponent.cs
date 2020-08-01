using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebShop.Domain.ViewModels;
using WebShop.Interfaces;

namespace WebShop.Components
{
    public class SectionsViewComponent : ViewComponent
    {
        private readonly IProductData _productData;

        public SectionsViewComponent(IProductData productData)
            => _productData = productData;

        public IViewComponentResult Invoke()
            => View(GetSections());

        private IEnumerable<SectionViewModel> GetSections()
        {
            var sections = _productData.GetSections().ToArray();

            var parent_sections = sections.Where(s => s.ParentId is null);

            var parent_sections_views = parent_sections.Select(s => new SectionViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Order = s.Order
            }).ToList();

            foreach (var parentSection in parent_sections_views)
            {
                var childs = sections.Where(s => s.ParentId == parentSection.Id);

                foreach (var child_section in childs)
                {
                    parentSection.ChildSections.Add(new SectionViewModel
                    {
                        Id = child_section.Id,
                        Name = child_section.Name,
                        Order = child_section.Order,
                        ParentSection = parentSection
                    });
                }

                parentSection.ChildSections.Sort((a,b) => Comparer<double>.Default.Compare(a.Order, b.Order));
            }

            parent_sections_views.Sort((a, b) => Comparer<double>.Default.Compare(a.Order, b.Order));
            return parent_sections_views;
        }
    }
}
