using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
