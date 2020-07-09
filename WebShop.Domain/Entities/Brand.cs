using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Domain.Entities.Base;
using WebShop.Domain.Entities.Base.Interfaces;

namespace WebShop.Domain.Entities
{
    class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }

    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public int? ParentId { get; set; }
    }
}
