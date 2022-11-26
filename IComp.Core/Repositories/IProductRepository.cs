using IComp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IComp.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> Filter(IQueryable<Product> query, Expression<Func<Product, bool>> exp);
        IQueryable<Product> FilterByPrice(IQueryable<Product> query, string AscOrDesc);
        IQueryable<Product> FilterByNameAsc(IQueryable<Product> query, string AscOrDesc);
        decimal FilterByPriceRange(string val);

    }
}
